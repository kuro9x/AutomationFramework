using ProjectCore.Drivers;
using ProjectCore.WebElement;
using UnsplashTest.Constant;
using UnsplashTest.Pages;

namespace UnsplashTest.UI.Pages
{
    public class LikesPage: HomePage
    {
        public bool VerifyUnlikeProcess(List<string> photoNames)
        {
            try
            {
                DriverManager.GetCurrentDriver().Refresh();
                
                foreach(var photoName in photoNames)
                {
                    var isVisible = ElementByPhotoName(photoName).IsElementVisible();

                    if (isVisible)
                    {
                        return false;
                    }
                }

                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public void ProcessUnlikePhotos(List<string> likedPhotos)
        {
            foreach (var photoName in likedPhotos)
            {
                ElementByPhotoName(photoName).Click();
                ElementPhotoActionButton(ActionButton.Like).Click();

                if (buttonInDialog.IsElementVisible())
                {
                    CloseDialogPhoto();
                }
            }
        }
    }
}
