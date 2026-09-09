using System;

namespace Animals;

public class StartUp
{
    public static void Main(string[] args)
    {
        string animalType;
        while ((animalType = Console.ReadLine()) != "Beast!")
        {
            string[] animalInfo = Console.ReadLine().Split();
            string name = animalInfo[0];
            int age = int.Parse(animalInfo[1]);
            string gender = animalInfo[2];

            try
            {
                switch (animalType)
                {
                    case "Cat":
                        Cat cat = new(name, age, gender);
                        PrintAnimal(animalType, cat);
                        break;

                    case "Dog":
                        Dog dog = new(name, age, gender);
                        PrintAnimal(animalType, dog);
                        break;

                    case "Frog":
                        Frog frog = new(name, age, gender);
                        PrintAnimal(animalType, frog);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
    private static void PrintAnimal<T>(string animalType, T animal) where T : Animal
    {
        Console.WriteLine(animalType);
        Console.WriteLine(animal.ToString());
    }
}
