﻿namespace ContestFormApp
{
    partial class Form1
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
            this.catVarstaList = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.competitionsList = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.participantsTable = new System.Windows.Forms.DataGridView();
            this.IdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AgeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoCompCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.filterRadio = new System.Windows.Forms.RadioButton();
            this.allRadio = new System.Windows.Forms.RadioButton();
            this.filter = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.compList2 = new System.Windows.Forms.CheckedListBox();
            this.comp2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comp1 = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.AgeBox = new System.Windows.Forms.TextBox();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.logOutBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.participantsTable)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // catVarstaList
            // 
            this.catVarstaList.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.catVarstaList.FormattingEnabled = true;
            this.catVarstaList.Location = new System.Drawing.Point(6, 168);
            this.catVarstaList.Name = "catVarstaList";
            this.catVarstaList.Size = new System.Drawing.Size(101, 64);
            this.catVarstaList.TabIndex = 0;
            this.catVarstaList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.handleSelectionAgeCategs);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Age Categories";
            // 
            // competitionsList
            // 
            this.competitionsList.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.competitionsList.FormattingEnabled = true;
            this.competitionsList.Location = new System.Drawing.Point(6, 278);
            this.competitionsList.Name = "competitionsList";
            this.competitionsList.Size = new System.Drawing.Size(101, 94);
            this.competitionsList.TabIndex = 2;
            this.competitionsList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.handleSelectionCompetitions);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Competitions";
            // 
            // participantsTable
            // 
            this.participantsTable.AllowUserToAddRows = false;
            this.participantsTable.AllowUserToDeleteRows = false;
            this.participantsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.participantsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdCol,
            this.NameCol,
            this.AgeCol,
            this.NoCompCol});
            this.participantsTable.Location = new System.Drawing.Point(154, 78);
            this.participantsTable.Name = "participantsTable";
            this.participantsTable.ReadOnly = true;
            this.participantsTable.Size = new System.Drawing.Size(284, 345);
            this.participantsTable.TabIndex = 4;
            this.participantsTable.SelectionChanged += new System.EventHandler(this.handleParticipantsSelection);
            // 
            // IdCol
            // 
            this.IdCol.HeaderText = "Id";
            this.IdCol.MaxInputLength = 100;
            this.IdCol.Name = "IdCol";
            this.IdCol.ReadOnly = true;
            this.IdCol.Width = 40;
            // 
            // NameCol
            // 
            this.NameCol.HeaderText = "Name";
            this.NameCol.Name = "NameCol";
            this.NameCol.ReadOnly = true;
            // 
            // AgeCol
            // 
            this.AgeCol.HeaderText = "Age";
            this.AgeCol.Name = "AgeCol";
            this.AgeCol.ReadOnly = true;
            this.AgeCol.Width = 40;
            // 
            // NoCompCol
            // 
            this.NoCompCol.HeaderText = "NoComp";
            this.NoCompCol.Name = "NoCompCol";
            this.NoCompCol.ReadOnly = true;
            this.NoCompCol.Width = 60;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.Controls.Add(this.filterRadio);
            this.panel1.Controls.Add(this.allRadio);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.catVarstaList);
            this.panel1.Controls.Add(this.competitionsList);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(127, 453);
            this.panel1.TabIndex = 5;
            // 
            // filterRadio
            // 
            this.filterRadio.AutoSize = true;
            this.filterRadio.Location = new System.Drawing.Point(3, 93);
            this.filterRadio.Name = "filterRadio";
            this.filterRadio.Size = new System.Drawing.Size(114, 17);
            this.filterRadio.TabIndex = 5;
            this.filterRadio.TabStop = true;
            this.filterRadio.Text = "Filter by Categories";
            this.filterRadio.UseVisualStyleBackColor = true;
            // 
            // allRadio
            // 
            this.allRadio.AutoSize = true;
            this.allRadio.Location = new System.Drawing.Point(3, 70);
            this.allRadio.Name = "allRadio";
            this.allRadio.Size = new System.Drawing.Size(94, 17);
            this.allRadio.TabIndex = 4;
            this.allRadio.TabStop = true;
            this.allRadio.Text = "All Participants";
            this.allRadio.UseVisualStyleBackColor = true;
            this.allRadio.CheckedChanged += new System.EventHandler(this.handleRadioButtons);
            // 
            // filter
            // 
            this.filter.Location = new System.Drawing.Point(242, 40);
            this.filter.Name = "filter";
            this.filter.Size = new System.Drawing.Size(196, 20);
            this.filter.TabIndex = 7;
            this.filter.TextChanged += new System.EventHandler(this.handleFilter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(151, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Filter by name";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateGray;
            this.panel2.Controls.Add(this.logOutBtn);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.compList2);
            this.panel2.Controls.Add(this.comp2);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.comp1);
            this.panel2.Controls.Add(this.label);
            this.panel2.Controls.Add(this.AgeBox);
            this.panel2.Controls.Add(this.NameBox);
            this.panel2.Location = new System.Drawing.Point(599, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 453);
            this.panel2.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Competition 2";
            // 
            // compList2
            // 
            this.compList2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.compList2.FormattingEnabled = true;
            this.compList2.Location = new System.Drawing.Point(48, 244);
            this.compList2.Name = "compList2";
            this.compList2.Size = new System.Drawing.Size(120, 94);
            this.compList2.TabIndex = 5;
            // 
            // comp2
            // 
            this.comp2.Location = new System.Drawing.Point(98, 169);
            this.comp2.Name = "comp2";
            this.comp2.Size = new System.Drawing.Size(91, 20);
            this.comp2.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Competition 1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 209);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Get Available Competitions";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.handleGetCompetitions2);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Age";
            // 
            // comp1
            // 
            this.comp1.Location = new System.Drawing.Point(98, 143);
            this.comp1.Name = "comp1";
            this.comp1.Size = new System.Drawing.Size(91, 20);
            this.comp1.TabIndex = 1;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(19, 78);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(35, 13);
            this.label.TabIndex = 2;
            this.label.Text = "Name";
            // 
            // AgeBox
            // 
            this.AgeBox.Location = new System.Drawing.Point(61, 104);
            this.AgeBox.Name = "AgeBox";
            this.AgeBox.Size = new System.Drawing.Size(128, 20);
            this.AgeBox.TabIndex = 1;
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(60, 75);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(128, 20);
            this.NameBox.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::ContestFormApp.Properties.Resources.arrow;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Location = new System.Drawing.Point(461, 78);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 53);
            this.button2.TabIndex = 6;
            this.button2.Text = "Add";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.handleAddParticipant);
            this.button2.MouseLeave += new System.EventHandler(this.handleUndoHover);
            this.button2.MouseHover += new System.EventHandler(this.handleHover);
            // 
            // button3
            // 
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.Location = new System.Drawing.Point(461, 153);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 51);
            this.button3.TabIndex = 0;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.handleDeleteParticipant);
            this.button3.MouseLeave += new System.EventHandler(this.handleUndoHover);
            this.button3.MouseHover += new System.EventHandler(this.handleHover);
            // 
            // logOutBtn
            // 
            this.logOutBtn.Location = new System.Drawing.Point(48, 390);
            this.logOutBtn.Name = "logOutBtn";
            this.logOutBtn.Size = new System.Drawing.Size(120, 48);
            this.logOutBtn.TabIndex = 0;
            this.logOutBtn.Text = "LogOut";
            this.logOutBtn.UseVisualStyleBackColor = true;
            this.logOutBtn.Click += new System.EventHandler(this.logOutBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.filter);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.participantsTable);
            this.Name = "Form1";
            this.Text = "ContestApp for user:  ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.participantsTable)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox catVarstaList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox competitionsList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView participantsTable;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn AgeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoCompCol;
        private System.Windows.Forms.TextBox filter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton allRadio;
        private System.Windows.Forms.RadioButton filterRadio;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox AgeBox;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckedListBox compList2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox comp2;
        private System.Windows.Forms.TextBox comp1;
        private System.Windows.Forms.Button logOutBtn;
    }
}

