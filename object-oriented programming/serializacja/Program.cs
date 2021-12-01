using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace Projekt1
{
    class Program
    {
        static void Main(string[] args)
        {
            Osoba osoba1 = new Osoba("Jan", "Nowak");
            Osoba student1 = new Student("Tom", "Tomson", 111);
            Student student2 = new Student("Bob", "Bobson", 222);

            Console.WriteLine("Przed serializacja");
            Console.WriteLine(osoba1.ToString());
            Console.WriteLine(student1.ToString());
            Console.WriteLine(student2.ToString());
            Console.WriteLine("---");
            /*
            Osoba[] osoby = new Osoba[] { osoba1, student1, student2 };

            foreach (Osoba os in osoby)
            {
                os.ToString();
                Console.WriteLine();
            }
            */

            //zapis do pliku binarnego
            BinaryFormatter binFormater = new BinaryFormatter();
            using (Stream fs = new FileStream("osoby_i_studenci.dat", FileMode.Create, FileAccess.Write))
            {
                binFormater.Serialize(fs, osoba1);
                binFormater.Serialize(fs, student1);
                binFormater.Serialize(fs, student2);
            }

            //odczyt z pliku binarnego
            Osoba os1;
            Student st1;
            Student st2;
            using (Stream fsr = new FileStream("osoby_i_studenci.dat", FileMode.Open, FileAccess.Read))
            {
                os1 = (Osoba)binFormater.Deserialize(fsr);
                st1 = (Student)binFormater.Deserialize(fsr);
                st2 = (Student)binFormater.Deserialize(fsr);
            }

            Console.WriteLine("Po serializacji");
            Console.WriteLine(os1.ToString());
            Console.WriteLine(st1.ToString());
            Console.WriteLine(st2.ToString());
            Console.WriteLine("---");

            Console.ReadKey();
        }
    }
}
