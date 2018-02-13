using Migrations.Data;
using Migrations.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

using Xamarin.Forms;

namespace Migrations
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			MainPage = new Migrations.MainPage();
		}

		protected override async void OnStart ()
		{
			// Handle when your app starts
            var dbFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string fileName = "people.db";
            string path = Path.Combine(dbFolder, fileName);

            //DbContextOptions options = new DbContextOptions();
            using(var db = new PersonContext(path))
            {
                //await db.Database.MigrateAsync();
               db.Database.Migrate();

                Person p1 = new Person() { ID = 1, FirstName = "Matt", LastName = "Johnson" };
                Person p2 = new Person() { ID = 1, FirstName = "Will", LastName = "Austin" };

                db.People.Add(p1);
                db.People.Add(p2);
                await db.SaveChangesAsync();
            }
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
