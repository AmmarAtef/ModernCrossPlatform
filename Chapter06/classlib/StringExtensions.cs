// <copyright file="StringExtensions.cs" company="ammar">
// Copyright (C) ammar .All rights reserved.
// </copyright>
using System.Text.RegularExpressions;

namespace Classlib
{
    /// <summary>
    /// Class to add extension method.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// check is the email is valid or not.
        /// </summary>
        /// <param name="input">a string input</param>
        /// <returns>return true or false if the email is valid.</returns>
        public static bool IsValidEmail(this string input)
        {
            return Regex.IsMatch(input, @"[a-zA-Z0-9\.-_]+@[a-zA-Z0-9\.-_]+");
        }
    }
}
