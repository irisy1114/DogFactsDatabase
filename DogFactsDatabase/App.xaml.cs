using System;
using Xamarin.Forms;
using System.Collections.Generic;
using DogFactsDatabase.Data;
using DogFactsDatabase.Models;

namespace DogFactsDatabase
{
    public partial class App : Application
    {
        static PersonalFactDatabase database;
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        public static PersonalFactDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new PersonalFactDatabase();
                    prefillDatabase();

                }
                return database;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        static void prefillDatabase()
        {
            database.ClearAllAsync();
            List<PersonalFact> items = new List<PersonalFact>();
            items.Add(new PersonalFact() { TheFact = "I like shopping at Target", ShortFact = "Target", Image = "target.jpg" });
            items.Add(new PersonalFact() { TheFact = "I had a road trip during the spring break", ShortFact = "Indianna", Image = "indianna.jpeg" });
            items.Add(new PersonalFact() { TheFact = "I love my hair color", ShortFact = "Black", Image = "happy.jpg" });
            items.Add(new PersonalFact() { TheFact = "Noodle is one of my favorite food", ShortFact = "Spaghetti", Image = "spagetti.jpg" });
            items.Add(new PersonalFact() { TheFact = "I don't have any pets", ShortFact = "Pet", Image = "pet.jpeg" });
            database.InsertList(items);

        }
    }
}
