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
    enum RowState
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }
    public partial class Form3 : Form
    {
        private readonly checkUser _user;

        DataBase dataBase = new DataBase();

        int selectedRow;
        public Form3(checkUser user)
        {
            _user = user;
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void IsAdmin()
        {
            управлениеToolStripMenuItem.Enabled = _user.IsAdmin;
            button_newrecord.Enabled = _user.IsAdmin;
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("Ar_name_material", "Наименование материала");
            dataGridView1.Columns.Add("Ar_date", "Дата прихода");
            dataGridView1.Columns.Add("Ar_number_vehicle", "Номер ТС");
            dataGridView1.Columns.Add("Ar_number_consigment", "Транспортная накладная");
            dataGridView1.Columns.Add("Ar_name_provider", "Поставщик");
            dataGridView1.Columns.Add("Ar_tonnage", "Тоннаж");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }


        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt64(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5), record.GetInt32(6), RowState.ModifiedNew);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from Arrival";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = $"{_user.Login}: {_user.Status}";
            IsAdmin();
            CreateColumns();
            RefreshDataGrid(dataGridView1);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if(e.RowIndex >=0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

               
                textBox_namemat.Text = row.Cells[1].Value.ToString();
                textBox_date.Text = row.Cells[2].Value.ToString();
                textBox_numberv.Text = row.Cells[3].Value.ToString();
                textBox_transcons.Text = row.Cells[4].Value.ToString();
                textBox_prov.Text = row.Cells[5].Value.ToString();
                textBox_tonnage.Text = row.Cells[6].Value.ToString();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox_refresh_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
        }

        private void button_newrecord_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
        }

        private void pictureBox_search_Click(object sender, EventArgs e)
        {

        }

        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from Arrival where concat (Arrival_ID,Ar_name_material,Ar_date,Ar_number_vehicle,Ar_number_consignment,Ar_name_provider,Ar_tonnage) like '%" + textBox_search.Text + "%'";

            SqlCommand com = new SqlCommand(searchString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader read = com.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRow(dgw, read);
            }

            read.Close();
        }

        private void deleteRow()
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            dataGridView1.Rows[index].Visible = false;

            if (dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView1.Rows[index].Cells[7].Value = RowState.Deleted;
                return;
            }

        }

        private void Update()
        {
            dataBase.openConnection();

            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[7].Value;

                if (rowState == RowState.Existed)
                        continue;

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt64(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from Arrival where Arrival_ID = {id}";

                    var command = new SqlCommand(deleteQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();


                }
                if (rowState == RowState.Modified)
                {
                    var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var namemat = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var date = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var numberv = dataGridView1.Rows[index].Cells[3].Value.ToString();
                    var transcons = dataGridView1.Rows[index].Cells[4].Value.ToString();
                    var prov = dataGridView1.Rows[index].Cells[5].Value.ToString();
                    var tonnage = dataGridView1.Rows[index].Cells[6].Value.ToString();

                    var changeQuery = $"update Arrival set Ar_name_material = '{namemat}', Ar_date = '{date}', Ar_number_vehicle ='{numberv}', Ar_number_consignment ='{transcons}',Ar_name_provider ='{prov}',Ar_tonnage ='{tonnage}' where Arrival_ID = '{id}'";

                    var command = new SqlCommand(changeQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }
        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            deleteRow();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void Change()
        {
            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;

            
            var namemat = textBox_namemat.Text;
            var date = textBox_date.Text;
            var numberv = textBox_numberv.Text;
            var transcons = textBox_transcons.Text;
            var prov = textBox_prov.Text;
            int tonnage;

            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                if (int.TryParse(textBox_tonnage.Text, out tonnage))
                {
                    dataGridView1.Rows[selectedRowIndex].SetValues(namemat, date, numberv, transcons, prov, tonnage);
                    dataGridView1.Rows[selectedRowIndex].Cells[7].Value = RowState.Modified;
                }
                else
                {
                    MessageBox.Show("Тоннаж должен иметь числовой формат!");
                }
            }
        }
        private void button_change_Click(object sender, EventArgs e)
        {
            Change();
        }

        private void pictureBox_clear_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
