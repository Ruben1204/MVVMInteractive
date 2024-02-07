using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVMInteractivo
{
    public class HslViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private float _tonalidadHue, _saturacion, _luminosidad;
        private Color _color;

        public float TonalidadHue
        {
            get => _tonalidadHue;
            set
            {
                if (_tonalidadHue !=value)
                    Color = Color.FromHsla(value, _saturacion, _luminosidad);
            }
        }

        public float Saturacion
        {
            get => _saturacion;
            set
            {
                if (_saturacion !=value)
                    Color = Color.FromHsla(_tonalidadHue, value, _luminosidad);
            }
        }

        public float Luminosidad
        {
            get => _luminosidad;
            set
            {
                if (_luminosidad !=value)
                    Color = Color.FromHsla(_tonalidadHue, _saturacion, value);
            }
        }
        public Color Color
        {
            get => _color;
            set
            {
                if(_color != value)
                {
                    _color = value;
                    _tonalidadHue = _color.GetHue();
                    _saturacion = _color.GetSaturation();
                    _luminosidad = _color.GetLuminosity();

                    OnPropertyChanged("TonalidadHue");
                    OnPropertyChanged("Saturacion");
                    OnPropertyChanged("Luminosidad");
                    OnPropertyChanged();


                }
            }
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
