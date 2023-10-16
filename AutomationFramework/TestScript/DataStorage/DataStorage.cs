using UnsplashTest.Models;

namespace UnsplashTest.DataStorage
{
    public class DataStorage
    {
        private static AsyncLocal<Dictionary<string, AccountModel>> _accountStorage = new AsyncLocal<Dictionary<string, AccountModel>>();


        public static void AddAccountData(string key, AccountModel accountModel)
        {
            _accountStorage.Value = new Dictionary<string, AccountModel>
            {
                { key, accountModel }
            };
        }

        public static AccountModel GetAccountInfo(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return null;
            }

            return _accountStorage.Value.GetValueOrDefault(key);
        }

        public static void ClearAccountData()
        {
            if (_accountStorage.Value is not null)
            {
                _accountStorage.Value.Clear();
            }
        }
    }
}
