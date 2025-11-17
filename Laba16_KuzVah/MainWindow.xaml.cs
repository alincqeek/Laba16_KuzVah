using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Data;

namespace Laba16_KuzVah;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        ClearControls();
        BindCurrency();
    }

    private void BindCurrency()
    {
        DataTable dtCurrency = new DataTable();
        dtCurrency.Columns.Add("Text");
        dtCurrency.Columns.Add("Value");
        dtCurrency.Rows.Add("RUB",1.2);
        dtCurrency.Rows.Add("INR",1);
        dtCurrency.Rows.Add("USD",75);
        dtCurrency.Rows.Add("EUR",85);
        dtCurrency.Rows.Add("SAR",20);
        dtCurrency.Rows.Add("POUND",5);
        dtCurrency.Rows.Add("DEM",43);

        cmbFromCurrency.ItemsSource = dtCurrency.DefaultView;
        cmbFromCurrency.DisplayMemberPath = "Text";
        cmbFromCurrency.SelectedValuePath = "Value";
        cmbFromCurrency.SelectedIndex= 0;

        cmbFromCurrency.ItemsSource = dtCurrency.DefaultView;
        cmbFromCurrency.DisplayMemberPath = "Text";
        cmbFromCurrency.SelectedValuePath = "Value";
        cmbFromCurrency.SelectedIndex = 0;

    }

    private void ClearControls()
    {
       txtCurrency.Text=string.Empty;
        if (cmbFromCurrency.Items.Count > 0) cmbFromCurrency.SelectedIndex = 0;
        if (cmbToCurrency.Items.Count > 0) cmbToCurrency.SelectedIndex = 0;
        lblCurrency.Content = "";
        txtCurrency.Focus();

    }

    private void Convert_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(txtCurrency.Text)) { MessageBox.Show("Please enter amount"); return; }
        if (cmbFromCurrency.SelectedIndex <= 0 || cmbToCurrency.SelectedIndex <= 0)
        {
            MessageBox.Show("Please select currencies"); return;
        }
        double amount = double.Parse(txtCurrency.Text);
        double fromValue = double.Parse(cmbFromCurrency.SelectedValue.ToString());

        
    }
     
    private void Clear_Click(object sender, RoutedEventArgs e)
    {
        ClearControls();
    }

    private void cmbFromCurrency_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void txtCurrency_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void cmbToCurrency_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        
    }

    private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
    {
       
    }

    private void txtCurrency_TextChanged_1(object sender, TextChangedEventArgs e)
    {

    }
}