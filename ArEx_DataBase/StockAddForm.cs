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

            var brand = textBox2.Text;
            var gost = textBox3.Text;
            int reserve;
            int total;
            var ware = textBox4.Text;
               

            if (int.TryParse(textBox1.Text, out reserve))
            {
                if (int.TryParse(textBox5.Text, out total))
                {
                    var addQuery = $"insert into Stock (St_brand_material, St_GOST, St_remains, St_total_tonnage, St_ware_fac) values ('{brand}','{gost}','{reserve}','{total}','{ware}')";

                    var command = new SqlCommand(addQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();

                    MessageBox.Show("Запись создана!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {

                MessageBox.Show("Запас материала или общий тоннаж должен иметь целочисленный формат!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            dataBase.closeConnection();
        }
    }
}
