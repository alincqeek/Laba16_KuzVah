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

namespace DZ
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

        private void Zaregat_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Okoshko1.Text) & !string.IsNullOrEmpty(Okoshko2.Text) & !string.IsNullOrEmpty(Okoshko3.Password))
            {
                if (int.TryParse(Okoshko2.Text, out int age))
                {
                    if (age > 1 && age < 121)
                    {
                        if (Okoshko3.Password.Length > 6)
                        {
                            MessageBox.Show("Регистрация прошла успешна!");
                            Okoshko1.Clear();
                            Okoshko2.Text = "";
                            Okoshko3.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Пароль должен быть длиной не менее 6 символов");
                            Okoshko3.Clear();
                        }
                    }
                    else
                    {
                        Okoshko2.Text = "";
                        MessageBox.Show("Введите корректный возраст (1-120)");
                    }
                }
            }
            else
            {
                MessageBox.Show("Есть пустые поля");
            }
        }

        private void Okoshko2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);
        }
    }
}