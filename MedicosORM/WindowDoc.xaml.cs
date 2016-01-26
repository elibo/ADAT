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

namespace MedicosORM
{
    /// <summary>
    /// Lógica de interacción para WindowDoc.xaml
    /// </summary>
    public partial class WindowDoc : Window
    {
        Doctor d = new Doctor();
        Medicos medico = new Medicos();
        List<Medicos> list;

        public WindowDoc()
        {
            InitializeComponent();
            list = d.getAll();
            dataGrid.ItemsSource = list;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {//nuevo
            clear();
            medico = new Medicos();
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {//guardar
            if (medico != null)
            {
                if (medico.idMedico != null)
                {
                    medico.servicio = serv_tb.Text;
                    medico.especialidad = esp_tb.Text;
                    medico.nombre = nmbre_tb.Text;
                    medico.apellidos = ap_tb.Text;
                    medico.telefono = telf_tb.Text;
                    medico.dni = dni_tb.Text;
                    d.Update(medico);
                }
            }
            else {
                medico.idMedico = id_tb.Text;
                medico.servicio = serv_tb.Text;
                medico.especialidad = esp_tb.Text;
                medico.nombre = nmbre_tb.Text;
                medico.apellidos = ap_tb.Text;
                medico.telefono = telf_tb.Text;
                medico.dni = dni_tb.Text;
                d.Create(medico);
            }
                list.Add(medico);
                dataGrid.ItemsSource = list.ToArray();
        }

        private void button_Copy1_Click(object sender, RoutedEventArgs e)
        {//eliminar
            medico = list[dataGrid.SelectedIndex];
            d.Delete(medico);
            clear();
            list.Remove(medico);
            dataGrid.ItemsSource = list.ToArray();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedIndex != -1)
            {
                medico = list[dataGrid.SelectedIndex];
                id_tb.Text = medico.idMedico.ToString();
                dni_tb.Text = medico.dni.ToString();
                nmbre_tb.Text = medico.nombre.ToString();
                ap_tb.Text = medico.apellidos.ToString();
                telf_tb.Text = medico.telefono.ToString();
                serv_tb.Text = medico.ServicioMedico.nombre.ToString();
                esp_tb.Text = medico.Especialidades.nombre.ToString();
               
            }
        }

        public void clear()
        {
            id_tb.Clear();
            nmbre_tb.Clear();
            telf_tb.Clear();
            dni_tb.Clear();
            ap_tb.Clear();
            serv_tb.Clear(); 
            esp_tb.Clear();
            
        }
    }
}
