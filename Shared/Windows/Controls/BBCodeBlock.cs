using Istar.ModernUI.Windows.Controls.BbCode;
using Istar.ModernUI.Windows.Navigation;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Navigation;

namespace Istar.ModernUI.Windows.Controls
{
    /// <summary>
    /// A lighweight control for displaying small amounts of rich formatted BbCode content.
    /// </summary>
    [ContentProperty("BbCode")]
    public class BbCodeBlock
        : TextBlock
    {
        /// <summary>
        /// Identifies the BbCode dependency property.
        /// </summary>
        public static DependencyProperty BbCodeProperty = DependencyProperty.Register("BbCode", typeof(string), typeof(BbCodeBlock), new PropertyMetadata(OnBbCodeChangedrty));
        /// <summary>
        /// Identifies the LinkNavigator dependency property.
        /// </summary>
        public static DependencyProperty LinkNavigatorProperty = DependencyProperty.Register("LinkNavigator", typeof(ILinkNavigator), typeof(BbCodeBlock), new PropertyMetadata(new DefaultLinkNavigator(), OnLinkNavigatorChanged));

        private bool _dirty;

        /// <summary>
        /// Initializes a new instance of the <see cref="BbCodeBlock"/> class.
        /// </summary>
        public BbCodeBlock()
        {
            // ensures the implicit BbCodeBlock style is used
            DefaultStyleKey = typeof(BbCodeBlock);

            AddHandler(FrameworkContentElement.LoadedEvent, new RoutedEventHandler(OnLoaded));
            AddHandler(Hyperlink.RequestNavigateEvent, new RequestNavigateEventHandler(OnRequestNavigate));
        }

        private static void OnBbCodeChangedrty(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            ((BbCodeBlock)o).UpdateDirty();
        }

        private static void OnLinkNavigatorChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null) {
                // null values disallowed
                throw new ArgumentNullException(nameof(o));
            }

            ((BbCodeBlock)o).UpdateDirty();
        }

        private void OnLoaded(object o, EventArgs e)
        {
            Update();
        }

        private void UpdateDirty()
        {
            _dirty = true;
            Update();
        }

        private void Update()
        {
            if (!IsLoaded || !_dirty) {
                return;
            }

            var bbCode = BbCode;

            Inlines.Clear();

            if (!string.IsNullOrWhiteSpace(bbCode)) {
                Inline inline;
                try {
                    var parser = new BbCodeParser(bbCode, this) {
                        Commands = LinkNavigator.Commands
                    };
                    inline = parser.Parse();
                }
                catch (Exception) {
                    // parsing failed, display BbCode value as-is
                    inline = new Run { Text = bbCode };
                }
                Inlines.Add(inline);
            }
            _dirty = false;
        }

        private void OnRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            try {
                // perform navigation using the link navigator
                LinkNavigator.Navigate(e.Uri, this, e.Target);
            }
            catch (Exception error) {
                // display navigation failures
                ModernDialog.ShowMessage(error.Message, ModernUI.Resources.NavigationFailed, MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// Gets or sets the BB code.
        /// </summary>
        /// <value>The BB code.</value>
        public string BbCode
        {
            get { return (string)GetValue(BbCodeProperty); }
            set { SetValue(BbCodeProperty, value); }
        }

        /// <summary>
        /// Gets or sets the link navigator.
        /// </summary>
        /// <value>The link navigator.</value>
        public ILinkNavigator LinkNavigator
        {
            get { return (ILinkNavigator)GetValue(LinkNavigatorProperty); }
            set { SetValue(LinkNavigatorProperty, value); }
        }
    }
}
