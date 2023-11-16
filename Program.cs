// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

List<Plant> plants = new List<Plant>()
{
    new Plant()
    {
        Species = "Rose",
        LightNeeds = 4,
        AskingPrice = 20.50M,
        City = "Exampleville",
        ZIP = 12345,
        Sold = false,
        AvailableUntil = new DateTime(2022, 12, 31) // Set a specific expiration date
    },
    new Plant()
    {
        Species = "Fern",
        LightNeeds = 2,
        AskingPrice = 15.08M,
        City = "Garden City",
        ZIP = 67890,
        Sold = true,
        AvailableUntil = new DateTime(2024, 11, 15) // Set a specific expiration date
    },
    new Plant()
    {
        Species = "Sunflower",
        LightNeeds = 5,
        AskingPrice = 25.07M,
        City = "Sunnytown",
        ZIP = 54321,
        Sold = false,
        AvailableUntil = new DateTime(2024, 12, 10) // Set a specific expiration date
    },
    new Plant()
    {
        Species = "Cactus",
        LightNeeds = 3,
        AskingPrice = 18.04M,
        City = "Desertville",
        ZIP = 98765,
        Sold = false,
        AvailableUntil = new DateTime(2024, 12, 5) // Set a specific expiration date
    },
    new Plant()
    {
        Species = "Orchid",
        LightNeeds = 4,
        AskingPrice = 30.10M,
        City = "Blossom City",
        ZIP = 13579,
        Sold = true,
        AvailableUntil = new DateTime(2024, 11, 30) // Set a specific expiration date
    }
};


    string greeting = @"Welcome to The Plant Store
Your one-stop shop for Plants";

Console.WriteLine(greeting);

Random random = new Random();



string choice = null;
while (choice != "0")
{
    Console.Clear(); // Clears the console before displaying the menu

    Console.WriteLine(@"Choose an option:
                        0. Exit
                        1. Display All Plants
                        2. Post a plant to be adopted
                        3. Adopt a plant
                        4. Delist a plant
                        5. Random Plant
                        6. Display Plants by light needs
                        7. View Plant Stats");

    choice = Console.ReadLine();
    
    if (choice == "0")
    {
        Console.WriteLine("Goodbye!");
    }
    else if (choice == "1")
    {
        Console.Clear(); // Clears the console before displaying the message
        DisplayAllPlants();
    }
    else if (choice == "2")
    {
        Console.Clear(); // Clears the console before displaying the message
        PostPlant();
    }
    else if (choice == "3")
    {
        Console.Clear(); // Clears the console before displaying the message
        AdoptPlant();
    }
    else if (choice == "4")
    {
        Console.Clear(); // Clears the console before displaying the message
        DelistAPlant();
    }
    else if (choice == "5")
    {
        Console.Clear(); // Clears the console before displaying the message
        RandomPlant(random);
    }
     else if (choice == "6")
    {
        Console.Clear(); // Clears the console before displaying the message
        DisplayPlantsByLightNeeds();
    }
    else if (choice == "7")
    {
        Console.Clear(); // Clears the console before displaying the message
        ViewPlantStatistics();
    }
    else
    {
        Console.Clear(); // Clears the console before displaying the error message
        Console.WriteLine("Choose an option that is listed. Press any key to continue");
        Console.ReadKey(); // Pauses the program until the user presses any key
    }
}


void DisplayAllPlants()
{
        for (int i = 0; i < plants.Count; i++)
{
    Console.WriteLine($"{i + 1}. {PlantDetails(plants[i])}");
}
Console.WriteLine("press any key to continue...");
Console.ReadKey();
}


void PostPlant()
{
    Console.WriteLine("Enter details for the new plant:");

    Console.Write("Species: ");
    string species = Console.ReadLine();

    Console.Write("Light Needs (1-5): ");
    int lightNeeds;
    while (!int.TryParse(Console.ReadLine(), out lightNeeds) || lightNeeds < 1 || lightNeeds > 5)
    {
        Console.WriteLine($"{InvalidLightNeeds()}");
        Console.Write("Light Needs (1-5): ");
    }

    Console.Write("Asking Price: $");
    decimal askingPrice;
    while (!decimal.TryParse(Console.ReadLine(), out askingPrice) || askingPrice < 0)
    {
        Console.WriteLine("Invalid input. Asking Price should be a positive number.");
        Console.Write("Asking Price: $");
    }

    Console.Write("City: ");
    string city = Console.ReadLine();

    Console.Write("ZIP: ");
    int zip;
    while (!int.TryParse(Console.ReadLine(), out zip) || zip < 10000 || zip > 99999)
    {
        Console.WriteLine("Invalid input. ZIP should be a 5 digit number");
        Console.Write("ZIP: ");
    }

    Console.Write("Year Available Until: ");
    int year;
    while (!int.TryParse(Console.ReadLine(), out year) || year < DateTime.Now.Year)
    {
        Console.WriteLine("Invalid input. Please enter a valid year.");
        Console.Write("Year Available Until: ");
    }

    Console.Write("Month Available Until: ");
    int month;
    while (!int.TryParse(Console.ReadLine(), out month) || month < 1 || month > 12)
    {
        Console.WriteLine("Invalid input. Please enter a valid month (1-12).");
        Console.Write("Month Available Until: ");
    }

    Console.Write("Day Available Until: ");
    int day;
    while (!int.TryParse(Console.ReadLine(), out day) || day < 1 || day > DateTime.DaysInMonth(year, month))
    {
        Console.WriteLine("Invalid input. Please enter a valid day.");
        Console.Write("Day Available Until: ");
    }

    // Create a new Plant object with the user's input
    Plant newPlant = new Plant()
    {
        Species = species,
        LightNeeds = lightNeeds,
        AskingPrice = askingPrice,
        City = city,
        ZIP = zip,
        Sold = false, // The plant is available by default
        AvailableUntil = new DateTime(year, month, day) // Set the AvailableUntil property
    };

    // Add the new plant to the plants List
    plants.Add(newPlant);

    Console.WriteLine($"The plant '{species}' has been posted successfully!");
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}





void AdoptPlant()
{
    // Display available plants
    Console.WriteLine("Available Plants:");
    List<int> availablePlantIndices = new List<int>();
    DateTime currentDate = DateTime.Now;

    for (int i = 0; i < plants.Count; i++)
    {
        if (!plants[i].Sold && (plants[i].AvailableUntil == null || plants[i].AvailableUntil > currentDate))
        {
            availablePlantIndices.Add(i);
            Console.WriteLine($"{availablePlantIndices.Count}. {plants[i].Species} in {plants[i].City} for ${plants[i].AskingPrice}");
        }
    }

    // Ask the user to choose a plant
    Console.Write("Enter the number of the plant you want to adopt (5000 to cancel): ");
    if (int.TryParse(Console.ReadLine(), out int adoptChoice) && availablePlantIndices.Contains(adoptChoice))
    {
        // Update the chosen plant's Sold property to true
        Plant chosenPlant = plants[availablePlantIndices[adoptChoice - 1]];
        chosenPlant.Sold = true;

        Console.WriteLine($"You have adopted the {chosenPlant.Species} for ${chosenPlant.AskingPrice}. Thank you!");

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
    else if (adoptChoice == 5000)
    {
        Console.WriteLine("Adoption canceled.");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine("Invalid input or selected plant is not available. Please enter a valid number.");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}




void DelistAPlant()
{
    Console.WriteLine("Choose a plant to delist by entering its number:");
    for (int i = 0; i < plants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {plants[i].Species} {(plants[i].Sold ? "is sold" : "is available")}");
    }

    try
    {
        int plantNumber = int.Parse(Console.ReadLine());
        if (plantNumber >= 1 && plantNumber <= plants.Count)
        {
            // Remove the plant at the specified index
            plants.RemoveAt(plantNumber - 1);
            Console.WriteLine("Plant delisted successfully.");
        }
        else
        {
            Console.WriteLine("Invalid plant number. Please choose a valid number.");
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Invalid input. Please enter a valid number.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }

    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}

void RandomPlant(Random random)
{
    if (plants.Count > 0)
    {
        // Generate a random index within the range of the plant list
        int randomIndex = random.Next(0, plants.Count);

        // Display details of the randomly selected plant
        Plant randomPlant = plants[randomIndex];
        Console.WriteLine($"Randomly Selected Plant:");
        Console.WriteLine($"{randomPlant.Species}");
    }
    else
    {
        Console.WriteLine("No plants available to display.");
    }

    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}
void DisplayPlantsByLightNeeds()
{
    Console.WriteLine("Enter the maximum light needs (1-5):");

    // Validate user input for maximum light needs
    if (int.TryParse(Console.ReadLine(), out int maxLightNeeds) && maxLightNeeds >= 1 && maxLightNeeds <= 5)
    {
        List<Plant> selectedPlants = new List<Plant>();

        // Collect plants with lighting needs at or below the specified level
        foreach (Plant plant in plants)
        {
            if (plant.LightNeeds <= maxLightNeeds)
            {
                selectedPlants.Add(plant);
            }
        }

        // Display the selected plants
        Console.WriteLine("Plants with light needs at or below the specified level:");
        foreach (Plant selectedPlant in selectedPlants)
        {
            Console.WriteLine($"{selectedPlant.Species} - Light Needs: {selectedPlant.LightNeeds}");
        }

        // Prompt the user to press any key to continue
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine($"{InvalidLightNeeds()}");

        // Prompt the user to press any key to continue
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}

void ViewPlantStatistics()
{
    Console.Clear();
    Console.WriteLine("App Statistics:");

    // Lowest price plant
    Plant lowestPricePlant = plants.OrderBy(p => p.AskingPrice).FirstOrDefault();
    Console.WriteLine($"Lowest Price Plant: {lowestPricePlant?.Species} (${lowestPricePlant?.AskingPrice})");

    // Number of plants available
    int availablePlantsCount = plants.Count(p => !p.Sold);
    Console.WriteLine($"Number of Plants Available: {availablePlantsCount}");

    // Plant with highest light needs
    Plant highestLightPlant = plants.OrderByDescending(p => p.LightNeeds).FirstOrDefault();
    Console.WriteLine($"Plant with Highest Light Needs: {highestLightPlant?.Species} (Light Needs: {highestLightPlant?.LightNeeds})");

    // Average light needs
    double averageLightNeeds = plants.Average(p => p.LightNeeds);
    Console.WriteLine($"Average Light Needs: {averageLightNeeds:F2}");

    // Percentage of plants adopted
    double adoptionPercentage = (double)plants.Count(p => p.Sold) / plants.Count * 100;
    Console.WriteLine($"Percentage of Plants Adopted: {adoptionPercentage:F2}%");

    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}


string PlantDetails(Plant plant)
{
    string plantString = $"{plant.Species} in {plant.City} {(plant.Sold ? "is sold" : $"is available for ${plant.AskingPrice}")}.";

    return plantString;
}

string InvalidLightNeeds()
{
    string invalidlightString = $"Invalid input. Please enter a number between 1 and 5.";
    return invalidlightString;
}
