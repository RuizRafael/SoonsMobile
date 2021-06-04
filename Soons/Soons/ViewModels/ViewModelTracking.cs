using Soons.Base;
using Soons.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Soons.ViewModels
{
    public class ViewModelTracking : ViewModelBase
    {
        public ViewModelTracking()
        { }
        private Order _Order;
        public Order Order
        {
            get { return this._Order; }
            set
            {
                this._Order = value;
                OnPropertyChanged("Order");
            }
        }

        public bool State2 { get { if (this.Order != null) { return this.Order.State >= 2; } else { return false; } } }
        public bool NotState2 { get { if (this.Order != null) { return !(this.Order.State >= 2); } else { return true; } } }
        public bool State3 { get { if (this.Order != null) { return this.Order.State >= 3; } else { return false; } } }
        public bool NotState3 { get { if (this.Order != null) { return !(this.Order.State >= 3); } else { return true; } } }
        public bool State4 { get { if (this.Order != null) { return this.Order.State >= 4; } else { return false; } } }
        public bool NotState4 { get { if (this.Order != null) { return !(this.Order.State >= 4); } else { return true; } } }
        public bool State5 { get { if (this.Order != null) { return this.Order.State >= 5; } else { return false; } } }
        public bool NotState5 { get { if (this.Order != null) { return !(this.Order.State >= 5); } else { return true; } } }

    }
}
