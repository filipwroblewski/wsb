using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Adres
    {
        private string _ulica;
        private string _nrDomu;
        private string _nrMieszkania;
        private string _kodPocztowy;
        private string _miasto;
        private string _panstwo;

        public string ulica
        {
            get => _ulica;
            set => _ulica = value;
        }

        public string nrDomu
        {
            get => _nrDomu;
            set => _nrDomu = value;
        }

        public string nrMieszkania
        {
            get => _nrMieszkania;
            set => _nrMieszkania = value;
        }

        public string kodPocztowy
        {
            get => _kodPocztowy;
            set => _kodPocztowy = value;
        }

        public string miasto
        {
            get => _miasto;
            set => _miasto = value;
        }

        public string panstwo
        {
            get => _panstwo;
            set => _panstwo = value;
        }

        public void OdczytDanych()
        {
            Console.WriteLine($"Ul. {this.ulica} {this.nrDomu}/{this.nrMieszkania}\n{this.kodPocztowy} {this.miasto}\n{this.panstwo}");
        }

        public void SetUpAddress(int i, string[,] osoby)
        {
            Console.WriteLine("\n--- Adres ---");

            Console.Write("Ulica: ");
            this.ulica = Console.ReadLine();
            osoby[i, 3] = this.ulica;

            Console.Write("Nr domu: ");
            this.nrDomu = Console.ReadLine();
            osoby[i, 4] = this.nrDomu;

            Console.Write("Nr mieszkania: ");
            this.nrMieszkania = Console.ReadLine();
            osoby[i, 5] = this.nrMieszkania;

            Console.Write("Kod pocztowy: ");
            this.kodPocztowy = Console.ReadLine();
            osoby[i, 6] = this.kodPocztowy;

            Console.Write("Miasto: ");
            this.miasto = Console.ReadLine();
            osoby[i, 7] = this.miasto;

            Console.Write("Panstwo: ");
            this.panstwo = Console.ReadLine();
            osoby[i, 8] = this.panstwo;
        }
    }
}
