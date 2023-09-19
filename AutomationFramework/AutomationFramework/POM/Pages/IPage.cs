namespace ProjectCore.POM.Pages
{
    public interface IPage
    {
        void Open(string url);
        void GoBack();
        void ConfirmAlert();
        void CloseAdvertisement();
    }
}
