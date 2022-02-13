using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestHelpers;

namespace PageObjects
{
    public class ContactUs
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

        public ContactUs()
        {
            Browser.Wait.Until(e => e.FindElement(contactFormBox).Displayed);
        }

        /// <summary>
        /// Gets a relative path to the attachment.pdf file located in the repository.
        /// </summary>
        /// <returns></returns>
        private string GetAttachmentPath()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            return path.Remove(path.LastIndexOf("bin")) + "Attachment/Attachment.pdf";
        }
        
        /// <summary>
        /// Fill In all form data.
        /// </summary>
        /// <returns></returns>
        public ContactUs FillInFormData()
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

        /// <summary>
        /// Clicks the Submit Form Button.
        /// </summary>
        /// <returns></returns>
        public ContactUs SubmitForm()
        {
            Browser.Driver.FindElement(sendBtn).Click();
            return this;
        }

        /// <summary>
        /// Returns true if the Success Message is displayed.
        /// </summary>
        /// <returns></returns>
        public bool CheckIfSentSuccessfully(){
            return Browser.Wait.Until(e => e.FindElement(alertSuccess).Displayed);
        }

        /// <summary>
        /// Returns true id the error message is displayed.
        /// </summary>
        /// <returns></returns>
        public bool CheckIfErrorDisplayed(){
            return Browser.Wait.Until(e => e.FindElement(alertError).Displayed);
        }
    }
}