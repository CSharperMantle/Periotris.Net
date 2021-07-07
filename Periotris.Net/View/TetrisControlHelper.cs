/*
 * Periotris.Net
 * Copyright (C) 2020-present Rong "Mantle" Bao (CSharperMantle)
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see < https://github.com/CSharperMantle/Periotris.Net/blob/main/LICENSE >.
 */

using Periotris.Net.Common;
using Periotris.Net.Customization.Element;
using Periotris.Net.Model;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Periotris.Net.View
{
    public static class TetrisControlHelper
    {
        public static FrameworkElement AnnotatedBlockControlFactory(Block block, ColorMode colorMode, double scale)
        {
            AnnotatedBlockControl newBlockControl = new();
            int atomicNumber = block.AtomicNumber;

            newBlockControl.SetFill(GetBlockColorByAtomicNumber(atomicNumber, colorMode));
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

        public static SolidColorBrush GetBlockColorByAtomicNumber(int atomicNumber, ColorMode colorMode)
        {
            if (colorMode == ColorMode.None)
            {
                return new SolidColorBrush(Colors.White);
            }
            else if (colorMode == ColorMode.Default)
            {
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
                if (atomicNumber <= 0)
                {
                    return new SolidColorBrush(Colors.Gray);
                }
                if (atomicNumber == 57 || atomicNumber == 89)
                {
                    return new SolidColorBrush(Colors.LightGreen);
                }
                if (atomicNumber == 1)
                {
                    return new SolidColorBrush(Colors.White);
                }
                return new SolidColorBrush(Colors.Green);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(colorMode), colorMode, null);
            }
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

        public static void SetCanvasLocation(FrameworkElement element, double x, double y)
        {
            Canvas.SetLeft(element, x);
            Canvas.SetTop(element, y);
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
    }
}