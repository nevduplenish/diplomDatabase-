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
    public partial class AddFormReEx : Form
    {
        DataBase dataBase = new DataBase();

        public AddFormReEx()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

        }

        private void AddFormReEx_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            var re = textBox1.Text;
            var ex = textBox2.Text;


            var addQuery = $"insert into Recipe_Expense (Recipe_ID, Expense_ID) values ('{re}','{ex}')";

            var command = new SqlCommand(addQuery, dataBase.getConnection());
            command.ExecuteNonQuery();

            MessageBox.Show("Запись создана!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataBase.closeConnection();
        }
    }
}
