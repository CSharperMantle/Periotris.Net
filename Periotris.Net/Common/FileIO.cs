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
        /// Get a <see cref="FileStream"/> corresponding to the given file in <see cref="PeriotrisConst.PeriotrisGameDataPath"/>.
        /// </summary>
        /// <param name="relativeFilename">A filename relative to <see cref="PeriotrisConst.PeriotrisGameDataPath"/>.</param>
        /// <returns>A <see cref="FileStream"/> opened for the file.</returns>
        /// <remarks>
        /// All non-builtin file-related operations in Periotris.Net should be handled with this method.
        /// Files should be closed by the invoker.
        /// </remarks>
        public static FileStream OpenDataFile(string relativeFilename)
        {
            string finalPath = PeriotrisConst.PeriotrisGameDataPath + relativeFilename;
            if (!Directory.Exists(PeriotrisConst.PeriotrisGameDataPath))
            {
                Directory.CreateDirectory(PeriotrisConst.PeriotrisGameDataPath);
            }

            return File.Open(finalPath, FileMode.OpenOrCreate);
        }

        /// <summary>
        /// Get a <see cref="Stream"/> from the specified resource. See <see cref="Application.GetResourceStream(Uri)"/>.
        /// </summary>
        /// <param name="resourceName">A URI string to the resource.</param>
        /// <returns>A <see cref="Stream"/> of the opened resource.</returns>
        /// <remarks>
        /// Streams should be closed by the invoker.
        /// </remarks>
        public static Stream OpenResourceStream(string resourceName)
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
