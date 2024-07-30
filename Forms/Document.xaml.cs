using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для Document.xaml
    /// </summary>
    public partial class Document : Window
    {
        public Document()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Files (*.txt)|*.txt|RichText Files (*.rtf)|*.rtf|XAML Files (*.xaml)|*.xaml|All files (*.*)|*.*";
            if (sfd.ShowDialog() == true)
            {
                TextRange doc = new TextRange(docBox.Document.ContentStart, docBox.Document.ContentEnd);
                using (FileStream fs = File.Create(sfd.FileName))
                {
                    if (System.IO.Path.GetExtension(sfd.FileName).ToLower() == ".rtf")
                        doc.Save(fs, DataFormats.Rtf);
                    else if (System.IO.Path.GetExtension(sfd.FileName).ToLower() == ".txt")
                        doc.Save(fs, DataFormats.Text);
                    else
                        doc.Save(fs, DataFormats.Xaml);
                }
            }
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "RichText Files (*.rtf)|*.rtf|All files (*.*)|*.*";

            if (ofd.ShowDialog() == true)
            {
                TextRange doc = new TextRange(docBox.Document.ContentStart, docBox.Document.ContentEnd);
                using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                {
                    if (System.IO.Path.GetExtension(ofd.FileName).ToLower() == ".rtf")
                        doc.Load(fs, DataFormats.Rtf);
                    else if (System.IO.Path.GetExtension(ofd.FileName).ToLower() == ".txt")
                        doc.Load(fs, DataFormats.Text);
                    else
                        doc.Load(fs, DataFormats.Xaml);
                }
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
