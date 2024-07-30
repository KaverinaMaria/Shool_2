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
using System.Windows.Shapes;
using System.Xml.Linq;

namespace School.Forms
{
    /// <summary>
    /// Логика взаимодействия для ListStudents.xaml
    /// </summary>
    public partial class ListStudents : Window
    {
        SchoolProjectWPFEntities db = new SchoolProjectWPFEntities();
        public ListStudents()
        {
            InitializeComponent();
            dgList.ItemsSource = db.Students.ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            
            string name = tbName.Text;
            DateTime bithday = dpBithday.DisplayDate;
            string email = tbEmail.Text;
            string login = tbLogin.Text;
            string password = tbPassword.Text;
            var student = new Students { NameStudent = name, LoginStudent = login, PasswordStudent = password, BithdayStudent = bithday, EmailStudent = email };
            db.Students.Add(student);
            db.SaveChanges();
            dgList.Items.Refresh();
            MessageBox.Show("Пользователь успешно зарегистрирован", "Сообщение", MessageBoxButton.OK);
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            tbName.Clear();
            tbEmail.Clear();
            tbLogin.Clear();
            tbPassword.Clear();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.OKCancel,
              MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                Students user = dgList.SelectedItem as Students;
                if (user is null) return;
                db.Students.Remove(user);
                db.SaveChanges();
                dgList.Items.Refresh();
            }
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Forms.AccountTeacher account = new Forms.AccountTeacher();
            account.Show();
            this.Close();
        }
    }
}
