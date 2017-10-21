using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumWebDriverTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instancia um objeto do tipo driver que é utilizado para interagir com navegador
            // Nesse caso iremos utilizar o Google Chrome para executar nossas ações
            var driver = new ChromeDriver();

            // Define qual URL será chamada e o método .Navigate é responsável por abrir a URL
            driver.Url = "http://www.buscacep.correios.com.br";
            driver.Navigate();

            // Utiliza XPath para reconhecer o campo "Endereço ou CEP" da tela
            // O comando SendKeys é responsável por digitar o valor 20271-130 nesse campo
            driver.FindElementByXPath("//*[@id='Geral']/div/div/span[2]/label/input").SendKeys("20271-130");

            // Utiliza XPath para reconhecer o campo "CEP de:"
            var tipoCEP = driver.FindElementByXPath("//*[@id='Geral']/div/div/span[3]/label/select");

            // Instancia um objeto da classe SelectElement que é utilizado para interagir com um campo do tipo DropDownList
            var tipoCEPDropDown = new SelectElement(tipoCEP);

            // Seleciona o valor "Localidade/Logradouro" no campo "CEP de:"
            tipoCEPDropDown.SelectByText("Localidade/Logradouro");

            // Executa o método Click() para clicar no botão Buscar
            driver.FindElementByXPath("//*[@id='Geral']/div/div/div[6]/input").Click();

            // Nessa parte verificamos o resultado de nosso teste
            // Para isso, identificamos via XPath o valor da coluna "Logradouro/Nome" na página de resultados
            // E comparamos o resultado com nosso valor esperado, ou seja, "Avenina Presidente Castelo Branco"
            if (driver.FindElementByXPath("/html/body/div[1]/div[3]/div[2]/div/div/div[2]/div[2]/div[2]/table/tbody/tr[2]/td[1]").Text
                .Contains("Avenida Presidente Castelo Branco"))
            {
                // Caso o resultado seja verificado imprime no console o valor "OK"
                Console.WriteLine("OK");
            }
            else
            {
                // Caso o resultado seja diferente do valor esperado imprime no console o valor "ERRO"
                Console.WriteLine("ERRO");
            }

            // Fecha o navegador e executa o Disponse() do objeto driver
            driver.Quit();
        }
    }
}
