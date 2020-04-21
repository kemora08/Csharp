using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoCos
{
    class Program
    {
        //DriverLicense Class
        public class DriverLicense
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Gender { get; set; }
            public string LicenseNumber { get; set; }

            //DriverLicense Constructor
            public DriverLicense(string initialFirstName, string initialLastName, string initialGender, string initialLicenseNumber)
            {
                FirstName = initialFirstName;
                LastName = initialLastName;
                Gender = initialGender;
                LicenseNumber = initialLicenseNumber;
            }

            //DriverLicense Method
            public string GetFullName()
            {
                string FullName = FirstName + " " + LastName;
                return FullName;
            }
        }
        //Book Class
        public class Book
        {
            public int BookID { get; set; }
            public string Title { get; set; }



            public string AuthorName { get; set; }
            public string Publisher { get; set; }
            public string Pages { get; set; }
            public string SKU { get; set; }
            public string Price { get; set; }

            //Book Constructor
            public Book(int iBookID, string iTitle, string iAuthorName, string iPublisher, string iPages, string iSKU, string iPrice)
            {
                BookID = iBookID;
                Title = iTitle;
                AuthorName = iAuthorName;
                Publisher = iPublisher;
                Pages = iPages;
                SKU = iSKU;
                Price = iPrice;
            }
        }

        //Airplane class
        public class Airplane
        {
            public int PlaneID { get; set; }
            public string Manufacturer { get; set; }
            public string Model { get; set; }
            public string Variant { get; set; }
            public string Capacity { get; set; }
            public string Engines { get; set; }


            //Airplane Constructor
            public Airplane(int iPlaneID, string iManufacturer, string iModel, string iVariant, string iCapacity, string iEngines)
            {
                PlaneID = iPlaneID;
                Manufacturer = iManufacturer;
                Model = iModel;
                Variant = iVariant;
                Capacity = iCapacity;
                Engines = iEngines;
            }
        }
        public static void Main(string[] args)
        {
            //Driver License Instance
            DriverLicense Driver1 = new DriverLicense("Kevin", "Mora", "Male", "27606268" );
            string FullName = Driver1.GetFullName();
            Console.WriteLine(FullName);




            //Book Instance
            Book Book1 = new Book(1, "Harry Potter", "J.K. Rowling", "Publisher", "500", "400", "$19.99");
            Book Book2 = new Book(2, "LOTR", "J.R.R Tolkien", "Publisher", "1000", "12345", "$100,000");
            Book Book3 = new Book(3, "Amelia Bedilia", "Peggy Parish", "Publisher", "340", "320", "$9.96");
            Book Book4 = new Book(4, "Killing of Lincoln", "Bill O; Reilly", "Martin Dugard", "Publisher", "400", "$32.99");




            //Plane Instance
            Airplane Plane1 = new Airplane(1, "Boeing", "Model-1", "Variant 5", "40", "3");
            Airplane Plane2 = new Airplane(2, "Airbus", "Model-2", "Variant 3", "32", "12");
            Airplane Plane3 = new Airplane(3, "Bombardier", "Model-3", "Variant 4", "45", "13");
            Airplane Plane4 = new Airplane(4, "Cirrus Aircraft", "Model-IO-550-N", "Variant 10", "30", "65");
        }
    }
}
 