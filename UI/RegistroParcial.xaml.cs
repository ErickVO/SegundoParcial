using SegundoParcial.BLL;
using SegundoParcial.Entidades;
using System;
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

namespace SegundoParcial.UI
{
    /// <summary>
    /// Interaction logic for RegistroParcial.xaml
    /// </summary>
    public partial class RegistroParcial : Window
    {
        Llamadas llamadas = new Llamadas();

        public RegistroParcial()
        {
            InitializeComponent();
            this.DataContext = llamadas;
            IdTextBox.Text = "0";
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = llamadas;
        }

        private void Limpiar()
        {
            IdTextBox.Text = "0";
            DescripcionTextBox.Text = string.Empty;
            ProblemaTextBox.Text = string.Empty;
            SolucionTextBox.Text = string.Empty;
            llamadas.LlamadasDetalle = new List<LlamadasDetalle>();
            llamadas = new Llamadas();
            Cargar();
        }


        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Llamadas l = LlamadasBLL.Buscar(llamadas.LlamadaId);

            return (l != null);
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (llamadas.LlamadaId == 0)
            {
                paso = LlamadasBLL.Guardar(llamadas);
            }
            else
            {
                if (ExisteEnLaBaseDeDatos())
                {
                    paso = LlamadasBLL.Modificar(llamadas);
                }
                else
                {
                    MessageBox.Show("No Existe en la base de datos", "ERROR");
                    return;
                }

                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Guardado!!", "Exito");
                }
                else
                {
                    MessageBox.Show("No se pudo Guardar", "ERROR");
                }
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (LlamadasBLL.Eliminar(llamadas.LlamadaId))
            {
                Limpiar();
                MessageBox.Show("Eliminado","EXITO");
            }
            else
            {
                MessageBox.Show("No se pudo eliminar", "Error");
            }
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            if(DetalleDataGrid.Items.Count > 1 && DetalleDataGrid.SelectedIndex < DetalleDataGrid.Items.Count - 1) 
            {
                llamadas.LlamadasDetalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                Cargar();
            }

        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Llamadas l = LlamadasBLL.Buscar(llamadas.LlamadaId);
            
            if (l != null)
            {
                llamadas = l;
                Cargar();
            }
            else
            {
                MessageBox.Show("No se encontro", "ERROR");
            }
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            llamadas.LlamadasDetalle.Add(new LlamadasDetalle(llamadas.LlamadaId, ProblemaTextBox.Text, SolucionTextBox.Text));

            Cargar();

            ProblemaTextBox.Clear();
            SolucionTextBox.Clear();
            SolucionTextBox.Focus();
        }
    }
}
