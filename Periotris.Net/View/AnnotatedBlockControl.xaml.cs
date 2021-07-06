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
        ///     Set the element to display on this <see cref="AnnotatedBlockControl" />.
        /// </summary>
        /// <param name="info">The <see cref="ElementInfo" /> to set.</param>
        public void SetElement(ElementInfo info)
        {
            Element = info;
            ElementNameTextBlock.Text = info.Symbol;
        }

        /// <summary>
        ///     Set the background color.
        /// </summary>
        /// <param name="brush">The color brush.</param>
        public void SetFill(Brush brush)
        {
            Background = brush;
        }
    }
}