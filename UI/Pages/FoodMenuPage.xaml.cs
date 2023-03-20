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
            this.Close();
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            int[] foodSelection = new int[3];
            bool[] specialNeeds = new bool[3];

            int.TryParse(breakfastTxt.Text, out foodSelection[0]);
            int.TryParse(breakfastTxt.Text, out foodSelection[1]);
            int.TryParse(breakfastTxt.Text, out foodSelection[2]);

            specialNeeds[0] = (bool)CleaningCheckbox.IsChecked;
            specialNeeds[1] = (bool)TowelsCheckbox.IsChecked;
            specialNeeds[2] = (bool)SSurpriseCheckbox.IsChecked;


            FoodMenuDataReturned?.Invoke(this, new FoodMenuDataEventArgs(foodSelection, specialNeeds));
            this.Close();

        }

        private void EnableBreakfastTextBox(object sender, RoutedEventArgs e)
        {
            breakfastTxt.IsReadOnly = false;
        }

        private void DisableBreakfastTextBox(object sender, RoutedEventArgs e)
        {
            breakfastTxt.Text = string.Empty;
            breakfastTxt.IsReadOnly = true;
        }

        private void EnableDinnerTextBox(object sender, RoutedEventArgs e)
        {
            dinnerTxt.IsReadOnly = false;

        }

        private void DisableDinnerTextBox(object sender, RoutedEventArgs e)
        {
            dinnerTxt.Text = string.Empty;
            dinnerTxt.IsReadOnly = true;

        }

        private void EnableLunchTextBox(object sender, RoutedEventArgs e)
        {
            lunchTxt.IsReadOnly = false;
        }

        private void DisableLunchTextBox(object sender, RoutedEventArgs e)
        {
            lunchTxt.Text = string.Empty;
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
