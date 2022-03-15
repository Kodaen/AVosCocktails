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
        private static ListViewModel _instance;

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

            //supression de la bd
            await App.Database.DeleteAllCocktails();


            Cocktail[] requestedCocktail = CocktailAPI.SearchByLetter('a').ToArray();

            LocalCocktail MyCocktail = new LocalCocktail();

            for (int i = 0; i < requestedCocktail.Length || i <= 20; i++)
            {

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


                string[] IngredientsTemp = new string[13];

                if (requestedCocktail[i].strIngredient1 != null)
                {
                    IngredientsTemp[0] = requestedCocktail[i].strIngredient1;
                    if (requestedCocktail[i].strMeasure1 != null)
                    {
                        IngredientsTemp[0] = IngredientsTemp[0]  + " "+ requestedCocktail[i].strMeasure1;
                    }
                }
                if (requestedCocktail[i].strIngredient2 != null)
                {
                    IngredientsTemp[1] = requestedCocktail[i].strIngredient2;
                    if (requestedCocktail[i].strMeasure2 != null)
                    {
                        IngredientsTemp[1] = IngredientsTemp[1] + " " + requestedCocktail[i].strMeasure2;
                    }
                }
                if (requestedCocktail[i].strIngredient3 != null)
                {
                    IngredientsTemp[2] = requestedCocktail[i].strIngredient3;
                    if (requestedCocktail[i].strMeasure3 != null)
                    {
                        IngredientsTemp[2] = IngredientsTemp[2] + " " + requestedCocktail[i].strMeasure3;
                    }
                }
                if (requestedCocktail[i].strIngredient4 != null)
                {
                    IngredientsTemp[3] = requestedCocktail[i].strIngredient4;
                    if (requestedCocktail[i].strMeasure4 != null)
                    {
                        IngredientsTemp[3] = IngredientsTemp[3] + " " + requestedCocktail[i].strMeasure4;
                    }
                }
                if (requestedCocktail[i].strIngredient5 != null)
                {
                    IngredientsTemp[4] = requestedCocktail[i].strIngredient5;
                    if (requestedCocktail[i].strMeasure5 != null)
                    {
                        IngredientsTemp[4] = IngredientsTemp[4] + " " + requestedCocktail[i].strMeasure5;
                    }
                }
                if (requestedCocktail[i].strIngredient6 != null)
                {
                    IngredientsTemp[5] = requestedCocktail[i].strIngredient6;
                    if (requestedCocktail[i].strMeasure6 != null)
                    {
                        IngredientsTemp[5] = IngredientsTemp[5] + " " + requestedCocktail[i].strMeasure6;
                    }
                }
                if (requestedCocktail[i].strIngredient7 != null)
                {
                    IngredientsTemp[6] = requestedCocktail[i].strIngredient7;
                    if (requestedCocktail[i].strMeasure7 != null)
                    {
                        IngredientsTemp[6] = IngredientsTemp[6] + " " + requestedCocktail[i].strMeasure7;
                    }
                }
                if (requestedCocktail[i].strIngredient8 != null)
                {
                    IngredientsTemp[7] = requestedCocktail[i].strIngredient8;
                    if (requestedCocktail[i].strMeasure8 != null)
                    {
                        IngredientsTemp[7] = IngredientsTemp[7] + " " + requestedCocktail[i].strMeasure8;
                    }
                }
                if (requestedCocktail[i].strIngredient9 != null)
                {
                    IngredientsTemp[8] = requestedCocktail[i].strIngredient9;
                    if (requestedCocktail[i].strMeasure9 != null)
                    {
                        IngredientsTemp[8] = IngredientsTemp[8] + " " + requestedCocktail[i].strMeasure9;
                    }
                }
                if (requestedCocktail[i].strIngredient10 != null)
                {
                    IngredientsTemp[9] = requestedCocktail[i].strIngredient10;
                    if (requestedCocktail[i].strMeasure10 != null)
                    {
                        IngredientsTemp[9] = IngredientsTemp[9] + " " + requestedCocktail[i].strMeasure10;
                    }
                }
                if (requestedCocktail[i].strIngredient11 != null)
                {
                    IngredientsTemp[10] = requestedCocktail[i].strIngredient11;
                    if (requestedCocktail[i].strMeasure1 != null)
                    {
                        IngredientsTemp[10] = IngredientsTemp[10] + " " + requestedCocktail[i].strMeasure11;
                    }
                }
                if (requestedCocktail[i].strIngredient12 != null)
                {
                    IngredientsTemp[11] = requestedCocktail[i].strIngredient12;
                    if (requestedCocktail[i].strMeasure12 != null)
                    {
                        IngredientsTemp[11] = IngredientsTemp[11] + " " + requestedCocktail[i].strMeasure12;
                    }
                }
                if (requestedCocktail[i].strIngredient13 != null)
                {
                    IngredientsTemp[12] = requestedCocktail[i].strIngredient12;
                    if (requestedCocktail[i].strMeasure13 != null)
                    {
                        IngredientsTemp[12] = IngredientsTemp[12] + " " + requestedCocktail[i].strMeasure12;
                    }
                }
                if (requestedCocktail[i].strIngredient14 != null)
                {
                    IngredientsTemp[13] = requestedCocktail[i].strIngredient14;
                    if (requestedCocktail[i].strMeasure14 != null)
                    {
                        IngredientsTemp[13] = IngredientsTemp[13] + " " + requestedCocktail[i].strMeasure13;
                    }
                }
                MyCocktail.Tags = requestedCocktail[i].strTags;
                MyCocktail.Ingredients = String.Join(",", IngredientsTemp);
                Debug.WriteLine(i + " + " + MyCocktail.Name);

                await App.Database.SaveCocktailAsync(MyCocktail);
                
            }

             
            ListeDeCocktail = new ObservableCollection<LocalCocktail>(App.Database.GetCocktailAsync().Result);

        }

    }

}