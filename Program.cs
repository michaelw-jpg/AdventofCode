using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace AdventofCode
{
    internal class Program
    {
        
        static int DuplicateFinder(List<int> List1, List<int>List2)
        {
            int answerb = 0;
            Dictionary<int, int> counter = new Dictionary<int, int>();
            foreach (int num in List2) //checks for multiple instances of same numbers if it finds 1 ++ else add a new instance of dictionary
            {
                if (counter.ContainsKey(num))
                    counter[num]++;
                else
                    counter[num] = 1;
            }
            foreach (int num in List1) //checks against list 1 if number exists in list1 add to answer * number of times found in list2
            {
                if (counter.ContainsKey(num))
                {
                    answerb += num * counter[num];
                }
            }
            return answerb;

        }
        static int differenceFinder(List<int> List1, List<int>List2)
        {

            int answera = 0;

            for (int i = 0; i < List1.Count; i++)
            {
                int b = List1[i] - List2[i];
                b = Math.Abs(b);
                answera += b;
            }
            return answera;
        }

        static int[] diffChecker(List<int> numbers) // returns number that needs to be removed and at what index otherwise -10 and -10
        {
            bool isIncreasing = true;
            for (int i = 1; i < numbers.Count; i++)
            {
                
                if (i == 1)
                {
                    isIncreasing = numbers[i] > numbers[i - 1];
                }

                int diff = Math.Abs(numbers[i] - numbers[i - 1]);

                if (diff < 1 || diff > 3)
                {

                    //part 2 
                    int[] ans2 = { numbers[i-1], i -1};
                    return ans2;
                }

                bool currentIsIncreasing = numbers[i] > numbers[i - 1];

                // Rule 2: Check if the direction has switched
                if (currentIsIncreasing != isIncreasing)
                {


                    int[] ans3 = { numbers[i-1], i-1 };
                    return ans3;
                }

            }

            int[] ans = { -10, -10 };
            return ans;
        }

        static void Main(string[] args)
        {
             //StreamReader reader = new StreamReader("C:\\Users\\46760\\source\\repos\\AdventofCode\\Input.txt");
             //string[] lines = reader.ReadToEnd().Split();
             //var numbers = lines.Where(
             //    line => !string.IsNullOrEmpty(line)
             //  ).Select(
             //    line => line.Trim()
             //  ).Select(
             //    line => int.Parse(line)
               //).ToList();
            

            //string[] lines1 = File.ReadAllLines("C:\\Users\\46760\\source\\repos\\AdventofCode\\TextFile1.txt");

            //// Process each line to get groups of numbers
            //var numberGroups = lines1
            //    .Select(line => line
            //        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            //        .Select(int.Parse)                               
            //        .ToArray())                                      
            //    .ToArray();

            StreamReader reader1 = new StreamReader("C:\\Users\\micha\\source\\repos\\AdventofCode\\TextFile2.txt");
            string lines2 = reader1.ReadToEnd();

            string pattern = @"mul\((\d{1,3}),(\d{1,3})\)";
            Regex rg = new Regex(pattern);
            string pattern2 = @"do\(\)|don't\(\)|mul\((\d{1,3}),(\d{1,3})\)";
            Regex rg2 = new Regex(pattern2);
            MatchCollection test2 = rg2.Matches(lines2);


            int answerb = 0;
            MatchCollection test = rg.Matches(lines2);
            for(int i = 0; i < test.Count; i++)
            {
                Console.WriteLine(test[i].Value);

            }

            bool skip = false;
            foreach(Match match in test2)
            {
                if (match.Value == "do()")
                {
                    skip = false;
                }
                else if(match.Value == "don't()")
                {
                    skip = true;
                }

                else if(match.Value.StartsWith("mul") && skip == false)
                {

                    // Extract the numbers from capture groups
                    int num1 = int.Parse(match.Groups[1].Value);
                    int num2 = int.Parse(match.Groups[2].Value);

                    // Multiply the numbers
                    int result = num1 * num2;
                    answerb += result;
                }
            }
            
            int answer = 0;
            foreach (Match match in test)
            {
                // Extract the numbers from capture groups
                int num1 = int.Parse(match.Groups[1].Value);
                int num2 = int.Parse(match.Groups[2].Value);

                // Multiply the numbers
                int result = num1 * num2;

                answer += result;

            }
            Console.WriteLine(answer);
            Console.WriteLine(answerb);


            //for (int j = 0; j < numberGroups.Length; j++)
            //{
            //    //bool isIncreasing = true;

            //    //bool isSafe = true;

            //    List<int> ints = new List<int>();
            //    ints.AddRange(numberGroups[j]);

            //    int[] nums = diffChecker(ints);
            //    Console.WriteLine(nums[0] + " " + nums[1]);
            //    if (nums[0] == -10 && nums[1] == -10)
            //    {
            //        counter++;
            //        continue;
            //    }
            //    ints.RemoveAt(nums[1]);
            //    nums = diffChecker(ints);
            //    if (nums[0] == -10 && nums[1] == -10)
            //    {
            //        counter++;
            //        continue;
            //    }


            //    //for (int i = 1; i < numberGroups[j].Length; i++)
            //    //{


            //    //    int diff = Math.Abs(numberGroups[j][i] - numberGroups[j][i - 1]);
            //    //    if (i ==1)
            //    //    {
            //    //        isIncreasing = numberGroups[j][i] > numberGroups[j][i - 1];
            //    //    }

            //    //    // Rule 1: 
            //    //    if (diff < 1 || diff > 3)
            //    //    {


            //    //        isSafe = false;
            //    //        break; 
            //    //    }

            //    //    // Determine the direction
            //    //    bool currentIsIncreasing = numberGroups[j][i] > numberGroups[j][i - 1];

            //    //    // Rule 2: Check if the direction has switched
            //    //    if (currentIsIncreasing != isIncreasing)
            //    //    {

            //    //        isSafe = false;

            //    //        break;
            //    //    }

            //    //}
            //    //if (isSafe)
            //    //    counter++;
            //}
            //Console.WriteLine(counter);

            // List<int> List1 = new List<int>();
            // List<int> List2 = new List<int>();
            // for(int i = 0; i <= numbers.Count-1; i = i+2)
            // {
            //     List1.Add(numbers[i]);
            //     List2.Add(numbers[i + 1]);

            // }

            // List1.Sort();
            // List2.Sort();
            // int answera = differenceFinder(List1, List2);
            // int answerb = DuplicateFinder(List1, List2);



            //Console.WriteLine(answerb);

        }
    }
}
