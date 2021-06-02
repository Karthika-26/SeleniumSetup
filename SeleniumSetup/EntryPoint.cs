using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

class EntryPoint
{
    static IWebDriver driver = new ChromeDriver();
    static IWebElement textBox;
    static IWebElement checkBox;
    static IWebElement radioButton;
    static IWebElement dropDownMenu;
    static IWebElement elementFromDropDownMenu;
    static void Main()
    {
        //test1();
        //test2();
        //test3();
        //test4();
        //test5();
        //test6();
        test7();
    }
    static void test1()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://testing.todorvachev.com/selectors/name/");
        IWebElement element = driver.FindElement(By.Name("myName"));
        if (element.Displayed)
        {
            GreenMessage("I can see the element");
        }
        else
        {
            RedMessage("I can't see");
        }
        driver.Quit();
    }
    static void test2()
    {
        string url = "http://testing.todorvachev.com/selectors/class-name/";
        string className = "testClass";
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl(url);
        IWebElement element = driver.FindElement(By.ClassName(className));
        Console.WriteLine(element.Text);
        driver.Quit();
    }
    static void test3()
    {
        String url = "https://testing.todorvachev.com/selectors/css-path/";
        String cssPath = "#post-108 > div > img";
        String xPath = "//*[@id='post-108']/div/figure/img";

        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl(url);
        IWebElement cssPathelement;
        IWebElement xPathelement = driver.FindElement(By.XPath(xPath));

        try
        {
            cssPathelement = driver.FindElement(By.CssSelector(cssPath));
            if (cssPathelement.Displayed)
            {
                GreenMessage("I can see the css Path element");
            }
        }
        catch (NoSuchElementException)
        {
            RedMessage("I can't see css Path element ");
        }


        if (xPathelement.Displayed)
        {
            GreenMessage("I can see the xPath element");
        }
        else
        {
            RedMessage("I can't see x Path element ");
        }
        driver.Quit();
    }

    static void test4()
    {
        String url = "https://testing.todorvachev.com/special-elements/text-input-field/";
        driver.Navigate().GoToUrl(url);
        textBox = driver.FindElement(By.Name("username"));
        textBox.SendKeys("Karthika");
        Thread.Sleep(2000);



        Console.WriteLine(textBox.GetAttribute("maxlength"));
        Thread.Sleep(4000);

        driver.Quit();
    }
    static void test5()
    {
        string url = "https://testing.todorvachev.com/special-elements/check-button-test-3/";
        string option = "1";
        driver.Navigate().GoToUrl(url);
        checkBox = driver.FindElement(By.CssSelector($"#post-33 > div > p:nth-child(8) > input[type=checkbox]:nth-child({option})"));
        checkBox.Click();
        Thread.Sleep(4000);
        driver.Quit();

    }
    static void test6()
    {
        String url = "https://testing.todorvachev.com/special-elements/radio-button-test/";
        String[] option = { "1", " 3", "5" };
        driver.Navigate().GoToUrl(url);
        for (int i = 0; i < option.Length; i++)
        {
            radioButton = driver.FindElement(By.CssSelector($"#post-10 > div > form > p:nth-child(6) > input[type=radio]:nth-child({option[i]})"));
            if (radioButton.GetAttribute("checked") == "true")
            {
                Console.WriteLine($"The {i + 1} Radio Button is checked");
            }
            else
            {
                Console.WriteLine("Radio Button is not checked");
            }
        }
        driver.Quit();
    }
    static void test7()
    {
        String url = "https://testing.todorvachev.com/special-elements/drop-down-menu-test/";
        String dropDownMenuElements = "#post-6 > div > p:nth-child(6) > select > option:nth-child(3)";

        driver.Navigate().GoToUrl(url);

        dropDownMenu = driver.FindElement(By.Name("DropDownTest"));

        Console.WriteLine("The selected value is " +dropDownMenu.GetAttribute("value"));
        elementFromDropDownMenu = driver.FindElement(By.CssSelector(dropDownMenuElements));
        Console.WriteLine("The Third option from the drop down menu "+elementFromDropDownMenu.GetAttribute("value"));
        elementFromDropDownMenu.Click();

        Console.WriteLine("The selected value is "+ dropDownMenu.GetAttribute("value"));
        Thread.Sleep(4000);
        for( int i=1; i<=4; i++)
        {
            dropDownMenuElements = $"#post-6 > div > p:nth-child(6) > select > option:nth-child({i})";
        }
        driver.Quit();
    }


    private static void RedMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;

    }

    private static void GreenMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;

    }
}
