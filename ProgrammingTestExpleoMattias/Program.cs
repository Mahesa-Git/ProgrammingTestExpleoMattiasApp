using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ProgrammingTestExpleoMattias
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 3; i++)
            {
                Console.Write($"Level {i} calculator\nEnter your mathematical expression: ");
                double returnValue = default;
                switch (i)
                {
                    case 1:
                        returnValue = Calculator.LevelOne(Console.ReadLine().Trim());
                        break;
                    case 2:
                        returnValue = Calculator.LevelTwo(Console.ReadLine().Trim());
                        break;
                    case 3:
                        returnValue = Calculator.LevelThree(Console.ReadLine().Trim());
                        break;
                }
                Console.WriteLine($"The answer is: {returnValue}\n");
            }
            Console.WriteLine("Press any key to launch Chrome and search https://google.com for links on the startpage of the site");
            Console.ReadKey(true);

            //Problem 2, Using Selenium
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://google.com");
            Console.Clear();
            var pageSourceElements = driver.FindElements(By.TagName("a"));
            
            Console.WriteLine("Links on selected website:\n");

            foreach (var link in pageSourceElements)
            {
                Console.WriteLine(link.GetAttribute("href"));
            }
            driver.Close();
            driver.Quit();
        }
    }
}
