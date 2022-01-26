using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Komputer : Produkt
    {
        private string rodzajProcesora;
        private int pamiecROM;
        private int pamiecRAM;
        private string systemOperacyjny;

        public Komputer(string nazwaProduktu, float cenaNetto, float podatek, int liczbaDostepnych,
            string rodzajProcesora, int pamiecROM, int pamiecRAM, string systemOperacyjny) : base(nazwaProduktu, cenaNetto, podatek, liczbaDostepnych)
        {
            this.rodzajProcesora = rodzajProcesora;
            this.pamiecROM = pamiecROM;
            this.pamiecRAM = pamiecRAM;
            this.systemOperacyjny = systemOperacyjny;
        }

        public Komputer() : this("IBM", (float)24432.98, (float)0.02, 7, "AMD", 4, 16, "Linux") { }

        public string RodzajProcesora { get => rodzajProcesora; set => rodzajProcesora = value; }
        public int PamiecROM { get => pamiecROM; set => pamiecROM = value; }
        public int PamiecRAM { get => pamiecRAM; set => pamiecRAM = value; }
        public string SystemOperacyjny { get => systemOperacyjny; set => systemOperacyjny = value; }

        public override void Wyswietl()
        {
            base.Wyswietl();
            Console.WriteLine($"Rodzaj procesora: {this.rodzajProcesora},\nROM: {this.PamiecROM} Mb,\nRAM: {this.pamiecRAM} GB,\nSystem operacyjny: {this.systemOperacyjny}");
        }
    }
}
