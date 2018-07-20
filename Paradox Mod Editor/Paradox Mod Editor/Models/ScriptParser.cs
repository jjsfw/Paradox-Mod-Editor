using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Paradox_Mod_Editor.Models;
using System.Text.RegularExpressions;
using System.ComponentModel;
using Paradox_Mod_Editor.ParadoxSyntax;
using System.Diagnostics;

namespace Paradox_Mod_Editor.Models
{
    public class ScriptParser
    {
        private IScriptStrategy strategy;
        private const string scriptPattern = @"^\s*[a-zA-Z_]+\s*=\s*{\s*$";
        Stopwatch stopWatch;

        public ScriptParser(IScriptStrategy strategy)
        {
            this.strategy = strategy;
        }

        public List<ScriptObject> Split(string data, FileType fileType)
        {
            // TODO: add IScriptObject type detection based on file type
            // TODO: add file type detection
            // TODO: move excluded strings to file type
            List<ScriptObject> scriptObjects = new List<ScriptObject>();
            string[] lineData = data.Split('\n');
            int start = 0;
            int depth = 0;
            bool insideObject = false;
            string scriptPattern = @"^\s*[a-zA-Z_]+\s*=\s*{\s*$";
            for (int i = 0; i < lineData.Length; i++)
            {
                string line = lineData[i];
                
                if (line.Contains("#"))
                {
                    line = line.Substring(0, line.IndexOf("#"));
                }
                if (!insideObject && Regex.IsMatch(line, scriptPattern) && !fileType.ExcludedStrings.Any(line.Contains))
                {
                    start = i;
                    insideObject = true;
                    depth = 0;
                    continue;
                }
                if (insideObject)
                {
                    if (line.Contains("{"))
                    {
                        depth++;
                    }
                    if (line.Contains("}"))
                    {
                        depth--;
                    }
                    if (depth == -1)
                    {
                        insideObject = false;
                        scriptObjects.Add(Parse(fileType.ScriptTypes[0], lineData.Skip(start).Take(i - start + 1).ToArray()));
                    }
                }
            }
            return scriptObjects;
        }

        public List<ScriptObject> Split(string[] lineData, Type scriptType)
        {
            stopWatch = Stopwatch.StartNew();
            if (scriptType == null)
            {
                return null;
            }
            List<ScriptObject> scriptObjects = new List<ScriptObject>();
            int start = 0;
            int depth = 0;
            bool insideObject = false;
            for (int i = 0; i < lineData.Length; i++)
            {
                string line = lineData[i];

                if (line.Contains("#"))
                {
                    line = line.Substring(0, line.IndexOf("#"));
                }
                if (!insideObject && Regex.IsMatch(line, scriptPattern)) // excluded strings(?)
                {
                    start = i;
                    insideObject = true;
                    depth = 0;
                    continue;
                }
                if (insideObject)
                {
                    if (line.Contains("{"))
                    {
                        depth++;
                    }
                    if (line.Contains("}"))
                    {
                        depth--;
                    }
                    if (depth == -1)
                    {
                        insideObject = false;
                        scriptObjects.Add(Parse(scriptType, lineData.Skip(start).Take(i - start + 1).ToArray()));
                    }
                }
            }
            string splitTime = stopWatch.ElapsedMilliseconds.ToString();
            Debug.WriteLine("{0} sub-split in {1}ms", lineData[0], splitTime);
            return scriptObjects;
        }

        private object ParseToType(string text, Type type)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(type);
            return converter.ConvertFromString(text);

            //throw new InvalidCastException(string.Format("cannot store {0} {1} in {2} for {3}", newValue.GetType(), newValue, typeof(T), ScriptText));
        }

        private ScriptObject Parse(Type scriptType, string[] data)
        {
            // TODO: parsing current stops at a position, reads sub-string recursively, then starts again at beginning of substring
            // make it jump to to the end of the substring at the end of the recursion
            
            // TODO: assign name to SciptObject properly
            PropertyInfo[] properties = scriptType.GetProperties().Where(
                prop => Attribute.IsDefined(prop, typeof(ScriptValueAttribute))).ToArray();
            // PropertyInfo[] properties = ((ScriptPropertyGiver)scriptObject).GetScriptProperties();
            Dictionary<string, IScriptContainer> scriptToProperty = new Dictionary<string, IScriptContainer>();

            // TODO: parse sub-objects (recursively?)

            string name = data[0].Substring(0, data[0].IndexOf('=')).Trim();
            ScriptObject scriptObject = strategy.GetScriptObject(scriptType, name);
            stopWatch = Stopwatch.StartNew();
            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType.Name == typeof(ScriptValue<>).Name || property.PropertyType == typeof(ScriptPBool)) // use Name to account for ScriptValues of fixed type not being equal
                {
                    // N.B. notes below are tentative - possibly obsolete
                    // TODO: move scriptText to xml file, have factory/builder/whatever makes the scriptObjects pass the relevant data
                    // to the scriptObject in PropertyName -> PropertyScriptText dict
                    // TODO: use Builder instead of Factory?
                    // TODO: steps below:
                    // 1) create dumby scriptObject to get the ScriptTexts from using default ReligionFactory
                    // 2) parse information
                    // 3) use new "factory" to input parsed data into dumby object (use null coalesce if needed)
                    
                    scriptToProperty.Add(((IScriptContainer)property.GetValue(scriptObject)).ScriptText, (IScriptContainer)property.GetValue(scriptObject));
                }
            }
            stopWatch.Stop();
            string propertyTime = stopWatch.ElapsedMilliseconds.ToString();
            Debug.WriteLine(string.Format("{0}'s properties gathered in {1}", name, propertyTime));

            List<string> parsedFields = new List<string>();
            stopWatch = Stopwatch.StartNew();
            for (int i = 1; i < data.Length; i++)
            {
                string line = data[i];
                if (scriptToProperty.Keys.Any(line.Contains))
                {
                    // TODO: add check for default PBools
                    // TODO: add check for undefined properties
                    // TODO: add check for repeated properties within same object

                    IScriptContainer scriptValue = default(IScriptContainer);
                    foreach (string key in scriptToProperty.Keys)
                    {
                        if (Regex.IsMatch(line, @"\b" + key + @"\b"))
                        {
                            scriptValue = scriptToProperty[key];
                            break;
                        }
                    }
                    if (parsedFields.Contains(scriptValue.ScriptText))
                    {
                        continue;
                    }
                    string lineValue = line.Substring(line.IndexOf('=') + 1).Trim();
                    if (lineValue.Contains('#'))
                    {
                        lineValue = lineValue.Substring(0, lineValue.IndexOf('#')).Trim(); ;
                    }
                    if (scriptValue.GetType().GetGenericArguments().Length > 0 && 
                        scriptValue.GetType().GetGenericArguments()[0] == typeof(List<string>))
                    {
                        while (!lineValue.Contains('}'))
                        {
                            i++;
                            lineValue += data[i];
                        }
                        lineValue = lineValue.Replace("{", "").Replace("}", "").Trim();

                        List<string> values = lineValue.Split(' ').ToList();

                        scriptValue.SetValue(values);
                        parsedFields.Add(scriptValue.ScriptText);
                        continue;
                    }
                    scriptValue.SetValue(ParseToType(lineValue, scriptValue.GetContainedType()));
                    parsedFields.Add(scriptValue.ScriptText);
                }
                else if (scriptObject.GetChildType() != null && i > 0 && Regex.IsMatch(line, scriptPattern) && !scriptObject.GetExcludedStrings().Any(line.Contains))
                {
                    string[] subData = new List<string>(data).GetRange(i, data.Length - i).ToArray();
                    List<ScriptObject> subObjects = Split(subData, scriptObject.GetChildType());
                    if (subObjects != null)
                    {
                        scriptObject.Children = subObjects;
                        i += subData.Length;
                    }
                }
            }
            string buildTime = stopWatch.ElapsedMilliseconds.ToString();
            Debug.WriteLine(string.Format("{0} built in {1}", name, buildTime));
            return scriptObject;
        }
    }
}
