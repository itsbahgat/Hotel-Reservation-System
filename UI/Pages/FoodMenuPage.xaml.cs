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

namespace HotelManagementSystem.Pages
{
    public partial class FoodMenuPage : Window
    {
        public event EventHandler<FoodMenuDataEventArgs> FoodMenuDataReturned;

        public FoodMenuPage()
        {
            InitializeComponent();
        }   
        

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            //this.Close();
            this.Visibility = Visibility.Hidden;

        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            int[] foodSelection = new int[3];
            bool[] specialNeeds = new bool[3];

            foodSelection[0] = int.TryParse(breakfastTxt.Text, out int breakfastValue) ? breakfastValue : 0;
            foodSelection[1] = int.TryParse(dinnerTxt.Text, out int dinnerValue) ? dinnerValue : 0;
            foodSelection[2] = int.TryParse(lunchTxt.Text, out int lunchValue) ? lunchValue : 0;

            specialNeeds[0] = (bool)CleaningCheckbox.IsChecked;
            specialNeeds[1] = (bool)TowelsCheckbox.IsChecked;
            specialNeeds[2] = (bool)SSurpriseCheckbox.IsChecked;


            FoodMenuDataReturned?.Invoke(this, new FoodMenuDataEventArgs(foodSelection, specialNeeds));
            this.Visibility = Visibility.Hidden;

        }

        private void EnableBreakfastTextBox(object sender, RoutedEventArgs e)
        {
            breakfastTxt.IsReadOnly = false;
        }

        private void DisableBreakfastTextBox(object sender, RoutedEventArgs e)
        {
            breakfastTxt.Text = null;
            breakfastTxt.IsReadOnly = true;
        }

        private void EnableDinnerTextBox(object sender, RoutedEventArgs e)
        {
            dinnerTxt.IsReadOnly = false;

        }

        private void DisableDinnerTextBox(object sender, RoutedEventArgs e)
        {
            dinnerTxt.Text = null;
            dinnerTxt.IsReadOnly = true;

        }

        private void EnableLunchTextBox(object sender, RoutedEventArgs e)
        {
            lunchTxt.IsReadOnly = false;
        }

        private void DisableLunchTextBox(object sender, RoutedEventArgs e)
        {
            lunchTxt.Text = null;
            lunchTxt.IsReadOnly = true;
        }

 
    }

    public class FoodMenuDataEventArgs : EventArgs
    {
        public int[] FoodSelection { get; set; }
        public bool[] SpecialNeeds { get; set; }

        public FoodMenuDataEventArgs(int[] foodSelection, bool[] specialNeeds)
        {
            FoodSelection = foodSelection;
            SpecialNeeds = specialNeeds;
        }
    }

}
