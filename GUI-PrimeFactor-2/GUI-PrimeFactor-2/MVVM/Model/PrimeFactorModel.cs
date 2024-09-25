using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_PrimeFactor_2.MVVM.Model
{
    public class PrimeFactorModel
    {

        // In the future logic would go here for deciding between which algorithm to use. Each algorithm will follow the same interface, and so should be interchangeable

        private readonly IPrimeFactorAlgorithm _algorithm;

        public PrimeFactorModel(IPrimeFactorAlgorithm algorithm)
        {
            _algorithm = algorithm;
        }

        public List<int> GetPrimeFactors(int number)
        {
            return _algorithm.GetPrimeFactors(number);
        }

        public string GetAlgorithmName() 
        {
            return _algorithm.AlgorithmName;
        }
    }
}
