using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelConcessionLibrary
{
    public class ConcessionCalculator
    {
        private const decimal TotalFare = 500;

        public string CalculateConcession(int age)
        {
            if (age <= 5)
            {
                return "Little Champs - Free Ticket";
            }
            else if (age > 60)
            {
                decimal concessionAmount = TotalFare * 0.30m; 
                decimal finalFare = TotalFare - concessionAmount;
                return $"Senior Citizen - Fare after 30% concession: {finalFare}";
            }
            else
            {
                return $"Ticket Booked - Fare: {TotalFare}";
            }
        }
    }
}
