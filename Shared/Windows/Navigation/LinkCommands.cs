using System.Windows.Input;

namespace Istar.ModernUI.Windows.Navigation
{
    /// <summary>
    /// The routed link commands.
    /// </summary>
    public static class LinkCommands
    {
        /// <summary>
        /// Gets the navigate link routed command.
        /// </summary>
        public static RoutedUICommand NavigateLink { get; } = new RoutedUICommand(Resources.NavigateLink, "NavigateLink", typeof(LinkCommands));
    }
}
