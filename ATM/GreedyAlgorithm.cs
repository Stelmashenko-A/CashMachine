using System;
using System.Collections.Generic;
using System.Linq;

namespace ATM
{
    internal class GreedyAlgorithm : IBanknoteSelector
    {
        private List<MutablePair<decimal, int>> _moneyCassettes;

        public ErrorMessages Result { get; private set; }
        public void Initialize(List<MutablePair<decimal, int>> moneyCassettes)
        {
            _moneyCassettes = moneyCassettes;
            SelectedMoney = new List<MutablePair<decimal, int>>();
        }

        private decimal TotalSum
        {
            get
            {
                return _moneyCassettes.Sum(variable => variable.Key*variable.Value);
            }
        }
        public void TrySelect(decimal requestedSum)
        {

            if (TotalSum < requestedSum)
            {
                Result = ErrorMessages.MoneyDeficiency;
                return;
            }

            var cassetteUsed = new Stack<MutablePair<decimal, int>>();
            var cassetteForUsing = new LinkedList<MutablePair<decimal, int>>();
            var moneyStack = new Stack<MutablePair<decimal, int>>();
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
                if ((cassetteForUsing.Count() > 1) ||(
                    ((requestedSum%currentCassette.Key == 0) &&(
                     requestedSum/currentCassette.Key <= currentCassette.Value))))

                {
                    //извекаем текущий номинал из стека неиспользованных номиналов
                    cassetteForUsing.RemoveLast();
                    //находим наименьшее между количеством купюр в банкомате и максиммальным количеством купюр
                    //суммарное достоинство которых не превышает требуемой суммы
                    var banknotesNumber = Math.Min((int) (requestedSum/currentCassette.Key),
                        currentCassette.Value);
                    //извлекаем купюры из кассеты
                    currentCassette.Value -= banknotesNumber;
                    //из запрошенной суммы вычитаем сумму выбранных на данном шаге купюр
                    requestedSum -= currentCassette.Key * banknotesNumber;
                    //в стек использованных номиналов добавляем текущий номинал
                    cassetteUsed.Push(currentCassette);
                    //в деньги для выдачи добавляем купюры, выбранные на текущем шаге 
                    moneyStack.Push(new MutablePair<decimal, int>(currentCassette.Key, banknotesNumber));
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
                    Result = ErrorMessages.CombinationFailed;
                    return;
                }

                //если номиналы остались, то уменьшаем на единицу количество купюр
                //номинала из вершины стека
                moneyStack.Peek().Value--;
                //возвращаем эту купюру в контейнер
                cassetteUsed.Peek().Value++;
                //увеличиваем сумму для подбора на номинал купюры, перемещённой обратно в банкомат
                requestedSum += cassetteUsed.Peek().Key;
            }

            //если произошёл успешный выход из цикла, состоянию присваиваем статус успешного завершения
            Result = ErrorMessages.NoError;
            //деньги из стека перекладываем в объект класса Money и возвращаем результат
            SelectedMoney.AddRange(moneyStack.ToArray());
        }

        public List<MutablePair<decimal, int>> SelectedMoney
        {
            get; private set;
        }
    }
}