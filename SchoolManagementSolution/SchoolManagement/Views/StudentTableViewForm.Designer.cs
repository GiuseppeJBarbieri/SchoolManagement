
namespace SchoolManagement.Views
{
    partial class StudentTableViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentTableViewForm));
            this.backBtn = new System.Windows.Forms.Button();
            this.StudentTableGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.StudentTableGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // backBtn
            // 
            this.backBtn.BackColor = System.Drawing.Color.White;
            this.backBtn.Location = new System.Drawing.Point(847, 258);
            this.backBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(116, 45);
            this.backBtn.TabIndex = 1;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = false;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // StudentTableGrid
            // 
            this.StudentTableGrid.AllowUserToAddRows = false;
            this.StudentTableGrid.AllowUserToDeleteRows = false;
            this.StudentTableGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudentTableGrid.Location = new System.Drawing.Point(45, 31);
            this.StudentTableGrid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.StudentTableGrid.Name = "StudentTableGrid";
            this.StudentTableGrid.ReadOnly = true;
            this.StudentTableGrid.Size = new System.Drawing.Size(917, 210);
            this.StudentTableGrid.TabIndex = 2;
            // 
            // StudentTableViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1005, 358);
            this.Controls.Add(this.StudentTableGrid);
            this.Controls.Add(this.backBtn);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "StudentTableViewForm";
            this.Text = "StudentTableViewForm";
            this.Load += new System.EventHandler(this.StudentTableViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StudentTableGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
       
        
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.DataGridView StudentTableGrid;
    }
}