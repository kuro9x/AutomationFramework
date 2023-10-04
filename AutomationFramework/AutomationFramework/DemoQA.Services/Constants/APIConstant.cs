namespace TestScript
{
    public static class APIConstant
    {
        public static string userName = "group3";
        public static string password = "Abcd@1234";
        public static string domain = "https://demoqa.com/";
        public static string accountEndpoint = $"{domain}/Account/v1";

        public static string userEndpoint = $"{accountEndpoint}/User";

        public static string bookStoreEndpoint = $"{domain}/BookStore/v1";

        public static string bookEndpoint = $"{bookStoreEndpoint}/Book";

        public static string booksEndpoint = $"{bookStoreEndpoint}/Books";
    }
}
