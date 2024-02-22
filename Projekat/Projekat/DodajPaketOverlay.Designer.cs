namespace Projekat
{
    partial class DodajPaketOverlay
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
            this.label1 = new System.Windows.Forms.Label();
            this.tipPaketaDropDownBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nazivPaketaForma = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cenaPaketaForma = new System.Windows.Forms.NumericUpDown();
            this.brojKanalaForm = new System.Windows.Forms.NumericUpDown();
            this.brojKanalaLabel = new System.Windows.Forms.Label();
            this.kolicinaInternetaLabel = new System.Windows.Forms.Label();
            this.kolicinaInternetaForm = new System.Windows.Forms.NumericUpDown();
            this.kolicinaInternetaFormZaInternetPaket = new System.Windows.Forms.NumericUpDown();
            this.kolicinaInternetaLabelZaInternetPaket = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cenaPaketaForma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brojKanalaForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kolicinaInternetaForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kolicinaInternetaFormZaInternetPaket)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(85, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dodavanje paketa";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tipPaketaDropDownBox
            // 
            this.tipPaketaDropDownBox.DropDownHeight = 120;
            this.tipPaketaDropDownBox.FormattingEnabled = true;
            this.tipPaketaDropDownBox.IntegralHeight = false;
            this.tipPaketaDropDownBox.ItemHeight = 16;
            this.tipPaketaDropDownBox.Items.AddRange(new object[] {
            "TV paket",
            "Internet paket",
            "Kombinovani paket"});
            this.tipPaketaDropDownBox.Location = new System.Drawing.Point(91, 211);
            this.tipPaketaDropDownBox.Name = "tipPaketaDropDownBox";
            this.tipPaketaDropDownBox.Size = new System.Drawing.Size(247, 24);
            this.tipPaketaDropDownBox.TabIndex = 1;
            this.tipPaketaDropDownBox.Tag = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(87, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Odaberite tip paketa";
            // 
            // nazivPaketaForma
            // 
            this.nazivPaketaForma.Location = new System.Drawing.Point(91, 94);
            this.nazivPaketaForma.MaxLength = 30;
            this.nazivPaketaForma.Name = "nazivPaketaForma";
            this.nazivPaketaForma.Size = new System.Drawing.Size(247, 22);
            this.nazivPaketaForma.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(87, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Unesite naziv paketa";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(91, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Cena paketa";
            // 
            // cenaPaketaForma
            // 
            this.cenaPaketaForma.Location = new System.Drawing.Point(91, 152);
            this.cenaPaketaForma.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.cenaPaketaForma.Name = "cenaPaketaForma";
            this.cenaPaketaForma.Size = new System.Drawing.Size(247, 22);
            this.cenaPaketaForma.TabIndex = 7;
            // 
            // brojKanalaForm
            // 
            this.brojKanalaForm.Location = new System.Drawing.Point(91, 268);
            this.brojKanalaForm.Name = "brojKanalaForm";
            this.brojKanalaForm.Size = new System.Drawing.Size(247, 22);
            this.brojKanalaForm.TabIndex = 8;
            // 
            // brojKanalaLabel
            // 
            this.brojKanalaLabel.AutoSize = true;
            this.brojKanalaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brojKanalaLabel.Location = new System.Drawing.Point(91, 245);
            this.brojKanalaLabel.Name = "brojKanalaLabel";
            this.brojKanalaLabel.Size = new System.Drawing.Size(93, 20);
            this.brojKanalaLabel.TabIndex = 9;
            this.brojKanalaLabel.Text = "Broj kanala";
            // 
            // kolicinaInternetaLabel
            // 
            this.kolicinaInternetaLabel.AutoSize = true;
            this.kolicinaInternetaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kolicinaInternetaLabel.Location = new System.Drawing.Point(91, 302);
            this.kolicinaInternetaLabel.Name = "kolicinaInternetaLabel";
            this.kolicinaInternetaLabel.Size = new System.Drawing.Size(138, 20);
            this.kolicinaInternetaLabel.TabIndex = 10;
            this.kolicinaInternetaLabel.Text = "Količina interneta";
            // 
            // kolicinaInternetaForm
            // 
            this.kolicinaInternetaForm.Location = new System.Drawing.Point(91, 325);
            this.kolicinaInternetaForm.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.kolicinaInternetaForm.Name = "kolicinaInternetaForm";
            this.kolicinaInternetaForm.Size = new System.Drawing.Size(247, 22);
            this.kolicinaInternetaForm.TabIndex = 11;
            // 
            // kolicinaInternetaFormZaInternetPaket
            // 
            this.kolicinaInternetaFormZaInternetPaket.Location = new System.Drawing.Point(91, 268);
            this.kolicinaInternetaFormZaInternetPaket.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.kolicinaInternetaFormZaInternetPaket.Name = "kolicinaInternetaFormZaInternetPaket";
            this.kolicinaInternetaFormZaInternetPaket.Size = new System.Drawing.Size(247, 22);
            this.kolicinaInternetaFormZaInternetPaket.TabIndex = 12;
            this.kolicinaInternetaFormZaInternetPaket.Visible = false;
            // 
            // kolicinaInternetaLabelZaInternetPaket
            // 
            this.kolicinaInternetaLabelZaInternetPaket.AutoSize = true;
            this.kolicinaInternetaLabelZaInternetPaket.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kolicinaInternetaLabelZaInternetPaket.Location = new System.Drawing.Point(87, 245);
            this.kolicinaInternetaLabelZaInternetPaket.Name = "kolicinaInternetaLabelZaInternetPaket";
            this.kolicinaInternetaLabelZaInternetPaket.Size = new System.Drawing.Size(138, 20);
            this.kolicinaInternetaLabelZaInternetPaket.TabIndex = 13;
            this.kolicinaInternetaLabelZaInternetPaket.Text = "Količina interneta";
            this.kolicinaInternetaLabelZaInternetPaket.Visible = false;
            // 
            // DodajPaketOverlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(429, 450);
            this.Controls.Add(this.kolicinaInternetaLabelZaInternetPaket);
            this.Controls.Add(this.kolicinaInternetaFormZaInternetPaket);
            this.Controls.Add(this.kolicinaInternetaForm);
            this.Controls.Add(this.kolicinaInternetaLabel);
            this.Controls.Add(this.brojKanalaLabel);
            this.Controls.Add(this.brojKanalaForm);
            this.Controls.Add(this.cenaPaketaForma);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nazivPaketaForma);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tipPaketaDropDownBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DodajPaketOverlay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dodavanje paketa";
            this.Load += new System.EventHandler(this.DodajPaketOverlay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cenaPaketaForma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brojKanalaForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kolicinaInternetaForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kolicinaInternetaFormZaInternetPaket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox tipPaketaDropDownBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nazivPaketaForma;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown cenaPaketaForma;
        private System.Windows.Forms.NumericUpDown brojKanalaForm;
        private System.Windows.Forms.Label brojKanalaLabel;
        private System.Windows.Forms.Label kolicinaInternetaLabel;
        private System.Windows.Forms.NumericUpDown kolicinaInternetaForm;
        private System.Windows.Forms.NumericUpDown kolicinaInternetaFormZaInternetPaket;
        private System.Windows.Forms.Label kolicinaInternetaLabelZaInternetPaket;
    }
}