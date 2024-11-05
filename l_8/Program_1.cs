using System.Xml.Serialization;
using System.IO;
using AnimalLibrary;

public class Program_1
{
    static void Main(string[] args)
    {
        Animal animal = new Cow("Vatican", true, "CowName", AnimalClassification.Herbivores);
        XmlSerializer serializer = new XmlSerializer(typeof(Animal));
        using (TextWriter writer = new StreamWriter("animal.xml"))
        {
            serializer.Serialize(writer, animal);
        }
        Console.WriteLine("Animal object has been serialized to animal.xml");
        using (TextReader reader = new StreamReader("animal.xml"))
        {
            Animal deserializedAnimal = (Animal)serializer.Deserialize(reader);
            Console.WriteLine("\nDeserialized Animal Object:");
            Console.WriteLine($"Country: {deserializedAnimal.Country}");
            Console.WriteLine($"HideFromOtherAnimals: {deserializedAnimal.HideFromOtherAnimals}");
            Console.WriteLine($"Name: {deserializedAnimal.Name}");
            Console.WriteLine($"WhatAnimal: {deserializedAnimal.WhatAnimal}");
            deserializedAnimal.SayHello();
            Console.WriteLine($"Favorite Food: {deserializedAnimal.GetFavouriteFood()}");
        }
    }
}
