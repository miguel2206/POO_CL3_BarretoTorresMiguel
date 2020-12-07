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
    public partial class FrmMantenimientoVehiculo : Form
    {
        string ACCION = "";
        public FrmMantenimientoVehiculo()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            HabilitarEdicion(true);
            HabilitarBotones(false);
            txtID.Clear();
            txtPlaca.Focus();
            ACCION = "N";
        }

        private void FrmMantenimientoVehiculo_Load(object sender, EventArgs e)
        {
            HabilitarEdicion(false);
            HabilitarBotones(true);
            cargarCombo();
            Listar();
        }

    

        void HabilitarEdicion(bool valor)
        {
            txtPlaca.Enabled = valor;
            txtMarca.Enabled = valor;
            txtModelo.Enabled = valor;
            cboFecha.Enabled = valor;
            txtCertificado.Enabled = valor;
            txtPeso.Enabled = valor;
            txtVolumen.Enabled = valor;
        }

        void HabilitarBotones(bool valor)
        {
            btnNuevo.Enabled = valor;
            btnEditar.Enabled = valor;
            btnEliminar.Enabled = valor;
            dgvLista.Enabled = valor;
            btnAceptar.Enabled = !valor;
            btnCancelar.Enabled = !valor;
        }

        void LimpiarFormulario()
        {
            ACCION = string.Empty;
            txtPlaca.Clear();
            txtMarca.Clear();
            txtModelo.Clear();
            cboFecha.SelectedIndex = -1;
            txtCertificado.Clear();
            txtPeso.Clear();
            txtVolumen.Clear();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarEdicion(true);
            HabilitarBotones(false);
            ACCION = "E";
        }

        void Listar()
        {
            dgvLista.DataSource = null;
            dgvLista.DataSource = new DAOVehiculo().Listar();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            HabilitarEdicion(false);
            HabilitarBotones(true);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(txtPlaca.Text == "" || txtPlaca.Text == null || txtMarca.Text == "" || txtMarca.Text == null ||
                txtModelo.Text == "" || txtModelo.Text == null || cboFecha.Text == "" || cboFecha.Text == null || 
                txtCertificado.Text == "" || txtCertificado.Text == null || txtPeso.Text == "" || txtPeso.Text == null ||
                txtVolumen.Text == "" || txtVolumen.Text == null)
            {
                MessageBox.Show("Ingrese datos completos", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else{
                Vehiculo obj = new Vehiculo();
                obj.Placa = txtPlaca.Text;
                obj.Marca = txtMarca.Text;
                obj.Modelo = txtModelo.Text;
                obj.AnioFabricacion = cboFecha.Text.ToString();
                obj.Certificado = txtCertificado.Text;
                obj.PesoMaximo = Convert.ToDecimal(txtPeso.Text);
                obj.VolumenMaximo = Convert.ToDecimal(txtVolumen.Text);

                if (ACCION.Equals("N"))
                {
                    int res = new DAOVehiculo().Insertar(obj);
                    if (res == 1)
                    {
                        MessageBox.Show("Se registró el vehículo", "Vehiculo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HabilitarEdicion(false);
                        HabilitarBotones(true);
                        Listar();
                    }
                    else
                    {
                        MessageBox.Show("No se registró el vehículo", "Vehiculo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (ACCION.Equals("E"))
                {
                    obj.IdVehiculo = Convert.ToInt32(txtID.Text);
                    int res = new DAOVehiculo().Actualizar(obj);
                    if (res == 1)
                    {
                        MessageBox.Show("Se actualizó el vehiculo", "Vehiculo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HabilitarEdicion(false);
                        HabilitarBotones(true);
                        Listar();
                    }
                    else
                    {
                        MessageBox.Show("No se actualizó el vehiculo", "Vehiculo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                HabilitarEdicion(false);
                HabilitarBotones(true);
            }  
        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLista.Rows[e.RowIndex];
                if (row != null)
                {
                    int id = Convert.ToInt32(row.Cells[0].Value);
                  
                    Vehiculo v = new DAOVehiculo().Obtener(id);
                    if (v != null)
                    {
                        txtID.Text = v.IdVehiculo.ToString();
                        txtPlaca.Text = v.Placa;
                        txtMarca.Text = v.Marca;
                        txtModelo.Text = v.Modelo;
                        cboFecha.Text = v.AnioFabricacion;
                        txtCertificado.Text = v.Certificado;
                        txtPeso.Text = v.PesoMaximo.ToString();
                        txtVolumen.Text = v.VolumenMaximo.ToString();
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Vehiculo v = new Vehiculo();
            v.IdVehiculo = Convert.ToInt32(txtID.Text);

            if (!string.IsNullOrEmpty(txtID.Text))
            {
                DialogResult boton = MessageBox.Show("Realmente desea eliminar registro?", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (boton == DialogResult.OK)
                {
                    int res = new DAOVehiculo().Eliminar(v);
                    if (res == 1)
                    {
                        MessageBox.Show("Se eliminó el vehículo", "Vehiculo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Listar();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el Vehículo", "Vehiculo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    Listar();
            }
        }

        void cargarCombo()
        {
            for(int i = 1900; i <= 2020; i++)
            {
                cboFecha.Items.Add(i);
            }
        }
    }
}
