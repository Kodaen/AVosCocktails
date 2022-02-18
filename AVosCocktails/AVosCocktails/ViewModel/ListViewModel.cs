using CocktailDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using static AVosCocktails.Model.Cocktail;

namespace AVosCocktails.ViewModel
{
    class ListViewModel : BaseViewModel
    {
        private static ListViewModel _instance = new ListViewModel();
        public static ListViewModel Instance
        {
            get { return _instance; }
        }

        public ObservableCollection<CocktailTest> Items
        {
            get => GetValue<ObservableCollection<CocktailTest>>();

            set => SetValue(value);
        }

        public ListViewModel()
        {
            this.Items = new ObservableCollection<CocktailTest>() {
                new CocktailTest() {
                    name = "cuba libré",
                    description = "Du rhome (5 Gal), du coca, et du citron. Avec ça la fête est garantie !",
                    ingredients = new string[] {"Rhome", "Coca", "Citron" },
                }
            };

            //ConnectApiCoctail();
            //InitList();
        }

        //private void InitList()
        //{
        //    throw new NotImplementedException();
        //}

        //private void ConnectApiCoctail()
        //{
        //    throw new NotImplementedException();
        //}
    }
}

