using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation_TrainingM10B.Base_Files;
using OpenQA.Selenium;

namespace Automation_TrainingM10B.Page_Objects
{
    class LinkedIn_LoginPageModel : BaseTest
    {
        /*DRIVER REFERENCE*/
        private static IWebDriver _objDriver;

        public LinkedIn_LoginPageModel(IWebDriver objDriver)
        {
            _objDriver = objDriver;
        }

        /*ELEMENT LOCATORS*/
        private static readonly string STR_USERNAME_TEXTFIELD_Id = "username";
        private static readonly string STR_PASSWORD_TEXTFIELD_Id = "password";
        private static readonly string STR_LOGIN_BUTTON_XPath = "//*[text()='Iniciar sesión' or text()='Sign in']";

        /*PAGE ELEMENT OBJECTS*/
        private static IWebElement objUsernameText => _objDriver.FindElement(By.Id(STR_USERNAME_TEXTFIELD_Id));
        private static IWebElement objPasswordText => _objDriver.FindElement(By.Id(STR_PASSWORD_TEXTFIELD_Id));
        private static IWebElement objLoginButton => _objDriver.FindElement(By.XPath(STR_LOGIN_BUTTON_XPath));

        /*GET ELEMENT METHODS*/
        public IWebElement GetUsernameField()
        {
            return objUsernameText;
        }
        public IWebElement GetPasswordField()
        {
            return objPasswordText;
        }
        public IWebElement GetLoginButton()
        {
            return objLoginButton;
        }

        /*PAGE ELEMENT ACTIONS*/
        public void fnEnterUsername(string pstrUsername)
        {
            objUsernameText.Clear();
            objUsernameText.SendKeys(pstrUsername);
        }

        public void fnEnterPassword(string pstrPassword)
        {
            objPasswordText.Clear();
            objPasswordText.SendKeys(pstrPassword);
        }

        public void fnClickSignInButton()
        {
            objLoginButton.Click();
        }
    }
}
