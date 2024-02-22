using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekat
{
    public partial class DodajPaketOverlay : Form
    {
        Facade userFacade;
        public DodajPaketOverlay(DbConnection connection)
        {

            Button savePackageBtn = Paketi_pocetna.createPrimaryButton("Sačuvaj", new Point(100, 400), 130);
            Button cancelPackageBtn = Paketi_pocetna.createSecondaryButton("Otkaži", new Point(250, 400));

            cancelPackageBtn.Click += closeOverlay;
            savePackageBtn.Click += addPackage;
            

            this.Controls.Add(savePackageBtn);
            this.Controls.Add(cancelPackageBtn);

            InitializeComponent();

            tipPaketaDropDownBox.SelectedIndex = 0;
            tipPaketaDropDownBox.SelectedIndexChanged += selectedIndexChange;
            kolicinaInternetaForm.Visible = false;
            kolicinaInternetaLabel.Visible = false;

            Paketi_pocetna paketi_Pocetna = new Paketi_pocetna(connection, "SBB");
            userFacade = new Facade(connection, paketi_Pocetna);
        }

        private void addPackage(object sender, EventArgs e)
        {
            string name = nazivPaketaForma.Text;
            int price = Convert.ToInt32(cenaPaketaForma.Value);
            int type = tipPaketaDropDownBox.SelectedIndex + 1;
            int channel_count = 0;
            int internet_speed = 0;

            if (type == 1)
            {
                channel_count = Convert.ToInt32(brojKanalaForm.Value);

            }
            else if (type == 2)
            {
                internet_speed = Convert.ToInt32(kolicinaInternetaFormZaInternetPaket.Value);
            }
            else
            {
                channel_count = Convert.ToInt32(brojKanalaForm.Value);
                internet_speed = Convert.ToInt32(kolicinaInternetaForm.Value);
            }

            userFacade.AddNewPackage(name, price, type, internet_speed, channel_count);
            this.Close();
        }

        private void selectedIndexChange(object sender, EventArgs e)
        {
            int selectedIndex = tipPaketaDropDownBox.SelectedIndex;

            if(selectedIndex == 0)
            {
                brojKanalaLabel.Visible = true;
                brojKanalaLabel.Visible = true;

                kolicinaInternetaForm.Visible = false;
                kolicinaInternetaLabel.Visible = false;

                kolicinaInternetaFormZaInternetPaket.Visible = false;
                kolicinaInternetaLabelZaInternetPaket.Visible = false;
            }
            else if(selectedIndex == 1)
            {
                kolicinaInternetaFormZaInternetPaket.Visible = true;
                kolicinaInternetaLabelZaInternetPaket.Visible = true;

                kolicinaInternetaForm.Visible = false;
                kolicinaInternetaLabel.Visible = false;

                brojKanalaForm.Visible = false;
                brojKanalaLabel.Visible = false;
            }
            else if(selectedIndex == 2)
            {
                brojKanalaForm.Visible = true;
                brojKanalaLabel.Visible = true;

                kolicinaInternetaForm.Visible = true;
                kolicinaInternetaLabel.Visible = true;

                kolicinaInternetaFormZaInternetPaket.Visible = false;
                kolicinaInternetaLabelZaInternetPaket.Visible = false;
            }
        }

        private void closeOverlay(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DodajPaketOverlay_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
