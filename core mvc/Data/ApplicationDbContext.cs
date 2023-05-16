//this folder and file is created by me to create an object of the db


//This code defines a C# class named "ApplicationDbContext" that inherits from the "DbContext"
//class provided by the Entity Framework Core library.

//The "DbContext" class is a key component of Entity Framework Core that allows developers to
//interact with a database using C# code.

//The constructor of the "ApplicationDbContext" class takes an argument of type
//"DbContextOptions<ApplicationDbContext>",which is a configuration object that contains information
//about how to connect to a particular database.

//This constructor then passes this configuration object to the constructor of the base "DbContext" class using the
//"base(options)" syntax, which initializes the "DbContext" instance with the given options.


using System.ComponentModel;
using Microsoft.EntityFrameworkCore;                                    //this is an installed nuget package
using BulkyBookWeb.Models;

namespace BulkyBookWeb.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)       //constructor

        //In other words, base(options) is a way to invoke the constructor of the base class and pass it arguments that
        //it requires to initialize its state.

        //In the code you provided, the constructor of the base class is the DbContext class constructor that takes a
        //single argument of type DbContextOptions<ApplicationDbContext>.
        {

        }
        public DbSet<Category> Categories { get; set; }

       // The public DbSet<Category> Categories { get; set; } line of code creates a property named "Categories"
       // that represents a collection of Category objects in the underlying database.

        
    }
}
