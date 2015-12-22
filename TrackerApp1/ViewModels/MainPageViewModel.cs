using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TrackerApp1.Annotations;
using TrackerApp1.Commands;
using TrackerForWindowsPhoneClassLibrary.Models;

namespace TrackerApp1.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private string _textBlockText1;
        private string _textBlockText2;
        private string _textBlockText3;
        private string _textBlockText4;
        private ClickCommand _clickCommand;
        private double _angle;
        private List<MPKs> _mpKses;

        public event PropertyChangedEventHandler PropertyChanged;

        public double Angle
        {
            get { return _angle; }
            set
            {
                if (value == _angle) return;
                _angle = value;
                OnPropertyChanged();
            }
        }

       public  class MPKs
        {
            public Vehicle Vehicle { get; set; }
            public double Top { get; set; }
            public double Left { get; set; }
        }

        public List<MPKs> MPKses
        {
            get { return _mpKses; }
            set
            {
                if (Equals(value, _mpKses)) return;
                _mpKses = value;
                OnPropertyChanged();
            }
        }

        public string TextBlockText1
        {
            get { return _textBlockText1; }
            set
            {
                if (value == _textBlockText1) return;
                _textBlockText1 = value;
                OnPropertyChanged();
            }
        }

        public string TextBlockText3
        {
            get { return _textBlockText3; }
            set
            {
                if (value == _textBlockText3) return;
                _textBlockText3 = value;
                OnPropertyChanged();
            }
        }

        public string TextBlockText2
        {
            get { return _textBlockText2; }
            set
            {
                if (value == _textBlockText2) return;
                _textBlockText2 = value;
                OnPropertyChanged();
            }
        }

        public string TextBlockText4
        {
            get { return _textBlockText4; }
            set
            {
                if (value == _textBlockText4) return;
                _textBlockText4 = value;
                OnPropertyChanged();
            }
        }

        public ClickCommand ClickCommand
        {
            get
            {
                return _clickCommand ?? new ClickCommand(this);
            }
        }


        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }


        public MainPageViewModel()
        {
           MPKses = new List<MPKs>();

            var obj = new MPKs();
            obj.Top = 30;
            obj.Left = 30;
            MPKses.Add(obj);

            obj = new MPKs();
            obj.Top = 60;
            obj.Left = 130;
            MPKses.Add(obj);
        
        }

    }
}
