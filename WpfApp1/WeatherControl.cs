using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    enum Precipitation
    {
        sunny,
        cloudy,
        rain,
        snow
    }
    class WeatherControl:DependencyObject
    {
        public static readonly DependencyProperty TemperatureProperty;
        private string directionWind;
        public static readonly DependencyProperty SpeedWindProperty;
        private Precipitation precipitation;

        public int Temperature
        {
            get => (int)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }
        public string DirectionWind
        {
            get => directionWind;
            set => directionWind = value;
        }
          public int SpeedWind
        {
            get => (int)GetValue(SpeedWindProperty);
            set => SetValue(SpeedWindProperty, value);
        }
        public WeatherControl(int temperature, string directionWind, int speedWind, Precipitation precipitation)
        {
            this.Temperature = temperature;
            this.DirectionWind = directionWind;
            this.SpeedWind = speedWind;
            this.precipitation = precipitation;
        }
        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperature),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemperature)),
                new ValidateValueCallback(ValidateTemperature));

            SpeedWindProperty = DependencyProperty.Register(
                nameof(SpeedWind),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceSpeedWind)),
                new ValidateValueCallback(ValidateSpeedWind));
        }

        private static bool ValidateSpeedWind(object value)
        {
            int s = (int)value;
            if (s >= 0 && s <= 100)
            {
                return true;
            }
            else
                return false;
        }

        private static object CoerceSpeedWind(DependencyObject d, object baseValue)
        {
            int s = (int)baseValue;
            if (s >= 0)
            {
                return s;
            }
            else
                return 0;
        }

        private static bool ValidateTemperature(object value)
        {
            int t = (int)value;
            if (t >= -50 && t <= 50)
            {
                return true;
            }
            else
                return false;
        }

        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            int t = (int)baseValue;
            if (t >= -50 && t <= 50)
            {
                return t;
            }
            else
                return null;
        }
    }
}
