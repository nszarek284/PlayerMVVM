using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Models;
using Newtonsoft.Json;
using System.IO;


namespace ViewsModels
{
    internal partial class PlayersViewModel : ViewModelBase
    {
        private ICommand _add = null;
        private ICommand _delete = null;
        private ICommand _edit = null;
        private ICommand _load = null;

        public ICommand Add
        {
            get
            {
                if(_add == null)
                  {
                      _add = new RelayCommand(
                      arg =>
                    {
                        Players.Add(new ViewModel(new Player(Imie, Nazwisko, Wiek, Waga)));
                      
                    },
                    arg => !(string.IsNullOrEmpty(Imie) || string.IsNullOrEmpty(Nazwisko)) || Nazwisko == "" || Imie == "" );


                }
                return _add;
            }
        }

        public ICommand Delete
        {
            get
            {
                if(_delete == null)
                {
                    _delete = new RelayCommand(
                        arg =>
                        {
                            _players.RemoveAt(SelectedIndex);
                            onPropertyChanged(nameof(Players));
                        },
                        args => SelectedIndex != -1); 
                }
                return _delete;
            }
        }

        public ICommand Edit
        {
            get
            {
                if(_edit == null)
                {
                    _edit = new RelayCommand(
                        arg =>
                        {
                            ViewModel player = _players[SelectedIndex];
                            player.Imie = Imie;
                            player.Nazwisko = Nazwisko;
                            player.Wiek = Wiek;
                            player.Waga = Waga;
                        },
                        arg => SelectedIndex != -1
                        );

                }
                return _edit;
            }
        }

        public ICommand Load
        {
            get
            {
                if(_load == null)
                {
                    _load = new RelayCommand(
                        arg =>
                        {
                            ViewModel player = _players[SelectedIndex];
                            player.Imie = Imie;
                            player.Nazwisko = Nazwisko;
                            player.Wiek = Wiek;
                            player.Waga = Waga;
                            onPropertyChanged(nameof(Imie), nameof(Nazwisko), nameof(Wiek), nameof(Waga));
                        },
                        arg => SelectedIndex != 0
                        );
                }
                return _load;
            }
        }

       /* public ICommand Clear
        {
            get
            {
                if(_clear == null)
                {

                }
                return _clear;
            }
        }*/

        public ICommand Write 
        {
            get
            {
                return new RelayCommand(arg => write(), arg => true);
            }
        }

        public void write()
        {
            List<Player> writing = new List<Player>();

            foreach(ViewModel player in _players)
            {
                writing.Add(player.ViewPlayer);
            }

            string WriteJson = JsonConvert.SerializeObject(writing);
            File.WriteAllText(@"data.json", WriteJson);
        }

        public void read()
        {
            if(File.Exists("data.json"))
            {
                List<Player> reading = JsonConvert.DeserializeObject<List<Player>>(File.ReadAllText("data.json"));

                if(reading != null)
                {
                    foreach(Player player in reading)
                    {
                        _players.Add(new ViewModel(player));
                    }
                }
            }
        }

    }
}
