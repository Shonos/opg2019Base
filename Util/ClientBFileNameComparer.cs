using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace opg_201910_interview.Util
{
    public class ClientBFileNameComparer : IComparer<string>
    {
        public int Compare(string left, string right)
        {
            return GetWeight(left) - GetWeight(right);
        }

        private int GetWeight(string word)
        {
            return word switch
            {
                "orca" => 1,
                "widget" => 2,
                "eclair" => 3,
                "talon" => 4,
                _ => 5,
            };
        }
    }
}
