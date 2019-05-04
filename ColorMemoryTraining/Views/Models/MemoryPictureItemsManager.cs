using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PictureMemoryTraining.Business.MemoryPicturesData;
using PictureMemoryTraining.Utils;

namespace PictureMemoryTraining.Views.Models
{
    public static class MemoryPictureItemsManager
    {
        private static List<MemoryPictureItem> _learning1MemoryPictures = null;
        public static List<MemoryPictureItem> GetLearning1MemoryPictures()
        {
            var memoryPictureItems = _learning1MemoryPictures ?? (_learning1MemoryPictures = GetFamiliarMemoryPictures());
            return memoryPictureItems;
        }
        private static List<MemoryPictureItem> _learning2MemoryPictures = null;
        public static List<MemoryPictureItem> GetLearning2MemoryPictures()
        {
            var memoryPictureItems = _learning2MemoryPictures ?? (_learning2MemoryPictures = GetFamiliarMemoryPictures());
            return memoryPictureItems;
        }
        private static List<MemoryPictureItem> GetFamiliarMemoryPictures()
        {
            var allFamiliarMemoryPictures = new List<MemoryPictureItem>();

            var conflictedPictures = MemoryPictureManager.GetConflictedPictures();
            var interferedPictures = MemoryPictureManager.GetInterferedPictures();
            var consistentPicctures = MemoryPictureManager.GetConsistentPictures();

            allFamiliarMemoryPictures.AddRange(conflictedPictures.RandomSort().Take(2).Select(j => new MemoryPictureItem()
            {
                ImageUri = j.FilePath
            }));
            allFamiliarMemoryPictures.AddRange(interferedPictures.RandomSort().Take(2).Select(j => new MemoryPictureItem()
            {
                ImageUri = j.FilePath
            }));
            allFamiliarMemoryPictures.AddRange(consistentPicctures.RandomSort().Take(2).Select(j => new MemoryPictureItem()
            {
                ImageUri = j.FilePath
            }));

            return allFamiliarMemoryPictures;
        }

        private static List<MemoryPictureItem> _test1MemoryPictures = null;
        public static List<MemoryPictureItem> GetTest1MemoryPictures()
        {
            var memoryPictureItems = _test1MemoryPictures ?? (_test1MemoryPictures = GetMemoryPictures()[0]);
            return memoryPictureItems;
        }
        private static List<MemoryPictureItem> _test2MemoryPictures = null;
        public static List<MemoryPictureItem> GetTest2MemoryPictures()
        {
            var memoryPictureItems = _test2MemoryPictures ?? (_test2MemoryPictures = GetMemoryPictures()[1]);
            return memoryPictureItems;
        }

        private static List<MemoryPictureItem> _test3MemoryPictures = null;
        public static List<MemoryPictureItem> GetTest3MemoryPictures()
        {
            var memoryPictureItems = _test3MemoryPictures ?? (_test3MemoryPictures = GetMemoryPictures()[2]);
            return memoryPictureItems;
        }
        private static List<MemoryPictureItem> _test4MemoryPictures = null;
        public static List<MemoryPictureItem> GetTest4MemoryPictures()
        {
            var memoryPictureItems = _test4MemoryPictures ?? (_test4MemoryPictures = GetMemoryPictures()[3]);
            return memoryPictureItems;
        }
        private static List<MemoryPictureItem> _test5MemoryPictures = null;
        public static List<MemoryPictureItem> GetTest5MemoryPictures()
        {
            var memoryPictureItems = _test5MemoryPictures ?? (_test5MemoryPictures = GetMemoryPictures()[4]);
            return memoryPictureItems;
        }

        private static List<MemoryPictureItem> _test6MemoryPictures = null;
        public static List<MemoryPictureItem> GetTest6MemoryPictures()
        {
            var memoryPictureItems = _test6MemoryPictures ?? (_test6MemoryPictures = GetMemoryPictures()[5]);
            return memoryPictureItems;
        }

        private static List<List<MemoryPictureItem>> _allMemoryPictures = null;
        private static List<List<MemoryPictureItem>> GetMemoryPictures()
        {
            if (_allMemoryPictures == null)
            {
                _allMemoryPictures = new List<List<MemoryPictureItem>>()
                {
                    new List<MemoryPictureItem>(),
                    new List<MemoryPictureItem>(),
                    new List<MemoryPictureItem>(),
                    new List<MemoryPictureItem>(),
                    new List<MemoryPictureItem>(),
                    new List<MemoryPictureItem>(),
                };
                //conflictedPictures
                var typePictures = MemoryPictureManager.GetConflictedPictures();
                var typePicturesByColor = typePictures.Where(i => i.Color == "Black").Select(j => new MemoryPictureItem() { ImageUri = j.FilePath }).ToList();
                for (int i = 0; i < 6; i++)
                {
                    _allMemoryPictures[i].Add(typePicturesByColor.RandomSort()[0]);
                }
                typePicturesByColor = typePictures.Where(i => i.Color == "Blue").Select(j => new MemoryPictureItem() { ImageUri = j.FilePath }).ToList();
                for (int i = 0; i < 6; i++)
                {
                    _allMemoryPictures[i].Add(typePicturesByColor.RandomSort()[0]);
                }
                typePicturesByColor = typePictures.Where(i => i.Color == "Green").Select(j => new MemoryPictureItem() { ImageUri = j.FilePath }).ToList();
                for (int i = 0; i < 6; i++)
                {
                    _allMemoryPictures[i].Add(typePicturesByColor.RandomSort()[0]);
                }
                typePicturesByColor = typePictures.Where(i => i.Color == "Red").Select(j => new MemoryPictureItem() { ImageUri = j.FilePath }).ToList();
                for (int i = 0; i < 6; i++)
                {
                    _allMemoryPictures[i].Add(typePicturesByColor.RandomSort()[0]);
                }

                //interferedPictures
                typePictures = MemoryPictureManager.GetInterferedPictures();
                typePicturesByColor = typePictures.Where(i => i.Color == "Black").Select(j => new MemoryPictureItem() { ImageUri = j.FilePath }).ToList();
                for (int i = 0; i < 6; i++)
                {
                    _allMemoryPictures[i].Add(typePicturesByColor[i]);
                }
                typePicturesByColor = typePictures.Where(i => i.Color == "Blue").Select(j => new MemoryPictureItem() { ImageUri = j.FilePath }).ToList();
                for (int i = 0; i < 6; i++)
                {
                    _allMemoryPictures[i].Add(typePicturesByColor[i]);
                }
                typePicturesByColor = typePictures.Where(i => i.Color == "Green").Select(j => new MemoryPictureItem() { ImageUri = j.FilePath }).ToList();
                for (int i = 0; i < 6; i++)
                {
                    _allMemoryPictures[i].Add(typePicturesByColor[i]);
                }
                typePicturesByColor = typePictures.Where(i => i.Color == "Red").Select(j => new MemoryPictureItem() { ImageUri = j.FilePath }).ToList();
                for (int i = 0; i < 6; i++)
                {
                    _allMemoryPictures[i].Add(typePicturesByColor[i]);
                }

                //consistentPicctures
                var consistentPicctures = MemoryPictureManager.GetConsistentPictures().Select(j => new MemoryPictureItem() { ImageUri = j.FilePath }).ToList();
                for (int i = 0; i < 6; i++)
                {
                    _allMemoryPictures[i].AddRange(consistentPicctures.RandomSort().ToList());
                }
            }

            return _allMemoryPictures;
        }
    }
}
