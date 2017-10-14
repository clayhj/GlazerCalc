using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GlazerCalc
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            tintComboBox.Items.Add("Black");
            tintComboBox.Items.Add("Brown");
            tintComboBox.Items.Add("Blue");
            tintComboBox.SelectedIndex = 1;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            const double MAX_WIDTH = 5.0;
            const double MIN_WIDTH = 0.5;
            const double MAX_HEIGHT = 3.0;
            const double MIN_HEIGHT = 0.75;

            

            double width;
            double height;
            widthInput.Background = new SolidColorBrush(Colors.White);
            heightInput.Background = new SolidColorBrush(Colors.White);

            if (!double.TryParse(widthInput.Text, out width) || !double.TryParse(heightInput.Text, out height))
            {
                
                if (!double.TryParse(widthInput.Text, out width))
                {
                    widthInput.Background = new SolidColorBrush(Colors.Red);
                    var msg = new MessageDialog("Make sure Width is not empty and that there are not multiple dots.");

                    await msg.ShowAsync();

                }
                if (!double.TryParse(heightInput.Text, out height))
                {
                    heightInput.Background = new SolidColorBrush(Colors.Red);
                    var msg = new MessageDialog("Make sure Height is not empty and that there are not multiple dots.");

                    await msg.ShowAsync();
                }
            }
            else if (double.Parse(widthInput.Text) < MIN_WIDTH || double.Parse(widthInput.Text) > MAX_WIDTH || double.Parse(heightInput.Text) < MIN_HEIGHT || double.Parse(heightInput.Text) > MAX_HEIGHT)
            {
                if (double.Parse(widthInput.Text) < MIN_WIDTH || double.Parse(widthInput.Text) > MAX_WIDTH)
                {
                    widthInput.Background = new SolidColorBrush(Colors.Red);
                    var msg = new MessageDialog("Width must be between 0.5 and 5.0");
                    await msg.ShowAsync();
                }

                if (double.Parse(heightInput.Text) < MIN_HEIGHT || double.Parse(heightInput.Text) > MAX_HEIGHT)
                {
                    heightInput.Background = new SolidColorBrush(Colors.Red);
                    var msg = new MessageDialog("Height must be between 0.75 and 3.0");
                    await msg.ShowAsync();
                }
            }
            else
            {


                Order order = new Order();

                order.Width = double.Parse(widthInput.Text);
                order.Height = double.Parse(heightInput.Text);
                order.Tint = Convert.ToString(tintComboBox.SelectedValue);
                order.Amount = Convert.ToInt32(amountSlider.Value);
                order.Date = DateTime.Now;

                this.Frame.Navigate(typeof(DisplayOrder), order);
            }
        }

        private void Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            amountValueDisplay.Text = amountSlider.Value.ToString();
        }

        private void widthInput_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.Key.ToString(), "[0-9.]"))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void heightInput_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.Key.ToString(), "[0-9.]"))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
