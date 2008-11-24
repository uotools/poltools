namespace Controls
{
    partial class LandTilesAlternative
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
            this.vScrollBar = new System.Windows.Forms.VScrollBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.namelabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.graphiclabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.FlagsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // vScrollBar
            // 
            this.vScrollBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar.Location = new System.Drawing.Point(602, 0);
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Size = new System.Drawing.Size(17, 302);
            this.vScrollBar.TabIndex = 7;
            this.vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.OnScroll);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.namelabel,
            this.graphiclabel,
            this.FlagsLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 302);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(619, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.pictureBox.Size = new System.Drawing.Size(602, 302);
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            this.pictureBox.Click += new System.EventHandler(this.OnClick);
            this.pictureBox.SizeChanged += new System.EventHandler(this.OnResize);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(602, 302);
            this.panel1.TabIndex = 3;
            // 
            // namelabel
            // 
            this.namelabel.AutoSize = false;
            this.namelabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.namelabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.namelabel.Name = "namelabel";
            this.namelabel.Size = new System.Drawing.Size(150, 17);
            this.namelabel.Text = "Name:";
            this.namelabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // graphiclabel
            // 
            this.graphiclabel.AutoSize = false;
            this.graphiclabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.graphiclabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.graphiclabel.Name = "graphiclabel";
            this.graphiclabel.Size = new System.Drawing.Size(100, 17);
            this.graphiclabel.Text = "Graphic:";
            this.graphiclabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FlagsLabel
            // 
            this.FlagsLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FlagsLabel.Name = "FlagsLabel";
            this.FlagsLabel.Size = new System.Drawing.Size(36, 17);
            this.FlagsLabel.Text = "Flags:";
            this.FlagsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LandTilesAlternative
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.vScrollBar);
            this.Controls.Add(this.statusStrip1);
            this.Name = "LandTilesAlternative";
            this.Size = new System.Drawing.Size(619, 324);
            this.Load += new System.EventHandler(this.OnLoad);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.VScrollBar vScrollBar;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripStatusLabel namelabel;
        private System.Windows.Forms.ToolStripStatusLabel graphiclabel;
        private System.Windows.Forms.ToolStripStatusLabel FlagsLabel;

    }
}
