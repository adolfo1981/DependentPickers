using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace DependentPickers.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<string> _wildCartTeam1Options;
        private ObservableCollection<string> _wildCartTeam2Options;
        private List<string> _availableTeams;
        private string _selectedWildCardTeam1, _selectedWildCardTeam2;
        public ViewModel()
        {
            GetData();
            this.PropertyChanged += ViewModel_PropertyChanged;
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(SelectedWildCardTeam1))
            {
                if(WildCardTeam2Options.Contains(SelectedWildCardTeam1))
                {
                    WildCardTeam2Options.Remove(SelectedWildCardTeam1);
                }
            }
        }

        private void GetData()
        {
            AvailableTeams = new List<string>();
            for (int i = 0; i < 18; i++)
            {
                AvailableTeams.Add("Team" + (i + 1));
            }

            WildCardTeam1Options = new ObservableCollection<string>();

            AvailableTeams.ForEach(x =>
            {
                WildCardTeam1Options.Add(x);
            });

            WildCardTeam2Options = new ObservableCollection<string>();

            AvailableTeams.ForEach(x =>
            {
                WildCardTeam2Options.Add(x);
            });
        }

        public string SelectedWildCardTeam1
        {
            get => _selectedWildCardTeam1;
            set
            {
                _selectedWildCardTeam1 = value;
                NotifyPropertyChanged(nameof(SelectedWildCardTeam1));
            }
        }

        public string SelectedWildCardTeam2
        {
            get => _selectedWildCardTeam2;
            set
            {
                _selectedWildCardTeam2 = value;
                NotifyPropertyChanged(nameof(SelectedWildCardTeam2));
            }
        }

        public List<string> AvailableTeams
        {
            get
            {
                return _availableTeams;
            }
            set
            {
                _availableTeams = value;
            }
        }

        public ObservableCollection<string> WildCardTeam1Options
        {
            get
            {
                return _wildCartTeam1Options;
            }
            set
            {
                _wildCartTeam1Options = value;
                NotifyPropertyChanged(nameof(WildCardTeam1Options));
            }
        }

        public ObservableCollection<string> WildCardTeam2Options
        {
            get
            {
                return _wildCartTeam2Options;
            }
            set
            {
                _wildCartTeam2Options = value;
                NotifyPropertyChanged(nameof(WildCardTeam2Options));
            }
        }

        public void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
