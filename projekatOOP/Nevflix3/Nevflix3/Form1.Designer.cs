
namespace Nevflix3
{
    partial class forma
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
            this.Nevflix = new System.Windows.Forms.PictureBox();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cbZanrovi = new System.Windows.Forms.ComboBox();
            this.lblPoslednjeGledano = new System.Windows.Forms.Label();
            this.pnlPoslednjiFilm = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.Nevflix)).BeginInit();
            this.pnlPoslednjiFilm.SuspendLayout();
            this.SuspendLayout();
            // 
            // Nevflix
            // 
            this.Nevflix.Dock = System.Windows.Forms.DockStyle.Top;
            this.Nevflix.Image = global::Nevflix3.Properties.Resources.nevflix;
            this.Nevflix.Location = new System.Drawing.Point(0, 0);
            this.Nevflix.Name = "Nevflix";
            this.Nevflix.Size = new System.Drawing.Size(800, 140);
            this.Nevflix.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Nevflix.TabIndex = 0;
            this.Nevflix.TabStop = false;
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbSearch.Location = new System.Drawing.Point(557, 146);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(231, 20);
            this.tbSearch.TabIndex = 1;
            this.tbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyDown);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRefresh.Location = new System.Drawing.Point(12, 145);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(72, 20);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cbZanrovi
            // 
            this.cbZanrovi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbZanrovi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbZanrovi.FormattingEnabled = true;
            this.cbZanrovi.Location = new System.Drawing.Point(412, 147);
            this.cbZanrovi.Name = "cbZanrovi";
            this.cbZanrovi.Size = new System.Drawing.Size(132, 21);
            this.cbZanrovi.TabIndex = 3;
            this.cbZanrovi.SelectedIndexChanged += new System.EventHandler(this.cbZanrovi_SelectedIndexChanged);
            // 
            // lblPoslednjeGledano
            // 
            this.lblPoslednjeGledano.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPoslednjeGledano.AutoSize = true;
            this.lblPoslednjeGledano.BackColor = System.Drawing.Color.IndianRed;
            this.lblPoslednjeGledano.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoslednjeGledano.Location = new System.Drawing.Point(19, 16);
            this.lblPoslednjeGledano.Name = "lblPoslednjeGledano";
            this.lblPoslednjeGledano.Size = new System.Drawing.Size(179, 20);
            this.lblPoslednjeGledano.TabIndex = 4;
            this.lblPoslednjeGledano.Text = "Poslednje ste gledali:";
            // 
            // pnlPoslednjiFilm
            // 
            this.pnlPoslednjiFilm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlPoslednjiFilm.BackColor = System.Drawing.Color.Firebrick;
            this.pnlPoslednjiFilm.Controls.Add(this.lblPoslednjeGledano);
            this.pnlPoslednjiFilm.Location = new System.Drawing.Point(569, 172);
            this.pnlPoslednjiFilm.Name = "pnlPoslednjiFilm";
            this.pnlPoslednjiFilm.Size = new System.Drawing.Size(219, 166);
            this.pnlPoslednjiFilm.TabIndex = 5;
            // 
            // forma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlPoslednjiFilm);
            this.Controls.Add(this.cbZanrovi);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.Nevflix);
            this.Name = "forma";
            this.Text = "Nevflix";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Nevflix)).EndInit();
            this.pnlPoslednjiFilm.ResumeLayout(false);
            this.pnlPoslednjiFilm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Nevflix;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cbZanrovi;
        private System.Windows.Forms.Label lblPoslednjeGledano;
        private System.Windows.Forms.Panel pnlPoslednjiFilm;
    }
}

