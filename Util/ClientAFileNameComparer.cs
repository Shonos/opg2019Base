using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace opg_201910_interview.Util
{
    public class ClientAFileNameComparer : IComparer<string>
    {
        public int Compare(string left, string right)
        {
            return GetWeight(left) - GetWeight(right);
        }

        private int GetWeight(string word)
        {
            return word switch
            {
                "shovel" => 1,
                "waghor" => 2,
                "blaze" => 3,
                "discus" => 4,
                _ => - 1,
            };
        }
    }
}
