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
        History his = new History();
        List<Medicos> listam;
        List<Usuarios> listau;
        List<Historiales> historiales;
        Historiales historial;

        public WindowHis()
        {
            historiales=his.getAll();
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
            clear();
            historial = new Historiales();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {//eliminar historial
            his.Delete(historial);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {// guardar o modificar
            his.Update(historial);
            his.Create(historial);
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        public void clear() {

            sint_tb.Clear();
            diag_tb.Clear();
            trat_tb.Clear();
            
        }
    }
}
