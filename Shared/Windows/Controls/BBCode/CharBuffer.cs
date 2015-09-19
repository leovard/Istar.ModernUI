﻿using System;
using System.Diagnostics.CodeAnalysis;

namespace Istar.ModernUI.Windows.Controls.BbCode
{
    /// <summary>
    /// Represents a character buffer.
    /// </summary>
    internal class CharBuffer
    {
        private readonly string _value;
        private int _position;
        private int _mark;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CharBuffer"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public CharBuffer(string value)
        {
            if (value == null) {
                throw new ArgumentNullException(nameof(value));
            }
            _value = value;
        }

        /// <summary>
        /// Performs a look-ahead.
        /// </summary>
        /// <param name="count">The number of character to look ahead.</param>
        /// <returns></returns>
        public char La(int count)
        {
            var index = _position + count - 1;
            return index < _value.Length ? _value[index] : char.MaxValue;
        }

        /// <summary>
        /// Marks the current position.
        /// </summary>
        public void Mark()
        {
            _mark = _position;
        }

        /// <summary>
        /// Gets the mark.
        /// </summary>
        /// <returns></returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public string GetMark()
        {
            return _mark < _position ? _value.Substring(_mark, _position - _mark) : string.Empty;
        }

        /// <summary>
        /// Consumes the next character.
        /// </summary>
        public void Consume()
        {
            _position++;
        }
    }
}
