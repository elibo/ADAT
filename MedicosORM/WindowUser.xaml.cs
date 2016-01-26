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
    /// Lógica de interacción para WindowUser.xaml
    /// </summary>
    public partial class WindowUser : Window
    {
        Users u = new Users();
        Usuarios usuario = new Usuarios();
        List<Usuarios> list;
       

        public WindowUser()
        {
            InitializeComponent();
            list = u.getAll();
            dataGrid.ItemsSource = list;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {//nuevo usuario
            clear();
            usuario = new Usuarios();

        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {//guardar usuario
            if (usuario != null)
            {
                if (usuario.NssUsuario != null)
                {
                    usuario.dni = dni_tb.Text;
                    usuario.nombre = nmbre_tb.Text;
                    usuario.apellidos = ap_tb.Text;
                    usuario.direccion = drcn_tb.Text;
                    usuario.localidad = locald_tb.Text;
                    usuario.telefono = telf_tb.Text;
                    usuario.email = mail_tb.Text;
                    usuario.contrasena = contra_tb.Text;
                    u.Update(usuario);
                }
            }
            else
            {
                usuario.NssUsuario = nss_tb.Text;
                usuario.dni = dni_tb.Text;
                usuario.nombre = nmbre_tb.Text;
                usuario.apellidos = ap_tb.Text;
                usuario.direccion = drcn_tb.Text;
                usuario.localidad = locald_tb.Text;
                usuario.telefono = telf_tb.Text;
                usuario.email = mail_tb.Text;
                usuario.contrasena = contra_tb.Text;
                u.Create(usuario);
            }
            
            list.Add(usuario);
            dataGrid.ItemsSource = list.ToArray();

        }

        private void button_Copy1_Click(object sender, RoutedEventArgs e)
        {//eliminar usuario
            usuario = list[dataGrid.SelectedIndex];
            u.Delete(usuario);
            clear();
            list.Remove(usuario);
            dataGrid.ItemsSource = list.ToArray();

        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
            if (dataGrid.SelectedIndex != -1)
            {
                usuario = list[dataGrid.SelectedIndex];
                nss_tb.Text = usuario.NssUsuario.ToString();
                dni_tb.Text = usuario.dni.ToString();
                nmbre_tb.Text = usuario.nombre.ToString();
                ap_tb.Text = usuario.apellidos.ToString();
                drcn_tb.Text = usuario.direccion.ToString();
                mail_tb.Text = usuario.email.ToString();
                telf_tb.Text = usuario.telefono.ToString();
                locald_tb.Text = usuario.localidad.ToString();
                contra_tb.Text = usuario.contrasena.ToString();
            }
               
            
        }

        public void clear() {
            nss_tb.Clear();
            nmbre_tb.Clear();
            telf_tb.Clear();
            dni_tb.Clear();
            ap_tb.Clear();
            locald_tb.Clear();
            telf_tb.Clear();
            mail_tb.Clear();
            drcn_tb.Clear();
            contra_tb.Clear();
        }
    }
}
