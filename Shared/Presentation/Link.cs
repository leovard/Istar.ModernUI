using System;

namespace Istar.ModernUI.Presentation
{
    /// <summary>
    /// Represents a displayable link.
    /// </summary>
    public class Link
        : Displayable
    {
        private Uri _source;

        /// <summary>
        /// Gets or sets the source uri.
        /// </summary>
        /// <value>The source.</value>
        public Uri Source
        {
            get { return _source; }
            set
            {
                if (_source == value) return;
                _source = value;
                OnPropertyChanged("Source");
            }
        }
    }
}
