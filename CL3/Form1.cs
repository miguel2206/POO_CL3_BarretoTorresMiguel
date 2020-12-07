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
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void mantenimientoVehiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMantenimientoVehiculo mant = new FrmMantenimientoVehiculo();
            mant.Show();
        }

        private void consultarPorAñoFabricToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultarPorAnios consult = new FrmConsultarPorAnios();
            consult.Show();
        }
    }
}
