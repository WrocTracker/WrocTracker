using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Devices.Geolocation;
using Windows.Devices.Sensors;
using Windows.Foundation;
using Windows.UI.Core;
using TrackerApp1.Annotations;
using TrackerApp1.ViewModels;
using TrackerApp1;

namespace TrackerApp1.Commands
{
    public class ClickCommand : ICommand
    {
        private Random _rand = new Random(DateTime.Now.Millisecond);
        public event EventHandler CanExecuteChanged;
        private MainPageViewModel _viewModel;
        private Accelerometer _accelerometr;
        private Compass _compass;

        public ClickCommand(MainPageViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            var localizator = new Geolocator();
            var position = await localizator.GetGeopositionAsync();


            var tracker = new TrackerForWindowsPhoneClassLibrary.Tracker();

            var tram4 = tracker.GetPositions("10");

            _compass = Compass.GetDefault();
            _compass.ReadingChanged += ReadingChanged;


            //   _viewModel.TextBlockText1 = tram4.First().Position.Latitude + ", " + tram4.First().Position.Longitude;
            //    _viewModel.TextBlockText2 = position.Coordinate.Point.Position.Latitude + ", " + position.Coordinate.Point.Position.Longitude;
            //  _viewModel.TextBlockText2 = sdsd.HeadingTrueNorth.ToString();
            // _viewModel.TextBlockText4 = sdsd.HeadingMagneticNorth.ToString();

            //    var distance = PositionHelper.CalculateDistance(new Point(position.Coordinate.Latitude, position.Coordinate.Longitude), new Point(tram4.First().Position.Latitude, tram4.First().Position.Longitude));

            //      _viewModel.TextBlockText3 = distance.ToString();



            var obj = new MainPageViewModel.MPKs();
            obj.Top = 130;
            obj.Left = 60;
            _viewModel.MPKses.Add(obj);
            var wqeasd = new List<MainPageViewModel.MPKs>(_viewModel.MPKses);
            _viewModel.MPKses = wqeasd;


            _accelerometr = Accelerometer.GetDefault();

        }

        private void ReadingChanged(Compass sender, CompassReadingChangedEventArgs args)
        {
            Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                _viewModel.Angle = _compass.GetCurrentReading().HeadingMagneticNorth;
            });
        }

        private void SOmemethod(Accelerometer sender, AccelerometerReadingChangedEventArgs args)
        {
            var accReading = _accelerometr.GetCurrentReading();
            _viewModel.TextBlockText4 = accReading.AccelerationX + ",   " + accReading.AccelerationY + ",   " + accReading.AccelerationZ;

        }
    }
}
