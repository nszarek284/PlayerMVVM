using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace ViewsModels
{
    class ViewModel : ViewModelBase
    {
        private Player viewPlayer;

        public string Imie
        {
            get => viewPlayer.Imie;
            set { viewPlayer.Imie = value; onPropertyChanged(nameof(Imie)); }
        }

        public string Nazwisko
        {
            get => viewPlayer.Nazwisko;
            set { viewPlayer.Nazwisko = value; onPropertyChanged(nameof(Nazwisko)); }
        }

        public int Wiek
        {
            get => viewPlayer.Wiek;
            set { viewPlayer.Wiek = value; onPropertyChanged(nameof(Wiek)); }
        }

        public double Waga
        {
            get => viewPlayer.Waga;
            set { viewPlayer.Waga = value; onPropertyChanged(nameof(Waga)); }
        }

        public ViewModel (Player player)
        {
            viewPlayer = player;
        }

        public Player ViewPlayer
        {
            get => viewPlayer;
        }

        public override string ToString()
        {
            return viewPlayer.ToString();
        }
    }
}
