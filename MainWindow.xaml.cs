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

namespace School
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SchoolProjectWPFEntities db = new SchoolProjectWPFEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Registr_Click(object sender, RoutedEventArgs e)
        {
            Forms.Registration registration = new Forms.Registration();
            registration.Show();
            this.Close();
        }

        private void Input_Click(object sender, RoutedEventArgs e)
        {
            var login = tbLogin.Text;
            var pass = pbPassword.Password;

            var teacher = db.Teachers.Where(t => t.LoginTeacher == login && t.PasswordTeacher == pass).FirstOrDefault();
            var student = db.Students.Where(s => s.LoginStudent == login && s.PasswordStudent == pass).FirstOrDefault();
            if (teacher != null)
            {
                Forms.AccountTeacher account = new Forms.AccountTeacher();
                account.Show();
                this.Close();
            }
            else if (student != null)
            {
                Forms.AccountStudent account = new Forms.AccountStudent();
                account.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Пользователь не идентифицирован в системе", "Ошибка системы", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
