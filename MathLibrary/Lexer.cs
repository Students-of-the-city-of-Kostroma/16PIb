﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SimpleLexer
{
    public class Lexer : ILexer
    {
        Regex endOfLineRegex = new Regex(@"\r\n|\r|\n", RegexOptions.Compiled);
        IList<TokenDefinition> tokenDefinitions = new List<TokenDefinition>();

        public void AddDefinition(TokenDefinition tokenDefinition)
        {
            tokenDefinitions.Add(tokenDefinition);
        }

        public IEnumerable<Token> Tokenize(string source)
        {
            int currentIndex = 0;
            int currentLine = 1;
            int currentColumn = 0;

            while (currentIndex < source.Length)
            {
                TokenDefinition matchedDefinition = null;
                int matchLength = 0;

                foreach (var rule in tokenDefinitions)
                {
                    var match = rule.Regex.Match(source, currentIndex);

                    if (match.Success && (match.Index - currentIndex) == 0)
                    {
                        matchedDefinition = rule;
                        matchLength = match.Length;
                        break;
                    }
                }

                if (matchedDefinition == null)
                {
                    throw new Exception(string.Format("Unrecognized symbol '{0}' at index {1} (line {2}, column {3}).", source[currentIndex], currentIndex, currentLine, currentColumn));
                }
                else
                {
                    var value = source.Substring(currentIndex, matchLength);

                    if (!matchedDefinition.IsIgnored)
                        yield return new Token(matchedDefinition.Type, value, new TokenPosition(currentIndex, currentLine, currentColumn));

                    var endOfLineMatch = endOfLineRegex.Match(value);
                    if (endOfLineMatch.Success)
                    {
                        currentLine += 1;
                        currentColumn = value.Length - (endOfLineMatch.Index + endOfLineMatch.Length);
                    }
                    else
                    {
                        currentColumn += matchLength;
                    }

                    currentIndex += matchLength;
                }
            }

            //yield return new Token("(end)", null, new TokenPosition(currentIndex, currentLine, currentColumn));
        }
    }

    public class MathLexer : Lexer
    {
        public MathLexer() : base()
        {
            this.AddDefinition(new TokenDefinition(
               "(literal)",
               new Regex(@"\d+(\.\d+)?([eE][+\-]\d+)?")));

            this.AddDefinition(new TokenDefinition(
                "(operator)",
                new Regex(@"\*|\/|\+|\-|\=|\&")));

            this.AddDefinition(new TokenDefinition(
                "(parenthesis)",
                new Regex(@"[\(\)]")
                ));

            this.AddDefinition(new TokenDefinition(
                "(white-space)",
                new Regex(@"\s+"),
                true));

            this.AddDefinition(new TokenDefinition(
                "(identifier)",
                new Regex(@"\b[a-zA-Z_][a-zA-Z0-9_]*\b")));
        }
    }
}
