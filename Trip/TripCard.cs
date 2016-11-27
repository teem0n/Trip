using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip
{
    /// <summary>
    /// Карточка путешествия
    /// 
    /// Город отправления не может быть равен городу назначения.
    /// Для строк делается Trim, чтобы не было городов вида "   Москва  ", "     "
    /// и т д
    /// </summary>
    public class TripCard
    {
        public string CityFrom { get; private set; }

        public string CityTo { get; private set; }

        public TripCard(string cityFrom, string cityTo)
        {
            if (string.IsNullOrWhiteSpace(cityFrom))
                throw new ArgumentException(nameof(cityFrom));
            if (string.IsNullOrWhiteSpace(cityTo))
                throw new ArgumentException(nameof(cityTo));

            CityFrom = cityFrom.Trim();
            CityTo = cityTo.Trim();

            if (CityTo == CityFrom)
                throw new ArgumentException(nameof(cityFrom) + " cannot be equal to the " + nameof(cityTo));
        }
    }
}
