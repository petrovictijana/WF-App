using System;
using System.Data.Common;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Projekat
{
    public partial class DodajKorisnikaOverlay : Form
    {
        Facade userFacade;
        public DodajKorisnikaOverlay(DbConnection connection)
        {
            Button savePackageBtn = Paketi_pocetna.createPrimaryButton("Sačuvaj", new Point(70, 250), 130);
            Button cancelPackageBtn = Paketi_pocetna.createSecondaryButton("Otkaži", new Point(220, 250));

            cancelPackageBtn.Click += closeOverlay;
            savePackageBtn.Click += saveClient;

            this.Controls.Add(savePackageBtn);
            this.Controls.Add(cancelPackageBtn);

            Paketi_pocetna paketi_Pocetna = new Paketi_pocetna(connection, "SBB");
            userFacade = new Facade(connection, paketi_Pocetna);

            InitializeComponent();
        }

        private void saveClient(object sender, EventArgs e)
        {
            userFacade.AddNewUser(nazivPaketaForma.Text, textBox1.Text, textBox2.Text);
            this.Close();
        }

        private void closeOverlay(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DodajKorisnikaOverlay_Load(object sender, EventArgs e)
        {

        }

    }
}
