using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArEx_DataBase
{
    public partial class arex : Form
    {
        public arex()
        {
            InitializeComponent();
        }

        private void arrivalBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.arrivalBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.arExDbDataSet);

        }

        private void arex_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "arExDbDataSet.Arrival". При необходимости она может быть перемещена или удалена.
            this.arrivalTableAdapter.Fill(this.arExDbDataSet.Arrival);

        }

        private void button12_Click(object sender, EventArgs e)
        {
            arrivalBindingSource.AddNew();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            arrivalBindingSource.EndEdit();
            arrivalTableAdapter.Update(arExDbDataSet.Arrival);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            arrivalBindingSource.RemoveCurrent();
        }
    }
}
