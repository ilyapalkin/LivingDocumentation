﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LivingDocumentation
{
    public static class StringExtensions
    {
        public static bool IsEnumerable(this string type)
        {
            if (!type.StartsWith("System.Collections.", StringComparison.Ordinal))
            {
                return false;
            }
            else if (type.StartsWith("System.Collections.Generic.", StringComparison.Ordinal))
            {
                return !type.Contains("Enumerator") && !type.Contains("Compar") && !type.Contains("Exception");
            }
            else if (type.StartsWith("System.Collections.Concurrent.", StringComparison.Ordinal))
            {
                return !type.Contains("Partition");
            }

            return !type.Contains("Enumerator") && !type.Contains("Compar") && !type.Contains("Structural") && !type.Contains("Provider");
        }

        public static bool IsGeneric(this string type)
        {
            return type.IndexOf('>') > -1 && type.EndsWith(">");
        }

        public static IReadOnlyList<string> GenericTypes(this string type)
        {
            if (!type.IsGeneric())
            {
                return new List<string>(0);
            }

            var typeParts = type.Substring(type.IndexOf('<') + 1, type.Length - type.IndexOf('<') - 2).Split(',');
            var types = new List<string>();

            foreach (var part in typeParts)
            {
                if (part.IndexOf('>') > -1 && types.Count > 0 && types.Last().ToCharArray().Count(c => c == '<') > types.Last().ToCharArray().Count(c => c == '>'))
                {
                    types[types.Count - 1] = types[types.Count - 1] + "," + part.Trim();
                }
                else
                {
                    types.Add(part.Trim());
                }
            }

            return types;
        }

        public static string ForDiagram(this string type)
        {
            if (type.IsGeneric())
            {
                var a = type.Substring(0, type.IndexOf('<')).ForDiagram();
                var b = type.GenericTypes().Select(s => s.ForDiagram());
                return $"{a}<{string.Join(", ", b)}>";
            }
            else if (type.IndexOf('.') > -1)
            {
                return type.Substring(type.LastIndexOf('.') + 1);
            }
            else
            {
                return type;
            }
        }

        public static string ToSentenceCase(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            var stringBuilder = new StringBuilder();

            stringBuilder.Append(char.ToUpper(input[0]));

            for (var i = 1; i < input.Length; i++)
            {
                if (char.IsUpper(input[i]) || char.IsDigit(input[i]))
                {
                    stringBuilder.Append(' ');
                }

                stringBuilder.Append(input[i]);
            }

            return stringBuilder.ToString();
        }
    }
}
