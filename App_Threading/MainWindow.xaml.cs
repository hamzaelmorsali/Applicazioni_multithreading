using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace App_Threading
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Btn_Task_Click(object sender, RoutedEventArgs e)
        {
            //DoWork();
            lbl_Risultato.Content = "";
            Task.Factory.StartNew(DoWork);

        }

        private void DoWork()
        {
            for (int i = 0; i <= 10000; i++)
            {
                for (int j = 0; j <= 100000; j++)
                {

                }
            }
            //AggiornaInterfaccia();
            Dispatcher.Invoke(AggiornaInterfaccia);
        }

        private void AggiornaInterfaccia()
        {
            lbl_Risultato.Content = "finito";
        }

        private void Btn_conta_Click(object sender, RoutedEventArgs e)
        {
            //DoCount();
            Task.Factory.StartNew(DoCount);
        }

        private void DoCount()
        {
            for (int i = 0; i <= 1000; i++)
            {
                for (int j = 0; j <= 1000; j++)
                {
                    Dispatcher.Invoke(()=>AggiornaInterfaccia(j));
                    Thread.Sleep(1000);
                }
            }
        }

        private void AggiornaInterfaccia(int j)
        {
            lbl_conta.Content = j.ToString();
        }
    }
}
