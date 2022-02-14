using TestHelpers;

namespace PageObjects
{
    public class MyAccount : BasePage
    {
        public bool VerifyMyAccountIsOpened() => Browser.Driver.Title.Equals("My account - My Store");
    }
}
