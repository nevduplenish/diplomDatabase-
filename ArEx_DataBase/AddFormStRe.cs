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
    public partial class AddFormStRe : Form
    {
        DataBase dataBase = new DataBase();

        public AddFormStRe()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

        }

        private void AddFormStRe_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            var st = textBox1.Text;
            var re = textBox2.Text;


                var addQuery = $"insert into Stock_Recipe (Stock_ID, Recipe_ID) values ('{st}','{re}')";

                var command = new SqlCommand(addQuery, dataBase.getConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Запись создана!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataBase.closeConnection();
        }
    }
}
