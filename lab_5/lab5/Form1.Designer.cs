
namespace lab5
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
            this.clipBtn = new System.Windows.Forms.Button();
            this.middleBtn = new System.Windows.Forms.Button();
            this.inputTb = new System.Windows.Forms.TextBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // clipBtn
            // 
            this.clipBtn.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clipBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.clipBtn.Location = new System.Drawing.Point(977, 464);
            this.clipBtn.Name = "clipBtn";
            this.clipBtn.Size = new System.Drawing.Size(128, 60);
            this.clipBtn.TabIndex = 7;
            this.clipBtn.Text = "Clip line by polygon";
            this.clipBtn.UseVisualStyleBackColor = true;
            this.clipBtn.Click += new System.EventHandler(this.clipBtn_Click);
            // 
            // middleBtn
            // 
            this.middleBtn.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.middleBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.middleBtn.Location = new System.Drawing.Point(811, 464);
            this.middleBtn.Name = "middleBtn";
            this.middleBtn.Size = new System.Drawing.Size(128, 60);
            this.middleBtn.TabIndex = 6;
            this.middleBtn.Text = "Middle Point";
            this.middleBtn.UseVisualStyleBackColor = true;
            this.middleBtn.Click += new System.EventHandler(this.middleBtn_Click);
            // 
            // inputTb
            // 
            this.inputTb.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inputTb.Location = new System.Drawing.Point(811, 80);
            this.inputTb.Multiline = true;
            this.inputTb.Name = "inputTb";
            this.inputTb.Size = new System.Drawing.Size(294, 294);
            this.inputTb.TabIndex = 4;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(29, 28);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(10);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(750, 601);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 5;
            this.pictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(805, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 34);
            this.label1.TabIndex = 8;
            this.label1.Text = "Initial parameters";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Candara", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(805, 410);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 35);
            this.label2.TabIndex = 9;
            this.label2.Text = "Algorithms";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1136, 675);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clipBtn);
            this.Controls.Add(this.middleBtn);
            this.Controls.Add(this.inputTb);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.Text = "Lab 5";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button clipBtn;
        private System.Windows.Forms.Button middleBtn;
        private System.Windows.Forms.TextBox inputTb;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

