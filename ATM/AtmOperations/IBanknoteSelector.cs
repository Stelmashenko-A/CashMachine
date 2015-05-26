using System;
using System.Collections.Generic;
using ATM.Utility;

namespace ATM.AtmOperations
{
    public interface IBanknoteSelector
    {
        bool TrySelect(List<MutablePair<decimal, int>> moneyCassettes, decimal requestedSum, out AtmState result,
            out List<MutablePair<decimal, int>> selectedMoney);
    }
}
