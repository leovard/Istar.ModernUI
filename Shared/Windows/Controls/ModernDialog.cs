using Istar.ModernUI.Presentation;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Istar.ModernUI.Windows.Controls
{
    /// <summary>
    /// Represents a Modern UI styled dialog window.
    /// </summary>
    public class ModernDialog
        : DpiAwareWindow
    {
        /// <summary>
        /// Identifies the BackgroundContent dependency property.
        /// </summary>
        public static readonly DependencyProperty BackgroundContentProperty = DependencyProperty.Register("BackgroundContent", typeof(object), typeof(ModernDialog));
        /// <summary>
        /// Identifies the Buttons dependency property.
        /// </summary>
        public static readonly DependencyProperty ButtonsProperty = DependencyProperty.Register("Buttons", typeof(IEnumerable<Button>), typeof(ModernDialog));

        private Button _okButton;
        private Button _cancelButton;
        private Button _yesButton;
        private Button _noButton;
        private Button _closeButton;

        private MessageBoxResult _messageBoxResult = MessageBoxResult.None;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModernDialog"/> class.
        /// </summary>
        public ModernDialog()
        {
            DefaultStyleKey = typeof(ModernDialog);
            WindowStartupLocation = WindowStartupLocation.CenterOwner;

            CloseCommand = new RelayCommand(o => {
                var result = o as MessageBoxResult?;
                if (result.HasValue)
                {
                    _messageBoxResult = result.Value;

                    // sets the Window.DialogResult as well
                    if (result.Value != MessageBoxResult.OK && result.Value != MessageBoxResult.Yes)
                    {
                        if (result.Value == MessageBoxResult.Cancel || result.Value == MessageBoxResult.No)
                        {
                            DialogResult = false;
                        }
                        else
                        {
                            DialogResult = null;
                        }
                    }
                    else
                    {
                        DialogResult = true;
                    }
                }
                                                      Close();
            });

            Buttons = new[] { CloseButton };

            // set the default owner to the app main window (if possible)
            if (Application.Current != null && !Equals(Application.Current.MainWindow, this)) {
                Owner = Application.Current.MainWindow;
            }
        }

        private Button CreateCloseDialogButton(string content, bool isDefault, bool isCancel, MessageBoxResult result)
        {
            return new Button {
                Content = content,
                Command = CloseCommand,
                CommandParameter = result,
                IsDefault = isDefault,
                IsCancel = isCancel,
                MinHeight = 21,
                MinWidth = 65,
                Margin = new Thickness(4, 0, 0, 0)
            };
        }

        /// <summary>
        /// Gets the close window command.
        /// </summary>
        public ICommand CloseCommand { get; }

        /// <summary>
        /// Gets the Ok button.
        /// </summary>
        public Button OkButton => _okButton ??
                                  (_okButton = CreateCloseDialogButton(ModernUI.Resources.Ok, true, false, MessageBoxResult.OK));

        /// <summary>
        /// Gets the Cancel button.
        /// </summary>
        public Button CancelButton => _cancelButton ??
                                      (_cancelButton =
                                          CreateCloseDialogButton(ModernUI.Resources.Cancel, false, true, MessageBoxResult.Cancel));

        /// <summary>
        /// Gets the Yes button.
        /// </summary>
        public Button YesButton => _yesButton ??
                                   (_yesButton = CreateCloseDialogButton(ModernUI.Resources.Yes, true, false, MessageBoxResult.Yes));

        /// <summary>
        /// Gets the No button.
        /// </summary>
        public Button NoButton => _noButton ??
                                  (_noButton = CreateCloseDialogButton(ModernUI.Resources.No, false, true, MessageBoxResult.No));

        /// <summary>
        /// Gets the Close button.
        /// </summary>
        public Button CloseButton => _closeButton ??
                                     (_closeButton =
                                         CreateCloseDialogButton(ModernUI.Resources.Close, true, false, MessageBoxResult.None));

        /// <summary>
        /// Gets or sets the background content of this window instance.
        /// </summary>
        public object BackgroundContent
        {
            get { return GetValue(BackgroundContentProperty); }
            set { SetValue(BackgroundContentProperty, value); }
        }

        /// <summary>
        /// Gets or sets the dialog buttons.
        /// </summary>
        public IEnumerable<Button> Buttons
        {
            get { return (IEnumerable<Button>)GetValue(ButtonsProperty); }
            set { SetValue(ButtonsProperty, value); }
        }

        /// <summary>
        /// Gets the message box result.
        /// </summary>
        /// <value>
        /// The message box result.
        /// </value>
        public MessageBoxResult MessageBoxResult => _messageBoxResult;

        /// <summary>
        /// Displays a messagebox.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="title">The title.</param>
        /// <param name="button">The button.</param>
        /// <param name="owner">The window owning the messagebox. The messagebox will be located at the center of the owner.</param>
        /// <returns></returns>
        public static MessageBoxResult ShowMessage(string text, string title, MessageBoxButton button, Window owner = null)
        {
            var dlg = new ModernDialog {
                Title = title,
                Content = new BbCodeBlock { BbCode = text, Margin = new Thickness(0, 0, 0, 8) },
                MinHeight = 0,
                MinWidth = 0,
                MaxHeight = 480,
                MaxWidth = 640,
            };
            if (owner != null) {
                dlg.Owner = owner;
            }

            dlg.Buttons = GetButtons(dlg, button);
            dlg.ShowDialog();
            return dlg._messageBoxResult;
        }

        private static IEnumerable<Button> GetButtons(ModernDialog owner, MessageBoxButton button)
        {
            if (button != MessageBoxButton.OK)
            {
                if (button != MessageBoxButton.OKCancel)
                {
                    if (button != MessageBoxButton.YesNo)
                    {
                        if (button != MessageBoxButton.YesNoCancel) yield break;
                        yield return owner.YesButton;
                        yield return owner.NoButton;
                        yield return owner.CancelButton;
                    }
                    else
                    {
                        yield return owner.YesButton;
                        yield return owner.NoButton;
                    }
                }
                else
                {
                    yield return owner.OkButton;
                    yield return owner.CancelButton;
                }
            }
            else
            {
                yield return owner.OkButton;
            }
        }
    }
}
