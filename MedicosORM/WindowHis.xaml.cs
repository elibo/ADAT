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
using MedicosORM.DAL;

namespace MedicosORM
{
    /// <summary>
    /// Lógica de interacción para WindowHis.xaml
    /// </summary>
    public partial class WindowHis : Window
    {
        Doctor doc = new Doctor();
        Users u = new Users();
        List<Medicos> listam;
        List<Usuarios> listau;

        public WindowHis()
        {
            InitializeComponent();
            listam = doc.getAll();
            foreach (var doctor in listam)
            {
                comboBox.Items.Add(doctor.nombre.ToString());
            }
            listau = u.getAll();
            foreach (var user in listau)
            {
                comboBox1.Items.Add(user.nombre.ToString());
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {//nuevo historial

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {//eliminar historial

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {// guardar o modificar

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
