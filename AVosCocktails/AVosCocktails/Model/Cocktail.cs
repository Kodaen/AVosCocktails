using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AVosCocktails.Model
{
    public class Cocktail : ContentView
    {
        public class CocktailTest
        {
            public string name { get; set;}
            public string description { get; set;}
            public string[] ingredients { get; set;}
        }
    }
}