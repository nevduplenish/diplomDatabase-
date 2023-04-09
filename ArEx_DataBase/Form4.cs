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
    public partial class Form4 : Form
    {
        DataBase dataBase = new DataBase();
        public Form4()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button_save_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            
            var namemat = textBox_namemat.Text;
            var date = textBox_date.Text;
            var numberv = textBox_numberv.Text;
            var transcons = textBox_transcons.Text;
            var prov = textBox_prov.Text;
            int tonnage;
            int idStock;

            if (int.TryParse(textBox_tonnage.Text, out tonnage))
            {
                if (int.TryParse(textBox1.Text, out idStock))
                {

                    var addQuery = $"insert into Arrival (Stock_ID, Ar_material_supplies, Ar_date, Ar_number_vehicle, Ar_number_consignment, Ar_name_provider, Ar_tonnage) values ('{idStock}','{namemat}','{date}','{numberv}','{transcons}','{prov}','{tonnage}')";

                    var command = new SqlCommand(addQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();

                    MessageBox.Show("Запись создана!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
            else
            {
                MessageBox.Show("Тоннаж или номер складского объекта должны иметь целочисленный формат!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            dataBase.closeConnection();
        }
    }
}
