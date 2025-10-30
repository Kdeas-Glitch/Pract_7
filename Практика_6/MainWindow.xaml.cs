using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Практика_6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private People CurrentUser = new People();

        public MainWindow()
        {
            InitializeComponent();
            Application.Current.Resources["CurrentUser"] = CurrentUser;
            DataContext = CurrentUser;
        }

        private void MessageUser(object sender, RoutedEventArgs e)
        {
            try
            {
                var currentUser = (People)Application.Current.Resources["CurrentUser"];
                string jsonString = JsonSerializer.Serialize(currentUser);
                int i = 0;
                while (true)
                {
                    if (File.Exists($"D_{i.ToString().PadLeft(5, '0')}.json"))
                    {
                        i++;
                    }
                    else
                    {
                        break;
                    }
                }
                string fileName = $"D_{i.ToString().PadLeft(5, '0')}.json";
                File.WriteAllText(fileName, jsonString);
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
        private void Login(object sender, RoutedEventArgs e)
        {
            try
            {
                int i = Convert.ToInt32(_ID.Text.ToString());
                    string fileName = $"D_{i.ToString().PadLeft(5, '0')}.json";
                if (File.Exists(fileName))
                {
                    string jsonString = File.ReadAllText(fileName);
                    People people =JsonSerializer.Deserialize<People>(jsonString)!;
                    if (people != null)
                    {

                        if (people.Password == _Password.Text.ToString())
                        {
                            ID.Content = i.ToString().PadLeft(5, '0');
                            FIO.Content = $"{people.Name} {people.Last_Name} {people.Middle_Name}";
                            Spec.Content = people.Specialisation;
                            Pass.Content = people.Password;
                        }
                        else
                        {
                            MessageBox.Show("Неверный пароль");

                        }
                    }
                    else
                    {
                        MessageBox.Show("Пусто(");
                    }

                }
                else
                {
                    MessageBox.Show("Такого id нет");
                }
            }
            catch (IOException a)
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void DeleteUser(object sender, RoutedEventArgs e)
        {
            var currentUser = (People)Application.Current.Resources["CurrentUser"];
            currentUser.Name = "";
            currentUser.Last_Name = "";
            currentUser.Middle_Name = "";
            currentUser.Password="";
            currentUser.Specialisation = "";
        }
    }
}