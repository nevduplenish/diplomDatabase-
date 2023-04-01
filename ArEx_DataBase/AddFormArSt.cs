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
    public partial class AddFormArSt : Form
    {
        DataBase dataBase = new DataBase();

        public AddFormArSt()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

        }

        private void AddFormArSt_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            var ar = textBox2.Text;
            var st = textBox3.Text;
        

           
                var addQuery = $"insert into Arrival_Stock (Arrival_ID, Stock_ID) values ('{ar}','{st}')";

                var command = new SqlCommand(addQuery, dataBase.getConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Запись создана!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            dataBase.closeConnection();
        }
    }
}
