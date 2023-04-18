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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

            decimal loss;
            float quantity;
            decimal humidity;

            if (decimal.TryParse(textBox1.Text, out loss))
            {
                if (float.TryParse(textBox2.Text, out quantity))
                {
                    if (decimal.TryParse(textBox3.Text, out humidity))
                    {
                        var addQuery = $"insert into Recipe (Re_loss, Re_quantity_material_per_batch, Re_humidity) values ('{loss}','{quantity}','{humidity})";

                        var command = new SqlCommand(addQuery, dataBase.getConnection());
                        command.ExecuteNonQuery();

                        MessageBox.Show("Запись создана!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Потери и влажность записываются в процентах!Количество на один замес в числовом формате!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
           
            dataBase.closeConnection();

        }
    }
}
