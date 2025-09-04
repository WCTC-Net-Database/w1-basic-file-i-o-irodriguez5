using System.ComponentModel.Design;

bool running = true;

while (running)
{
    DisplayMenu();
    var choice = Console.ReadLine();

    if (choice == "1")
    {
        Console.WriteLine("Displaying characters...");
        var lines = File.ReadAllLines("input.csv");
        foreach (var line in lines)
        {
            var cols = line.Split(',');
            var name = cols[0];
            var profession = cols[1];
            var level = cols[2];
            var hp = cols[3];
            var equipment = cols[4].Split('|');

            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Profession: {profession}");
            Console.WriteLine($"Level: {level}");
            Console.WriteLine($"HP: {hp}");
            Console.WriteLine("Equipment:");
            foreach (var eq in equipment)
            {
                Console.WriteLine($" - {eq}");
            }
            Console.WriteLine("__________________________");
        }
    }
    else if (choice == "2")
    {
        Console.Write("Enter your character's name: ");
        string name = Console.ReadLine();

        Console.Write("Enter your character's class: ");
        string profession = Console.ReadLine();

        Console.Write("Enter your character's level: ");
        int level = int.Parse(Console.ReadLine());

        Console.Write("Enter your character's HP: ");
        int hp = int.Parse(Console.ReadLine());

        Console.Write("Enter your character's equipment (separate items with a '|'): ");
        string[] equipment = Console.ReadLine().Split('|');

        Console.WriteLine($"Welcome, {name} the {profession}! \tYou are level {level} and you have these items in your magic pouch: \t{string.Join(", ", equipment)}.");

        using (var writer = new StreamWriter("input.csv", true))
        {
            writer.WriteLine($"{name},{profession},{level},{hp},{string.Join("|", equipment)}");
        }
    }
    else if (choice == "3")
    {
        Console.WriteLine("Leveling up character...");
    }
    else if (choice == "4")
    {
        Console.WriteLine("Exiting program...");
        running = false;
    }
    else
    {
        Console.WriteLine("Invalid option. Please try again.");
    }
}

void DisplayMenu()
{
    Console.WriteLine("1 - Display Characters");
    Console.WriteLine("2 - Add Character");
    Console.WriteLine("3 - Level Up Character");
    Console.WriteLine("4 - Exit");
}