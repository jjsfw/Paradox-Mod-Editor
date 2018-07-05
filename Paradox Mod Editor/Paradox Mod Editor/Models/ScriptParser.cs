﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Paradox_Mod_Editor.Models;
using System.Text.RegularExpressions;
using System.ComponentModel;
using Paradox_Mod_Editor.ParadoxSyntax;

namespace Paradox_Mod_Editor.Models
{
    public class ScriptParser
    {
        public void Split(string data, FileType fileType)
        {
            // TODO: add IScriptObject type detection based on file type
            // TODO: add file type detection
            // TODO: move excluded strings to file type
            string[] lineData = data.Split('\n');
            int start = 0;
            int depth = 0;
            bool insideObject = false;
            string scriptPattern = @"^\s*[a-zA-Z]+\s*=\s*{\s*$";
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
                        Parse(scriptObject, lineData.Skip(start).Take(i - start + 1).ToArray());
                    }
                }
            }
        }

        private void Parse(IScriptObject scriptObject, string[] data)
        {
            PropertyInfo[] properties = ((ScriptPropertyGiver)scriptObject).GetScriptProperties();
            Dictionary<string, IScriptContainer> scriptToProperty = new Dictionary<string, IScriptContainer>();
            foreach(PropertyInfo property in properties)
            {
                if (property.PropertyType.Name == typeof(ScriptValue<>).Name || property.PropertyType == typeof(ScriptPBool)) // use Name to account for ScriptValues of fixed type not being equal
                {
                    scriptToProperty.Add(((IScriptContainer)property.GetValue(scriptObject)).ScriptText, (IScriptContainer)property.GetValue(scriptObject));
                }
            }
            for (int i = 0; i < data.Length; i++)
            {
                string line = data[i];
                if (scriptToProperty.Keys.Any(line.Contains))
                {
                    // TODO: add check for default PBools
                    // TODO: add check for undefined properties
                    // TODO: add check for repeated properties
                    IScriptContainer scriptValue = scriptToProperty[scriptToProperty.Keys.First(line.Contains)];
                    string lineValue = line.Substring(line.IndexOf('=') + 1).Trim();
                    if (lineValue.Contains('#'))
                    {
                        lineValue = lineValue.Substring(0, lineValue.IndexOf('#')).Trim(); ;
                    }
                    scriptValue.SetValue(lineValue);
                }
            }
        }
    }
}
