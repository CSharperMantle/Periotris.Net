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
using System.IO;
using System.Windows;
using System.Windows.Resources;

namespace Periotris.Net.Common
{
    /// <summary>
    /// Helper class for data file handling.
    /// </summary>
    public static class FileIO
    {
        /// <summary>
        ///     Get a generalized <see cref="Stream"/> by file.
        /// </summary>
        /// <param name="name">The filename.</param>
        /// <param name="type">The type of the filename.</param>
        /// <returns>An opened stream.</returns>
        public static Stream OpenStreamByType(string name, PathType type)
        {
            Stream stream;

            switch (type)
            {
                case PathType.Resource:
                    {
                        stream = OpenResourceStream(name);
                        break;
                    }
                case PathType.External:
                    {
                        stream = OpenAbsoluteNamedFile(name);
                        break;
                    }
                case PathType.Data:
                    {
                        stream = OpenDataFile(name);
                        break;
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            return stream;
        }

        /// <summary>
        ///     Get a <see cref="FileStream"/> corresponding to the given path.
        /// </summary>
        /// <param name="relativeFilename">An absolute file path.</param>
        /// <returns>A <see cref="FileStream"/> opened for the file.</returns>
        /// <remarks>
        ///     All non-builtin file-related operations in Periotris.Net should be handled with this method.
        ///     Files should be closed by the invoker.
        /// </remarks>
        private static FileStream OpenAbsoluteNamedFile(string absoluteFilename)
        {
            return File.Open(absoluteFilename, FileMode.OpenOrCreate);
        }

        /// <summary>
        ///     Get a <see cref="FileStream"/> corresponding to the given file in <see cref="PeriotrisConst.PeriotrisGameDataPath"/>.
        /// </summary>
        /// <param name="relativeFilename">A filename relative to <see cref="PeriotrisConst.PeriotrisGameDataPath"/>.</param>
        /// <returns>A <see cref="FileStream"/> opened for the file.</returns>
        /// <remarks>
        ///     All non-builtin file-related operations in Periotris.Net should be handled with this method.
        ///     Files should be closed by the invoker.
        /// </remarks>
        private static FileStream OpenDataFile(string relativeFilename)
        {
            string finalPath = PeriotrisConst.PeriotrisGameDataPath + relativeFilename;
            if (!Directory.Exists(PeriotrisConst.PeriotrisGameDataPath))
            {
                _ = Directory.CreateDirectory(PeriotrisConst.PeriotrisGameDataPath);
            }

            return File.Open(finalPath, FileMode.OpenOrCreate);
        }

        /// <summary>
        ///     Get a <see cref="Stream"/> from the specified resource. See <see cref="Application.GetResourceStream(Uri)"/>.
        /// </summary>
        /// <param name="resourceName">A URI string to the resource.</param>
        /// <returns>A <see cref="Stream"/> of the opened resource.</returns>
        /// <exception cref="FileNotFoundException"/>
        /// <remarks>
        ///     Streams should be closed by the invoker.
        /// </remarks>
        private static Stream OpenResourceStream(string resourceName)
        {
            Uri uri = new(resourceName);
            StreamResourceInfo resource = Application.GetResourceStream(uri);
            if (resource == null)
            {
                throw new FileNotFoundException(null, resourceName);
            }
            return resource.Stream;
        }
    }
}