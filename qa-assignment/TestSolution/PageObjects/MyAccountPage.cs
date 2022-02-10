using TestHelpers;

namespace PageObjects
{
    public class MyAccountPage
    {
        public bool VerifyMyAccountIsOpened() => Browser.Driver.Title.Equals("My account - My Store");
    }
}
