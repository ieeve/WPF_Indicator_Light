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

namespace WPF_Indicator_Light
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            this.indicatorLight.LightType = UserControls.IndicatorType.Stop;
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            this.indicatorLight.LightType = UserControls.IndicatorType.Start;
        }

        private void wranning_Click(object sender, RoutedEventArgs e)
        {
            this.indicatorLight.LightType = UserControls.IndicatorType.Warning;
        }

        private void error_Click(object sender, RoutedEventArgs e)
        {
            this.indicatorLight.LightType = UserControls.IndicatorType.Error;
        }

        private void Fatal_Click(object sender, RoutedEventArgs e)
        {
            this.indicatorLight.LightType = UserControls.IndicatorType.Fatal;
        }
    }
}
