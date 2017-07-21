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
using MaterialDesignThemes.Wpf;

namespace HCI_Assignment_New.Control {
    /// <summary>
    /// Interaction logic for DialogBox.xaml
    /// </summary>
    public partial class DialogBox : UserControl {
        public enum DialogResult {
            LeftButtonClicked,
            RightButtonClicked
        }
        public DialogBox() {
            InitializeComponent();
        }

        private static DialogBox _singleton;

        public DialogResult Result { get; private set; }
        private static DialogHost _host;
        public static void Initialize(DialogHost h) {            
            _host = h;            
            _singleton = new DialogBox();
            _host.DialogContent = new DialogBox();
        }

        /// <summary>
        /// If rightButton is not set, then it will not be shown
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="leftButtonText"></param>
        /// <param name="rightButtonText"></param>
        public static void Show(string title, string message, string leftButtonText, string rightButtonText=null) {            
            _singleton.SetContent(title, message, leftButtonText,rightButtonText);
            _host.IsOpen = true;
        }

        private void SetContent(string title, string message, string leftButtonText, string rightButtonText) {
            Button_Right.Visibility = rightButtonText == null ? Visibility.Collapsed : Visibility.Visible;
            TextBlock_Title.Text = title;
            TextBlock_Message.Text = message;
            Button_Left.Content = leftButtonText;
            Button_Right.Content = rightButtonText;
            _host.DialogContent = this;
        }

        private void Button_Left_OnClick(object sender, RoutedEventArgs e) {
            Result = DialogResult.LeftButtonClicked;
            _host.IsOpen = false;
        }

        private void Button_Right_OnClick(object sender, RoutedEventArgs e) {
            Result = DialogResult.RightButtonClicked;
            _host.IsOpen = false;
        }
    }
}
