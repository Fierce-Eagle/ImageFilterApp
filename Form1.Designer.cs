namespace ImageFilter_Lab
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.loadImage = new System.Windows.Forms.Button();
            this.perform = new System.Windows.Forms.Button();
            this.median = new System.Windows.Forms.Button();
            this.addSharpness = new System.Windows.Forms.Button();
            this.addNoise = new System.Windows.Forms.Button();
            this.acvarel = new System.Windows.Forms.Button();
            this.blackWhiteColor = new System.Windows.Forms.Button();
            this.grayColor = new System.Windows.Forms.Button();
            this.correctBrightTrackBar = new System.Windows.Forms.TrackBar();
            this.correctContrastTrackBar = new System.Windows.Forms.TrackBar();
            this.openFileDialogImage = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.correctBrightTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.correctContrastTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1024, 768);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // loadImage
            // 
            this.loadImage.Location = new System.Drawing.Point(1031, 13);
            this.loadImage.Name = "loadImage";
            this.loadImage.Size = new System.Drawing.Size(200, 60);
            this.loadImage.TabIndex = 1;
            this.loadImage.Text = "Загрузить изображение";
            this.loadImage.UseVisualStyleBackColor = true;
            this.loadImage.Click += new System.EventHandler(this.LoadImage_Click);
            // 
            // perform
            // 
            this.perform.Location = new System.Drawing.Point(1031, 79);
            this.perform.Name = "perform";
            this.perform.Size = new System.Drawing.Size(200, 60);
            this.perform.TabIndex = 2;
            this.perform.Text = "Равномерный фильтр";
            this.perform.UseVisualStyleBackColor = true;
            this.perform.Click += new System.EventHandler(this.Perform_Click);
            // 
            // median
            // 
            this.median.Location = new System.Drawing.Point(1031, 145);
            this.median.Name = "median";
            this.median.Size = new System.Drawing.Size(200, 60);
            this.median.TabIndex = 3;
            this.median.Text = "Медианный фильтр";
            this.median.UseVisualStyleBackColor = true;
            this.median.Click += new System.EventHandler(this.Median_Click);
            // 
            // addSharpness
            // 
            this.addSharpness.Location = new System.Drawing.Point(1030, 211);
            this.addSharpness.Name = "addSharpness";
            this.addSharpness.Size = new System.Drawing.Size(200, 60);
            this.addSharpness.TabIndex = 4;
            this.addSharpness.Text = "Добавить резкости";
            this.addSharpness.UseVisualStyleBackColor = true;
            this.addSharpness.Click += new System.EventHandler(this.AddSharpness_Click);
            // 
            // addNoise
            // 
            this.addNoise.Location = new System.Drawing.Point(1031, 277);
            this.addNoise.Name = "addNoise";
            this.addNoise.Size = new System.Drawing.Size(200, 60);
            this.addNoise.TabIndex = 5;
            this.addNoise.Text = "Добавить шумы";
            this.addNoise.UseVisualStyleBackColor = true;
            this.addNoise.Click += new System.EventHandler(this.AddNoise_Click);
            // 
            // acvarel
            // 
            this.acvarel.Location = new System.Drawing.Point(1031, 343);
            this.acvarel.Name = "acvarel";
            this.acvarel.Size = new System.Drawing.Size(200, 60);
            this.acvarel.TabIndex = 6;
            this.acvarel.Text = "Акварелизация";
            this.acvarel.UseVisualStyleBackColor = true;
            this.acvarel.Click += new System.EventHandler(this.Acvarel_Click);
            // 
            // blackWhiteColor
            // 
            this.blackWhiteColor.Location = new System.Drawing.Point(1031, 409);
            this.blackWhiteColor.Name = "blackWhiteColor";
            this.blackWhiteColor.Size = new System.Drawing.Size(200, 60);
            this.blackWhiteColor.TabIndex = 7;
            this.blackWhiteColor.Text = "Сделать чёрно-белым";
            this.blackWhiteColor.UseVisualStyleBackColor = true;
            this.blackWhiteColor.Click += new System.EventHandler(this.BlackWhiteColor_Click);
            // 
            // grayColor
            // 
            this.grayColor.Location = new System.Drawing.Point(1031, 475);
            this.grayColor.Name = "grayColor";
            this.grayColor.Size = new System.Drawing.Size(200, 60);
            this.grayColor.TabIndex = 8;
            this.grayColor.Text = "Сделать в оттенках серого";
            this.grayColor.UseVisualStyleBackColor = true;
            this.grayColor.Click += new System.EventHandler(this.GrayColor_Click);
            // 
            // correctBrightTrackBar
            // 
            this.correctBrightTrackBar.Location = new System.Drawing.Point(1031, 642);
            this.correctBrightTrackBar.Name = "correctBrightTrackBar";
            this.correctBrightTrackBar.Size = new System.Drawing.Size(200, 45);
            this.correctBrightTrackBar.TabIndex = 100;
            this.correctBrightTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.correctBrightTrackBar.Value = 5;
            this.correctBrightTrackBar.Scroll += new System.EventHandler(this.CorrectBrightTrackBar_Scroll);
            // 
            // correctContrastTrackBar
            // 
            this.correctContrastTrackBar.Location = new System.Drawing.Point(1031, 710);
            this.correctContrastTrackBar.Name = "correctContrastTrackBar";
            this.correctContrastTrackBar.Size = new System.Drawing.Size(200, 45);
            this.correctContrastTrackBar.TabIndex = 100;
            this.correctContrastTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.correctContrastTrackBar.Value = 5;
            this.correctContrastTrackBar.Scroll += new System.EventHandler(this.CorrectContrastTrackBar_Scroll);
            // 
            // openFileDialogImage
            // 
            this.openFileDialogImage.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(1100, 622);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 101;
            this.label1.Text = "Яркость";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(1100, 690);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 102;
            this.label2.Text = "Контраст";
            // 
            // negative
            // 
            this.button1.Location = new System.Drawing.Point(1031, 541);
            this.button1.Name = "negative";
            this.button1.Size = new System.Drawing.Size(200, 60);
            this.button1.TabIndex = 103;
            this.button1.Text = "Негатив";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Negative_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 767);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.correctContrastTrackBar);
            this.Controls.Add(this.correctBrightTrackBar);
            this.Controls.Add(this.grayColor);
            this.Controls.Add(this.blackWhiteColor);
            this.Controls.Add(this.acvarel);
            this.Controls.Add(this.addNoise);
            this.Controls.Add(this.addSharpness);
            this.Controls.Add(this.median);
            this.Controls.Add(this.perform);
            this.Controls.Add(this.loadImage);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Фильтр изображений";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.correctBrightTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.correctContrastTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button loadImage;
        private System.Windows.Forms.Button perform;
        private System.Windows.Forms.Button median;
        private System.Windows.Forms.Button addSharpness;
        private System.Windows.Forms.Button addNoise;
        private System.Windows.Forms.Button acvarel;
        private System.Windows.Forms.Button blackWhiteColor;
        private System.Windows.Forms.Button grayColor;
        private System.Windows.Forms.TrackBar correctBrightTrackBar;
        private System.Windows.Forms.TrackBar correctContrastTrackBar;
        private System.Windows.Forms.OpenFileDialog openFileDialogImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}

