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

namespace dz_24._11._2021
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        List<double> l1 = new List<double>();
        List<string> l2 = new List<string>();
        bool flag = true;
        private void numClick(object sender, RoutedEventArgs e)
        {
            if (!flag)
            {
                flag = true;
                tb2.Text = "";
            }
            string st = tb2.Text;

            if (((Button)sender).Content.Equals(",") && st.Contains(",")) ;
            else
            {
                if (st.Equals("0") || st.Equals("∞")) tb2.Text = "";
                tb2.Text += ((Button)sender).Content;
            }


        }
        private void bClick(object sender, RoutedEventArgs e)
        {
            string st = ((Button)sender).Content.ToString();
            if (flag)
            {
                l1.Add(Convert.ToDouble(tb2.Text));
                tb1.Text += tb2.Text + st;
                l2.Add(st);

                if (st.Equals("="))
                {
                    tb1.Text = "";
                    double res = 0, x = l1.Last();
                    for (int i = 0; i < l2.Count - 1; i++)
                    {
                        tb1.Text += l1[i];
                        tb1.Text += l2[i];
                        switch (l2[i])
                        {
                            case "+": res = Convert.ToDouble(l1[i]) + Convert.ToDouble(l1[i + 1]); l1[i + 1] = res; break;
                            case "-": res = Convert.ToDouble(l1[i]) - Convert.ToDouble(l1[i + 1]); l1[i + 1] = res; break;
                            case "*": res = Convert.ToDouble(l1[i]) * Convert.ToDouble(l1[i + 1]); l1[i + 1] = res; break;
                            case "/": res = Convert.ToDouble(l1[i]) / Convert.ToDouble(l1[i + 1]); l1[i + 1] = res; break;
                            default:
                                break;
                        }
                    }
                    tb1.Text += x;
                    tb1.Text += "=";
                    if (l2.Count == 1) tb2.Text = x.ToString();
                    else { tb2.Text = res.ToString(); }
                    l1 = new List<double> { };
                    l2 = new List<string> { };


                }
                else flag = false;

            }
            else
            {
                tb1.Text = tb1.Text.Remove(tb1.Text.Length - 1);
                tb1.Text += st;
                l2[l2.Count - 1] = st;
            }
        }

        private void bCE_Click(object sender, RoutedEventArgs e)
        {
            if (!flag) tb2.Text = "0";
            else bC_Click(sender, e);
        }

        private void bC_Click(object sender, RoutedEventArgs e)
        {
            tb2.Text = "0";
            tb1.Text = "";
            l1 = new List<double>();
            l2 = new List<string>();
        }

        private void bBackspace_Click(object sender, RoutedEventArgs e)
        {
            if (tb2.Text.Length > 0)
            {
                tb2.Text = tb2.Text.Remove(tb2.Text.Length - 1);
            }
            else { tb2.Text = "0"; }

        }
    }
}
