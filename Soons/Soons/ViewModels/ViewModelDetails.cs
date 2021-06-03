using Soons.Base;
using Soons.Models;
using Soons.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Soons.ViewModels
{
    public class ViewModelDetails : ViewModelBase
    {
        ServiceSoons ServiceSoons;

        public ViewModelDetails(ServiceSoons serviceSoons)
        {
            this.ServiceSoons = serviceSoons;
        }

        private Prod _Producto;
        private ObservableCollection<Stock> _Stock;
        private ObservableCollection<String> _Fotos;

        public Prod Producto
        {
            get { return this._Producto; }
            set
            {
                this._Producto = value;
                OnPropertyChanged("Stock");
            }
        }
        public ObservableCollection<Stock> Stock 
        {
            get { return this._Stock; }
            set
            {
                this._Stock = value;
                OnPropertyChanged("Stock");
            }
        }

        public ObservableCollection<String> Fotos
        {
            get { return this._Fotos; }
            set
            {
                this._Fotos = value;
                OnPropertyChanged("Fotos");
            }
        }
    }
}
