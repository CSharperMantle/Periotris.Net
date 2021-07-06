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

using System.Windows;

namespace Periotris.Net.Common
{
    /// <summary>
    ///     Enum for different file path types.
    /// </summary>
    /// A path is considered a <see cref="Resource"/> when it can be read via
    /// <see cref="Application.GetResourceStream(System.Uri)"/>, e.g.
    /// "pack://application:,,,/Assets/PeriodicTable.json".
    ///
    /// It is considered an <see cref="External"/> when it is a physical
    /// absolute path, e.g. "D:\\foo\\bar\\grok.json".
    ///
    /// It is considered <see cref="Data"/> when it is relative to
    /// <see cref="PeriotrisConst.PeriotrisGameDataPath"/>, e.g. "history.json".
    public enum PathType
    {
        Resource,
        External,
        Data
    }
}