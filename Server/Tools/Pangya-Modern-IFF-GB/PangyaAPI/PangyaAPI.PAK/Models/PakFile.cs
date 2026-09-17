using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PangyaAPI.PAK.Models
{
    public class PakFileEx: PakFile
    {public int Index { get; set; }
        /// <summary>
        /// pasta raiz
        /// </summary>
        public string FolderSource { get; set; } = "";
        /// <summary>
        /// pasta sub
        /// </summary>
        public string FolderSub { get; set; } = "";
        /// <summary>
        /// é folder?
        /// </summary>
        public bool IsFolder { get; set; } = false;
        /// <summary>
        /// verifica se tem arquivo nas pastas
        /// </summary>
        public bool IsFile { get; set; } = false;
        /// <summary>
        /// é subfolder?
        /// </summary>
        public bool IsSubFolder { get; set; } = false;

        public bool IsOthersFolder { get; set; }
        /// <summary>
        /// nome do arquivo + local
        /// </summary>
        public string PathFull { get; set; }
    }
    /// <summary>
    /// Main structure of file entries
    /// </summary>
    public class PakFile : IEquatable<PakFile>
    {
        /// <summary>
        /// Length of the file name
        /// </summary>
        public byte FileNameLength { get; set; }

        /// <summary>
        /// Compression flag determining if the file is compressed, or a directory
        /// </summary>
        public byte Compression { get; set; }

        /// <summary>
        /// Offset of the file data from the beginning of the archive
        /// </summary>
        public uint Offset { get; set; }

        /// <summary>
        /// (Compressed) size of the file
        /// </summary>
        public uint FileSize { get; set; }

        /// <summary>
        /// Real size of the file
        /// </summary>
        public uint RealFileSize { get; set; }

        /// <summary>
        /// Full path and name of the file
        /// </summary>
        public string FileName { get; set; }

        public bool Equals(PakFile other)
        {
            return FileNameLength == other.FileNameLength && Compression == other.Compression &&
                   Offset == other.Offset && FileSize == other.FileSize && RealFileSize == other.RealFileSize &&
                   string.Equals(FileName, other.FileName);
        }
    }
}
