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
    public partial class StockAddForm : Form
    {
        DataBase dataBase = new DataBase();
        public StockAddForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void StockAddForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            var namemat = textBox1.Text;
            var brand = textBox2.Text;
            var gost = textBox3.Text;
            int reserve;

            if (int.TryParse(textBox4.Text, out reserve))
            {
                var addQuery = $"insert into Stock (St_name_material, St_brand_material, St_GOST, St_reserve_material) values ('{namemat}','{brand}','{gost}','{reserve}')";

                var command = new SqlCommand(addQuery, dataBase.getConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Запись создана!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Запас материала должен иметь целочисленный формат!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            dataBase.closeConnection();
        }
    }
}
