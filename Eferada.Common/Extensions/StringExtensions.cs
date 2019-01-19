using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Eferada.Common.Extensions
{
    /// <summary>
    /// Class contains <see cref="T:System.String"/> extensions.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Indicates whether the specified <see cref="T:System.String"/> is null or an <see cref="T:System.String.Empty"/> string.
        /// </summary>
        /// <param name="value">A <see cref="T:System.String"/> reference to test.</param>
        /// <returns>
        /// <c>true</c> if provided value is null or an empty string (""); otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrEmpty(this string value) => string.IsNullOrEmpty(value);

        /// <summary>
        /// Indicates whether the specified <see cref="T:System.String"/> is null or an <see cref="T:System.String.Empty"/> string.
        /// </summary>
        /// <param name="value">A <see cref="T:System.String"/> reference to test.</param>
        /// <returns>
        /// <c>true</c> if provided value is null or if value consists exclusively of white-space characters; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrWhiteSpace(this string value) => string.IsNullOrWhiteSpace(value);

        /// <summary>
        /// Indicates whether the specified <see cref="T:System.String"/> is null or an <see cref="T:System.String.Empty"/> string.
        /// </summary>
        /// <param name="value">A <see cref="T:System.String"/> reference to test.</param>
        /// <returns>
        /// <c>true</c> if provided value is not null or not an empty string (""); otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNotNullOrEmpty(this string value) => !string.IsNullOrEmpty(value);

        /// <summary>
        /// Indicates whether the specified <see cref="T:System.String"/> is null or an <see cref="T:System.String.Empty"/> string.
        /// </summary>
        /// <param name="value">A <see cref="T:System.String"/> reference to test.</param>
        /// <returns>
        /// <c>true</c> if provided value is not null or if value not consists exclusively white-space characters; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNotNullOrWhiteSpace(this string value) => !string.IsNullOrWhiteSpace(value);

        /// <summary>
        /// Formats a string with one literal placeholder.
        /// </summary>
        /// <param name="text">The extension text</param>
        /// <param name="arg0">Argument 0</param>
        /// <returns>The formatted string</returns>
        public static string FormatWith(this string text, object arg0) => string.Format(text, arg0);

        /// <summary>
        /// Formats a string with a list of literal placeholders.
        /// </summary>
        /// <param name="text">The extension text</param>
        /// <param name="args">The argument list</param>
        /// <returns>The formatted string</returns>
        public static string FormatWith(this string text, params object[] args) => string.Format(text, args);

        /// <summary>
        /// Formats a string with a list of literal placeholders.
        /// </summary>
        /// <param name="text">The extension text</param>
        /// <param name="provider">The format provider</param>
        /// <param name="args">The argument list</param>
        /// <returns>The formatted string</returns>
        public static string FormatWith(this string text, IFormatProvider provider, params object[] args) => string.Format(provider, text, args);

        /// <summary>
        /// Converts a string to CamelCase.
        /// </summary>
        /// <param name="s">The text that will be formatted</param>
        /// <returns>String as CamelCase</returns>
        public static string ToCamelCase(this string s)
        {
            if (s.Contains("."))
            {
                var splitted = s.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

                var builder = new StringBuilder(s.Length);
                foreach (var item in splitted)
                {
                    builder.Append($"{ToCamelCase(item)}.");
                }

                // Remove last '.'
                builder.Length--;

                return builder.ToString();
            }

            if (s.IsNullOrEmpty() || !char.IsUpper(s[0]))
            {
                return s;
            }

            var chars = s.ToCharArray();
            for (var i = 0; i < chars.Length; i++)
            {
                if (i == 1 && !char.IsUpper(chars[i])) break;

                var hasNext = i + 1 < chars.Length;
                if (i > 0 && hasNext && !char.IsUpper(chars[i + 1]))
                {
                    break;
                }

                chars[i] = char.ToLower(chars[i], CultureInfo.InvariantCulture);
            }

            return new string(chars);
        }

        /// <summary>
        /// Decode parameters from given string as key-value pairs.
        /// </summary>
        /// <param name="s">The string from which parameters needs to be decoded.</param>
        /// <param name="separators">Char array used as param separators</param>
        /// <returns>Returns dictionary with parameters and its values.<seealso>
        ///         <cref>System.Collections.Generic.IDictionary{string, string}</cref>
        ///     </seealso>
        /// </returns>
        /// <remarks>
        /// If there is several parameters with the same key name, they will be added as one key and values will be concatenated with  comma char ','.
        /// </remarks>
        public static Dictionary<string, string> DecodeParameters(this string s, char[] separators)
        {
            if (s.IsNullOrWhiteSpace() || s.Length == 0)
                return new Dictionary<string, string>();

            return s.Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .Select(parameter => parameter.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries))
                .GroupBy(parts => parts[0],
                    parts => parts.Length > 2
                        ? string.Join("=", parts, 1, parts.Length - 1)
                        : (parts.Length > 1 ? parts[1] : ""))
                .ToDictionary(grouping => grouping.Key,
                    grouping => string.Join(",", grouping));
        }


        public static string TrimStart(this string target, string trimString)
        {
            var result = target;
            while (result.StartsWith(trimString))
            {
                result = result.Substring(trimString.Length);
            }

            return result;
        }

        public static string TrimEnd(this string target, string trimString)
        {
            var result = target;
            while (result.EndsWith(trimString))
            {
                result = result.Substring(0, result.Length - trimString.Length);
            }

            return result;
        }

        public static string ToEmptyIfNull(this string target)
        {
            return target ?? string.Empty;
        }

        /// <summary>
        /// Splits a string into substrings based on the characters in an array and trims each substring.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string[] SplitAndTrim(this string target, params char[] separator)
        {
            var splitResult = target.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            for (var i = 0; i < splitResult.Length; i++)
            {
                splitResult[i] = splitResult[i].Trim();
            }

            return splitResult;
        }

        public static T DeserializeJson<T>(this string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        /// <summary>
        /// Returns a new MemoryStream from target string
        /// </summary>
        /// <param name="target"></param>        
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static MemoryStream ToMemoryStream(this string target, Encoding encoding = null)
        {
            var bytes = encoding == null ? Encoding.UTF8.GetBytes(target) : encoding.GetBytes(target);

            return new MemoryStream(bytes);
        }
    }
}
