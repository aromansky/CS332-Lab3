namespace CS332_Lab2
{
    partial class Menu
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.task1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.task2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.task3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_color = new System.Windows.Forms.Button();
            this.button_image = new System.Windows.Forms.Button();
            this.button_bolder = new System.Windows.Forms.Button();
            this.button_bresenham = new System.Windows.Forms.Button();
            this.button_wu = new System.Windows.Forms.Button();
            this.button_select_color = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox_oldcolor = new System.Windows.Forms.PictureBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox_newcolor = new System.Windows.Forms.PictureBox();
            this.drawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_triangle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_oldcolor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_newcolor)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.Enabled = false;
            this.pictureBox.Location = new System.Drawing.Point(12, 36);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(626, 402);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageToolStripMenuItem,
            this.taskToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadImageToolStripMenuItem,
            this.saveImageToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.drawToolStripMenuItem});
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.imageToolStripMenuItem.Text = "Image";
            // 
            // loadImageToolStripMenuItem
            // 
            this.loadImageToolStripMenuItem.Name = "loadImageToolStripMenuItem";
            this.loadImageToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.loadImageToolStripMenuItem.Text = "Load image";
            this.loadImageToolStripMenuItem.Click += new System.EventHandler(this.loadImageToolStripMenuItem_Click);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.saveImageToolStripMenuItem.Text = "Save image";
            this.saveImageToolStripMenuItem.Click += new System.EventHandler(this.saveImageToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // taskToolStripMenuItem
            // 
            this.taskToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.task1ToolStripMenuItem,
            this.task2ToolStripMenuItem,
            this.task3ToolStripMenuItem});
            this.taskToolStripMenuItem.Name = "taskToolStripMenuItem";
            this.taskToolStripMenuItem.Size = new System.Drawing.Size(50, 24);
            this.taskToolStripMenuItem.Text = "Task";
            // 
            // task1ToolStripMenuItem
            // 
            this.task1ToolStripMenuItem.Name = "task1ToolStripMenuItem";
            this.task1ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.task1ToolStripMenuItem.Text = "Task1";
            this.task1ToolStripMenuItem.Click += new System.EventHandler(this.task1ToolStripMenuItem_Click);
            // 
            // task2ToolStripMenuItem
            // 
            this.task2ToolStripMenuItem.Name = "task2ToolStripMenuItem";
            this.task2ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.task2ToolStripMenuItem.Text = "Task2";
            this.task2ToolStripMenuItem.Click += new System.EventHandler(this.task2ToolStripMenuItem_Click);
            // 
            // task3ToolStripMenuItem
            // 
            this.task3ToolStripMenuItem.Name = "task3ToolStripMenuItem";
            this.task3ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.task3ToolStripMenuItem.Text = "Task3";
            this.task3ToolStripMenuItem.Click += new System.EventHandler(this.task3ToolStripMenuItem_Click);
            // 
            // button_color
            // 
            this.button_color.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_color.Enabled = false;
            this.button_color.Location = new System.Drawing.Point(644, 156);
            this.button_color.Name = "button_color";
            this.button_color.Size = new System.Drawing.Size(144, 54);
            this.button_color.TabIndex = 2;
            this.button_color.Text = "Заливка цветом";
            this.button_color.UseVisualStyleBackColor = true;
            this.button_color.Visible = false;
            this.button_color.Click += new System.EventHandler(this.button_color_Click);
            // 
            // button_image
            // 
            this.button_image.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_image.Enabled = false;
            this.button_image.Location = new System.Drawing.Point(644, 36);
            this.button_image.Name = "button_image";
            this.button_image.Size = new System.Drawing.Size(144, 54);
            this.button_image.TabIndex = 3;
            this.button_image.Text = "Заливка рисунком";
            this.button_image.UseVisualStyleBackColor = true;
            this.button_image.Visible = false;
            this.button_image.Click += new System.EventHandler(this.button_image_Click);
            // 
            // button_bolder
            // 
            this.button_bolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_bolder.Enabled = false;
            this.button_bolder.Location = new System.Drawing.Point(644, 96);
            this.button_bolder.Name = "button_bolder";
            this.button_bolder.Size = new System.Drawing.Size(144, 54);
            this.button_bolder.TabIndex = 4;
            this.button_bolder.Text = "Выделение границы";
            this.button_bolder.UseVisualStyleBackColor = true;
            this.button_bolder.Visible = false;
            this.button_bolder.Click += new System.EventHandler(this.button_bolder_Click);
            // 
            // button_bresenham
            // 
            this.button_bresenham.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_bresenham.Enabled = false;
            this.button_bresenham.Location = new System.Drawing.Point(644, 36);
            this.button_bresenham.Name = "button_bresenham";
            this.button_bresenham.Size = new System.Drawing.Size(144, 54);
            this.button_bresenham.TabIndex = 5;
            this.button_bresenham.Text = "Алгоритм Брезенхейма";
            this.button_bresenham.UseVisualStyleBackColor = true;
            this.button_bresenham.Visible = false;
            this.button_bresenham.Click += new System.EventHandler(this.button_bresenham_Click);
            // 
            // button_wu
            // 
            this.button_wu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_wu.Enabled = false;
            this.button_wu.Location = new System.Drawing.Point(644, 96);
            this.button_wu.Name = "button_wu";
            this.button_wu.Size = new System.Drawing.Size(144, 54);
            this.button_wu.TabIndex = 6;
            this.button_wu.Text = "Алгоритм Ву";
            this.button_wu.UseVisualStyleBackColor = true;
            this.button_wu.Visible = false;
            this.button_wu.Click += new System.EventHandler(this.button_wu_Click);
            // 
            // button_select_color
            // 
            this.button_select_color.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_select_color.Enabled = false;
            this.button_select_color.Location = new System.Drawing.Point(644, 36);
            this.button_select_color.Name = "button_select_color";
            this.button_select_color.Size = new System.Drawing.Size(144, 54);
            this.button_select_color.TabIndex = 7;
            this.button_select_color.Text = "Выбрать цвет";
            this.button_select_color.UseVisualStyleBackColor = true;
            this.button_select_color.Visible = false;
            this.button_select_color.Click += new System.EventHandler(this.button_select_color_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(644, 283);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Текущий цвет: ";
            this.label1.Visible = false;
            // 
            // pictureBox_oldcolor
            // 
            this.pictureBox_oldcolor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_oldcolor.BackColor = System.Drawing.Color.Red;
            this.pictureBox_oldcolor.Enabled = false;
            this.pictureBox_oldcolor.Location = new System.Drawing.Point(754, 283);
            this.pictureBox_oldcolor.Name = "pictureBox_oldcolor";
            this.pictureBox_oldcolor.Size = new System.Drawing.Size(34, 16);
            this.pictureBox_oldcolor.TabIndex = 9;
            this.pictureBox_oldcolor.TabStop = false;
            this.pictureBox_oldcolor.Visible = false;
            // 
            // colorDialog
            // 
            this.colorDialog.AnyColor = true;
            this.colorDialog.Color = System.Drawing.Color.Red;
            this.colorDialog.FullOpen = true;
            this.colorDialog.SolidColorOnly = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(644, 299);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Новый цвет: ";
            this.label2.Visible = false;
            // 
            // pictureBox_newcolor
            // 
            this.pictureBox_newcolor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_newcolor.BackColor = System.Drawing.Color.Red;
            this.pictureBox_newcolor.Enabled = false;
            this.pictureBox_newcolor.Location = new System.Drawing.Point(754, 302);
            this.pictureBox_newcolor.Name = "pictureBox_newcolor";
            this.pictureBox_newcolor.Size = new System.Drawing.Size(34, 16);
            this.pictureBox_newcolor.TabIndex = 11;
            this.pictureBox_newcolor.TabStop = false;
            this.pictureBox_newcolor.Visible = false;
            this.pictureBox_newcolor.Click += new System.EventHandler(this.pictureBox_newcolor_Click);
            // 
            // drawToolStripMenuItem
            // 
            this.drawToolStripMenuItem.Name = "drawToolStripMenuItem";
            this.drawToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.drawToolStripMenuItem.Text = "Draw";
            this.drawToolStripMenuItem.Click += new System.EventHandler(this.drawToolStripMenuItem_Click);
            // 
            // button_triangle
            // 
            this.button_triangle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_triangle.Enabled = false;
            this.button_triangle.Location = new System.Drawing.Point(644, 96);
            this.button_triangle.Name = "button_triangle";
            this.button_triangle.Size = new System.Drawing.Size(144, 54);
            this.button_triangle.TabIndex = 12;
            this.button_triangle.Text = "Выполнить заливку";
            this.button_triangle.UseVisualStyleBackColor = true;
            this.button_triangle.Visible = false;
            this.button_triangle.Click += new System.EventHandler(this.button_triangle_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_triangle);
            this.Controls.Add(this.pictureBox_newcolor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox_oldcolor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_select_color);
            this.Controls.Add(this.button_wu);
            this.Controls.Add(this.button_bresenham);
            this.Controls.Add(this.button_bolder);
            this.Controls.Add(this.button_image);
            this.Controls.Add(this.button_color);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_oldcolor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_newcolor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem taskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem task1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem task2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem task3ToolStripMenuItem;
        private System.Windows.Forms.Button button_color;
        private System.Windows.Forms.Button button_image;
        private System.Windows.Forms.Button button_bolder;
        private System.Windows.Forms.Button button_bresenham;
        private System.Windows.Forms.Button button_wu;
        private System.Windows.Forms.Button button_select_color;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox_oldcolor;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox_newcolor;
        private System.Windows.Forms.ToolStripMenuItem drawToolStripMenuItem;
        private System.Windows.Forms.Button button_triangle;
    }
}

