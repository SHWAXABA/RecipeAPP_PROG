﻿using System.Collections;

class Program
{
    //By Shwabade Ntsika Xaba
    //ST10100655
    static void Main(string[] args)
    {
       
        AppMenu menu = new AppMenu();
        menu.appMenu();

    }
}



class recipeLogger
{
    private Dictionary<string, Recipe> recipeDictionary = new Dictionary<string, Recipe>();

    public void LogDetails()
    {
        Console.Write("Enter number of recipes:");
        int repNum;
        if (int.TryParse(Console.ReadLine(), out repNum))
        {
            for (int i = 0; i < repNum; i++)
            {
                Console.Write("Enter Recipe Name:");
                string repName = Console.ReadLine();
                Recipe recipe = new Recipe();
                recipe.DetailEntry();
                recipeDictionary.Add(repName, recipe);
            }

            string ans;
            do
            {
                Console.WriteLine("Display Ingredients and steps? (Y/N)");
                ans = Console.ReadLine();
                switch (ans)
                {
                    case "Y":
                        foreach (var recipeEntry in recipeDictionary)
                        {
                            Console.WriteLine($"Recipe Name: {recipeEntry.Key}");
                            recipeEntry.Value.DisplayRecipe();
                        }
                        break;
                    case "N":
                        // Assuming menu.appMenu() is part of the AppMenu class
                        AppMenu menu = new AppMenu();
                        menu.appMenu();
                        break;
                    default:
                        Console.WriteLine("Please select a valid input");
                        break;
                }
            } while (ans != "N");
        }
        else
        {
            Console.WriteLine("Please enter a number");
        }
    }

    public void recipeList()
    {
        foreach (var recipeEntry in recipeDictionary)
        {
            Console.WriteLine($"Recipe Name: {recipeEntry.Key}");
        }
    }

    public void chooseRecipe()
    {
        Console.Write("Please enter the name of the recipe: ");
        string recipeName = Console.ReadLine();
        if (recipeDictionary.ContainsKey(recipeName))
        {
            Console.WriteLine($"Recipe Name: {recipeName}");
            recipeDictionary[recipeName].DisplayRecipe();
        }
        else
        {
            Console.WriteLine("Recipe does not exist");
        }
    }
}

//The following class leads ito the Ingredient creating Menu
class IngMenu
{
    public IngMenu() {
        //Created a recipe object out of the class recipe
        //The methods will be called from the recipe object class
       
        AppMenu appMenu = new AppMenu();
        Recipe recipe = new Recipe();
        while (true)
        {
            Console.WriteLine("===================================");
            Console.WriteLine("Enter '1' to enter recipe details");
            Console.WriteLine("Enter '2' to display recipe");
            Console.WriteLine("Enter '3' to scale recipe");
            Console.WriteLine("Enter '4' to reset quantities");
            Console.WriteLine("Enter '5' to clear recipe");
            Console.WriteLine("Enter '6' for Main Menu");
            Console.WriteLine("===================================");
            //These switch cases allow for the selection of each option
            string ans = Console.ReadLine();
            Console.WriteLine("                                     ");
            switch (ans)
            {

                case "1":
                    recipe.DetailEntry();
                    break;
                case "2":
                    recipe.DisplayRecipe();
                    break;
                case "3":
                    Console.Write("Enter scaling factor (0.5, 2, or 3): ");
                    double scale1;
                    if (double.TryParse(Console.ReadLine(), out scale1))
                    {
                        recipe.ScaleRecipe(scale1);
                    }
                    else
                    {
                        Console.WriteLine("\n+Please Enter a valid number+\n");
                    }

                    break;
                case "4":
                    recipe.ResetQuantities();
                    break;
                case "5":
                    recipe.ClearRecipe();
                    break;
                case "6":
                    appMenu.appMenu();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid choice.");
                    break;
            }
        }


    }
}

//the following class will calculate all of requirements using different methods
// The methods will then be called by the main statement
class Recipe
{
    private string[] ingredients;
    private double[] amount;
    private string[] units;
    private string[] steps;
    private double[] calories;
    private string[] foodGroup;

    public Recipe()
    {
        // Initialize empty arrays for ingredients, quantities, units, and steps
        ingredients = new string[0];
        amount = new double[0];
        units = new string[0];
        calories = new double[0];
        foodGroup = new string[0];
        steps = new string[0];

    }

    public void DetailEntry()
    {
        // Prompt the user to enter the number of ingredients

        Console.Write("Enter the number of ingredients: ");
        //If statement for error handling that will force the user to restart the program
        //
        int ingNum;
        if (int.TryParse(Console.ReadLine(), out ingNum))
        {
            // Initialize the arrays with the correct size
            ingredients = new string[ingNum];
            amount = new double[ingNum];
            units = new string[ingNum];
            calories = new double[ingNum];
            foodGroup = new string[ingNum];

            // Prompt the user to enter the details for each ingredient
            for (int i = 0; i < ingNum; i++)
            {
                Console.WriteLine($"Enter details for ingredient #{i + 1}:");
                Console.Write("Name: ");
                ingredients[i] = Console.ReadLine();
                do
                { 
                    Console.Write("Quantity: ");
                }
                while (!double.TryParse(Console.ReadLine(),out amount[i]));
                Console.Write("Unit of measurement: ");
                units[i] = Console.ReadLine();
                do {
                    Console.Write("Number of Calories: ");
                }
                while (!double.TryParse(Console.ReadLine(), out calories[i]));
                Console.Write("Food Group: ");
                foodGroup[i] = Console.ReadLine();
                

            }
            Console.Write("TOTAL CALORIES: ");
            double result = 0;
            for (int i = 0; i < calories.Length; i++)
            {
                result += calories[i];
            }
            Console.WriteLine(result);
            //Condition for if the calorie amount goes over 300
            if (result > 300)
            {
                Console.WriteLine("!!!-TOTAL CALORIES EXCEED 300-!!!");
            }

            // Prompt the user to enter the number of steps
            int Stnum;
            do
            {
                Console.Write("Enter the number of steps: ");
            } while (!int.TryParse(Console.ReadLine(), out Stnum));
            
            // Initialize the steps array with the correct size
            steps = new string[Stnum];

            // Prompt the user to enter the details for each step
            for (int i = 0; i < Stnum; i++)
            {
                Console.Write($"Enter step #{i + 1}: ");
                steps[i] = Console.ReadLine();
            }
            
        }
        else 
        { 
            Console.WriteLine("                                       ");
            Console.WriteLine("Please Enter a number+\n"); 
            
        }

        
    }

    public void DisplayRecipe()
    {
        // Display the ingredients and quantities
        Console.WriteLine("Ingredients:");
        for (int i = 0; i < ingredients.Length; i++)
        {
            Console.WriteLine($"- {amount[i]} {units[i]} of {ingredients[i]} at {calories[i]} Calories, Food Group: {foodGroup[i]}");
            
        }
        //Displays the total number of Calories in the recipe
        Console.WriteLine("Total Calories :");
        double result = 0;
        for(int i = 0; i < calories.Length; i++)
        {
            result += calories[i];
        }
        Console.WriteLine(result);
        //Condition for if the calorie amount goes over 300
        if (result > 300)
        {
            Console.WriteLine("!!!-TOTAL CALORIES EXCEED 300-!!!");
        }
        // Display the steps
        Console.WriteLine("Steps:");
        for (int i = 0; i < steps.Length; i++)
        {
            Console.WriteLine($"- {steps[i]}");
        }
        
       
    }

    public void ScaleRecipe(double scale)
    {
        // This will scale all our recipes by the scale we have chosen
        for (int i = 0; i < amount.Length; i++)
        {
            amount[i] *= scale;
        }
    }

    public void ResetQuantities()
    {
        // Reset all the amounts to their original values
        for (int i = 0; i < amount.Length; i++)
        {
            amount[i] /= 2;
        }
    }

    public void ClearRecipe()
    {
        // Reset all the arrays to empty
        ingredients = new string[0];
        amount = new double[0];
        units = new string[0];
        steps = new string[0];
    }
}
class AppMenu
{
    public void appMenu()
    {
        recipeLogger rep = new recipeLogger();
        while (true)
        {
            Console.WriteLine("========================================================================================");
            string art = @"
██████╗ ███████╗ ██████╗██╗██████╗ ███████╗     █████╗ ██████╗ ██████╗ 
██╔══██╗██╔════╝██╔════╝██║██╔══██╗██╔════╝    ██╔══██╗██╔══██╗██╔══██╗
██████╔╝█████╗  ██║     ██║██████╔╝█████╗      ███████║██████╔╝██████╔╝
██╔══██╗██╔══╝  ██║     ██║██╔═══╝ ██╔══╝      ██╔══██║██╔═══╝ ██╔═══╝ 
██║  ██║███████╗╚██████╗██║██║     ███████╗    ██║  ██║██║     ██║     
╚═╝  ╚═╝╚══════╝ ╚═════╝╚═╝╚═╝     ╚══════╝    ╚═╝  ╚═╝╚═╝     ╚═╝     
                                                                        ";

            Console.WriteLine(art);
            Console.WriteLine("========================================================================================");
            Console.WriteLine("1) Create Recipe");
            Console.WriteLine("2) Find Recipe");
            Console.WriteLine("3) Display All Recipes");
            Console.WriteLine("4) Exit App");
            Console.WriteLine("========================================================================================");
            Console.Write("Please Select Option:");
            string ans = Console.ReadLine();
            switch (ans)
            {
                case "1":
                    rep.LogDetails();
                    break;
                case "2":
                    rep.chooseRecipe();
                    break;
                case "3":
                    rep.recipeList();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please select Valid input");
                    break;
            }
        }
    }
}