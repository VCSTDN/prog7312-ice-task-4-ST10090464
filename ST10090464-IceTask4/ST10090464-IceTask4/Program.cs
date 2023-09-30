using System;
using System.Collections.Generic;

namespace ST10090464_IceTask4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> locationDictionary = new Dictionary<string, int>();
            locationDictionary.Add("South Africa", -1);
            locationDictionary.Add("Gauteng", 0);
            locationDictionary.Add("Pretoria", 1);
            locationDictionary.Add("Cape Town", 0);
            locationDictionary.Add("Western Cape", 3); 

            
            string inputLocation = "Pretoria"; 
            FindParents(locationDictionary, inputLocation);

            Console.ReadLine();
        }

        static void FindParents(Dictionary<string, int> dictionary, string location)
        {
            if (dictionary.ContainsKey(location))
            {
                int parentIndex = dictionary[location];
                if (parentIndex == -1)
                {
                    Console.WriteLine(location);
                }
                else
                {
                    string parent = dictionary.GetKeyByValue(parentIndex);
                    FindParents(dictionary, parent);
                    Console.WriteLine(location);
                }
            }
            else
            {
                Console.WriteLine("Location not found in the dictionary.");
            }
        }
    }

    public static class DictionaryExtensions
    {
        public static TKey GetKeyByValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TValue value)
        {
            foreach (var pair in dictionary)
            {
                if (EqualityComparer<TValue>.Default.Equals(pair.Value, value))
                {
                    return pair.Key;
                }
            }
            throw new KeyNotFoundException("The given value was not found in the dictionary.");
        }
    }
}