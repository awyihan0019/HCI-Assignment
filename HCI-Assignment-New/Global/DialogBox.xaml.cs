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
using System.Windows.Shapes;

namespace HCI_Assignment_New.Global {
    /// <summary>
    /// Interaction logic for DialogBoxx.xaml
    /// </summary>
    public partial class DialogBox : Window {
        public enum Result {
            LeftButtonClicked,
            RightButtonClicked
        }

        private Result _result;
        public DialogBox() {
            InitializeComponent();
        }

        public static Result Show(string title, string message, string leftButtonText, string rightButtonText=null) {
            var p = new DialogBox();
            p.SetContent(title, message, leftButtonText, rightButtonText);
            p.DialogHost.IsOpen = true;
            p.ShowDialog();
     
            return p._result;
        }
        private void SetContent(string title , string message , string leftButtonText , string rightButtonText) {
            Button_Right.Visibility = rightButtonText == null ? Visibility.Collapsed : Visibility.Visible;
            TextBlock_Title.Text = title;
            TextBlock_Message.Text = message;
            Button_Left.Content = leftButtonText;
            Button_Right.Content = rightButtonText;            
        }

        private void Button_Left_OnClick(object sender, RoutedEventArgs e) {
            _result = Result.LeftButtonClicked;
            this.Hide();
        }

        private void Button_Right_OnClick(object sender, RoutedEventArgs e) {
            _result = Result.RightButtonClicked;
            this.Hide();
        }

        private void SampleCode() {
            var result = DialogBox.Show("Title" , "message" , "OK" , "Cancel");
            switch (result) {
                case DialogBox.Result.LeftButtonClicked:
                    MessageBox.Show("You clicked left button");
                    break;
                case DialogBox.Result.RightButtonClicked:
                    MessageBox.Show("you clicked right button");
                    break;

            }
        }
    }
}
