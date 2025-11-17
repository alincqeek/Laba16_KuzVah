using System.Data;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
        if (string.IsNullOrWhiteSpace(txtCurrency.Text))
        {
            MessageBox.Show("Введите сумму", "Информация",
                MessageBoxButton.OK, MessageBoxImage.Information);
            return;
        }

        if (cmbFromCurrency.SelectedIndex <= 0 || cmbToCurrency.SelectedIndex <= 0)
        {
            MessageBox.Show("Выберите валюты (из/в)", "Информация",
                MessageBoxButton.OK, MessageBoxImage.Information);
            return;
        }

        if (!decimal.TryParse(txtCurrency.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal amount) &&
                !decimal.TryParse(txtCurrency.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out amount))
        {
            MessageBox.Show("Неверный формат числа", "Ошибка",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        decimal fromValue = decimal.Parse(cmbFromCurrency.SelectedValue.ToString());
        decimal toValue = decimal.Parse(cmbToCurrency.SelectedValue.ToString());
        decimal result = (amount * fromValue) / toValue;

        lblCurrency.Content = $"{cmbToCurrency.Text} {result:N3}";
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
        var tb = txtCurrency;
        if (!Regex.IsMatch(e.Text, @"^[0-9.,]$"))
        {
            e.Handled = true;
            return;
        }

        if ((e.Text == "." && tb.Text.Contains(".")) ||
            (e.Text == "," && tb.Text.Contains(",")) ||
            (tb.Text.Contains(".") && e.Text == ".") ||
            (tb.Text.Contains(",") && e.Text == ","))
        {
            e.Handled = true;
        }
    }

    private void txtCurrency_TextChanged_1(object sender, TextChangedEventArgs e)
    {

    }
}