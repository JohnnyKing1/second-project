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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int w = 30;
        const int h = 30;
        Rectangle[,] pole = new Rectangle[w, h];
        public MainWindow()
        {
            InitializeComponent();
            plane(w,h,300,300);
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            int[,] a = new int[h, w];
            int count;
            int w_1, h_1, w2, h2;

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    count = 0;
                    w_1 = j-1; h_1 = i-1; w2 = j+1; h2 = i+1;

                    if (w_1 < 0) 
                        w_1 = w - 1;
                    if (h_1 < 0)
                        h_1 = h - 1;
                    if (w2 == w)
                        w2 = 0;
                    if (h2 == h)
                        h2 = 0;

                    if (pole[h_1,w_1].Fill == Brushes.Red) count++;
                    if (pole[h_1,j].Fill == Brushes.Red) count++;
                    if (pole[h_1,w2].Fill == Brushes.Red) count++;
                    if (pole[i,w_1].Fill == Brushes.Red) count++;
                    if (pole[i,w2].Fill == Brushes.Red) count++;
                    if (pole[h2,w_1].Fill == Brushes.Red) count++;
                    if (pole[h2,j].Fill == Brushes.Red) count++;
                    if (pole[h2,w2].Fill == Brushes.Red) count++;

                    a[i, j] = count;
                }
            }

            for (int i = 0; i < h; i++) 
            {
                for (int j = 0; j < w; j++) 
                {
                    if (a[i, j] < 2 || a[i, j] > 3)
                    {
                        pole[i, j].Fill = Brushes.Green;
                    }
                    else if(a[i, j] == 3)
                    {
                        pole[i, j].Fill = Brushes.Red;
                    }                      
                }
            }

        }

        private void R_Mouse_Down(object sender, RoutedEventArgs e) 
        {
            ((Rectangle)sender).Fill = (((Rectangle)sender).Fill == Brushes.Green) ? Brushes.Red : Brushes.Green;
        }
        void plane(int w, int h, int width, int height)
        {
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    Rectangle r = new Rectangle();
                    r.Width = width / w - 2.0;
                    r.Height = height / h - 2.0;
                    r.Fill = Brushes.Green;
                    Canvas1.Children.Add(r);
                    Canvas.SetLeft(r, j * width / w);
                    Canvas.SetTop(r, i * height / h);
                    r.MouseDown += R_Mouse_Down;

                    pole[i, j] = r;
                }
            }
        }
    }
}
