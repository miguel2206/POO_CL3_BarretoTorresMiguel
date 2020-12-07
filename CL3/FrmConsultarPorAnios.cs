using CL3.DAO;
using CL3.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CL3
{
    public partial class FrmConsultarPorAnios : Form
    {
        public FrmConsultarPorAnios()
        {
            InitializeComponent();
        }

        private void FrmConsultarPorAnios_Load(object sender, EventArgs e)
        {
            cargarComboInicio();
            cargarComboFin();
        }

        void cargarComboInicio()
        {
            for (int i = 1900; i <= 2020; i++)
            {
                cboInicio.Items.Add(i);
            }
        }

        void cargarComboFin()
        {
            for (int i = 1900; i <= 2020; i++)
            {
                cboFin.Items.Add(i);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if(cboInicio.Text == "" || cboInicio.Text == null)
            {
                MessageBox.Show("Ingrese fecha de inicio", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (cboFin.Text == "" || cboFin.Text == null)
            {
                MessageBox.Show("Ingrese fecha de fin", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    string fechaInicio = cboInicio.Text;
                    string fechaFin = cboFin.Text;

                    dgvLista.DataSource = null;
                    dgvLista.DataSource = new DAOVehiculo().ListarXAnio(fechaInicio, fechaFin);
                   
                  
                    if(dgvLista.RowCount <= 0)
                    {
                        MessageBox.Show("No existe ningún registro en este rango", "Vehiculo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cboInicio.Text = "";
                        cboFin.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("registros cargados exitosamente", "Vehiculo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex1)
                {
                    MessageBox.Show("No existe ningún registro en este rango", "Vehiculo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }          
            }
        } 
    }
}
