using RegistroDeUsuarios.BLL;
using System;
using RegistroDeUsuarios.Entidades;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RegistroDeUsuarios.DAL;

namespace RegistroDeUsuarios.UI.Registros
{
    /// <summary>
    /// Interaction logic for rRoles.xaml
    /// </summary>
    public partial class rRoles : Window
    {
        private Roles Databases = new Roles();
        public rRoles()
        {
            InitializeComponent();
            this.DataContext = Databases;
        }

        private void Buscar_Click(object sender, RoutedEventArgs e)
        {
            var rol = RolesBLL.Buscar(Utilidades.ToInt(RolIdTextBox.Text));

            if (rol != null)
            {
                this.Databases = rol;
                MessageBox.Show("No se ha encontrado resultado!","Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                this.Databases = new Roles();
            }
            this.DataContext = this.Databases;
        }
        private void Clean()
        {
            this.Databases = new Roles();
            this.DataContext = Databases;
        }
        private bool Validar()
        {
            bool posibilidadEscritura = true;

            if (FechaDeCreacion.Text.Length == 0)
            {
                posibilidadEscritura = false;
                MessageBox.Show("Parametros no validos! ,intente denuevo", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (DescripcionTextBox.Text.Length == 0)
            {
                posibilidadEscritura = false;
                MessageBox.Show("Parametro no valido!, intente denuevo", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
 
            return posibilidadEscritura;
        }

        private void BotonNuevo_Click(object sender, RoutedEventArgs e)
        {
           Clean();
        }

        private void BotonGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            if (RolesBLL.Existe_Descripcion(DescripcionTextBox.Text))
            {
                MessageBox.Show("Ya existe este rol", 
                    "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var paso = RolesBLL.Guardar(this.Databases);

            if (paso)
            {
                Clean();
                MessageBox.Show("Transacion Exitosa!", "Hecho",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Hubo un error", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void BotonEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (RolesBLL.Eliminar(Utilidades.ToInt(RolIdTextBox.Text)))
            {
                Clean();
                MessageBox.Show("Registro Eliminado!", "Exito",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No se puede eliminar", "Fallo",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
