using System.Collections.Generic;

namespace ATM
{
    public interface IBanknoteSelector
    {
        void Initialize(List<Cassette> moneyCassettes);

        void TrySelect(decimal sum);

        Money SelectedMoney { get; }
    }
}
