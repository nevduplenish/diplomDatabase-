using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.Util;

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
            button_delete.Enabled = _user.IsAdmin;
            button_change.Enabled = _user.IsAdmin;
            button_save.Enabled = _user.IsAdmin;
            button4.Enabled = _user.IsAdmin;
            button3.Enabled = _user.IsAdmin;
            button2.Enabled = _user.IsAdmin;
            button1.Enabled = _user.IsAdmin;
            button8.Enabled = _user.IsAdmin;
            button7.Enabled = _user.IsAdmin;
            button6.Enabled = _user.IsAdmin;
            button5.Enabled = _user.IsAdmin;
            button12.Enabled = _user.IsAdmin;
            button11.Enabled = _user.IsAdmin;
            button10.Enabled = _user.IsAdmin;
            button9.Enabled = _user.IsAdmin;

        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("Arrival_ID", "№Поставки");
            dataGridView1.Columns.Add("Stock_ID", "№Складского объекта");
            dataGridView1.Columns.Add("Ar_material_supplies", "Наименование материала");
            dataGridView1.Columns.Add("Ar_date", "Дата прихода");
            dataGridView1.Columns.Add("Ar_number_vehicle", "Номер ТС");
            dataGridView1.Columns.Add("Ar_number_consigment", "Транспортная накладная");
            dataGridView1.Columns.Add("Ar_name_provider", "Поставщик");
            dataGridView1.Columns.Add("Ar_tonnage", "Тоннаж");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }
            
      

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5), record.GetString(6), record.GetInt32(7), RowState.Modified);
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
       
        private void Form3_Load(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = $"{_user.Login}: {_user.Status}";
            IsAdmin();
            CreateColumns();
            RefreshDataGrid(dataGridView1);
            CreateColumnsStock();
            RefreshDataGridStock(dataGridView2);
            CreateColumnsRecipe();
            RefreshDataGridRecipe(dataGridView3);
            CreateColumnsExpense();
            RefreshDataGridExpense(dataGridView4);
            dataGridView1.Columns["IsNew"].Visible = false;
            dataGridView2.Columns["IsNew"].Visible = false;
            dataGridView3.Columns["IsNew"].Visible = false;
            dataGridView4.Columns["IsNew"].Visible = false;


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if(e.RowIndex >=0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                textBox8.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox_namemat.Text = row.Cells[2].Value.ToString();
                textBox_date.Text = row.Cells[3].Value.ToString();
                textBox_numberv.Text = row.Cells[4].Value.ToString();
                textBox_transcons.Text = row.Cells[5].Value.ToString();
                textBox_prov.Text = row.Cells[6].Value.ToString();
                textBox_tonnage.Text = row.Cells[7].Value.ToString();
            }
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

        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from Arrival where concat (Arrival_ID, Stock_ID, Ar_material_supplies,Ar_date,Ar_number_vehicle,Ar_number_consignment,Ar_name_provider,Ar_tonnage) like '%" + textBox_search.Text + "%'";

            SqlCommand com = new SqlCommand(searchString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader read = com.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRow(dgw, read);
            }

            read.Close();
        }



        private void Update()
        {
            dataBase.openConnection();

            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[8].Value;

                if (rowState == RowState.Existed)
                        continue;

                if (rowState == RowState.Deleted)
                {
                    var idArrival = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from Arrival where Arrival_ID = {idArrival}";

                    var command = new SqlCommand(deleteQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();


                    
                }
                if (rowState == RowState.Modified)
                {
                    var idArrival = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var idStock = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var namemat = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var date = dataGridView1.Rows[index].Cells[3].Value.ToString();
                    var numberv = dataGridView1.Rows[index].Cells[4].Value.ToString();
                    var transcons = dataGridView1.Rows[index].Cells[5].Value.ToString();
                    var prov = dataGridView1.Rows[index].Cells[6].Value.ToString();
                    var tonnage = dataGridView1.Rows[index].Cells[7].Value.ToString();

                    var changeQuery = $"update Arrival set Stock_ID = '{idStock}', Ar_material_supplies = '{namemat}', Ar_date = '{date}', Ar_number_vehicle ='{numberv}', Ar_number_consignment ='{transcons}',Ar_name_provider ='{prov}',Ar_tonnage ='{tonnage}' where Arrival_ID = '{idArrival}'";

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
            // deleteRow();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        int id = Convert.ToInt32(row.Cells["Arrival_ID"].Value);
                        //удаляем запись из базы данных
                        string queryString = $"DELETE FROM Arrival WHERE Arrival_ID = {id}";

                        SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());

                        dataBase.openConnection();

                        int result = command.ExecuteNonQuery();

                        dataBase.closeConnection();

                        //удаляем запись из DataGridView
                        dataGridView1.Rows.Remove(row);
                    }
                }
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void Change()
        {
            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;

            var idArrival = textBox8.Text;
            var idStock = textBox2.Text;
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
                    dataGridView1.Rows[selectedRowIndex].SetValues(idArrival, idStock, namemat, date, numberv, transcons, prov, tonnage);
                    dataGridView1.Rows[selectedRowIndex].Cells[8].Value = RowState.Modified;
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





/*******************************************************************************************************************************************/
/*******************************************************************************************************************************************************/
/*********************************************************************************************************************************************************/


        private void CreateColumnsStock()
        {
            dataGridView2.Columns.Add("Stock_ID", "№Cкладского объекта");
            dataGridView2.Columns.Add("St_brand_material", "Марка материала");
            dataGridView2.Columns.Add("St_GOST", "ГОСТ материала");
            dataGridView2.Columns.Add("St_remains", "Запас материала");
            dataGridView2.Columns.Add("St_total_tonnage", "Общий тоннаж");
            dataGridView2.Columns.Add("St_ware_fac", "Вид складского объекта");
            dataGridView2.Columns.Add("IsNew", String.Empty);
        }

        private void ReadSingleRowStock(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetInt32(3), record.GetInt32(4), record.GetString(5), RowState.ModifiedNew);
        }

        private void RefreshDataGridStock(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from Stock";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRowStock(dgw, reader);

                int remains = reader.GetInt32(3);

                // Определяем границы запаса материала для окрашивания ячеек
                int greenLimit = 500;
                int yellowLimit = 250;

                // Окрашиваем ячейки в соответствующие цвета
                if (remains >= greenLimit)
                {
                    dgw.Rows[dgw.Rows.Count - 1].Cells[3].Style.BackColor = Color.LightGreen;
                }
                else if (remains >= yellowLimit)
                {
                    dgw.Rows[dgw.Rows.Count - 1].Cells[3].Style.BackColor = Color.Yellow;
                }
                else
                {
                    dgw.Rows[dgw.Rows.Count - 1].Cells[3].Style.BackColor = Color.Red;
                }

            }
            reader.Close();
        }

        private void SearchStock(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from Stock where concat (Stock_ID, St_brand_material,St_GOST, St_remains, St_total_tonnage, St_ware_fac) like '%" + textBox1.Text + "%'";

            SqlCommand com = new SqlCommand(searchString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader read = com.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRowStock(dgw, read);
            }

            read.Close();
        }
        private void deleteRowStock()
        {
           
            if (dataGridView2.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        int id = Convert.ToInt32(row.Cells["Stock_ID"].Value);
                        //удаляем запись из базы данных
                        string queryString = $"DELETE FROM Stock WHERE Stock_ID = {id}";

                        SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());

                        dataBase.openConnection();

                        int result = command.ExecuteNonQuery();

                        dataBase.closeConnection();

                        //удаляем запись из DataGridView
                        dataGridView2.Rows.Remove(row);
                    }
                }
            }

        }

        private void UpdateStock()
        {
            dataBase.openConnection();

            for (int index = 0; index < dataGridView2.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView2.Rows[index].Cells[6].Value;

                if (rowState == RowState.Existed)
                    continue;

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView2.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from Stock where Stock_ID = {id}";

                    var command = new SqlCommand(deleteQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();


                }
                if (rowState == RowState.Modified)
                {
                    var id = dataGridView2.Rows[index].Cells[0].Value.ToString();
                    var brand = dataGridView2.Rows[index].Cells[1].Value.ToString();
                    var gost = dataGridView2.Rows[index].Cells[2].Value.ToString();
                    var reserve = dataGridView2.Rows[index].Cells[3].Value.ToString();
                    var total = dataGridView2.Rows[index].Cells[4].Value.ToString();
                    var ware = dataGridView2.Rows[index].Cells[5].Value.ToString();

                    var changeQuery = $"update Stock set St_brand_material = '{brand}', St_GOST ='{gost}', St_remains ='{reserve}', St_total_tonnage ='{total}', St_ware_fac ='{ware}' where Stock_ID = '{id}'";

                    var command = new SqlCommand(changeQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }

        private void ChangeStock()
        {
            var selectedRowIndex = dataGridView2.CurrentCell.RowIndex;

            var idStock = textBox9.Text;
            var brand = textBox6.Text;
            var gost = textBox5.Text;
            int reserve;
            int total;
            var ware = textBox4.Text;

            if (dataGridView2.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                if (int.TryParse(textBox7.Text, out reserve))
                {
                    if (int.TryParse(textBox3.Text, out total))
                    dataGridView2.Rows[selectedRowIndex].SetValues(idStock, brand, gost, reserve, total, ware);
                    dataGridView2.Rows[selectedRowIndex].Cells[6].Value = RowState.Modified;
                }
            }
            else
            {
                MessageBox.Show("Запас материала или общий тоннаж должен иметь числовой формат!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            deleteRowStock();
        }

        private void button4_Click(object sender, EventArgs e)
        {
                StockAddForm addfrm = new StockAddForm();
            addfrm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeStock();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            UpdateStock();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[selectedRow];

                textBox9.Text = row.Cells[0].Value.ToString();
                textBox6.Text = row.Cells[1].Value.ToString();
                textBox5.Text = row.Cells[2].Value.ToString();
                textBox7.Text = row.Cells[3].Value.ToString();
                textBox3.Text = row.Cells[4].Value.ToString();
                textBox4.Text = row.Cells[5].Value.ToString();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            RefreshDataGridStock(dataGridView2);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SearchStock(dataGridView2);
        }


        /*************************************************************************************************************************************************************/
        /*************************************************************************************************************************************************************/
        /*************************************************************************************************************************************************************/
        private void CreateColumnsRecipe()
        {
            dataGridView3.Columns.Add("Recipe_ID", "№ рецепта");
            dataGridView3.Columns.Add("Stock_ID", "№ складского объекта");
            dataGridView3.Columns.Add("Re_loss", "Потери (%)");
            dataGridView3.Columns.Add("Re_quantity_material_per_batch", "Количество на один замес (т)");
            dataGridView3.Columns.Add("Re_humidity", "Влажность (%)");
            dataGridView3.Columns.Add("IsNew", String.Empty);
        }

        private void ReadSingleRowRecipe(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetInt32(2), record.GetInt32(3), record.GetInt32(4), RowState.ModifiedNew);
        }

        private void RefreshDataGridRecipe(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from Recipe";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRowRecipe(dgw, reader);
            }
            reader.Close();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView3.Rows[selectedRow];

                textBox15.Text = row.Cells[0].Value.ToString(); 
                textBox10.Text = row.Cells[1].Value.ToString();
                textBox13.Text = row.Cells[2].Value.ToString();
                textBox12.Text = row.Cells[3].Value.ToString();
                textBox11.Text = row.Cells[4].Value.ToString();
            }
        }

        private void SearchRecipe(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from Recipe where concat (Recipe_ID,Stock_ID, Re_loss, Re_quantity_material_per_batch, Re_humidity) like '%" + textBox14.Text + "%'";

            SqlCommand com = new SqlCommand(searchString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader read = com.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRowRecipe(dgw, read);
            }

            read.Close();
        }

        private void deleteRowRecipe()
        {
            
            if (dataGridView3.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView3.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        int id = Convert.ToInt32(row.Cells["Recipe_ID"].Value);
                        //удаляем запись из базы данных
                        string queryString = $"DELETE FROM Recipe WHERE Recipe_ID = {id}";

                        SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());

                        dataBase.openConnection();

                        int result = command.ExecuteNonQuery();

                        dataBase.closeConnection();

                        //удаляем запись из DataGridView
                        dataGridView3.Rows.Remove(row);
                    }
                }
            }

        }

        private void UpdateRecipe()
        {
            dataBase.openConnection();

            for (int index = 0; index < dataGridView3.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView3.Rows[index].Cells[5].Value;

                if (rowState == RowState.Existed)
                    continue;

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView3.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from Recipe where Recipe_ID = {id}";

                    var command = new SqlCommand(deleteQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();


                }
                if (rowState == RowState.Modified)
                {
                    var idRecipe = dataGridView3.Rows[index].Cells[0].Value.ToString();
                    var idStock = dataGridView3.Rows[index].Cells[1].Value.ToString();
                    var loss = dataGridView3.Rows[index].Cells[2].Value.ToString();
                    var quantity = dataGridView3.Rows[index].Cells[3].Value.ToString();
                    var humidity = dataGridView3.Rows[index].Cells[4].Value.ToString();

                    var changeQuery = $"update Recipe set Stock_ID = {idStock}, Re_loss = '{loss}', Re_quantity_material_per_batch = '{quantity}', Re_humidity ='{humidity}' where Recipe_ID = '{idRecipe}'";

                    var command = new SqlCommand(changeQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            SearchRecipe(dataGridView3);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            deleteRowRecipe();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            UpdateRecipe();
        }

        private void ChangeRecipe()
        {
            var selectedRowIndex = dataGridView3.CurrentCell.RowIndex;

            var idStock = textBox10.Text;
            var idRecipe = textBox15.Text;
            int loss;
            int quantity;
            int humidity;

            if (dataGridView3.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                if (int.TryParse(textBox13.Text, out loss))
                {
                    if (int.TryParse(textBox12.Text, out quantity))
                    {
                        if (int.TryParse(textBox11.Text, out humidity))
                        dataGridView3.Rows[selectedRowIndex].SetValues(idRecipe, idStock, loss, quantity, humidity);
                        dataGridView3.Rows[selectedRowIndex].Cells[5].Value = RowState.Modified;
                    }
                }
            }
            else
            {
                MessageBox.Show("Все данные в этой таблице имеют числовой формат (Потери и влажность - проценты!");
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            ChangeRecipe();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            RefreshDataGridRecipe(dataGridView3);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            RecipeAddForm addfrm = new RecipeAddForm();
            addfrm.Show();
        }

        /*************************************************************************************************************************************************************/
        /*************************************************************************************************************************************************************/
        /*************************************************************************************************************************************************************/


        private void CreateColumnsExpense()
        {
            dataGridView4.Columns.Add("Expense_ID", "№Производственного процесса(Расход)");
            dataGridView4.Columns.Add("Ex_per_shift", "Расход за смену");
            dataGridView4.Columns.Add("Ex_per_day", "Расход за сутки");
            dataGridView4.Columns.Add("IsNew", String.Empty);
        }

        private void ReadSingleRowExpense(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetInt32(2), RowState.ModifiedNew);
        }

        private void RefreshDataGridExpense(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from Expense";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRowExpense(dgw, reader);
            }
            reader.Close();
        }

       private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView4.Rows[selectedRow];

                textBox16.Text = row.Cells[0].Value.ToString();    
                textBox20.Text = row.Cells[1].Value.ToString();
                textBox19.Text = row.Cells[2].Value.ToString();
            }
        }

        private void SearchExpense(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from Expense where concat (Expense_ID,Ex_per_shift,Ex_per_day) like '%" + textBox21.Text + "%'";

            SqlCommand com = new SqlCommand(searchString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader read = com.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRowExpense(dgw, read);
            }

            read.Close();
        }

        private void deleteRowExpense()
        {
            /*
            int index = dataGridView4.CurrentCell.RowIndex;

            dataGridView4.Rows[index].Visible = false;

            if (dataGridView4.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView4.Rows[index].Cells[4].Value = RowState.Deleted;
                return;
            }
            */
            if (dataGridView4.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView4.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        int id = Convert.ToInt32(row.Cells["Expense_ID"].Value);
                        //удаляем запись из базы данных
                        string queryString = $"DELETE FROM Expense WHERE Expense_ID = {id}";

                        SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());

                        dataBase.openConnection();

                        int result = command.ExecuteNonQuery();

                        dataBase.closeConnection();

                        //удаляем запись из DataGridView
                        dataGridView4.Rows.Remove(row);
                    }
                }
            }

        }

        private void UpdateExpense()
        {
            dataBase.openConnection();

            for (int index = 0; index < dataGridView4.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView4.Rows[index].Cells[3].Value;

                if (rowState == RowState.Existed)
                    continue;

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView4.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from Expense where Expense = {id}";

                    var command = new SqlCommand(deleteQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();


                }
                if (rowState == RowState.Modified)
                {
                    var idExpense = dataGridView4.Rows[index].Cells[0].Value.ToString();
                    var shift = dataGridView4.Rows[index].Cells[1].Value.ToString();
                    var day = dataGridView4.Rows[index].Cells[2].Value.ToString();
                    

                    var changeQuery = $"update Expense set Ex_per_shift = '{shift}', Ex_per_day = '{day}' where Expense_ID = '{idExpense}'";

                    var command = new SqlCommand(changeQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }

        private void ChangeExpense()
        {
            var selectedRowIndex = dataGridView4.CurrentCell.RowIndex;


            var idExpense = textBox16.Text;
            int shift;
            int day;

            if (dataGridView4.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                if (int.TryParse(textBox20.Text, out shift))
                {
                    if (int.TryParse(textBox19.Text, out day))
                    {
                        dataGridView4.Rows[selectedRowIndex].SetValues(idExpense, shift,day);
                        dataGridView4.Rows[selectedRowIndex].Cells[3].Value = RowState.Modified;
                    }
                }
            }
            else
            {
                MessageBox.Show("Данные должны быть в числовом формате!");
            }
        }

      



        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            SearchExpense(dataGridView4);
        }
        private void button11_Click(object sender, EventArgs e)
        {
            deleteRowExpense();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            UpdateExpense();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ChangeExpense();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            RefreshDataGridExpense(dataGridView4);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ExpenseAddForm addfrm = new ExpenseAddForm();
            addfrm.Show();
        }


        private void ExportToExcel()
        {

            
             // Создание новой рабочей книги Excel
             XSSFWorkbook workbook = new XSSFWorkbook();
             // Создание нового листа
             XSSFSheet sheet = (XSSFSheet)workbook.CreateSheet("Расход(сводная)");

             // Создание заголовка таблицы 1
             XSSFRow headerRow1 = (XSSFRow)sheet.CreateRow(0);
             for (int i = 0; i < dataGridView1.Columns.Count - 1; i++)
             {
                 headerRow1.CreateCell(i).SetCellValue(dataGridView1.Columns[i].HeaderText);
             }

             // Заполнение таблицы 1 данными из dataGridView1
             for (int i = 0; i < dataGridView1.Rows.Count; i++)
             {
                 XSSFRow dataRow1 = (XSSFRow)sheet.CreateRow(i + 1);
                 for (int j = 0; j < dataGridView1.Columns.Count - 1; j++)
                 {
                     dataRow1.CreateCell(j).SetCellValue(dataGridView1.Rows[i].Cells[j].Value.ToString());
                 }
             }

             // Создание заголовка таблицы 2
             XSSFRow headerRow2 = (XSSFRow)sheet.CreateRow(dataGridView1.Rows.Count + 3);
             for (int i = 0; i < dataGridView4.Columns.Count - 1; i++)
             {
                 headerRow2.CreateCell(i).SetCellValue(dataGridView4.Columns[i].HeaderText);
             }

             // Заполнение таблицы 2 данными из dataGridView4
             for (int i = 0; i < dataGridView4.Rows.Count; i++)
             {
                 XSSFRow dataRow2 = (XSSFRow)sheet.CreateRow(dataGridView1.Rows.Count + 4 + i);
                 for (int j = 0; j < dataGridView4.Columns.Count - 1; j++)
                 {
                     dataRow2.CreateCell(j).SetCellValue(dataGridView4.Rows[i].Cells[j].Value.ToString());
                 }
             }

            // Выделение текста заголовков столбцов жирным шрифтом
            XSSFCellStyle headerCellStyle = (XSSFCellStyle)workbook.CreateCellStyle();
            XSSFFont headerFont = (XSSFFont)workbook.CreateFont();
            headerFont.IsBold = true;
            headerCellStyle.SetFont(headerFont);

            // Применение стиля к ячейкам заголовка таблицы 1
            for (int i = 0; i < dataGridView1.Columns.Count - 1; i++)
            {
                XSSFCell headerCell1 = (XSSFCell)headerRow1.GetCell(i);
                headerCell1.CellStyle = headerCellStyle;
            }

            // Применение стиля к ячейкам заголовка таблицы 2
            for (int i = 0; i < dataGridView4.Columns.Count - 1; i++)
            {
                XSSFCell headerCell2 = (XSSFCell)headerRow2.GetCell(i);
                headerCell2.CellStyle = headerCellStyle;
            }

            // Сохранение файла Excel
            SaveFileDialog sfd = new SaveFileDialog();
             sfd.Filter = "Excel Documents (*.xlsx)|*.xlsx";
             sfd.FileName = "Расход(сводная).xlsx";
             if (sfd.ShowDialog() == DialogResult.OK)
             {
                 using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write))
                 {
                     workbook.Write(fs);
                 }
                 MessageBox.Show("Файл сохранен.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
            
         

        }



        /*************************************************************************************************************************************************************/
        /*************************************************************************************************************************************************************/
        /*************************************************************************************************************************************************************/




        private void pictureBox_clear_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

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

        private void pictureBox_search_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void exp_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            RefreshDataGridStock(dataGridView2);
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void управлениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelAdmin pa = new PanelAdmin();
            pa.Show();
        }
    }
}
