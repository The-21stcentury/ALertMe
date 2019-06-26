using System;
using System.Collections.Generic;
using System.Windows;

namespace ALertMe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///

    public partial class MainWindow : Window
    {
        private ClockEngine engine;

        Clocks clocks = new Clocks();
        public MainWindow()
        {
            engine = new ClockEngine(this);
            InitializeComponent();
            ComboBoxInitatinzer();
            //hourscombo.Text = "0";
            //minutescomb.Text = "0";
        }

        public void initializeClock()
        {
            hour_box.Content = engine.SetWatch().Stunde.ToString();
            mintues_box.Content = engine.SetWatch().Mintue.ToString();
            seconds_box.Content = engine.SetWatch().Sekunde.ToString();
            
        }

        private void Grid_LayoutUpdated(object sender, EventArgs e)
        {
            initializeClock();

            if (engine.MsgAlert(clocks))
            {

                engine.PlaySound();
                MessageBox.Show("Hey i do altering..");
            }
        }

        public void ComboBoxInitatinzer()
        {
            List<string> hours = new List<string>();
            for (int i = 1; i < 24; i++)
            {
                hours.Add(i.ToString());
            }
            hourscombo.ItemsSource = hours;
            List<string> mintues = new List<string>();
            for (int i = 1; i < 60; i++)
            {
                mintues.Add(i.ToString());
            }
            minutescomb.ItemsSource = mintues;
        }    

        private void Btn_Click(object sender, EventArgs e)
        {
            try
            {
                initializeClock();


                if (int.TryParse(hourscombo.Text, out int x) && int.TryParse(minutescomb.Text, out int y))
                {
                    clocks.Stunde = x;
                    clocks.Mintue = y;
                };

               
                    aktive.IsChecked = true;
                    btn.Content = "activated";
    

                lb.Content = $"Alert set at {clocks.Stunde} : {clocks.Mintue}";
                
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
}