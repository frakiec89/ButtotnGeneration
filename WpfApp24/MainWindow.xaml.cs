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

namespace WpfApp24
{
       public partial class MainWindow : Window
    {

        private int count = 3;
        private int index = 0;
        List<string> Strings = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 1; i <= 71; i++)
            {
                Strings.Add("контент " + i);
            }
            lbTest.ItemsSource = Strings.Skip(index * count).Take(count);
            ButtonGeneration();
        }

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            var b = (Button)sender;
            switch (b.Name)
            {
                case "btnDown": DownConetnt();
                    break;
                case "btnUP":  UpConetnt (); break;
                    default: BtnGo(b);break;

                    // dfndjkfbdj
            }
        }

        private void BtnGo(Button b)
        {
            RefrashColor();

            b.Background = Brushes.Red;
            index = Convert.ToInt32(b.Content) - 1;
            lbTest.ItemsSource = Strings.Skip(index * count).Take(count);
        }

       

        private void UpConetnt()
        {
            int max = MaxIndex();

            if (index < max - 1)
            {
                index++;
                lbTest.ItemsSource = Strings.Skip(index * count).Take(count);
                NextColorButton();
            }
        }
        private int MaxIndex()
        {
            decimal d = (decimal)Strings.Count / (decimal)count;
            int max = (int)Math.Ceiling(d);
            return max;
        }

        private void DownConetnt()
        {
            if(index >0)
            {
                index--;
                lbTest.ItemsSource = Strings.Skip(index*count).Take(count);
                NextColorButton();
            }
        }


        public void ButtonGeneration ()
        {
            for (int i = 0; i < MaxIndex(); i++)
            {
                var b = new Button();
                b.Name = "bt" + i.ToString();
                b.Content = (i+1).ToString();
                b.Margin = new Thickness(5);
                b.Padding= new Thickness(5);
                b.Click += btnDown_Click;

                if(i==0)
                {
                    b.Background = new SolidColorBrush(Colors.Red);
                }
                spButton.Children.Add(b);
            }
        }

        private void RefrashColor()
        {
            foreach (var item in spButton.Children)
            {
                var b = item as Button;
                b.Background = Brushes.White;
            }
        }

        private void NextColorButton()
        {
            RefrashColor();
            foreach (var item in spButton.Children)
            {
                var b = item as Button;
                if (b.Content == (index + 1).ToString())
                    b.Background = Brushes.Red;
            }
        }
    }
}
