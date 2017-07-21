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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HCI_Assignment_New.Global;
using HCI_Assignment_New.Pages;
using MaterialDesignThemes.Wpf;
using Time_Table_Arranging_Program.Interfaces;
using Time_Table_Arranging_Program.UserInterface;

namespace HCI_Assignment_New {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public static Frame Frame;
        public MainWindow() {
            InitializeComponent();
            Frame = this.MainFrame;            
            MainFrame.Navigate(new Page_Login());           
        }

        private void ExtraMenuButton_OnClick(object sender , RoutedEventArgs e) {
            DrawerHost.IsRightDrawerOpen = true;
           

        }

        private void MainFrame_OnNavigating(object sender , NavigatingCancelEventArgs e) {
            if (e.Content.GetType() == (sender as Frame).Content?.GetType()) {
                e.Cancel = true;
                return;
            }
            var ta = new ThicknessAnimation {
                Duration = CustomAnimation.FullScreenAnimationDuration ,
                DecelerationRatio = CustomAnimation.DecelerationConstant ,
                To = new Thickness(0 , 0 , 0 , 0)
            };
            if (e.NavigationMode == NavigationMode.New || e.NavigationMode == NavigationMode.Forward) {
                ta.From = new Thickness(ActualWidth / 3 , 0 , 0 , 0);
            }
            else if (e.NavigationMode == NavigationMode.Back) {
                ta.From = new Thickness(0 , 0 , ActualWidth / 3 , 0);
            }
            ta.Completed += (o , args) => {
                var p = e.Content as IPageWithLoadedFunction;
                p?.ExecuteLoadedFunction();
            };
            (e.Content as Page)?.BeginAnimation(MarginProperty , ta);
        }
    }
}
