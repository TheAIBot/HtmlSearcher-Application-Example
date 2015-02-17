using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlSearcher;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Super_Memo_Card_Generator
{
    static class TestsInHere
    {
        public static void Test()
        {
            TextToFindInfo T1 = new TextToFindInfo();
            T1.TextAmountToFind = TextAmount.Multiple;
            T1.TextsToFind = new List<string>() 
            {
                "Exploiting fish stocks at a lower rate of fishing will make stocks more robust to ecological changes.",
                "Pour the sauce from cooking the fish in the pan and cook the rice, adding stock whenever necessary. "
            };

            TextToFindInfo T2 = new TextToFindInfo();
            T2.TextAmountToFind = TextAmount.Multiple;
            T2.TextsToFind = new List<string>() 
            {
                "Su explotación con tasas de captura más bajas permitirá a las poblaciones de peces resistir mejor los cambios ecológicos.",
                "Poner la salsa de la cocción en la cacerola y cocer el arroz, añadiendo caldo cuando sea necesario. ",
                "Es el pez más grande que existe, que puede llegar hasta 12 metros de largo."
            };

            GroupToFind TextGroup = new GroupToFind();
            TextGroup.TextsToFind.Add(T1);
            TextGroup.TextsToFind.Add(T2);

            ScrapInfo FInfo = new ScrapInfo();
            FInfo.WebAddresses.Add("http://www.linguee.com/english-spanish/search?source=auto&query=fish");
            FInfo.WebToAnalyze = "http://www.linguee.com/english-spanish/search?source=auto&query=fish";

            Stopwatch Watch = new Stopwatch();
            Watch.Start();
            Search.FindText(FInfo);
            Watch.Stop();
        }
    }
}
