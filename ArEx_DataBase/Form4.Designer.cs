
namespace ArEx_DataBase
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_namemat = new System.Windows.Forms.TextBox();
            this.textBox_date = new System.Windows.Forms.TextBox();
            this.textBox_numberv = new System.Windows.Forms.TextBox();
            this.textBox_transcons = new System.Windows.Forms.TextBox();
            this.textBox_prov = new System.Windows.Forms.TextBox();
            this.textBox_tonnage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button_save = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-1, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(797, 63);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(478, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Создание записи в таблицу \"Приход\"";
            // 
            // textBox_namemat
            // 
            this.textBox_namemat.Location = new System.Drawing.Point(224, 90);
            this.textBox_namemat.Multiline = true;
            this.textBox_namemat.Name = "textBox_namemat";
            this.textBox_namemat.Size = new System.Drawing.Size(266, 25);
            this.textBox_namemat.TabIndex = 2;
            // 
            // textBox_date
            // 
            this.textBox_date.Location = new System.Drawing.Point(224, 121);
            this.textBox_date.Multiline = true;
            this.textBox_date.Name = "textBox_date";
            this.textBox_date.Size = new System.Drawing.Size(266, 25);
            this.textBox_date.TabIndex = 3;
            // 
            // textBox_numberv
            // 
            this.textBox_numberv.Location = new System.Drawing.Point(224, 152);
            this.textBox_numberv.Multiline = true;
            this.textBox_numberv.Name = "textBox_numberv";
            this.textBox_numberv.Size = new System.Drawing.Size(266, 25);
            this.textBox_numberv.TabIndex = 4;
            // 
            // textBox_transcons
            // 
            this.textBox_transcons.Location = new System.Drawing.Point(224, 184);
            this.textBox_transcons.Multiline = true;
            this.textBox_transcons.Name = "textBox_transcons";
            this.textBox_transcons.Size = new System.Drawing.Size(266, 25);
            this.textBox_transcons.TabIndex = 5;
            // 
            // textBox_prov
            // 
            this.textBox_prov.Location = new System.Drawing.Point(224, 215);
            this.textBox_prov.Multiline = true;
            this.textBox_prov.Name = "textBox_prov";
            this.textBox_prov.Size = new System.Drawing.Size(266, 25);
            this.textBox_prov.TabIndex = 6;
            // 
            // textBox_tonnage
            // 
            this.textBox_tonnage.Location = new System.Drawing.Point(224, 246);
            this.textBox_tonnage.Multiline = true;
            this.textBox_tonnage.Name = "textBox_tonnage";
            this.textBox_tonnage.Size = new System.Drawing.Size(266, 25);
            this.textBox_tonnage.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Наименование материала";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(96, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Дата прихода";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(123, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Номер ТС";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Транспортная накладная";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(115, 218);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "Поставщик";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(138, 249);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "Тоннаж";
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(292, 277);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(132, 43);
            this.button_save.TabIndex = 16;
            this.button_save.Text = "Сохранить";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_tonnage);
            this.Controls.Add(this.textBox_prov);
            this.Controls.Add(this.textBox_transcons);
            this.Controls.Add(this.textBox_numberv);
            this.Controls.Add(this.textBox_date);
            this.Controls.Add(this.textBox_namemat);
            this.Controls.Add(this.panel1);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_namemat;
        private System.Windows.Forms.TextBox textBox_date;
        private System.Windows.Forms.TextBox textBox_numberv;
        private System.Windows.Forms.TextBox textBox_transcons;
        private System.Windows.Forms.TextBox textBox_prov;
        private System.Windows.Forms.TextBox textBox_tonnage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_save;
    }
}