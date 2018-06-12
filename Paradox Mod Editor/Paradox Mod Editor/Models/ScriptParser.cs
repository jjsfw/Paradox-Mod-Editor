using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Paradox_Mod_Editor.Models;
using System.Text.RegularExpressions;

namespace Paradox_Mod_Editor.Models
{
    static class ScriptParser
    {
        public static void Split(string data, IScriptObject scriptObject)
        {
            string[] lineData = data.Split('\n');
            int start = 0;
            int depth = 0;
            bool insideObject = false;
            for (int i = 0; i < lineData.Length; i++)
            {
                string line;
                
                if (lineData[i].Contains("#"))
                {
                    line = lineData[i].Substring(0, lineData[i].IndexOf("#"));
                }
                else
                {
                    line = lineData[i];
                }
                if (!insideObject && Regex.IsMatch(line, @"^\s*[a-zA-Z]+\s*=\s*{\s*$") && !scriptObject.ExcludedStrings.Any(line.Contains))
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

        private static void Parse(IScriptObject scriptObject, string[] data)
        {
            int i = 1;
        }
    }
}
