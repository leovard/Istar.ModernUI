namespace Istar.ModernUI.Presentation
{
    /// <summary>
    /// Represents a named group of links.
    /// </summary>
    public class LinkGroup
        : Displayable
    {
        private string _groupKey;
        private Link _selectedLink;

        /// <summary>
        /// Gets or sets the key of the group.
        /// </summary>
        /// <value>The key of the group.</value>
        /// <remarks>
        /// The group key is used to group link groups in a <see cref="Istar.ModernUI.Windows.Controls.ModernMenu"/>.
        /// </remarks>
        public string GroupKey
        {
            get { return _groupKey; }
            set
            {
                if (_groupKey == value) return;
                _groupKey = value;
                OnPropertyChanged("GroupKey");
            }
        }

        /// <summary>
        /// Gets or sets the selected link in this group.
        /// </summary>
        /// <value>The selected link.</value>
        internal Link SelectedLink
        {
            get { return _selectedLink; }
            set
            {
                if (_selectedLink == value) return;
                _selectedLink = value;
                OnPropertyChanged("SelectedLink");
            }
        }

        /// <summary>
        /// Gets the links.
        /// </summary>
        /// <value>The links.</value>
        public LinkCollection Links { get; } = new LinkCollection();
    }
}
