using System;
using System.Collections.Generic;
using SQLite;

namespace DogFactsDatabase.Models
{
    public class PersonalFact
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string TheFact { get; set; }
        public string ShortFact { get; set; }
        public string Image { get; set; }

        public PersonalFact()
        {
        }
        public static IEnumerable<PersonalFact> All { private set; get; }

    }
}
