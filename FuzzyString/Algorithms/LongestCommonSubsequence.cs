﻿using System;

namespace FuzzyString.Algorithms
{
    //https://en.wikipedia.org/wiki/Longest_common_subsequence_problem
    public static class LongestCommonSubsequence
    {
        /// <summary>
        /// Gives back the longes common subsequence
        /// For example: in source 123456 and target 003400 it will give back 34
        /// </summary>
        public static string Calculate(string source, string target)
        {
            int[,] C = LongestCommonSubsequenceLengthTable(source, target);

            return Backtrack(C, source, target, source.Length, target.Length);
        }

        private static int[,] LongestCommonSubsequenceLengthTable(string source, string target)
        {
            int[,] C = new int[source.Length + 1, target.Length + 1];

            for (int i = 0; i < source.Length + 1; i++)
                C[i, 0] = 0;

            for (int i = 0; i < target.Length + 1; i++)
                C[0, i] = 0;

            for (int i = 1; i < source.Length + 1; i++)
            {
                for (int i2 = 1; i2 < target.Length + 1; i2++)
                {
                    if (source[i - 1].Equals(target[i2 - 1]))
                        C[i, i2] = C[i - 1, i2 - 1] + 1;
                    else
                        C[i, i2] = Math.Max(C[i, i2 - 1], C[i - 1, i2]);
                }
            }

            return C;
        }

        private static string Backtrack(int[,] C, string source, string target, int i, int j)
        {
            if (i == 0 || j == 0)
                return string.Empty;

            if (source[i - 1].Equals(target[j - 1]))
                return Backtrack(C, source, target, i - 1, j - 1) + source[i - 1];

            if (C[i, j - 1] > C[i - 1, j])
                return Backtrack(C, source, target, i, j - 1);

            return Backtrack(C, source, target, i - 1, j);
        }
    }
}
