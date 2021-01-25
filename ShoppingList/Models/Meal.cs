using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList.Models
{
   public class Meal : List<Item>
    {

        // does a Meal need a unique reference?
        public int Id{ get; set; } // Unique key (how to generate? size of Meal array + 1?)
        public string Name { get; set; } // name of the meal 

        //public List<Item> IngredientsList { get; set; } // List<Item> of needed ingredients to make Meal

        public int PortionAmount { get; set; } //amount of people meal can serve (as entered by the user , relative to the amounts of each ingredient)

        public string imagePath { get; set; } // User can add images of there own Meals

        public string RecipeLink { get; set; }// link to meal recipe (if it has one)

        public int TasteRating { get; set; }// 1-10 rating of the meal 


        // could add 
        // time to cook (hh:mm) (would be in the recipe , doesnt matter if not recipe linked)
        // 

        public Meal(string name, List<Item> items)
        {
            Name = name;
        }

       // public List<Meal> MealsList { get; private set; } = new List<Meal>(); // list which contains all the meal, goes at top of VM

    }
}
