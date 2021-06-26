using Periotris.Net.Customization.Element;
using Periotris.Net.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Periotris.Net.View
{
    public static class TetrisControlHelper
    {
        public static FrameworkElement AnnotatedBlockControlFactory(Block block, bool renderColors, double scale)
        {
            AnnotatedBlockControl newBlockControl = new();
            int atomicNumber = block.AtomicNumber;

            newBlockControl.SetFill(GetBlockColorByAtomicNumber(atomicNumber, renderColors));
            newBlockControl.SetElement(ElementInfoManager.Instance.ByAtomicNumber(atomicNumber));

            newBlockControl.Height = AnnotatedBlockControl.OriginalHeight * scale;
            newBlockControl.Width = AnnotatedBlockControl.OriginalWidth * scale;
            SetCanvasLocation(newBlockControl,
                block.Position.X * AnnotatedBlockControl.OriginalHeight * scale,
                block.Position.Y * AnnotatedBlockControl.OriginalWidth * scale
            );
            Panel.SetZIndex(newBlockControl, 1);
            return newBlockControl;
        }

        public static FrameworkElement HorizontalAssistGridLineFactory(int y, int width, double scale)
        {
            Rectangle rectangle = new()
            {
                Width = width * scale,
                Height = 1,
                Opacity = 0.1,
                Fill = new SolidColorBrush(Colors.White)
            };
            SetCanvasLocation(rectangle, 0, y * scale);
            return rectangle;
        }

        public static FrameworkElement VerticalAssistGridLineFactory(int x, int height, double scale)
        {
            Rectangle rectangle = new()
            {
                Width = 1,
                Height = height * scale,
                Opacity = 0.1,
                Fill = new SolidColorBrush(Colors.White)
            };
            SetCanvasLocation(rectangle, x * scale, 0);
            return rectangle;
        }

        public static void SetCanvasLocation(FrameworkElement element, double x, double y)
        {
            Canvas.SetLeft(element, x);
            Canvas.SetTop(element, y);
        }

        public static SolidColorBrush GetBlockColorByAtomicNumber(int atomicNumber, bool renderColors)
        {
            if (!renderColors)
            {
                return new SolidColorBrush(Colors.White);
            }

            if (atomicNumber <= 0)
            {
                return new SolidColorBrush(Colors.Gray);
            }

            if (atomicNumber == 2
                || atomicNumber >= 5 && atomicNumber <= 10
                || atomicNumber >= 13 && atomicNumber <= 18
                || atomicNumber >= 31 && atomicNumber <= 36
                || atomicNumber >= 49 && atomicNumber <= 54
                || atomicNumber >= 81 && atomicNumber <= 86
                || atomicNumber >= 113 && atomicNumber <= 118)
            {
                return new SolidColorBrush(Colors.Yellow);
            }

            if (atomicNumber >= 3 && atomicNumber <= 4
                || atomicNumber >= 11 && atomicNumber <= 12
                || atomicNumber >= 19 && atomicNumber <= 20
                || atomicNumber >= 37 && atomicNumber <= 38
                || atomicNumber >= 55 && atomicNumber <= 56
                || atomicNumber >= 87 && atomicNumber <= 88)
            {
                return new SolidColorBrush(Colors.Magenta);
            }

            if (atomicNumber == 1)
            {
                return new SolidColorBrush(Colors.White);
            }

            if (atomicNumber == 57 || atomicNumber == 89)
            {
                return new SolidColorBrush(Colors.LightGreen);
            }

            return new SolidColorBrush(Colors.Green);
        }
    }
}