using Periotris.Net.Customization.Element;
using System.Windows.Controls;
using System.Windows.Media;

namespace Periotris.Net.View
{
    /// <summary>
    ///     Interaction logic for AnnotatedBlockControl.xaml
    /// </summary>
    public partial class AnnotatedBlockControl : UserControl
    {
        // TODO: 1 or 10?
        public static int OriginalHeight = 1;

        public static int OriginalWidth = 1;

        public AnnotatedBlockControl()
        {
            InitializeComponent();
        }

        public ElementInfo Element { get; private set; }

        /// <summary>
        ///     Set the background color.
        /// </summary>
        /// <param name="brush">The color brush.</param>
        public void SetFill(Brush brush)
        {
            Background = brush;
        }

        /// <summary>
        ///     Set the element to display on this <see cref="AnnotatedBlockControl" />.
        /// </summary>
        /// <param name="info">The <see cref="ElementInfo" /> to set.</param>
        public void SetElement(ElementInfo info)
        {
            Element = info;
            ElementNameTextBlock.Text = info.Symbol;
        }
    }
}