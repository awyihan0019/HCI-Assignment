using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MaterialDesignThemes.Wpf;

namespace HCI_Assignment_New.Global {    
        public static class DialogBox {
            private static DialogHost _dialogHost;
            private static TextBlock _titleBlock;
            private static TextBlock _messageBlock;
            private static Button _okButton;

            public static void Initialize(DialogHost dialogHost , TextBlock titleBlock , TextBlock messageBlock ,
                                          Button OkButton) {
                _dialogHost = dialogHost;
                _titleBlock = titleBlock;
                _messageBlock = messageBlock;
                _okButton = OkButton;
            }

            public static void ShowDialog(string title , string message , string buttonMessage = "Got it!") {
                _titleBlock.Text = title;
                _messageBlock.Text = message;
                _okButton.Content = buttonMessage;
                _dialogHost.IsOpen = true;
            }
        }
    
}
