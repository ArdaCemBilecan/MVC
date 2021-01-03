namespace StudentEF
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
            this.lblSearch = new System.Windows.Forms.Label();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.gbxUpdate = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.tbxNoteUpdate = new System.Windows.Forms.TextBox();
            this.lblNameUpdate = new System.Windows.Forms.Label();
            this.LblNoteUpdate = new System.Windows.Forms.Label();
            this.tbxNameUpdate = new System.Windows.Forms.TextBox();
            this.tbxNumberUpdate = new System.Windows.Forms.TextBox();
            this.lblNumberUpdate = new System.Windows.Forms.Label();
            this.gbxAdd = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbxNote = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblNote = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.tbxNumber = new System.Windows.Forms.TextBox();
            this.lblNumber = new System.Windows.Forms.Label();
            this.dgwStudent = new System.Windows.Forms.DataGridView();
            this.gbxUpdate.SuspendLayout();
            this.gbxAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwStudent)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(612, 5);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(41, 13);
            this.lblSearch.TabIndex = 21;
            this.lblSearch.Text = "Search";
            // 
            // tbxSearch
            // 
            this.tbxSearch.Location = new System.Drawing.Point(676, 5);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(100, 20);
            this.tbxSearch.TabIndex = 20;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(48, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(134, 25);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // gbxUpdate
            // 
            this.gbxUpdate.Controls.Add(this.btnUpdate);
            this.gbxUpdate.Controls.Add(this.tbxNoteUpdate);
            this.gbxUpdate.Controls.Add(this.lblNameUpdate);
            this.gbxUpdate.Controls.Add(this.LblNoteUpdate);
            this.gbxUpdate.Controls.Add(this.tbxNameUpdate);
            this.gbxUpdate.Controls.Add(this.tbxNumberUpdate);
            this.gbxUpdate.Controls.Add(this.lblNumberUpdate);
            this.gbxUpdate.Location = new System.Drawing.Point(424, 209);
            this.gbxUpdate.Name = "gbxUpdate";
            this.gbxUpdate.Size = new System.Drawing.Size(352, 178);
            this.gbxUpdate.TabIndex = 18;
            this.gbxUpdate.TabStop = false;
            this.gbxUpdate.Text = "Update a Product";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(263, 140);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(83, 32);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // tbxNoteUpdate
            // 
            this.tbxNoteUpdate.Location = new System.Drawing.Point(110, 113);
            this.tbxNoteUpdate.Name = "tbxNoteUpdate";
            this.tbxNoteUpdate.Size = new System.Drawing.Size(128, 20);
            this.tbxNoteUpdate.TabIndex = 6;
            // 
            // lblNameUpdate
            // 
            this.lblNameUpdate.AutoSize = true;
            this.lblNameUpdate.Location = new System.Drawing.Point(32, 30);
            this.lblNameUpdate.Name = "lblNameUpdate";
            this.lblNameUpdate.Size = new System.Drawing.Size(35, 13);
            this.lblNameUpdate.TabIndex = 1;
            this.lblNameUpdate.Text = "Name";
            // 
            // LblNoteUpdate
            // 
            this.LblNoteUpdate.AutoSize = true;
            this.LblNoteUpdate.Location = new System.Drawing.Point(32, 120);
            this.LblNoteUpdate.Name = "LblNoteUpdate";
            this.LblNoteUpdate.Size = new System.Drawing.Size(30, 13);
            this.LblNoteUpdate.TabIndex = 5;
            this.LblNoteUpdate.Text = "Note";
            // 
            // tbxNameUpdate
            // 
            this.tbxNameUpdate.Location = new System.Drawing.Point(110, 22);
            this.tbxNameUpdate.Name = "tbxNameUpdate";
            this.tbxNameUpdate.Size = new System.Drawing.Size(128, 20);
            this.tbxNameUpdate.TabIndex = 2;
            // 
            // tbxNumberUpdate
            // 
            this.tbxNumberUpdate.Location = new System.Drawing.Point(110, 64);
            this.tbxNumberUpdate.Name = "tbxNumberUpdate";
            this.tbxNumberUpdate.Size = new System.Drawing.Size(128, 20);
            this.tbxNumberUpdate.TabIndex = 4;
            // 
            // lblNumberUpdate
            // 
            this.lblNumberUpdate.AutoSize = true;
            this.lblNumberUpdate.Location = new System.Drawing.Point(32, 71);
            this.lblNumberUpdate.Name = "lblNumberUpdate";
            this.lblNumberUpdate.Size = new System.Drawing.Size(44, 13);
            this.lblNumberUpdate.TabIndex = 3;
            this.lblNumberUpdate.Text = "Number";
            // 
            // gbxAdd
            // 
            this.gbxAdd.Controls.Add(this.btnAdd);
            this.gbxAdd.Controls.Add(this.tbxNote);
            this.gbxAdd.Controls.Add(this.lblName);
            this.gbxAdd.Controls.Add(this.lblNote);
            this.gbxAdd.Controls.Add(this.tbxName);
            this.gbxAdd.Controls.Add(this.tbxNumber);
            this.gbxAdd.Controls.Add(this.lblNumber);
            this.gbxAdd.Location = new System.Drawing.Point(42, 209);
            this.gbxAdd.Name = "gbxAdd";
            this.gbxAdd.Size = new System.Drawing.Size(352, 178);
            this.gbxAdd.TabIndex = 17;
            this.gbxAdd.TabStop = false;
            this.gbxAdd.Text = "Add a Product";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(263, 140);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(83, 32);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // tbxNote
            // 
            this.tbxNote.Location = new System.Drawing.Point(110, 113);
            this.tbxNote.Name = "tbxNote";
            this.tbxNote.Size = new System.Drawing.Size(128, 20);
            this.tbxNote.TabIndex = 6;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(32, 30);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(32, 120);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(30, 13);
            this.lblNote.TabIndex = 5;
            this.lblNote.Text = "Note";
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(110, 22);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(128, 20);
            this.tbxName.TabIndex = 2;
            // 
            // tbxNumber
            // 
            this.tbxNumber.Location = new System.Drawing.Point(110, 64);
            this.tbxNumber.Name = "tbxNumber";
            this.tbxNumber.Size = new System.Drawing.Size(128, 20);
            this.tbxNumber.TabIndex = 4;
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(32, 71);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(44, 13);
            this.lblNumber.TabIndex = 3;
            this.lblNumber.Text = "Number";
            // 
            // dgwStudent
            // 
            this.dgwStudent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgwStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwStudent.Location = new System.Drawing.Point(48, 36);
            this.dgwStudent.Name = "dgwStudent";
            this.dgwStudent.Size = new System.Drawing.Size(728, 167);
            this.dgwStudent.TabIndex = 16;
            this.dgwStudent.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwStudent_CellContentClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 422);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.tbxSearch);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.gbxUpdate);
            this.Controls.Add(this.gbxAdd);
            this.Controls.Add(this.dgwStudent);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbxUpdate.ResumeLayout(false);
            this.gbxUpdate.PerformLayout();
            this.gbxAdd.ResumeLayout(false);
            this.gbxAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwStudent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox gbxUpdate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox tbxNoteUpdate;
        private System.Windows.Forms.Label lblNameUpdate;
        private System.Windows.Forms.Label LblNoteUpdate;
        private System.Windows.Forms.TextBox tbxNameUpdate;
        private System.Windows.Forms.TextBox tbxNumberUpdate;
        private System.Windows.Forms.Label lblNumberUpdate;
        private System.Windows.Forms.GroupBox gbxAdd;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbxNote;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.TextBox tbxNumber;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.DataGridView dgwStudent;
    }
}

