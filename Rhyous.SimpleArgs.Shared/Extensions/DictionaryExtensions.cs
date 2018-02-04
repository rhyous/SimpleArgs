using Rhyous.SimpleArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rhyous.SimpleArgs
{
    public static class DictionaryExtensions
    {
        const char QuoteChar = '"';
        const char EqualsChar = '=';
        const char SpaceChar = ' ';
        const char SlashChar = '/';
        const char DashChar = '-';

        public static string[] ToArgs(this Dictionary<string, string> dictionary)
        {
            var args = new string[dictionary.Count];
            int i = 0;
            foreach (var kvp in dictionary)
            {
                var key = kvp.Key;
                var value = kvp.Value;
                var startChars = new[] { SlashChar, DashChar };
                if (startChars.Any(c=> key.StartsWith(c.ToString())) && string.IsNullOrWhiteSpace(kvp.Value))
                {
                    key = key.TrimStart(startChars);
                    value = true.ToString();
                }
                args[i++] = key.WrapIfContains(wrap: QuoteChar, patterns: new[] { EqualsChar, SpaceChar }) 
                        + "="
                        + value.WrapIfContains(wrap: QuoteChar, patterns: new [] { EqualsChar, SpaceChar});
            }
            return args;
        }
    }
}
