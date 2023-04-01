using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ArEx_DataBase
{
    public partial class RecipeAddForm : Form
    {
        DataBase dataBase = new DataBase();
        public RecipeAddForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        private void RecipeAddForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            var namemat = textBox1.Text;
            var quantity = textBox2.Text;
            var humidity = textBox3.Text;

           
                var addQuery = $"insert into Recipe (Re_name_material, Re_quantity_material_per_batch, Re_humidity) values ('{namemat}','{quantity}','{humidity}')";

                var command = new SqlCommand(addQuery, dataBase.getConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Запись создана!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

         
        }
    }
}
