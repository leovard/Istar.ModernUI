using System;
using System.Collections.Generic;

namespace Istar.ModernUI.Windows.Controls.BbCode
{
    /// <summary>
    /// Represents a token buffer.
    /// </summary>
    internal class TokenBuffer
    {
        private readonly List<Token> _tokens = new List<Token>();
        private int _position;
        //private int mark;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:TokenBuffer"/> class.
        /// </summary>
        /// <param name="lexer">The lexer.</param>
        public TokenBuffer(Lexer lexer)
        {
            if (lexer == null) {
                throw new ArgumentNullException(nameof(lexer));
            }

            Token token;
            do {
                token = lexer.NextToken();
                _tokens.Add(token);
            }
            while (token.TokenType != Lexer.TokenEnd);
        }

        /// <summary>
        /// Performs a look-ahead.
        /// </summary>
        /// <param name="count">The number of tokens to look ahead.</param>
        /// <returns></returns>
        public Token La(int count)
        {
            var index = _position + count - 1;
            return index < _tokens.Count ? _tokens[index] : Token.End;
        }

        /// <summary>
        /// Consumes the next token.
        /// </summary>
        public void Consume()
        {
            _position++;
        }
    }
}
