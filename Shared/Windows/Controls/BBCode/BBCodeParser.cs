using System;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows;
using System.Windows.Input;
using Istar.ModernUI.Windows.Navigation;

namespace Istar.ModernUI.Windows.Controls.BbCode
{
    /// <summary>
    /// Represents the BbCode parser.
    /// </summary>
    internal class BbCodeParser
        : Parser<Span>
    {
        // supporting a basic set of BbCode tags
        private const string TagBold = "b";
        private const string TagColor = "color";
        private const string TagItalic = "i";
        private const string TagSize = "size";
        private const string TagUnderline = "u";
        private const string TagUrl = "url";

        class ParseContext
        {
            public ParseContext(Span parent)
            {
                Parent = parent;
            }

            private Span Parent { get; set; }

            public double? FontSize { private get; set; }
            public FontWeight? FontWeight { private get; set; }
            public FontStyle? FontStyle { private get; set; }
            public Brush Foreground { private get; set; }
            public TextDecorationCollection TextDecorations { private get; set; }
            public string NavigateUri { get; set; }

            /// <summary>
            /// Creates a run reflecting the current context settings.
            /// </summary>
            /// <returns></returns>
            public Run CreateRun(string text)
            {
                var run = new Run { Text = text };
                if (FontSize.HasValue) {
                    run.FontSize = FontSize.Value;
                }
                if (FontWeight.HasValue) {
                    run.FontWeight = FontWeight.Value;
                }
                if (FontStyle.HasValue) {
                    run.FontStyle = FontStyle.Value;
                }
                if (Foreground != null) {
                    run.Foreground = Foreground;
                }
                run.TextDecorations = TextDecorations;

                return run;
            }
        }

        private readonly FrameworkElement _source;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BbCodeParser"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="source">The framework source element this parser operates in.</param>
        public BbCodeParser(string value, FrameworkElement source)
            : base(new BbCodeLexer(value))
        {
            if (source == null) {
                throw new ArgumentNullException(nameof(source));
            }
            _source = source;
        }

        /// <summary>
        /// Gets or sets the available navigable commands.
        /// </summary>
        public CommandDictionary Commands { get; set; }

        private void ParseTag(string tag, bool start, ParseContext context)
        {
            if (tag != TagBold)
            {
                if (tag != TagColor)
                {
                    if (tag != TagItalic)
                    {
                        if (tag != TagSize)
                        {
                            if (tag != TagUnderline)
                            {
                                if (tag != TagUrl) return;
                                if (start)
                                {
                                    var token = La(1);
                                    if (token.TokenType != BbCodeLexer.TokenAttribute) return;
                                    context.NavigateUri = token.Value;
                                    Consume();
                                }
                                else
                                {
                                    context.NavigateUri = null;
                                }
                            }
                            else
                            {
                                context.TextDecorations = start ? TextDecorations.Underline : null;
                            }
                        }
                        else
                        {
                            if (start)
                            {
                                var token = La(1);
                                if (token.TokenType != BbCodeLexer.TokenAttribute) return;
                                context.FontSize = Convert.ToDouble(token.Value);

                                Consume();
                            }
                            else
                            {
                                context.FontSize = null;
                            }
                        }
                    }
                    else
                    {
                        if (start)
                        {
                            context.FontStyle = FontStyles.Italic;
                        }
                        else
                        {
                            context.FontStyle = null;
                        }
                    }
                }
                else
                {
                    if (start)
                    {
                        var token = La(1);
                        if (token.TokenType != BbCodeLexer.TokenAttribute) return;
                        var convertFromString = ColorConverter.ConvertFromString(token.Value);
                        if (convertFromString != null)
                        {
                            var color = (Color) convertFromString;
                            context.Foreground = new SolidColorBrush(color);
                        }

                        Consume();
                    }
                    else
                    {
                        context.Foreground = null;
                    }
                }
            }
            else
            {
                context.FontWeight = null;
                if (start)
                {
                    context.FontWeight = FontWeights.Bold;
                }
            }
        }

        private void Parse(Span span)
        {
            var context = new ParseContext(span);

            while (true) {
                var token = La(1);
                Consume();

                if (token.TokenType != BbCodeLexer.TokenStartTag)
                {
                    if (token.TokenType != BbCodeLexer.TokenEndTag)
                    {
                        if (token.TokenType != BbCodeLexer.TokenText)
                        {
                            if (token.TokenType != BbCodeLexer.TokenLineBreak)
                            {
                                if (token.TokenType == BbCodeLexer.TokenAttribute)
                                {
                                    throw new ParseException(Resources.UnexpectedToken);
                                }
                                if (token.TokenType == Lexer.TokenEnd)
                                {
                                    break;
                                }
                                throw new ParseException(Resources.UnknownTokenType);
                            }
                            span.Inlines.Add(new LineBreak());
                        }
                        else
                        {
                            var parent = span;
                            Uri uri;
                            string parameter;
                            string targetName;

                            // parse uri value for optional parameter and/or target, eg [url=cmd://foo|parameter|target]
                            if (NavigationHelper.TryParseUriWithParameters(context.NavigateUri, out uri, out parameter,
                                out targetName))
                            {
                                var link = new Hyperlink();

                                // assign ICommand instance if available, otherwise set NavigateUri
                                ICommand command;
                                if (Commands != null && Commands.TryGetValue(uri, out command))
                                {
                                    link.Command = command;
                                    link.CommandParameter = parameter;
                                    if (targetName != null)
                                    {
                                        link.CommandTarget = _source.FindName(targetName) as IInputElement;
                                    }
                                }
                                else
                                {
                                    link.NavigateUri = uri;
                                    link.TargetName = parameter;
                                }
                                parent = link;
                                span.Inlines.Add(parent);
                            }
                            var run = context.CreateRun(token.Value);
                            parent.Inlines.Add(run);
                        }
                    }
                    else
                    {
                        ParseTag(token.Value, false, context);
                    }
                }
                else
                {
                    ParseTag(token.Value, true, context);
                }
            }
        }

        /// <summary>
        /// Parses the text and returns a Span containing the parsed result.
        /// </summary>
        /// <returns></returns>
        public override Span Parse()
        {
            var span = new Span();

            Parse(span);

            return span;
        }
    }
}
