using OpenQA.Selenium;
using ProjectCore.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCore.WebElement
{
    public class Element
    {
        protected By locator;
        protected float timeout = 30;
        
        public Element(By locator, float timeOutSecond)
        {
            this.locator = locator;
            timeout = timeOutSecond;
        }

        public Element SetTimeOut(float timeOutSecond)
        {
            this.timeout = timeOutSecond;
            return this;
        }

        public By GetLocator() { return this.locator; }

        public void Click()
        {
            //DriverManager.GetCurrentDriver()
        }
    }
}
