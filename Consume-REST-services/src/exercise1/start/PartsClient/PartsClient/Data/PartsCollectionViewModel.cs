using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsClient.Data
{
    internal class PartsCollectionViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Part> parts = new ObservableCollection<Part>();

        public ObservableCollection<Part> Parts {
            get => parts;
        }
    }
}
