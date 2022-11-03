# Lab09_LINQ

## What is this?

This repository is Lab 09 in my 401 Course. The purpose is to support and strengthen my knowledge of LINQ queries as well as provide better understanding of using json files in C# projects. Lab09 is comprised of 5 different questions to be answered, all building upon one another and relying on a json file that we must query through.

## What does it look like?

There's a pretty standard json file comprised of different location objects(addresses, types, geometry, etc.). Most of the data is duplicates, but in all is around 149 differnt objects. I decided to answer each question as it's own method to separate and clean up my code, with each question method being called in the Main method of my Program file:

```csharp
static void Main(string[] args)
    {
      JToken[] allNeighborhoods = QuestionOne();
      List<JToken> neighborhoodsWithNames = QuestionTwo(allNeighborhoods);
      QuestionThree(neighborhoodsWithNames);
      QuestionFour();
      QuestionFive();
    }
```

Since most of the methods/questions rely on one another, I chose to return data from differnt methods in order to use them in the next ones( as shown above).

The final output is simply a list of neighborhoods from the json file, with no duplicates: so going from 147 neighborhoods down to 39.

## How do you use it?

The only thing you'd need to do to run this project is cd into the "Lab09" file, type "dotnet run" in your terminal and click "enter"

## Any Relevant Details?

Not really...Happy reminder to make sure you read instructions thoroughly. I spent 3 days struggling with the same question before realizing I had misread something simple.
