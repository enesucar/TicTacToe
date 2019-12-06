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

namespace TicTacToe
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            close.Source = new BitmapImage(new Uri(@"/img/close.png", UriKind.Relative));
            newgamebutton.Source = new BitmapImage(new Uri(@"/img/newg.png", UriKind.Relative));
        }

        TicTacToeGame tic = new TicTacToeGame();
        private void rowClick_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock txt = (TextBlock)sender;
            
            int x, y;
            GetHorizantalandVerticalNO(out x, out y, txt.Name.ToString());
            infolbl.Visibility = Visibility.Hidden;
            if(txt.Text == "" && tic.Next == 'X')
            {
                Color color = (Color)ColorConverter.ConvertFromString("#FF545454");
                txt.Foreground = new SolidColorBrush(color);
                txt.Text = tic.Next.ToString();
                tic.Next = 'O';
                tic.SetMatrix(x, y, 'X');
            }

            else if (txt.Text == "" && tic.Next == 'O')
            {
                Color color = (Color)ColorConverter.ConvertFromString("#FFF2EBD3");
                txt.Foreground = new SolidColorBrush(color);

                txt.Text = tic.Next.ToString();
                tic.Next = 'X';
                tic.SetMatrix(x, y, 'O');
            }

            if(tic.Update() == "truexVertical" || tic.Update() == "truexHorizontal" || tic.Update() == "truexCross")
            {
                infolbl.Visibility = Visibility.Visible;
                infolbl.Text = "X WIN!";
                DeleteLabel();
                tic.XPoint++;
                tic.Reset();
            }

            else if (tic.Update() == "trueoVertical" || tic.Update() == "trueoHorizontal" || tic.Update() == "trueoCross")
            {
                infolbl.Visibility = Visibility.Visible;
                infolbl.Text = "O WIN!";
                DeleteLabel();
                tic.OPoint++;
                tic.Reset();
                
            }
            else if (tic.Update() == "draw")
            {
                infolbl.Visibility = Visibility.Visible;
                infolbl.Text = "DRAW!";
                DeleteLabel();
                tic.Reset();
                
            }

            xpointlbl.Content = "X: " + tic.XPoint;
            opointlbl.Content = "O: " + tic.OPoint;
        }

        private void GetHorizantalandVerticalNO(out int horizantal, out int vertical,string name)
        {
            horizantal = 2;
            vertical = 2;

            if (name == "_1")
            {
                horizantal = 0;
                vertical = 0;
            }

            else if (name == "_2")
            {
                horizantal = 0;
                vertical = 1;
            }

            else if (name == "_3")
            {
                horizantal = 0;
                vertical = 2;
            }

            else if (name == "_4")
            {
                horizantal = 1;
                vertical = 0;
            }

            else if (name == "_5")
            {
                horizantal = 1;
                vertical = 1;
            }

            else if (name == "_6")
            {
                horizantal = 1;
                vertical = 2;
            }

            else if (name == "_7")
            {
                horizantal = 2;
                vertical = 0;
            }

            else if (name == "_8")
            {
                horizantal = 2;
                vertical = 1;
            }

            else if (name == "_9")
            {
                horizantal = 2;
                vertical = 2;
            }
        }

        private void DeleteLabel()
        {
            _1.Text = "";
            _2.Text = "";
            _3.Text = "";
            _4.Text = "";
            _5.Text = "";
            _6.Text = "";
            _7.Text = "";
            _8.Text = "";
            _9.Text = "";
        }

        private void Exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Close_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Newgamebutton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            tic.OPoint = 0;
            tic.XPoint = 0;
            xpointlbl.Content = "X: 0";
            opointlbl.Content = "O: 0";
            infolbl.Visibility = Visibility.Hidden;
            DeleteLabel();
            tic.Reset();
        }
    }
}
