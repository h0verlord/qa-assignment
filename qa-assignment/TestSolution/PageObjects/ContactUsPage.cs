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

        public ContactUsPage()
        {
            Browser.Wait.Until(e => e.FindElement(contactFormBox).Displayed);
        }

        private string GetAttachmentPath()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            return path.Remove(path.LastIndexOf("bin")) + "Attachment/Attachment.pdf";
        }

        private ContactUsPage FillInFormData()
        {
            // Select heading from dropdown.
            var subject = new SelectElement(Browser.Driver.FindElement(subjectDropDown));
            subject.SelectByIndex(1);
            return this;
        }
    }
}