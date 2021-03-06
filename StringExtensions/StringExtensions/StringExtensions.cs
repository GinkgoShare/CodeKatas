﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StringExtensions
{
    public static class StringExtensions
    {
        public static bool HasAllUniqueChars(this string input) 
        {
            IDictionary<char, int> chars = new Dictionary<char, int>();
            foreach (var character in input) 
            {
                if (chars.ContainsKey(character)) return false;
                chars.Add(character, 1);         
            }
            return true;
        }

        public static string Reverse(this string input) 
        {
            var chars = input.ToCharArray();
            var halvedLength = chars.Length / 2;
            for (var i = 0; i < halvedLength; i++) 
            {
                var swap = chars[i];
                chars[i] = chars[(chars.Length-1)-i];
                chars[(chars.Length-1)-i] = swap;
            }
            return new string(chars);
        }

        public static string ReplaceSpace20(this string input) 
        {
            var chars = input.ToCharArray();
            int spaceCount = 0;
            for(int i = 0; i < chars.Length; i++) 
            {
                if (chars[i] == ' ') spaceCount++;
            }
            int newLength = chars.Length + spaceCount * 2;
            var newString = new char[newLength];
            for(int i = 0, j = 0; i < chars.Length; i++) 
            {
                if (chars[i] != ' ') newString[j++] = chars[i];
                else {
                    newString[j++] = '%';
                    newString[j++] = '2';
                    newString[j++] = '0';
                }
            }
            return new string(newString);
        }

        public static string Compress(this string input) 
        {
            if (input.Length <= input.CountCompression()) return input;
            var inputArray = input.ToCharArray();
            StringBuilder sb = new StringBuilder();
            char currentChar = inputArray[0];
            int charCount = 1;
            for(int i = 1; i < inputArray.Length; i++)
            {
                if (inputArray[i] == currentChar) charCount++;
                else {
                    sb.Append(currentChar);
                    sb.Append(charCount);
                    currentChar = inputArray[i];
                    charCount = 1;
                }
            }
            sb.Append(currentChar);
            sb.Append(charCount);
            return sb.ToString();
        }

        public static int CountCompression(this string input) 
        {
            if (string.IsNullOrEmpty(input)) return 0;
            var inputArray = input.ToCharArray();
            int count = 0;
            char currentChar = inputArray[0];
            int charCount = 1;
            for(int i = 1; i < inputArray.Length; i++)
            {
                if (inputArray[i] == currentChar) charCount++;
                else {
                    currentChar = inputArray[i];
                    charCount = 1;
                    count += 2;
                }
            }
            count += 2;
            return count;
        }
    }
}
