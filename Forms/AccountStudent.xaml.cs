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
    /// Логика взаимодействия для AccountStudent.xaml
    /// </summary>
    public partial class AccountStudent : Window
    {
        SchoolProjectWPFEntities db = new SchoolProjectWPFEntities();
        public AccountStudent()
        {
            InitializeComponent();
        }

        private void ListStud_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
