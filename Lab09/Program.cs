using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using Lab09.ImplementingFiles;

namespace Lab09
{
  public class Program
  {
    static void Main(string[] args)
    {
      // JToken[] allNeighborhoods = QuestionOne();
      // List<JToken> neighborhoodsWithNames = QuestionTwo(allNeighborhoods);
      // QuestionThree(neighborhoodsWithNames);
      // QuestionFour();
      // QuestionFive();

      //*BONUS*
      Lab09.ImplementingFiles.ImplementingFiles.QuestionFour();
    }

    static void QuestionFive()
    {
      //Rewrite at least one of these questions only using the opposing method (example: Use LINQ Query statements instead of LINQ method calls and vice versa.)

      // QuestionOne and QuestionTwo rewrite- output all neighborhoods, only neighborhoods without empty names
      // getting here now, i'm realizing it was always just the neighborhood, not the data set for each object...i've been struggling because i can't read...
      string file = "../data.json";
      string jsonString = File.ReadAllText(file);
      JObject jsonData = JObject.Parse(jsonString);
      var query = from item in jsonData["features"].Children().ToList() 
                  where (item["properties"]["neighborhood"].ToString() != "") 
                  select item["properties"]["neighborhood"];
      foreach(var item in query)
        Console.WriteLine(item);

      // rewrite QuestionThree
      var queryTwo = query.Distinct().ToList();
      foreach(var item in queryTwo)
        Console.WriteLine(item);
      Console.WriteLine(queryTwo.Count());
    }

    static void QuestionFour()
    {
      //Rewrite the queries from above and consolidate all into one single query.
      // so, i need to read the text from json file and parse it into json object
      string file = "../data.json";
      string jsonStringData = File.ReadAllText(file);
      JObject jsonData = JObject.Parse(jsonStringData);
      // then create query that:
      // outputs all data
      // filter out neighborhoods with no names
      // and remove the duplicates
      // i kinda have no idea what is meant by consolidating it into a single query...
      List<string> queriedNeighborhoods = new List<string>();

      foreach (var item in jsonData["features"].Children().ToList())
      {
        if (item["properties"]["neighborhood"].ToString() != "")
        {
          queriedNeighborhoods.Add(item["properties"]["neighborhood"].ToString());
        }
      }
      List<string> queriedWithNoDuplicates = queriedNeighborhoods.Distinct().ToList();
      foreach (var item in queriedWithNoDuplicates)
        Console.WriteLine(item);
      Console.WriteLine($"Consolidated query: {queriedWithNoDuplicates.Count()}");

      var query = 
          from item in queriedNeighborhoods
          select item;
      int counter = 1;
      Console.WriteLine("================================ Question Four Remix ===================");
      foreach(var item in query.Distinct())
      {
        Console.WriteLine($"{counter} {item.ToString()}");
        counter++;
      }
      Console.WriteLine("================================ Question Four Remix ===================");
    }

    static void QuestionThree(List<JToken> neighborhoodsWithNames)
    {
      //Remove the duplicates (Final Total: 39 neighborhoods)

      //okay, after relooking at the instructions, it says to filter out neighborhoods, which i'm now realizing is probably just the neighborhoods property of the object we have, not the entire object itself...so i will now take a different approach
      List<string> Neighborhoods = new List<string>();
      foreach (var item in neighborhoodsWithNames)
      {
        Neighborhoods.Add(item["properties"]["neighborhood"].ToString());
      }
      List<string> noDuplicates = Neighborhoods.Distinct().ToList();
      foreach (var item in noDuplicates)
        Console.WriteLine($"{item}");
      Console.WriteLine($"No duplicates: {noDuplicates.Count()}");

      Console.WriteLine("=============== Alternate Way to Do this ===========================");
      var query = 
                  from spot in neighborhoodsWithNames
                  group spot by spot["properties"]["neighborhood"] into y
                  select y;
      foreach(var item in query)
        Console.WriteLine($"{item.Key.ToString()} appears {item.Count()} times");
      Console.WriteLine("==========================================");

      
    }

    static List<JToken> QuestionTwo(JToken[] allNeighborhoods)
    {
      //Filter out all the neighborhoods that do not have any names (Final Total: 143)
      Console.WriteLine("=====Question Two=====\nOutput only neighborhoods with names in this data list, should be 147 neighborhoods");
      List<JToken> noNames = new List<JToken>();
      foreach (var item in allNeighborhoods)
      {
        if (item["properties"]["neighborhood"].ToString() != "")
          noNames.Add(item);
      }
      foreach (var item in noNames)
        Console.WriteLine(item.ToString());
      Console.WriteLine($"Number of neighborhoods with names: {noNames.Count}");
      return noNames;
    }

    static JToken[] QuestionOne()
    {
      //Output all of the neighborhoods in this data list (Final Total: 147 neighborhoods)
      int counter = 0;
      string file = "../data.json";
      string jsonStringData = File.ReadAllText(file);
      // Console.WriteLine(jsonStringData);

      // create instance of jobject, which takes our json string and parses it into a json object
      JObject jsonData = JObject.Parse(jsonStringData);
      // we need all the objects in the features object of our data.json file, so target features, all it's children, and convert it to an array of jtokens so we can iterate through it later
      JToken[] jsonDataNeighborhoods = jsonData["features"].Children().ToArray();
      Console.WriteLine("=====Question One=====\nOutput all neighborhoods in this data list, should be 147 neighborhoods");
      foreach (var item in jsonDataNeighborhoods)
      {
        Console.WriteLine(item.ToString());
        counter++;
      }
      Console.WriteLine($"Number of neighborhoods: {counter}");
      return jsonDataNeighborhoods;
    }
  }
}