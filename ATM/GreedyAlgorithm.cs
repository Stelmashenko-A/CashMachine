using System;
using System.Collections.Generic;
using System.Linq;

namespace ATM
{
    internal class GreedyAlgorithm : IBanknoteSelector
    {
        private List<Cassette> _moneyCassettes;

        public void Initialize(List<Cassette> moneyCassettes)
        {
            _moneyCassettes = moneyCassettes;
            SelectedMoney = new Money();
        }

        private decimal TotalSum
        {
            get
            {
                return _moneyCassettes.Sum(item => item.TotalSum);
            }
        }
        public void TrySelect(decimal requestedSum)
        {

            if (TotalSum < requestedSum)
            {
                SelectedMoney.Result = States.MoneyDeficiency;
                return;
            }

            var cassetteUsed = new Stack<Cassette>();
            var cassetteForUsing = new LinkedList<Cassette>();
            var moneyStack = new Stack<MutablePair<Banknote, int>>();
            foreach (var item in _moneyCassettes)
            {
                cassetteForUsing.AddFirst(item);
            }
            //пока для выдачи не останется ноль повторяем
            while (requestedSum > 0)
            {
                //смотрим номинал купюр находящийся в вершине стека номиналов которые буду использованы
                var currentCassette = cassetteForUsing.Last();

                //если кроме текущего номинала доступен хотя бы ещё один
                //или с помощьью текущего номинала можно выдать оставшуюся сумму
                if (cassetteForUsing.Count() > 1 ||
                    (requestedSum%currentCassette.Banknote.Nominal == 0 &&
                     requestedSum%currentCassette.Banknote.Nominal <= currentCassette.Number))
                {
                    //извекаем текущий номинал из стека неиспользованных номиналов
                    cassetteForUsing.RemoveLast();
                    //находим наименьшее между количеством купюр в банкомате и максиммальным количеством купюр
                    //суммарное достоинство которых не превышает требуемой суммы
                    var banknotesNumber = Math.Min((int) (requestedSum/currentCassette.Banknote.Nominal),
                        currentCassette.Number);
                    //извлекаем купюры из кассеты
                    currentCassette.Number -= banknotesNumber;
                    //из запрошенной суммы вычитаем сумму выбранных на данном шаге купюр
                    requestedSum -= currentCassette.Banknote.Nominal * banknotesNumber;
                    //в стек использованных номиналов добавляем текущий номинал
                    cassetteUsed.Push(currentCassette);
                    //в деньги для выдачи добавляем купюры, выбранные на текущем шаге 
                    moneyStack.Push(new MutablePair<Banknote, int>(currentCassette.Banknote, banknotesNumber));
                    continue;
                }

                //если цикл не пошёл на следующий шаг
                //то пока есть использованные номиналы и количество
                //купюр текущего номминала равно нулю
                while (cassetteUsed.Any() && moneyStack.Peek().Value == 0)
                {
                    //переносим использованные номиналы в стек неиспользованных
                    cassetteForUsing.AddLast(cassetteUsed.Pop());
                    //извлекаем из выдачи номиналы с нулевым количеством
                    moneyStack.Pop();
                }

                //если после извлечения купюр на предыдущем этапе
                //в выдаче не осталось никаких номиналов
                if (!moneyStack.Any())
                {
                    // то получить нужную сумму невозможно
                    SelectedMoney.Result = States.CombinationFailed;
                    return;
                }

                //если номиналы остались, то уменьшаем на единицу количество купюр
                //номинала из вершины стека
                moneyStack.Peek().Value--;
                //возвращаем эту купюру в контейнер
                cassetteUsed.Peek().Number++;
                //увеличиваем сумму для подбора на номинал купюры, перемещённой обратно в банкомат
                requestedSum += cassetteUsed.Peek().Banknote.Nominal;
            }

            //если произошёл успешный выход из цикла, состоянию присваиваем статус успешного завершения
            SelectedMoney.Result = States.Success;
            //деньги из стека перекладываем в объект класса Money и возвращаем результат
            SelectedMoney.Banknotes.AddRange(moneyStack.ToArray());
        }

        public Money SelectedMoney
        {
            get; private set;
        }
    }
}