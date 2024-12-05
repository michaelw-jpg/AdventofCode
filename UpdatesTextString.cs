using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode
{
    internal class UpdatesTextString
    {
        private readonly string connectionString = @"C:\Users\micha\Source\Repos\AdventofCode\numbers.txt";
        public List<List<int>> GetUpdateList()
        {
            List<List<int>> updateList = new List<List<int>>();

            string line;
            using (StreamReader reader = new StreamReader(connectionString))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    string[] s = line.Split(',');
                    List<int> p = new List<int>();

                    for (int i = 0; i < s.Length; i++)
                    {
                        p.Add(Convert.ToInt32(s[i]));
                    }

                    updateList.Add(p);
                }
            }

            return updateList;
        }
    }
}
