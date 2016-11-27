using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip
{
    public class TripCardSorter
    {
        /// <summary>
        /// Сортирует последовательность карточек путешествия.
        /// 
        /// Краткое описание алгоритма:
        /// 1. Заполняем два словаря - from и to.
        /// 2. Выбираем опорный элемент (в данном случае, первый).
        /// 3. Сначала упорядочиваем все элементы "справа" от опорного ("To").
        /// 4. Затем то же самое делаем "слева" ("From").
        /// 
        /// Сложность алоритма - O(n), О(n^2) в худшем случае.
        /// Доказательство: над каждым элементом производится постоянное число операций (C), 
        /// добавление/поиск по словарю O(1), O(n) - при коллизиях (например, при большом числе городов),
        /// значит всего операций:
        /// С*n + C*n*O(1), значит сложность O(n)
        /// или
        /// С*n + C*n*O(n), значит сложность O(n^2)
        /// 
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public static IEnumerable<TripCard> Sort(IEnumerable<TripCard> cards)
        {
            if (cards == null)
                throw new ArgumentException("Null cards sequence");

            //LinkedList потому что будем вставлять элементы в начало списка
            LinkedList<TripCard> result = new LinkedList<TripCard>();

            TripCard first = cards.FirstOrDefault();
            if (first == null)
            {
                // Последовательность не содержит элементов 
                return result;
            }

            var dictFrom = new Dictionary<string, TripCard>();
            var dictTo = new Dictionary<string, TripCard>();
            
            foreach(var card in cards)
            {                                                                                                                                                                                                
                dictFrom[card.CityFrom] = card;
                dictTo[card.CityTo] = card;
            }
            
            // Выбрали опорный элемент, добавили его в список
            TripCard next = first;
            result.AddLast(next);

            // Сначала идем "вправо". Ищем следующий город после опорного
            do
            {
                if (!dictFrom.TryGetValue(next.CityTo, out next))
                    next = null;
                else
                    result.AddLast(next);
            }
            while (next != null);

            // Вернулись к опорному элементу
            next = result.First();

            do
            {
                if (!dictTo.TryGetValue(next.CityFrom, out next))
                    next = null;
                else
                    result.AddFirst(next);
            }
            while (next != null);
            
            return result;
        }
    }
}
