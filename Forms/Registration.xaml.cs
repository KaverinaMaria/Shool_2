using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace School.Forms
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        SchoolProjectWPFEntities db = new SchoolProjectWPFEntities();
        public Registration()
        {
            InitializeComponent();
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text;
            DateTime bithday = dpBithday.DisplayDate;
            string email = tbEmail.Text;
            string login = tbLogin.Text;
            string password = tbPassword.Text;
            if (cbRole.Text == "Преподаватель")
            {
                var teacher = new Teachers { NameTeacher = name, LoginTeacher = login, PasswordTeacher = password, BithdayTeacher = bithday, EmailTeacher = email };
                db.Teachers.Add(teacher);
                db.SaveChanges();
                MessageBox.Show("Пользователь успешно зарегистрирован", "Сообщение", MessageBoxButton.OK);
            }
            else if (cbRole.Text == "Обучающийся")
            {
                var student = new Students { NameStudent = name, LoginStudent = login, PasswordStudent = password, BithdayStudent = bithday, EmailStudent = email };
                db.Students.Add(student);
                db.SaveChanges();
                MessageBox.Show("Пользователь успешно зарегистрирован", "Сообщение", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Ошибка! Выберите статус", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackUp_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
