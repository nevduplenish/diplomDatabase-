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
    public partial class ExpenseForm : Form
    {
      

        DataBase dataBase = new DataBase();

        int selectedRow;
        public ExpenseForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("Expense_ID", "ID");
            dataGridView1.Columns.Add("Ex_name_material", "Наименование материала");
            dataGridView1.Columns.Add("Ex_per_day", "Расход за сутки");
            dataGridView1.Columns.Add("Ex_remains", "Остаток");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt64(0), record.GetString(1), record.GetString(2), record.GetInt32(3), RowState.ModifiedNew);
        }
        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from Expense";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void ExpenseForm_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridView1);
        }

        private void pictureBox_refresh_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                textBox_id.Text = row.Cells[0].Value.ToString();
                textBox_namemat.Text = row.Cells[1].Value.ToString();
                textBox_perday.Text = row.Cells[2].Value.ToString();
                textBox_remains.Text = row.Cells[3].Value.ToString();
            }
        }

        private void button_newrecord_Click(object sender, EventArgs e)
        {
            ExpenseAddForm addfrm = new ExpenseAddForm();
            addfrm.Show();
        }

        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from Expense where concat (Expense_ID,Ex_name_material,Ex_per_day,Ex_remains) like '%" + textBox_search.Text + "%'";

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
                dataGridView1.Rows[index].Cells[4].Value = RowState.Deleted;
                return;
            }

        }

        private void Update()
        {
            dataBase.openConnection();

            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[4].Value;

                if (rowState == RowState.Existed)
                    continue;

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt64(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from Expense where Expense_ID = {id}";

                    var command = new SqlCommand(deleteQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();


                }
                if (rowState == RowState.Modified)
                {
                    var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var namemat = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var perday = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var remains = dataGridView1.Rows[index].Cells[3].Value.ToString();
                 

                    var changeQuery = $"update Expense set Ex_name_material = '{namemat}', Ex_per_day = '{perday}', Ex_remains ='{remains}',  where Expense_ID = '{id}'";

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

        private void Change()
        {
            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;

            var id = textBox_id.Text;
            var namemat = textBox_namemat.Text;
            var perday = textBox_perday.Text;
            int remains;

            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                if (int.TryParse(textBox_remains.Text, out remains))
                {
                    dataGridView1.Rows[selectedRowIndex].SetValues(id, namemat, perday,remains);
                    dataGridView1.Rows[selectedRowIndex].Cells[4].Value = RowState.Modified;
                }
                else
                {
                    MessageBox.Show("Остаток должен иметь числовой формат!");
                }
            }
        }

        private void button_change_Click(object sender, EventArgs e)
        {
            Change();
        }
    }
}
