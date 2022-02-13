using TestHelpers;

namespace PageObjects
{
    public class MyAccount
    {
        public bool VerifyMyAccountIsOpened() => Browser.Driver.Title.Equals("My account - My Store");
    }
}
