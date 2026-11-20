using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace prakt7_Evsyukov_TRPO.Models
{
    public class ElectricityUsage : INotifyPropertyChanged
    {
        private string _address;
        public string Address
        {
            get => _address;
            set
            {
                if (_address != value)
                {
                    _address = value;
                    OnPropertyChanged();
                }
            }
        }

        private float _consumption;
        public float Consumption
        {
            get => _consumption;
            set
            {
                if (_consumption != value)
                {
                    _consumption = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(Payment));
                }
            }
        }

        private float _rate;
        public float Rate
        {
            get => _rate;
            set
            {
                if (_rate != value)
                {
                    _rate = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(Payment));
                }
            }
        }

        private float? _benefit;
        public float? Benefit
        {
            get => _benefit;
            set
            {
                if (_benefit != value)
                {
                    _benefit = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(Payment));
                }
            }
        }

        public float Payment
        {
            get
            {
                float baseCost = Consumption * Rate;
                float benefitAmount = baseCost * (Benefit ?? 0);
                return baseCost - benefitAmount;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

}
