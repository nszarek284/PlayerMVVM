using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal class Player
    {
        private string _imie;
        private string _nazwisko;
        private int _wiek;
        private double _waga;

        public Player(string imie = "Robert", string nazwisko = "Lewandowski", int wiek = 31, double waga = 80)
        {
            this._imie = imie;
            this._nazwisko = nazwisko;
            this._wiek = wiek;
            this._waga = waga;
        }

        public Player()
        {
            this._imie = "Robert";
            this._nazwisko = "Lewandowski";
            this._wiek = 31;
            this._waga = 80;
        }

        public Player(string w)
        {
            string[] s = w.Split();
            this._imie = s[0];
            this._nazwisko = s[1];
            this._wiek = int.Parse(s[2]);
            this._waga = double.Parse(s[3]);
        }

        public Player(Player p)
        {
            this._imie = p._imie;
            this._nazwisko = p._nazwisko;
            this._wiek = p._wiek;
            this._waga = p._waga;
        }
        ~Player() { }

        public override string ToString()
        {
            return String.Format($"{Imie} {Nazwisko} {Wiek} {Waga}kg");
        }
        public string Imie
        {
            get => _imie;
            set => _imie = value;
        }

        public string Nazwisko
        {
            get => _nazwisko;
            set => _nazwisko = value;
        }

        public int Wiek
        {
            get => _wiek;
            set => _wiek = value;
        }

        public double Waga
        {
            get => _waga;
            set => _waga = value;
        }

    }
}
