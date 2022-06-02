using System;
using System.Collections.Generic;
using System.Text;

namespace WebUI.Entities
{
    class OrderEntity
    {
        private string name;
        private string country;
        private string city;
        private string creditCard;
        private string month;
        private string year;

        public string Name { get { return name; } set { name = value; } }
        public string Country { get { return country; } set { country = value; } }
        public string City { get { return city; } set { city = value; } }
        public string CreditCard { get { return creditCard; } set { creditCard = value; } }
        public string Month { get { return month; } set { month = value; } }
        public string Year { get { return year; } set { year = value; } }




        public OrderEntity(string name, string country, string city, string creditCard, string month, string year)
        {
            this.name = name;
            this.country = country;
            this.city = city;
            this.creditCard = creditCard;
            this.month = month;
            this.year = year;
        }
    }
}
