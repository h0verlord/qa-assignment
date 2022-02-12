using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestHelpers;

namespace PageObjects
{
    public class ContactUsPage
    {
        private By contactFormBox = By.ClassName("contact-form-box");
        private By subjectDropDown = By.Id("id_contact");
        private By emailInput = By.Id("email");
        private By orderInput = By.Id("id_order");
        private By fileInput = By.Id("fileUpload");
        private By messageArea = By.Id("message");
        private By sendBtn = By.Id("submitMessage");
        private By alertSuccess = By.CssSelector("p.alert.alert-success");
        private By alertError = By.CssSelector("div.alert.alert-danger");

        public ContactUsPage()
        {
            Browser.Wait.Until(e => e.FindElement(contactFormBox).Displayed);
        }

        private string GetAttachmentPath()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            return path.Remove(path.LastIndexOf("bin")) + "Attachment/Attachment.pdf";
        }

        public ContactUsPage FillInFormData()
        {
            // Select heading from dropdown.
            var subject = new SelectElement(Browser.Driver.FindElement(subjectDropDown));
            subject.SelectByIndex(1);
            // Enter a valid Email Address
            Browser.Driver.FindElement(emailInput).SendKeys(Generators.GenerateEmailAddress(true));
            // Fill in order number
            Browser.Driver.FindElement(orderInput).SendKeys("123456789");
            // upload a file
            Browser.Driver.FindElement(fileInput).SendKeys(this.GetAttachmentPath());
            // Add a message
            Browser.Driver.FindElement(messageArea).SendKeys("Test Test Test 1:!!");
            return this;
        }

        public ContactUsPage SubmitForm()
        {
            Browser.Driver.FindElement(sendBtn).Click();
            return this;
        }

        public bool CheckIfSentSuccessfully(){
            return Browser.Wait.Until(e => e.FindElement(alertSuccess).Displayed);
        }

        public bool CheckIfErrorDisplayed(){
            return Browser.Wait.Until(e => e.FindElement(alertError).Displayed);
        }
    }
}