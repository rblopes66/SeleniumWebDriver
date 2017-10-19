using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumWebDriverTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            var driver = new ChromeDriver();
                        
            driver.Url = "http://www.buscacep.correios.com.br";
            driver.Navigate();

            driver.FindElementByXPath("//*[@id='Geral']/div/div/span[2]/label/input").SendKeys("20271-130");

            var tipoCEP = driver.FindElementByXPath("//*[@id='Geral']/div/div/span[3]/label/select");
            var tipoCEPDropDown = new SelectElement(tipoCEP);
            tipoCEPDropDown.SelectByText("Localidade/Logradouro");

            driver.FindElementByXPath("//*[@id='Geral']/div/div/div[6]/input").Click();

            if (driver.FindElementByXPath("/html/body/div[1]/div[3]/div[2]/div/div/div[2]/div[2]/div[2]/table/tbody/tr[2]/td[1]").Text
                .Contains("Avenida Presidente Castelo Branco"))
            { 
                Console.WriteLine("OK");
            }
            else
            { 
                Console.WriteLine("ERRO");
            }

            driver.Quit();            
        }
    }
}
