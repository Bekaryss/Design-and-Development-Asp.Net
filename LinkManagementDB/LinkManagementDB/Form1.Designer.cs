namespace LinkManagementDB
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnl_form = new System.Windows.Forms.Panel();
            this.btn_create = new System.Windows.Forms.Button();
            this.tb_create = new System.Windows.Forms.TextBox();
            this.pnl_list = new System.Windows.Forms.Panel();
            this.LinkList = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linkBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btn_upd = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.pnl_edit = new System.Windows.Forms.Panel();
            this.btn_edit = new System.Windows.Forms.Button();
            this.tb_edit = new System.Windows.Forms.TextBox();
            this.pnl_form.SuspendLayout();
            this.pnl_list.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LinkList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkBindingSource)).BeginInit();
            this.pnl_edit.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_form
            // 
            this.pnl_form.Controls.Add(this.btn_create);
            this.pnl_form.Controls.Add(this.tb_create);
            this.pnl_form.Location = new System.Drawing.Point(56, 40);
            this.pnl_form.Name = "pnl_form";
            this.pnl_form.Size = new System.Drawing.Size(579, 206);
            this.pnl_form.TabIndex = 0;
            // 
            // btn_create
            // 
            this.btn_create.Location = new System.Drawing.Point(375, 120);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(75, 23);
            this.btn_create.TabIndex = 1;
            this.btn_create.Text = "Create";
            this.btn_create.UseVisualStyleBackColor = true;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // tb_create
            // 
            this.tb_create.Location = new System.Drawing.Point(78, 32);
            this.tb_create.Name = "tb_create";
            this.tb_create.Size = new System.Drawing.Size(311, 22);
            this.tb_create.TabIndex = 0;
            // 
            // pnl_list
            // 
            this.pnl_list.Controls.Add(this.LinkList);
            this.pnl_list.Controls.Add(this.btn_upd);
            this.pnl_list.Controls.Add(this.btn_delete);
            this.pnl_list.Location = new System.Drawing.Point(721, 40);
            this.pnl_list.Name = "pnl_list";
            this.pnl_list.Size = new System.Drawing.Size(383, 552);
            this.pnl_list.TabIndex = 1;
            // 
            // LinkList
            // 
            this.LinkList.AllowUserToAddRows = false;
            this.LinkList.AllowUserToDeleteRows = false;
            this.LinkList.AutoGenerateColumns = false;
            this.LinkList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LinkList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn});
            this.LinkList.DataSource = this.linkBindingSource;
            this.LinkList.Location = new System.Drawing.Point(25, 17);
            this.LinkList.Name = "LinkList";
            this.LinkList.ReadOnly = true;
            this.LinkList.RowTemplate.Height = 24;
            this.LinkList.Size = new System.Drawing.Size(294, 295);
            this.LinkList.TabIndex = 3;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // linkBindingSource
            // 
            this.linkBindingSource.DataSource = typeof(LinkManagementDB.Models.Link);
            // 
            // btn_upd
            // 
            this.btn_upd.Location = new System.Drawing.Point(25, 357);
            this.btn_upd.Name = "btn_upd";
            this.btn_upd.Size = new System.Drawing.Size(75, 23);
            this.btn_upd.TabIndex = 2;
            this.btn_upd.Text = "Update";
            this.btn_upd.UseVisualStyleBackColor = true;
            this.btn_upd.Click += new System.EventHandler(this.btn_upd_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(244, 357);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 23);
            this.btn_delete.TabIndex = 1;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // pnl_edit
            // 
            this.pnl_edit.Controls.Add(this.btn_edit);
            this.pnl_edit.Controls.Add(this.tb_edit);
            this.pnl_edit.Location = new System.Drawing.Point(56, 282);
            this.pnl_edit.Name = "pnl_edit";
            this.pnl_edit.Size = new System.Drawing.Size(579, 280);
            this.pnl_edit.TabIndex = 2;
            // 
            // btn_edit
            // 
            this.btn_edit.Location = new System.Drawing.Point(375, 84);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(75, 23);
            this.btn_edit.TabIndex = 2;
            this.btn_edit.Text = "Edit";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // tb_edit
            // 
            this.tb_edit.Location = new System.Drawing.Point(78, 33);
            this.tb_edit.Name = "tb_edit";
            this.tb_edit.Size = new System.Drawing.Size(311, 22);
            this.tb_edit.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 736);
            this.Controls.Add(this.pnl_edit);
            this.Controls.Add(this.pnl_list);
            this.Controls.Add(this.pnl_form);
            this.Name = "Form1";
            this.Text = "Form1";
            this.pnl_form.ResumeLayout(false);
            this.pnl_form.PerformLayout();
            this.pnl_list.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LinkList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkBindingSource)).EndInit();
            this.pnl_edit.ResumeLayout(false);
            this.pnl_edit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_form;
        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.TextBox tb_create;
        private System.Windows.Forms.Panel pnl_list;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Panel pnl_edit;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.TextBox tb_edit;
        private System.Windows.Forms.Button btn_upd;
        private System.Windows.Forms.DataGridView LinkList;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource linkBindingSource;
    }
}

