using ShoppingList.Models;
using ShoppingList.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShoppingList.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Item _selectedItem;

        public ObservableCollection<Item> Items { get; }

        public List<Meal> MealsList { get; set; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Item> ItemTapped { get; }

        public ItemsViewModel()
        {
            Title = "Shopping List";

            Items = new ObservableCollection<Item>();
            // testing meal/item grouping
            //CreateMealList();

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand()); //  needed for Filling Items from the MockDataStore
            //LoadItemsCommand = new Command(CreateMealList); // testing loading meal data

            ItemTapped = new Command<Item>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                //Items.Clear();
                //var items = await DataStore.GetItemsAsync(true);
                //foreach (var item in items)
                //{
                //    Items.Add(item);
                //}

                MealsList = new List<Meal>
                {
                new Meal("Chicken Curry", new List<Item>
                {
                    new Item
                    {
                        Text = "Chicken Breast",
                        Description = "A breast of chicken",
                        Quantity = 2
                    },
                    new Item
                    {
                        Text = "Curry Paste",
                        Description = "Indian curry paste",
                        Quantity = 1
                    }

                }),

                new Meal("Beef Noodles", new List<Item>
                {
                    new Item
                    {
                        Text = "Beef Strips",
                        Description = "A packet of Beef steak, cut into strips",
                        Quantity = 1
                    },
                    new Item
                    {
                        Text = "Rice Noodles",
                        Description = "Noodles made from Rice, Gluten free!",
                        Quantity = 2
                    },
                      new Item
                    {
                        Text = "Sweet and Sour sauce",
                        Description = "A Jar of branded Sweet and Sour sauce",
                        Quantity = 1
                    }

                })
            };

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(Item item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }

        
    }
}