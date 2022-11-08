using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Lab09.ImplementingFiles
{
  public static class ImplementingFiles
  {
    public static void QuestionFour()
    {
      string file = "../data.json";
      string jsonStringData = File.ReadAllText(file);
      JObject jsonData = JObject.Parse(jsonStringData);

      List<string> queriedNeighborhoods = new List<string>();

      foreach (var item in jsonData["features"].Children().ToList())
      {
        if (item["properties"]["neighborhood"].ToString() != "")
        {
          queriedNeighborhoods.Add(item["properties"]["neighborhood"].ToString());
        }
      }
      int counter = 1;
      foreach (var item in queriedNeighborhoods.Distinct())
      {
        // Console.WriteLine($"{counter} {item.ToString()}");
        counter++;
      }
      string fileToCreate = "../Queried-Neighborhoods-39.txt";
      string CsvFileNameToCreate = "../Queried-Neighborhoods-39.csv";
      string JsonFileNameToCreate = "../Queried-Neighborhoods-AllData.json";

      // creating txt file
      // CreateNewFile(fileToCreate, queriedNeighborhoods);
      // creating csv file
      // CreateNewFileButMakeItCSV(CsvFileNameToCreate, queriedNeighborhoods);
      // creating json file
      CreateNewFileButMakeItJSONAllData(JsonFileNameToCreate, jsonData);
    }

    public static void CreateNewFileButMakeItJSONAllData(string fileName, JObject jsonData)
    {

      try
      {
        using (StreamWriter sw = new StreamWriter(fileName))
        {
          try
          {
            sw.WriteLine("These are the neighborhoods in json format, essentially i'm rewriting what i deconstructed earlier. There are 147 objects here:  \n");
            foreach(var item in jsonData["features"])
              sw.WriteLine(item);
          }
          catch (Exception e)
          {
            Console.WriteLine(e.Message);
            throw;
          }
          finally
          {
            sw.Close();
          }
        }
      }
      catch (System.Exception e)
      {
        Console.WriteLine(e.Message);
        throw;
      }
    }

    public static void CreateNewFileButMakeItCSV(string fileName, List<string> neighborhoods)
    {
      string[] hoodArr = new string[neighborhoods.Count()];
      for (int i = 0; i < neighborhoods.Count(); i++)
        hoodArr[i] = neighborhoods[i];
      string allHoods = string.Join(", ", hoodArr.Distinct());

      try
      {
        using (StreamWriter sw = new StreamWriter(fileName))
        {
          try
          {
            sw.WriteLine("These are the neighborhoods that contain no duplicates. There are 39 of them, but it's probably hard to see since this is just a comma separated block of string:  \n");
            sw.WriteLine(allHoods);
          }
          catch (Exception e)
          {
            Console.WriteLine(e.Message);
            throw;
          }
          finally
          {
            sw.Close();
          }
        }
      }
      catch (System.Exception e)
      {
        Console.WriteLine(e.Message);
        throw;
      }
    }

    static void CreateNewFile(string fileName, List<string> neighborhoods)
    {
      try
      {
        using (StreamWriter sw = new StreamWriter(fileName))
        {
          try
          {
            sw.WriteLine("These are the neighborhoods that contain no duplicates. There are 39 of them: \n");
            int counter = 1;
            foreach (string neighborhood in neighborhoods.Distinct())
            {
              sw.WriteLine(counter + ". " + neighborhood);
              counter++;
            }
          }
          catch (Exception e)
          {
            Console.WriteLine(e.Message);
            throw;
          }
          finally
          {
            sw.Close();
          }
        }
      }
      catch (System.Exception e)
      {
        Console.WriteLine(e.Message);
        throw;
      }
    }
  }
}