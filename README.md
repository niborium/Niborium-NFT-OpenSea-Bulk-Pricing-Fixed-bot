# Niborium NFT OpenSea Bulk Pricing (Fixed) bot

Last tested by author: 2022-05-23. Report bugs if found or proposals to improve bot.

## Instructions (Preparation)
1) Download this repository (Download as zip or git clone).
2) Edit the Program.cs file (All code is located in this file).\
 You need to set asseturl at line 9.\
 You need to set chain at line 10.\
 You need to set contract at line 11.\
 You need to set Startnumberofnft at line 12.\
 You need to set Endnumberofnft at line 13.\
 You need to set sellprice at line 14.
3) When everything above is configured correctly you can press on the sln file and open Visual Studio.
4) Run the application and the bot starts. Follow the instruction in terminal.

Note: Highly recommending to do the testing first on testnet with your collection (before mainnet). Make sure the bot is working properly.

## Instructions (Configure browser - after bot is started)
Note: This instructions will be displayed in the terminal aswell.
1) Configure your metamask extension in opened browser (import wallet, add chains (if needed).
2) Login to OpenSea with metamask you will land on target page (Make sure you see the sell button on NFTs in your target collection).
3) Close the Metatask extension tab, only tab in browser that should be open is your OpenSea tab.
4) Write confirm in this terminal to start selling all your NFTS.

## Dependencies
.NET 6.0 SDK (target framework)\
Selenium.WebDriver (4.2.0) installed Package.\
Selenium.WebDriver.ChromeDriver (102.0.5005.6102) installed Package.\
nkbihfbeogaeaoehlefnkodbefgpgknn-10.14.0-www.Crx4Chrome.com.crx (Metamask extension - in root folder).

## LICENSE (MIT)
Copyright (c) 2022 Robin Karlsson

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
