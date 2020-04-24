using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace ViewsModels
{

    internal partial class PlayersViewModel : ViewModelBase
    {
        private Player player = new Player();
        private string _imie=" ";
        private string _nazwisko=" ";
        private int _wiek = 18;
        private double _waga = 75;
        private int _selectedIndex = -1;
        private ObservableCollection<ViewModel> _players = null;
        private int[] _wiekTab = generate();

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
            set { _waga = Math.Round(value,1); onPropertyChanged(nameof(Waga)); }
        }

        public int SelectedIndex
        {
            get => _selectedIndex;
            set => _selectedIndex = value;
        }

        public ObservableCollection<ViewModel> Players
        {
            get
            {
                if (_players == null)
                {
                    _players = new ObservableCollection<ViewModel>();
                    read();

                }
              return _players;
            }

        }

        public int[] WiekTab
        {
            get => _wiekTab;
        }

        public static int[] generate()
        {
            int[] wiek = new int[33];
            for (int i = 0; i < 33; i++)
            {
                wiek[i] = 18 + i;
            }
            return wiek;
        }
    }
}
