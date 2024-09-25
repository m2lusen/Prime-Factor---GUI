using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_PrimeFactor_2.MVVM.Model
{
    public class TrialDivisionAlgorithm : IPrimeFactorAlgorithm
    {
        public string AlgorithmName => "Mock Algorithm"; 

        public List<int> GetPrimeFactors(int number)
        {
            List<int> factors = new List<int>();

            while (number % 2 == 0)
            {
                if (!factors.Contains(2))
                {
                    factors.Add(2);
                }
                number /= 2;
            }

            for (int i = 3; i <= Math.Sqrt(number); i += 2)
            {
                while (number % i == 0)
                {
                    if (!factors.Contains(i))
                    {
                        factors.Add(i);
                    }
                    number /= i;
                }
            }

            if (number > 2)
            {
                factors.Add(number);
            }

            return factors;
        }
    }
}
