using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Indicator_Light.UserControls
{
    /// <summary>
    /// IndicatorLight.xaml 的交互逻辑
    /// </summary>
    public partial class IndicatorLight : UserControl
    {
        private IndicatorType _IndicatorType = IndicatorType.Stop;
        [System.ComponentModel.Description("指示灯类别")]
        public IndicatorType Light { get => _IndicatorType; set => Draw(value); }

        private Brush StopColor = new SolidColorBrush(Colors.LightGray);

        private Brush RunningColorLight = new SolidColorBrush(Colors.LightSkyBlue);
        private Brush RunningColorDark = new SolidColorBrush(Colors.DodgerBlue);

        private Brush WarningColor = new SolidColorBrush(Colors.Orange);
        private Brush ErrorColor = new SolidColorBrush(Colors.OrangeRed);
        private Brush FatalColor = new SolidColorBrush(Colors.Red);
        System.Timers.Timer timerAlert = new System.Timers.Timer();

        int _dotloop = 1;
        bool _isInterval = true;

        public IndicatorLight()
        {
            InitializeComponent();
            timerAlert.Elapsed += TimerAlert_Elapsed;
        }

        private void Draw(IndicatorType type)
        {
            this._IndicatorType = type;

            switch (type)
            {
                case IndicatorType.Stop:
                    timerAlert.Stop();
                    Stop();
                    break;
                case IndicatorType.Start:
                    timerAlert.Interval = 500;  //正常工作
                    timerAlert.Start();
                    break;
                case IndicatorType.Warning:
                    timerAlert.Interval = 400;  //毫秒
                    timerAlert.Start();
                    break;
                case IndicatorType.Error:
                    timerAlert.Interval = 200;  //毫秒
                    timerAlert.Start();
                    break;
                case IndicatorType.Fatal:
                    timerAlert.Interval = 100;  //毫秒
                    timerAlert.Start();
                    break;
                default:
                    break;
            }
        }

        private void TimerAlert_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            switch (_IndicatorType)
            {
                case IndicatorType.Stop:
                    Stop();
                    break;
                case IndicatorType.Start:
                    Start();
                    break;
                case IndicatorType.Warning:
                    Warning();
                    break;
                case IndicatorType.Error:
                    Error();
                    break;
                case IndicatorType.Fatal:
                    Fatal();
                    break;
                default:
                    break;
            }
        }

        private void Stop()
        {
            Dispatcher.Invoke(new Action(() =>
            {
                label1.Foreground = StopColor;
                label2.Foreground = StopColor;
                label3.Foreground = StopColor;
                label4.Foreground = StopColor;
            }), System.Windows.Threading.DispatcherPriority.ApplicationIdle);
        }

        /// <summary>
        /// 
        /// </summary>
        private void Start()
        {
            Dispatcher.Invoke(new Action(() =>
            {

                switch (_dotloop)
                {
                    case 1:
                        label1.Foreground = RunningColorLight;
                        label2.Foreground = RunningColorDark;
                        label3.Foreground = RunningColorDark;
                        label4.Foreground = RunningColorDark;
                        _dotloop++;
                        break;
                    case 2:
                        label1.Foreground = RunningColorDark;
                        label2.Foreground = RunningColorLight;
                        label3.Foreground = RunningColorDark;
                        label4.Foreground = RunningColorDark;
                        _dotloop++;
                        break;
                    case 3:
                        label1.Foreground = RunningColorDark;
                        label2.Foreground = RunningColorDark;
                        label3.Foreground = RunningColorLight;
                        label4.Foreground = RunningColorDark;
                        _dotloop++;
                        break;
                    case 4:
                        label1.Foreground = RunningColorDark;
                        label2.Foreground = RunningColorDark;
                        label3.Foreground = RunningColorDark;
                        label4.Foreground = RunningColorLight;
                        _dotloop = 1;
                        break;
                }
            }), System.Windows.Threading.DispatcherPriority.ApplicationIdle);
        }

        private void Warning()
        {
            Dispatcher.Invoke(new Action(() =>
            {
                if (_isInterval)
                {
                    label1.Foreground = WarningColor;
                    label2.Foreground = WarningColor;
                    label3.Foreground = WarningColor;
                    label4.Foreground = WarningColor;
                }
                else
                {
                    label1.Foreground = StopColor;
                    label2.Foreground = StopColor;
                    label3.Foreground = StopColor;
                    label4.Foreground = StopColor;
                }
                _isInterval = !_isInterval;

            }), System.Windows.Threading.DispatcherPriority.ApplicationIdle);
        }

        private void Error()
        {
            Dispatcher.Invoke(new Action(() =>
            {
                if (_isInterval)
                {
                    label1.Foreground = ErrorColor;
                    label2.Foreground = ErrorColor;
                    label3.Foreground = ErrorColor;
                    label4.Foreground = ErrorColor;
                }
                else
                {
                    label1.Foreground = StopColor;
                    label2.Foreground = StopColor;
                    label3.Foreground = StopColor;
                    label4.Foreground = StopColor;
                }
                _isInterval = !_isInterval;

            }), System.Windows.Threading.DispatcherPriority.ApplicationIdle);
        }
        private void Fatal()
        {
            Dispatcher.Invoke(new Action(() =>
            {
                if (_isInterval)
                {
                    label1.Foreground = FatalColor;
                    label2.Foreground = FatalColor;
                    label3.Foreground = FatalColor;
                    label4.Foreground = FatalColor;
                }
                else
                {
                    label1.Foreground = StopColor;
                    label2.Foreground = StopColor;
                    label3.Foreground = StopColor;
                    label4.Foreground = StopColor;
                }
                _isInterval = !_isInterval;

            }), System.Windows.Threading.DispatcherPriority.ApplicationIdle);
        }
    }
}
