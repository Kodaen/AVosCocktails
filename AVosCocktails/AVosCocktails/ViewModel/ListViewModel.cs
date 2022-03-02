using AVosCocktails.Model;
using CocktailDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using static AVosCocktails.Model.LocalCocktail;

namespace AVosCocktails.ViewModel
{
    class ListViewModel : BaseViewModel
    {
        private static ListViewModel _instance = new ListViewModel();

        public static ListViewModel Instance
        {
            get { return _instance; }
        }

        public ObservableCollection<LocalCocktail> ListeDeCocktail
        {
            get => GetValue<ObservableCollection<LocalCocktail>>();
            set => SetValue(value);
        }


        public ListViewModel()
        {
            ListeDeCocktail = new ObservableCollection<LocalCocktail>();
            InitList();

        }
        //public ObservableCollection<Cocktail> ListeDeCocktail { get; private set; }


        public async void InitList()
        {

            // supp dans bd
            //await App.Database.DeletePokemonAsync();


            Cocktail[] requestedCocktail = await Task.Run(function: () => CocktailAPI.SearchByLetter('a').ToArray());

            string vide;
            for (int i = 0; i < requestedCocktail.Length || i <= 20; i++)
            {
                LocalCocktail MyCocktail = new LocalCocktail();

                if (requestedCocktail[i].idDrink != null)
                {
                    MyCocktail.Id = Int32.Parse(requestedCocktail[i].idDrink);
                } else { continue; }

                if (requestedCocktail[i].strDrink != null)
                {
                    MyCocktail.Name = requestedCocktail[i].strDrink;
                } else { continue; }

                if (requestedCocktail[i].strInstructions != null)
                {
                    MyCocktail.Instructions = requestedCocktail[i].strInstructions;
                } else { continue; }

                if (requestedCocktail[i].strDrinkThumb != null)
                {
                    MyCocktail.Image = requestedCocktail[i].strDrinkThumb;
                } else { continue; }


                MyCocktail.Ingredients = new Dictionary<string, string>();

                if (requestedCocktail[i].strIngredient1 != null)
                {
                    if (requestedCocktail[i].strMeasure1 != null)
                    {
                        MyCocktail.Ingredients.Add(requestedCocktail[i].strIngredient1, requestedCocktail[i].strMeasure1);
                    }
                    else
                    {
                        MyCocktail.Ingredients.Add(requestedCocktail[i].strIngredient1, "");
                    }
                }
                if (requestedCocktail[i].strIngredient2 != null)
                {
                    if (requestedCocktail[i].strMeasure2 != null)
                    {
                        MyCocktail.Ingredients.Add(requestedCocktail[i].strIngredient2, requestedCocktail[i].strMeasure2);
                    }
                    else
                    {
                        MyCocktail.Ingredients.Add(requestedCocktail[i].strIngredient2, "");
                    }
                }
                if (requestedCocktail[i].strIngredient3 != null)
                {
                    if (requestedCocktail[i].strMeasure3 != null)
                    {
                        MyCocktail.Ingredients.Add(requestedCocktail[i].strIngredient3, requestedCocktail[i].strMeasure3);
                    }
                    else
                    {
                        MyCocktail.Ingredients.Add(requestedCocktail[i].strIngredient3, "");
                    }
                }
                if (requestedCocktail[i].strIngredient4 != null)
                {
                    if (requestedCocktail[i].strMeasure4 != null)
                    {
                        MyCocktail.Ingredients.Add(requestedCocktail[i].strIngredient4, requestedCocktail[i].strMeasure4);
                    }
                    else
                    {
                        MyCocktail.Ingredients.Add(requestedCocktail[i].strIngredient4, "");
                    }
                }
                if (requestedCocktail[i].strIngredient5 != null)
                {
                    if (requestedCocktail[i].strMeasure5 != null)
                    {
                        MyCocktail.Ingredients.Add(requestedCocktail[i].strIngredient5, requestedCocktail[i].strMeasure5);
                    }
                    else
                    {
                        MyCocktail.Ingredients.Add(requestedCocktail[i].strIngredient5, "");
                    }
                }

                ListeDeCocktail.Add(MyCocktail);
                Debug.WriteLine(" added : " + requestedCocktail[i].strDrink + " ;");
            }
            //String alphabet = "abcdefghijklmnopqrstvwxyz";

            //for (int i = 0; i < alphabet.Length; i++)
            //{
            //    Cocktail[] ListdeCocktail = CocktailAPI.SearchByLetter(alphabet[i]).ToArray();
            //}
            //}
        }

    }

    //public ListViewModel()
    //{
    //    this.Items = new ObservableCollection<CocktailTest>() {
    //        new CocktailTest() {
    //            name = "cuba libré",
    //            description = "Du rhome (5 Gal), du coca, et du citron. Avec ça la fête est garantie !",
    //            ingredients = new string[] {"Rhome", "Coca", "Citron" },
    //        }
    //    };

    //    //ConnectApiCoctail();
    //    InitList();
    //}

    //public async void InitList()
    //{
    //    CocktailAPI pokeClient = new CocktailAPI();

    //    // supp dans bd
    //    //await App.Database.DeletePokemonAsync();

    //    Cocktail[] ListdeCocktail = CocktailAPI.SearchByLetter('a').ToArray();

    //    String alphabet = "abcdefghijklmnopqrstvwxyz";

    //    //for (int i = 0; i < alphabet.Length; i++)
    //    //{
    //    //    Cocktail[] ListdeCocktail = CocktailAPI.SearchByLetter(alphabet[i]).ToArray();
    //    //}
    //}
}

