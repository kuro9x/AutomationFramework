using Microsoft.Extensions.Configuration;
using ProjectCore.Configurations;
using UnsplashTest.Models;

namespace UnsplashTest.DataStorage
{
    public static class DataStorage
    {
        private static AsyncLocal<List<AccountModel>> _accountStorages = new AsyncLocal<List<AccountModel>>();
        private static AsyncLocal<List<PhotoModel>> _photos = new AsyncLocal<List<PhotoModel>>();
        private static AsyncLocal<List<CollectionModel>> _collections = new AsyncLocal<List<CollectionModel>>();

        public static void InitDataStorage()
        {
            _accountStorages.Value = new List<AccountModel>();
            _photos.Value = new List<PhotoModel>();
            _collections.Value = new List<CollectionModel>();
        }

        public static List<AccountModel> GetAccounts()
        {
            return _accountStorages.Value;
        }

        public static List<PhotoModel> GetPhotos()
        {
            return _photos.Value;
        }

        public static List<CollectionModel> GetCollections()
        {
            return _collections.Value;
        }

        public static void ProcessAddAccountData(List<AccountModel> accounts)
        {
            if (accounts == null) return;

            foreach (var account in accounts)
            {
                _accountStorages.Value.Add(account);
            }
        }

        public static void ProcessAddPhotoData(List<PhotoModel> photos)
        {
            if (photos == null) return;

            foreach (var photo in photos)
            {
                _photos.Value.Add(photo);
            }
        }

        public static void ProcessAddCollectionData(List<CollectionModel> collections)
        {
            if (collections == null) return;

            foreach (var collection in collections)
            {
                _collections.Value.Add(collection);
            }
        }

        public static AccountModel GetAccountInfo(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return null;
            }

            return _accountStorages.Value.Find(x => x.Key.Equals(key));
        }

        public static void ClearAllData()
        {
            if (_accountStorages.Value is not null)
            {
                _accountStorages.Value.Clear();
            }

            if (_photos.Value is not null)
            {
                _photos.Value.Clear();
            }

            if (_collections.Value is not null)
            {
                _collections.Value.Clear();
            }
        }

        public static void ClearDataByType(string type)
        {
            switch (type)
            {
                case "Account":
                    if (_accountStorages.Value is not null)
                    {
                        _accountStorages.Value.Clear();
                    }
                    break;
                case "Photo":
                    if (_photos.Value is not null)
                    {
                        _photos.Value.Clear();
                    }
                    break;
                case "Collection":
                    if (_collections.Value is not null)
                    {
                        _collections.Value.Clear();
                    }
                    break;
                default:
                    break;
            }
            
        }

        public static List<AccountModel> GetListAccountTestConfig()
        {
            var testUsers = Application.GetConfig().GetSection("TestUsers")
                           .GetChildren()
                           .ToList()
                           .Select(x => new AccountModel
                           {
                               Key = x.GetValue<string>("Key"),
                               UserName = x.GetValue<string>("UserName"),
                               Email = x.GetValue<string>("Email"),
                               Password = x.GetValue<string>("Password"),
                               AccessToken = x.GetValue<string>("AccessToken")
                           });

            return testUsers.ToList();
        }

        public static List<PhotoModel> GetListPhotoTestConfig()
        {
            var photos = Application.GetConfig().GetSection("PhotosTest")
                           .GetChildren()
                           .ToList()
                           .Select(x => new PhotoModel
                           {
                               Id = x.GetValue<string>("Id"),
                               Slug = x.GetValue<string>("Slug")
                           });

            return photos.ToList();
        }

        public static List<CollectionModel> GetListCollectionTestConfig()
        {
            var collections = Application.GetConfig().GetSection("CollectionsTest")
                           .GetChildren()
                           .ToList()
                           .Select(x => new CollectionModel
                           {
                               Id = x.GetValue<string>("Id"),
                               Title = x.GetValue<string>("Title"),
                               Description = x.GetValue<string>("Description"),
                               Private = x.GetValue<bool>("Private")
                           });

            return collections.ToList();
        }
    }
}
