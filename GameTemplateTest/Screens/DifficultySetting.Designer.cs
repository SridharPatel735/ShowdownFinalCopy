namespace GameTemplateTest
{
    partial class DifficultySetting
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DifficultySetting));
            this.image1 = new System.Windows.Forms.Button();
            this.difficultyLabel = new System.Windows.Forms.Label();
            this.image2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // image1
            // 
            this.image1.BackColor = System.Drawing.Color.Transparent;
            this.image1.BackgroundImage = global::GameTemplateTest.Properties.Resources.marco_left;
            this.image1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.image1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.image1.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.image1.Location = new System.Drawing.Point(194, 348);
            this.image1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.image1.Name = "image1";
            this.image1.Size = new System.Drawing.Size(251, 272);
            this.image1.TabIndex = 0;
            this.image1.UseVisualStyleBackColor = false;
            this.image1.Click += new System.EventHandler(this.image1_Click);
            // 
            // difficultyLabel
            // 
            this.difficultyLabel.BackColor = System.Drawing.Color.Transparent;
            this.difficultyLabel.Font = new System.Drawing.Font("PMingLiU-ExtB", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.difficultyLabel.ForeColor = System.Drawing.Color.Maroon;
            this.difficultyLabel.Location = new System.Drawing.Point(3, 0);
            this.difficultyLabel.Name = "difficultyLabel";
            this.difficultyLabel.Size = new System.Drawing.Size(546, 344);
            this.difficultyLabel.TabIndex = 3;
            this.difficultyLabel.Text = "CHOOSE YOUR HERO";
            // 
            // image2
            // 
            this.image2.BackColor = System.Drawing.Color.Transparent;
            this.image2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("image2.BackgroundImage")));
            this.image2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.image2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.image2.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.image2.Location = new System.Drawing.Point(491, 348);
            this.image2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.image2.Name = "image2";
            this.image2.Size = new System.Drawing.Size(251, 272);
            this.image2.TabIndex = 4;
            this.image2.UseVisualStyleBackColor = false;
            this.image2.Click += new System.EventHandler(this.image2_Click);
            // 
            // DifficultySetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.image2);
            this.Controls.Add(this.difficultyLabel);
            this.Controls.Add(this.image1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DifficultySetting";
            this.Size = new System.Drawing.Size(857, 624);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button image1;
        private System.Windows.Forms.Label difficultyLabel;
        private System.Windows.Forms.Button image2;
    }
}
