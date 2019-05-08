using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ColorMemoryTraining.Utils;

namespace ColorMemoryTraining.Business.MemoryPicturesData
{
    public class MemoryPictureManager
    {
        /// <summary>
        /// 冲突
        /// </summary>
        /// <returns></returns>
        public static List<ColorPictureInfo> GetConflictedPictures()
        {
            var list = new List<ColorPictureInfo>();
            var baseDirectory = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            var memoryPicturesFolder = Path.Combine(baseDirectory, @"Resources\MemoryPictures\冲突");
            if (Directory.Exists(memoryPicturesFolder))
            {
                var allFiles = FolderUtil.GetAllFiles(memoryPicturesFolder);
                list.AddRange(allFiles.Select(i => GetPictureInfo(i)));
            }

            if (list.Count < 1)
            {
                throw new InvalidOperationException($"图片配置数量小于{0}张！");
            }
            return list;
        }
        /// <summary>
        /// 干扰
        /// </summary>
        /// <returns></returns>
        public static List<ColorPictureInfo> GetInterferedPictures()
        {
            var list = new List<ColorPictureInfo>();
            var baseDirectory = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            var memoryPicturesFolder = Path.Combine(baseDirectory, @"Resources\MemoryPictures\干扰");
            if (Directory.Exists(memoryPicturesFolder))
            {
                var allFiles = FolderUtil.GetAllFiles(memoryPicturesFolder);
                list.AddRange(allFiles.Select(i => GetPictureInfo(i)));
            }

            if (list.Count < 24)
            {
                throw new InvalidOperationException($"图片配置数量小于{24}张！");
            }
            return list;
        }
        /// <summary>
        /// 一致
        /// </summary>
        /// <returns></returns>
        public static List<ColorPictureInfo> GetConsistentPictures()
        {
            var list = new List<ColorPictureInfo>();
            var baseDirectory = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            var memoryPicturesFolder = Path.Combine(baseDirectory, @"Resources\MemoryPictures\一致");
            if (Directory.Exists(memoryPicturesFolder))
            {
                var allFiles = FolderUtil.GetAllFiles(memoryPicturesFolder);
                list.AddRange(allFiles.Select(i=> GetPictureInfo(i)));
            }

            if (list.Count<1)
            {
                throw new InvalidOperationException($"图片配置数量小于{0}张！");
            }
            return list;
        }

        private static ColorPictureInfo GetPictureInfo(string filePath)
        {
            var fileName = Path.GetFileNameWithoutExtension(filePath);
            if (string.IsNullOrWhiteSpace(fileName)|| fileName.Length<2)
            {
                return null;
            }

            var colorPictureInfo = new ColorPictureInfo();
            colorPictureInfo.Color = fileName.Substring(0, fileName.Length - 1);
            colorPictureInfo.Hanzi = fileName.Substring(fileName.Length - 1);
            colorPictureInfo.FilePath = filePath;
            return colorPictureInfo;
        }
    }

    public class ColorPictureInfo
    {
        public string Hanzi { get; set; }
        public string Color { get; set; }
        public string FilePath { get; set; }
    }
}
