namespace ColorTriangle
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
            this.pnl_Draw = new System.Windows.Forms.Panel();
            this.btn_color1 = new System.Windows.Forms.Button();
            this.btn_color2 = new System.Windows.Forms.Button();
            this.btn_color3 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // pnl_Draw
            // 
            this.pnl_Draw.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnl_Draw.Location = new System.Drawing.Point(217, 12);
            this.pnl_Draw.Name = "pnl_Draw";
            this.pnl_Draw.Size = new System.Drawing.Size(842, 657);
            this.pnl_Draw.TabIndex = 0;
            this.pnl_Draw.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_Draw_Paint);
            // 
            // btn_color1
            // 
            this.btn_color1.Location = new System.Drawing.Point(65, 39);
            this.btn_color1.Name = "btn_color1";
            this.btn_color1.Size = new System.Drawing.Size(75, 23);
            this.btn_color1.TabIndex = 1;
            this.btn_color1.Text = "Color 1";
            this.btn_color1.UseVisualStyleBackColor = true;
            this.btn_color1.Click += new System.EventHandler(this.btn_color1_Click);
            // 
            // btn_color2
            // 
            this.btn_color2.Location = new System.Drawing.Point(65, 80);
            this.btn_color2.Name = "btn_color2";
            this.btn_color2.Size = new System.Drawing.Size(75, 23);
            this.btn_color2.TabIndex = 2;
            this.btn_color2.Text = "Color 2";
            this.btn_color2.UseVisualStyleBackColor = true;
            this.btn_color2.Click += new System.EventHandler(this.btn_color2_Click);
            // 
            // btn_color3
            // 
            this.btn_color3.Location = new System.Drawing.Point(65, 122);
            this.btn_color3.Name = "btn_color3";
            this.btn_color3.Size = new System.Drawing.Size(75, 23);
            this.btn_color3.TabIndex = 3;
            this.btn_color3.Text = "Color 3";
            this.btn_color3.UseVisualStyleBackColor = true;
            this.btn_color3.Click += new System.EventHandler(this.btn_color3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(1071, 678);
            this.Controls.Add(this.btn_color3);
            this.Controls.Add(this.btn_color2);
            this.Controls.Add(this.btn_color1);
            this.Controls.Add(this.pnl_Draw);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Draw;
        private System.Windows.Forms.Button btn_color1;
        private System.Windows.Forms.Button btn_color2;
        private System.Windows.Forms.Button btn_color3;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}

