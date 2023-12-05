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
        //dataLocation = "/Users/t452172/Documents/Personal/Advent_of_Code/2023/AoC-2023/Day_1_2023/sampleData1.txt";
        //dataLocation = "/Users/t452172/Documents/Personal/Advent_of_Code/2023/AoC-2023/Day_1_2023/sampleData2.txt";
        //dataLocation = "/Users/t452172/Documents/Personal/Advent_of_Code/2023/AoC-2023/Day_1_2023/aocData.txt"; 
        dataLocation = "/Users/t452172/Documents/Personal/Advent_of_Code/2023/AoC-2023/Day_1_2023/aocData2.txt"; 

        //problem part
        //int partNum = 1;
        int partNum = 2;

            try {
                using (StreamReader sr = new StreamReader(dataLocation)) {
                    
                    string data;
                    int calibrationTotal = 0;
                    
                    while ((data = sr.ReadLine()) != null) {
                        //check data if it's blank 
                        if (data.Length != 0) {
                            calibrationTotal += getCalibrationValue(data, partNum);
                        }
                    }
                    Console.WriteLine("calibrationTotal: {0}", calibrationTotal);
                }                    

            } catch (Exception e) {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
      }

      static int getCalibrationValue(string data, int partNum) {
        int digit = 0;
        string digitData = "";

        for (int x = data.Length - 1; x >= 0; x--) {
            string input = data[x].ToString();

            if(partNum.Equals(1)) {                                            
                if (Int32.TryParse(input, out digit))
                {
                    digitData += input;
                }
            } else {
                if (Int32.TryParse(input, out digit)){
                    digitData += input;
                } else {
                    //Console.WriteLine("data[x..]: {0}", data[x..]);
                    switch (input){
                        case "o": 
                            if (data[x..].IndexOf("one").Equals(0)){
                                digitData += "1";
                            }
                            break;
                        case "t":
                            if (data[x..].IndexOf("two").Equals(0)){
                                digitData += "2";
                            }

                            if (data[x..].IndexOf("three").Equals(0)){
                                digitData += "3";
                            }
                            break;
                        case "f":
                            if (data[x..].IndexOf("four").Equals(0)){
                                digitData += "4";
                            }

                            if (data[x..].IndexOf("five").Equals(0)){
                                digitData += "5";
                            }
                            break;
                        case "s":
                            if (data[x..].IndexOf("six").Equals(0)){
                                digitData += "6";
                            }

                            if (data[x..].IndexOf("seven").Equals(0)){
                                digitData += "7";
                            }
                            break;
                        case "e":
                            if (data[x..].IndexOf("eight").Equals(0)){
                                digitData += "8";
                            }
                            break;
                        case "n":
                            if (data[x..].IndexOf("nine").Equals(0)){
                                digitData += "9";
                            }
                            break;
                    }
                }
            }
            //Console.WriteLine("digitData: {0}", digitData);
        }

        //if there is only one digit, use same digit
        if (digitData.Length.Equals(1)) {
            digitData += digitData;        
        }

        //Console.WriteLine("digitData: {0}", digitData);

        //get last and first digit since the order is from the end
        String output = digitData[digitData.Length - 1].ToString() + digitData[0].ToString();

        //Console.WriteLine("output: {0}", output);

        return Int32.Parse(output);
      }
   }
}