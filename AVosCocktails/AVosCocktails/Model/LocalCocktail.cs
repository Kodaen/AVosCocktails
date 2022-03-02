using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AVosCocktails.Model
{
    public class LocalCocktail
    {
            public int Id { get; set; }
            public string Name { get; set;}
            public string Instructions { get; set;}
            public Dictionary<string, string> Ingredients { get; set;}
            public string Image { get; set; }


    }
}