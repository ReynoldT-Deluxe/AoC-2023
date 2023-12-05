using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections;

namespace FileApplication {
   class Program {
      static void Main(string[] args) {
        string dataLocation = "";
        
        //data to use
        //dataLocation = "/Users/t452172/Documents/Personal/Advent_of_Code/2023/AoC-2023/Day_2_2023/sampleData1.txt";
        dataLocation = "/Users/t452172/Documents/Personal/Advent_of_Code/2023/AoC-2023/Day_2_2023/aocData.txt"; 
        //dataLocation = "/Users/t452172/Documents/Personal/Advent_of_Code/2023/AoC-2023/Day_2_2023/aocData2.txt"; 

        //problem part
        //int partNum = 1;
        int partNum = 2;

            try {
                using (StreamReader sr = new StreamReader(dataLocation)) {
                    
                    string data;
                    int idSum = 0;
                    int powerSum = 0;

                    while ((data = sr.ReadLine()) != null) {
                        //check data if it's blank 
                        if (data.Length != 0) {
                            List<string> cubeData = getCubeList(data);

                            if (partNum == 1) {
                                idSum += getIdOfPossibleGames(data, cubeData);
                            } else {
                                powerSum += getPowerOfCubes(data, cubeData);
                            }
                        }
                    }

                    if (partNum == 1) {
                        Console.WriteLine("idSum: {0}", idSum);
                    } else {
                        Console.WriteLine("powerSum: {0}", powerSum);
                    }
                }                    

            } catch (Exception e) {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
      }

      static List<string> getCubeList(string data) {

        //Console.WriteLine("data: {0}", data);

        //get id from data
        string[] initialData = data.Split(' ');
        //Console.WriteLine("initialData[1]: {0}", initialData[1]);

        List<string> dataCollectedList = new List<string>();
        //Console.WriteLine("initialData.Length: {0}", initialData.Length);

        //get cube data
        for (int x = 2; x < initialData.Length; x++) {
            string dataCollected = "";
            //Console.WriteLine("x: {0}", x);
            //Console.WriteLine("initialData[x+1][0].ToString(): {0}", initialData[x+1][0].ToString());
            switch (initialData[x+1][0].ToString()) {
                case "b":
                    dataCollected = "blue " + initialData[x];
                    break;
                case "g":
                    dataCollected = "green " + initialData[x];
                    break;
                case "r":
                    dataCollected = "red " + initialData[x];
                    break;
            }
            dataCollectedList.Add(dataCollected);
            
            if (!x.Equals(initialData.Length)) {
                x++;
            }
        }

        return dataCollectedList;
      }

      static int getIdOfPossibleGames(string data, List<string> dataCollectedList) {

        int blue = 0;
        int green = 0;
        int red = 0;

        foreach(string text in dataCollectedList) {
            //Console.WriteLine(text);
            string[] colorData = text.Split((' '));
            string color = colorData[0];

            if (color.Equals("blue")) {
                int testBlue = Int32.Parse(colorData[1]);
                if (testBlue > blue) {
                    blue = testBlue;
                }
            } else if (color.Equals("green")) {
                int testGreen = Int32.Parse(colorData[1]);
                if (testGreen > green) {
                    green = testGreen;
                }
            } else if (color.Equals("red")) {
                int testRed = Int32.Parse(colorData[1]);
                if (testRed > red) {
                    red = testRed;
                }
            }
        }

        //Console.WriteLine("blue: {0}", blue);
        //Console.WriteLine("green: {0}", green);
        //Console.WriteLine("red: {0}", red);

        int id;
        string[] initialData = data.Split(' ');
        //Console.WriteLine("initialData[1]: {0}", initialData[1]);
        string[] game = initialData[1].Split(':');
        //Console.WriteLine("game[0]: {0}", game[0]);

        //compare with reference data
        //red 12
        //green 13
        //blue 14
        if (blue <= 14) {
            if (green <= 13) {
                if (red <= 12) {
                    id = Int32.Parse(game[0]);
                } else {
                    id = 0;
                }
            } else {
                id = 0;
            }
        } else {
            id = 0;
        }

        //Console.WriteLine(id);

        return id;
      }

      static int getPowerOfCubes(string data, List<string> dataCollectedList) {

        int blue = 0;
        int green = 0;
        int red = 0;

        foreach(string text in dataCollectedList) {
            //Console.WriteLine(text);
            string[] colorData = text.Split((' '));
            string color = colorData[0];

            if (color.Equals("blue")) {
                int testBlue = Int32.Parse(colorData[1]);
                if (testBlue > blue) {
                    blue = testBlue;
                }
            } else if (color.Equals("green")) {
                int testGreen = Int32.Parse(colorData[1]);
                if (testGreen > green) {
                    green = testGreen;
                }
            } else if (color.Equals("red")) {
                int testRed = Int32.Parse(colorData[1]);
                if (testRed > red) {
                    red = testRed;
                }
            }
        }

        //Console.WriteLine("blue: {0}", blue);
        //Console.WriteLine("green: {0}", green);
        //Console.WriteLine("red: {0}", red);

       return (blue * green * red);
      }
   }
}