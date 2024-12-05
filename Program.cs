using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace AdventofCode
{
    internal class Program
    {
       
            
        static List<int> Swapper(List<int> wrongupdates, List<List<int>>rules)
        {
            for (int j = 0; j < wrongupdates.Count; j++) // Every int in the row.
            {
                // X | Y

                for (int k = 0; k < rules.Count; k++) // Every rule
                {
                    // continue break; Rule broken
                    // X
                    if (rules[k][0] == wrongupdates[j])
                        if (wrongupdates.Contains(rules[k][1])) // If the Y value exists in the row.
                        {
                            int xIndex = wrongupdates.IndexOf(rules[k][0]);
                            int yIndex = wrongupdates.IndexOf(rules[k][1]);

                            // Ensure Y is before X in the row, which violates the rule.
                            if (yIndex > xIndex)
                            {
                                // Perform the swap.
                                int temp = wrongupdates[yIndex];  // Save the value at Y's index.
                                wrongupdates[yIndex] = wrongupdates[xIndex];  // Move X's value to Y's index.
                                wrongupdates[xIndex] = temp;  // Place Y's value in X's index.

                                return wrongupdates; // Return the updated list.
                            }
                        }
                        
                                                    // Y
                    if (rules[k][1] == wrongupdates[j])
                        if (wrongupdates.Contains(rules[k][0])) // If the X value exists in the row.
                        {
                            int xIndex = wrongupdates.IndexOf(rules[k][0]);
                            int yIndex = wrongupdates.IndexOf(rules[k][1]);

                            // Ensure Y is before X in the row, which violates the rule.
                            if (yIndex < xIndex)
                            {
                                // Perform the swap.
                                int temp = wrongupdates[yIndex];  // Save the value at Y's index.
                                wrongupdates[yIndex] = wrongupdates[xIndex];  // Move X's value to Y's index.
                                wrongupdates[xIndex] = temp;  // Place Y's value in X's index.

                                return wrongupdates; // Return the updated list.
                            }
                        }

                }

            }
            return wrongupdates;
        }
        static void Main(string[] args)
        {


            RulesTextString textRules = new();
            UpdatesTextString textUpdates = new();

            List<List<int>> updates = textUpdates.GetUpdateList();
            List<List<int>> rules = textRules.GetRuleList();
            List<List<int>> wrongupdates = new List<List<int>>();

            int totalSum = 0;

            for (int i = 0; i < updates.Count; i++) // Every Row in updates
            {
                bool areWeClear = true;

                for (int j = 0; j < updates[i].Count; j++) // Every int in the row.
                {
                    // X | Y

                    for (int k = 0; k < rules.Count; k++) // Every rule
                    {
                        // continue break; Rule broken
                        // X
                        if (rules[k][0] == updates[i][j])
                            if (updates[i].Contains(rules[k][1])) // If the Y value exists in the row.
                                if (updates[i].IndexOf(rules[k][0]) > updates[i].IndexOf(rules[k][1])) // is X-index > Y-index ?
                                    areWeClear = false; // continue break; Rule broken
                                                        // Y
                        if (rules[k][1] == updates[i][j])
                            if (updates[i].Contains(rules[k][0])) // If the X value exists in the row.
                                if (updates[i].IndexOf(rules[k][1]) < updates[i].IndexOf(rules[k][0])) // is Y-index < X-index ?
                                    areWeClear = false; // continue break; Rule broken

                    }

                }
                if (areWeClear)
                {
                    int middlePageNumber = updates[i][(updates[i].Count - 1) / 2];
                    totalSum += middlePageNumber;
                }
                else
                {
                    wrongupdates.Add(updates[i]);
                }
            }

            int totalSumInc = 0;

            for (int i = 0; i < wrongupdates.Count; i++) // Every Row in updates
            {
                bool areWeClear = true;
                int maxSwaps = (wrongupdates[i].Count * (wrongupdates[i].Count - 1)) / 2;
                // Loop swapper while bllemfemof
                int counter = 0;
                while (counter <= maxSwaps)
                {
                    wrongupdates[i] = Swapper(wrongupdates[i], rules);

                    counter++;
                }


                for (int j = 0; j < wrongupdates[i].Count; j++) // Every int in the row.
                {
                    // X | Y

                    for (int k = 0; k < rules.Count; k++) // Every rule
                    {
                        // continue break; Rule broken
                        // X
                        if (rules[k][0] == wrongupdates[i][j])
                            if (wrongupdates[i].Contains(rules[k][1])) // If the Y value exists in the row.
                                if (updates[i].IndexOf(rules[k][0]) > wrongupdates[i].IndexOf(rules[k][1])) // is X-index > Y-index ?
                                    areWeClear = false; // continue break; Rule broken
                                                        // Y
                        if (rules[k][1] == wrongupdates[i][j])
                            if (wrongupdates[i].Contains(rules[k][0])) // If the X value exists in the row.
                                if (wrongupdates[i].IndexOf(rules[k][1]) < wrongupdates[i].IndexOf(rules[k][0])) // is Y-index < X-index ?
                                    areWeClear = false; // continue break; Rule broken

                    }

                }
                if (areWeClear)
                {
                    int middlePageNumber = wrongupdates[i][(wrongupdates[i].Count - 1) / 2];
                    totalSumInc += middlePageNumber;
                }

            }
            Console.WriteLine($"The sum for part 2 is {totalSumInc}"); // 3778
            // TODO - Output 0
        }
    }
}
