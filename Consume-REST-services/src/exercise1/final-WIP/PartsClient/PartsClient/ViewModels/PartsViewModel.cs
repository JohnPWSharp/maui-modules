﻿using PartsClient.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsClient.ViewModels
{
    internal class PartsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Part> _parts;
        private PartsManager manager = new PartsManager();

        public event PropertyChangedEventHandler PropertyChanged;

        public PartsViewModel()
        {
            _parts = new ObservableCollection<Part>();
        }

        public ObservableCollection<Part> Parts
        {
            get => _parts;
            set => _parts = value;
        }

        public async Task<bool> UpdatePart(Part part)
        {
            try
            {
                var thePart = Parts.First(p => p.PartID == part.PartID);
                if (thePart is null)
                    return false;

                await manager.Update(part);
                thePart = part;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Parts"));
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeletePart(Part part)
        {
            try
            {
                var thePart = Parts.First(p => p.PartID == part.PartID);
                if (thePart is null)
                    return false;

                await manager.Delete(part.PartID);
                Parts.Remove(thePart);
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Parts"));
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task Populate()
        { 
        var partsCollection = await manager.GetAll();
            foreach (Part part in partsCollection)
            {
                if (Parts.All(p => p.PartID != part.PartID))
                {
                    Parts.Add(part);
                }
            }
        }
    }
}