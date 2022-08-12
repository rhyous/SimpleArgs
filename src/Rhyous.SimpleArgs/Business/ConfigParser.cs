using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Rhyous.SimpleArgs
{
    public class ConfigParser
    {
        static char[] SlashOrDash = new[] { '/', '-' };

        public static Dictionary<string, string> Parse(TextReader reader, Action exitAction)
        {
            var dictionary = new Dictionary<string, string>();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("//"))
                    continue;
                bool keyStartsWithSlashorDash = SlashOrDash.Any(c=>line.StartsWith(c.ToString()));
                bool inQuoteGroup = false;
                StringBuilder builder = new StringBuilder();
                string key = "";
                foreach (char c in line)
                {
                    if (c == '"' || c == '\'')
                    {
                        inQuoteGroup = !inQuoteGroup;
                        continue;
                    }
                    if (!inQuoteGroup && c == '=')
                    {
                        key = builder.ToString();
                        if (string.IsNullOrWhiteSpace(key))
                        {
                            if (exitAction != null)
                                exitAction();
                            else
                                Environment.Exit(1);
                        }
                        builder.Clear();
                        continue;
                    }
                    builder.Append(c);
                }
                string value = "";
                if (keyStartsWithSlashorDash && string.IsNullOrWhiteSpace(key))
                {
                    key = builder.ToString();
                    value = true.ToString();
                }
                else
                {
                    value = builder.ToString();
                }
                dictionary.Add(key.TrimStart(SlashOrDash), value);
            }
            return dictionary;
        }
    }
}
