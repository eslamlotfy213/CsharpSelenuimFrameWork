using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Csharp_Selenium_WebDriver_Project
{
    class JasonReader
    {


        public string extractDate(String tokenName)
        {
            String myJasonString = File.ReadAllText("Utlites/TestData.json");
            var JasonObject = JToken.Parse(myJasonString);
            return JasonObject.SelectToken(tokenName).Value<string>();
        }



        public string[] extractDateArray(String tokenName)
        {
            String myJasonString = File.ReadAllText("Utlites/TestData.json");
            var JasonObject = JToken.Parse(myJasonString);
            List<String> Productlist = JasonObject.SelectTokens(tokenName).Values<string>().ToList();
            return Productlist.ToArray();
        }


        public int[] extractDateArrayInteger(String tokenName)
        {
            String myJasonString = File.ReadAllText("Utlites/TestData.json");
            var JasonObject = JToken.Parse(myJasonString);
            List<int> Productlist = JasonObject.SelectTokens(tokenName).Values<int>().ToList();
            return Productlist.ToArray();
        }

    }

}
