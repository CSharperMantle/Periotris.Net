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

using System;

namespace Periotris.Net.Model
{
    /// <summary>
    ///     A subclass of <see cref="EventArgs" /> which is used when a <see cref="Block" /> changes, either in position or if
    ///     being shown.
    /// </summary>
    public class BlockChangedEventArgs : EventArgs
    {
        public BlockChangedEventArgs(Block blockUpdated, bool disappeared)
        {
            BlockUpdated = blockUpdated;
            Disappeared = disappeared;
        }

        public Block BlockUpdated { get; }
        public bool Disappeared { get; }
    }
}