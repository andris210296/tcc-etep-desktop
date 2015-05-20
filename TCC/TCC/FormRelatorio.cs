using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace TCC
{
    public partial class FormRelatorio : Form
    {
        acessoRelatorio teste = new acessoRelatorio();

        public FormRelatorio()
        {
            InitializeComponent();
        }

        private void FormRelatorio_Load(object sender, EventArgs e)
        {
            CrystalReport2 relatorio = new CrystalReport2();
            relatorio.SetDataSource(teste.listarteste());
            crystalReportViewer1.ReportSource = relatorio;
        }
    }
}
