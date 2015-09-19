﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace IstarWindows.ViewModels
{
    /// <summary>
    /// Base class for a View-Model in the MVVM pattern.
    /// </summary>
    public abstract class ViewModel : ObservableObject, IDataErrorInfo
    {
        /// <summary>
        /// Gets the validation error for a property whose name matches the specified <see cref="columnName"/>.
        /// </summary>
        /// <param name="columnName">The name of the property to validate.</param>
        /// <returns>Returns a validation error if there is one, otherwise returns null.</returns>
        public string this[string columnName] => OnValidate(columnName);

        /// <summary>
        /// Not supported.
        /// </summary>
        [Obsolete]
        public string Error
        {
            get { throw new NotSupportedException(); }
        }

        /// <summary>
        /// Validates a property whose name matches the specified <see cref="propertyName"/>.
        /// </summary>
        /// <param name="propertyName">The name of the property to validate.</param>
        /// <returns>Returns a validation error, if any, otherwise returns null.</returns>
        protected virtual string OnValidate(string propertyName)
        {
            var context = new ValidationContext(this)
            {
                MemberName = propertyName
            };

            var results = new Collection<ValidationResult>();
            var isValid = Validator.TryValidateObject(this, context, results, true);

            if (isValid) return null;
            var result = results.SingleOrDefault(p =>
                p.MemberNames.Any(memberName =>
                    memberName == propertyName));

            return result?.ErrorMessage;
        }
    }
}
