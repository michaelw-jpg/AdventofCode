using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode
{
    internal class RulesTextString
    {
        private readonly string connectionString = @"C:\Users\micha\Source\Repos\AdventofCode\Day5rule.txt";
        public List<List<int>> GetRuleList()
        {
            List<List<int>> ruleList = new List<List<int>>();

            string line;
            using (StreamReader reader = new StreamReader(connectionString))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    string[] s = line.Split('|');
                    List<int> p = new List<int>();

                    for (int i = 0; i < s.Length; i++)
                    {
                        p.Add(Convert.ToInt32(s[i]));
                    }

                    ruleList.Add(p);
                }
            }

            return ruleList;
        }

    }
}
