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
using HCI_Assignment_New.Global;

namespace HCI_Assignment_New.Pages {
    /// <summary>
    /// Interaction logic for Page_Login.xaml
    /// </summary>
    public partial class Page_Login : Page {
        public Page_Login() {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e) {
            DialogBox.Show("Hey", "You are hacker", "OK", "LOL");
            if (DialogBox.Result == DialogBox.ResultEnum.LeftButtonClicked) {
                MessageBox.Show("left button clicked");
            }
            else {
                MessageBox.Show("right button clicked");
            }
        }
    }
}
