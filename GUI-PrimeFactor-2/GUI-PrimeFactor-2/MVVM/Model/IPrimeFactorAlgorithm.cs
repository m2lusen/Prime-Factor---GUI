using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_PrimeFactor_2.MVVM.Model
{
    public interface IPrimeFactorAlgorithm
    {
        string AlgorithmName { get; }
        List<int> GetPrimeFactors(int number);
    }
}
