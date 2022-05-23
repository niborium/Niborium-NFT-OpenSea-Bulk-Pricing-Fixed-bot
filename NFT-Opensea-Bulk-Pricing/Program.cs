using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

class OpenSeaBulkFixedPricer
{
    static void Main(string[] args)
    {
        //Your profile:
        string asseturl = "https://opensea.io/assets"; //You can change to testnet (https://testnets.opensea.io/assets) or mainnet (https://opensea.io/assets).
        string chain = "matic"; //Specify your chain
        string contract = "0x000000000000000000000000000000000000000";  //Specify your contract address
        const int Startnumberofnft = 1;
        const int Endnumberofnft = 10000;
        const string sellprice = "0.006"; //Specify your sell price
        // End of profile.

        var option = new ChromeOptions();
        option.AddArgument("start-maximized");
        option.PageLoadStrategy = PageLoadStrategy.None;

        option.AddExtension(@"..\..\..\..\NFT-Opensea-Bulk-Pricing\nkbihfbeogaeaoehlefnkodbefgpgknn-10.14.0-www.Crx4Chrome.com.crx");
        option.Proxy = null;
        IWebDriver driver = new ChromeDriver(option);
        driver.Navigate().GoToUrl($"{asseturl}/{chain}//{contract}/{Startnumberofnft}/sell");
        Console.Clear();
        Console.WriteLine("1. Configure your metamask extension in opened browser (import wallet, add chains (if needed)");
        Console.WriteLine("2. Login to OpenSea with metamask you will land on target page (Make sure you see the sell button on NFTs in your target collection.");
        Console.WriteLine("3. Close the Metatask extension tab, only tab in browser that should be open is your OpenSea tab.");
        Console.WriteLine("4. Write confirm in this terminal below to start selling all your NFTS.");
        string? confirmedConfig = Console.ReadLine();

        while (confirmedConfig != "confirm")
        {
            Console.WriteLine("Please write confirm to continue.");
            confirmedConfig = Console.ReadLine();
        }
        int condition = Endnumberofnft + 1;
        for (int i = Startnumberofnft; i < condition; i++)
        {
            Console.WriteLine($"NFT {i} creation started");
            driver.Navigate().GoToUrl($"{asseturl}/{chain}//{contract}/{i}/sell");
        Setsellprice:
            Thread.Sleep(8000);
            try
            {
                driver.FindElement(By.Name("price")).SendKeys($"{sellprice}");
                //Relay request error
                if (driver.FindElement(By.CssSelector("div[class='Blockreact__Block-sc-1xf18x6-0 Flexreact__Flex-sc-1twd32i-0 jffCaG jYqxGr']")).Enabled)
                {
                    Console.WriteLine($"NFT {i} relay request error - NFT seems to be already listed for selling.");
                    continue;
                }
            }
            catch (NoSuchElementException)
            {
                //Cancel listing button exists (NFT is already listed by you)
                if (driver.FindElement(By.CssSelector("button[class='Blockreact__Block-sc-1xf18x6-0 Buttonreact__StyledButton-sc-glfma3-0 ggOswT fzwDgL OrderManager--second-button']")).Enabled)
                {
                    Console.WriteLine($"NFT {i} already listed for selling by you.");
                    continue;
                }
                //Make offer button exists (NFT owned and listed by another seller)
                if (driver.FindElement(By.CssSelector("button[class='Blockreact__Block-sc-1xf18x6-0 Buttonreact__StyledButton-sc-glfma3-0 dpXlkZ gIDfxn']")).Enabled)
                {
                    Console.WriteLine($"NFT {i} owned and listed by another seller.");
                    continue;
                }
                //Ring-bearer error
                Console.WriteLine($"NFT {i} failed sendkeys but tried repairing");
                driver.Navigate().Refresh();
                goto Setsellprice;
            }
            Thread.Sleep(4000);
            try
            {
                driver.FindElement(By.CssSelector("button[type=submit]")).Click();
                Thread.Sleep(6000);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine($"NFT {i} - failed to find submit button. Unusual error. Trying to repair.");
                driver.Navigate().Refresh();
                goto Setsellprice;
            }
            try
            {
                driver.FindElement(By.CssSelector("button[class='Blockreact__Block-sc-1xf18x6-0 Buttonreact__StyledButton-sc-glfma3-0 kXZare fzwDgL']")).Click();
                Thread.Sleep(8000);
            }
            catch (NoSuchElementException)
            {
                //Not loading correctly
                Console.WriteLine($"NFT {i} failed sendkeys but to find Blockreact - tried repairing. Cause: Probably slow page loading speed. Trying to repair.");
                driver.Navigate().Refresh();
                goto Setsellprice;
            }
            //Switching to metamask extension.
            driver.SwitchTo().Window(driver.WindowHandles.ToList().Last());

            try
            {
                Thread.Sleep(6000);
                //Scroll to bottom of page (signature message)
                driver.FindElement(By.CssSelector("div[class='signature-request-message__scroll-button']")).Click();
            }
            catch(NoSuchElementException)
            {
                Console.WriteLine($"NFT {i} failed to scroll signature button in metamask (popup) - Something seem wrong with extension. Restart the bot and try again. If problem persist report it to author of bot for bug correction.");
                Console.ReadLine();
            }
            try
            {
                Thread.Sleep(2000);
                driver.FindElement(By.CssSelector("button[class='button btn--rounded btn-primary btn--large']")).Click();
                Thread.Sleep(3000);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine($"NFT {i} failed to click on sign button in metamask (popup) - Something seem wrong with extension. Restart the bot and try again. If problem persist report it to author of bot for bug correction.");
                Console.ReadLine();
            }
            //Switching context from metamask extension to main page.
            driver.SwitchTo().Window(driver.WindowHandles.ToList().Last());
            Console.WriteLine($"NFT {i} is now listed for sell price {sellprice}");
            Thread.Sleep(1000);
        }
    }
}