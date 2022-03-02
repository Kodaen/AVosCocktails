using CocktailDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace AVosCocktails.ViewModel
{
    class ListViewModel : BaseViewModel
    {
        private static ListViewModel _instance = new ListViewModel();
        

        public static ListViewModel Instance
        {
            get { return _instance; }
        }

        public ObservableCollection<Cocktail> ListeDeCocktail
        {
            get => GetValue<ObservableCollection<Cocktail>>();

            set => SetValue(value);
        }


        public ListViewModel()
        {
            ListeDeCocktail = new ObservableCollection<Cocktail>();
            InitList();

        }
        //public ObservableCollection<Cocktail> ListeDeCocktail { get; private set; }
    

        public async void InitList()
        {

            // supp dans bd
            //await App.Database.DeletePokemonAsync();


            Cocktail[] requestedCocktail = await Task.Run(function: () => CocktailAPI.SearchByLetter('a').ToArray());


            for (int i = 0; i < requestedCocktail.Length || i <= 20; i++)
            {
                ListeDeCocktail.Add(requestedCocktail[i]);
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

