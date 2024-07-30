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

namespace School.Forms
{
    /// <summary>
    /// Логика взаимодействия для AccountTeacher.xaml
    /// </summary>
    public partial class AccountTeacher : Window
    {
        SchoolProjectWPFEntities db = new SchoolProjectWPFEntities();
        public AccountTeacher()
        {
            InitializeComponent();
        }

        private void ListStud_Click(object sender, RoutedEventArgs e)
        {
            Forms.ListStudents listStudents = new Forms.ListStudents();
            listStudents.Show();
            this.Close();
        }

        private void Document_Click(object sender, RoutedEventArgs e)
        {
            Forms.Document document = new Forms.Document();
            document.Show();
            this.Close();
        }
    }
}
