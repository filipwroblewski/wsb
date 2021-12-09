using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;

namespace ConsoleApp4
{
    class Program
    {
        static void ZapisBinarny()
        {
            Kolo k1 = new Kolo(3, 4, 5);
            Prostokat p1 = new Prostokat(2, 3, 5, 7);

            BinaryFormatter bF = new BinaryFormatter();
            using (Stream fSt = new FileStream("dane.dat", FileMode.Create, FileAccess.Write))
            {
                bF.Serialize(fSt, k1);
                bF.Serialize(fSt, p1);
            }
        }

        static void OdczytBinarny()
        {
            Kolo kolo;
            Prostokat pros;
            BinaryFormatter bF = new BinaryFormatter();
            using (Stream fStr = new FileStream("dane.dat", FileMode.Open, FileAccess.Read))
            {
                kolo = (Kolo)bF.Deserialize(fStr);
                pros = (Prostokat)bF.Deserialize(fStr);
            }
            kolo.Info();
            pros.Info();
        }

        static void ZapisXml ()//musi byc konstruktor pusty i all pola i klasy musza byc public
        {
            Prostokat pr = new Prostokat(5, 2, 8, 5);
            XmlSerializer xmlSer = new XmlSerializer(typeof(Prostokat));
            using (Stream fStr = new FileStream("dane.xml", FileMode.Create, FileAccess.Write))
            {
                xmlSer.Serialize(fStr, pr);
            }
        }

        static void OdczytXml()//musi byc konstruktor pusty i all pola i klasy musza byc public
        {
            Prostokat pr;
            XmlSerializer xmlSer = new XmlSerializer(typeof(Prostokat)); 
            using (Stream fStr = new FileStream("dane.xml", FileMode.Open, FileAccess.Read))
            {
                pr = (Prostokat)xmlSer.Deserialize(fStr);
            }
            pr.Info();
        }

        static void Main(string[] args)
        {
            //ZapisBinarny();
            //OdczytBinarny();
            //ZapisXml();
            OdczytXml();

            Console.ReadKey();
        }
    }
}
