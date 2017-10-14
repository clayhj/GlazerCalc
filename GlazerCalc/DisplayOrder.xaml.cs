using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GlazerCalc
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DisplayOrder : Page
    {
        public DisplayOrder()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Order order = e.Parameter as Order;

            widthDisplay.Text = order.Width.ToString();
            heightDisplay.Text = order.Height.ToString();
            woodLengthDisplay.Text = order.WoodLength().ToString();
            glassAreaDisplay.Text = order.GlassArea().ToString();
            tintDisplay.Text = order.Tint;
            amountDisplay.Text = order.Amount.ToString();
            dateDisplay.Text = order.Date.ToString();
        }

    }
}
