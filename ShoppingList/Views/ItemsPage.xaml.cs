using ShoppingList.Models;
using ShoppingList.ViewModels;
using ShoppingList.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShoppingList.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;
        public List<Meal> MealsList { get; set; }
        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();

            //delete this bit 
            // fuck knows how to get grouped data in collectionView
           
            //shoppingListView.ItemsSource = MealsList;
        }


        public void CreateMealList()
        {
            MealsList = new List<Meal>();
            MealsList.Clear();
            MealsList.Add(new Meal("Chicken Curry", new List<Item>
                {
                    new Item
                    {
                        Name = "Chicken Breast",
                        Description = "A breast of chicken",
                        Quantity = 2
                    },
                    new Item
                    {
                        Name = "Curry Paste",
                        Description = "Indian curry paste",
                        Quantity = 1
                    }

                }));

            MealsList.Add(new Meal("Beef Noodles", new List<Item>
                {
                    new Item
                    {
                        Name = "Beef Strips",
                        Description = "A packet of Beef steak, cut into strips",
                        Quantity = 1
                    },
                    new Item
                    {
                        Name = "Rice Noodles",
                        Description = "Noodles made from Rice, Gluten free!",
                        Quantity = 2
                    },
                      new Item
                    {
                        Name = "Sweet and Sour sauce",
                        Description = "A Jar of branded Sweet and Sour sauce",
                        Quantity = 1
                    }

                }));
        }


    }
}