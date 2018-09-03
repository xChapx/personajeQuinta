using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using attribTextBox;
namespace personajeQuinta
{
    public partial class personajeNuevo : Form
    {
        double modificador;
        List<TextBox> txtAttribs;
        List<Label> lblMods;
        List<Button> btnMods;
        string[] attribArray = new string[6]; //Base sin modificacion de raza para los atributos.
        Random rnd = new Random();
        int attributePoints;


        public personajeNuevo()
        {
            InitializeComponent();
            btnMods = new List<Button>(new Button[] {btnPlusS,btnPlusD,btnPlusC,btnPlusI,btnPlusW,btnPlusCh });
            txtAttribs = new List<TextBox>(new TextBox[] { attTextStr,attTextDex,attTextCon,attTextInt,attTextWis,attTextCha });
            lblMods = new List<Label>(new Label[] { lblModStr, lblModDex, lblModCon, lblModInt, lblModWis, lblModCha });
            MessageBox.Show("NUEVO PERSONAJE");
        }

        private void txtAttrib_TextChanged(object sender, EventArgs e)
        {


            if (((attTextBox)sender).Text != "")
            {
                modificador = (Convert.ToInt32(((TextBox)sender).Text) - 10) / 2;
                modificador = Math.Floor(modificador);
                lblMods[((attTextBox)sender).Num].Text = modificador.ToString();
                if (Int32.Parse(((attTextBox)sender).Text) > 20)
                {
                    MessageBox.Show("Los atributos no pueden ser mayores a 20");
                    ((attTextBox)sender).Text = "20";
                }
            }


        }


        private void btnGenerar_Click(object sender, EventArgs e)
        {

            //Compara para conseguir el dado con el menor resultado
            for (int j = 0; j < 6; j++)
            {
                //Tira los 4 dados generando un numero del 1 al 6
                int[] dados = new int[4];
                int nonSwaped = 0;
                bool swapped = true;

                for (int k = 0; k <= 3; k++)
                {
                    dados[k] = rnd.Next(1, 7);
                }
                System.Diagnostics.Debug.Write("Tirada: ");
                foreach (int item in dados)
                {
                  System.Diagnostics.Debug.Write(item.ToString());
                }
                System.Diagnostics.Debug.Write("\n");
                while (swapped == true)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (dados[i] < dados[i + 1])
                        {
                            dados[i] = dados[i] ^ dados[i + 1];
                            dados[i + 1] = dados[i] ^ dados[i + 1];
                            dados[i] = dados[i] ^ dados[i + 1];
                            swapped = true;
                        }
                        else
                        {
                            nonSwaped++;
                        }
                    }
                    if (nonSwaped == 3)
                    {
                        swapped = false;

                    }
                    else
                    {
                        nonSwaped = 0;
                    }
                  
                }
                System.Diagnostics.Debug.Write("Ordenado DL: ");
                foreach (int item in dados)
                {
                    System.Diagnostics.Debug.Write( item.ToString());

                }
                System.Diagnostics.Debug.Write("\n");
                System.Diagnostics.Debug.Write("Suma Total Atributo: " + (dados[0] + dados[1] + dados[2]).ToString());
                txtAttribs[j].Text = (dados[0] + dados[1] + dados[2]).ToString();
                attribArray[j] = txtAttribs[j].Text;
                System.Diagnostics.Debug.Write("\n");
                
            }
            ((Button)sender).Enabled = false;
            cbRaza.Enabled = true;
        }

        private void CbRaza_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            switch (cbRaza.Text)
            {
                case "Human":

                    for (int i = 0; i < 6; i++)
                    {
                        txtAttribs[i].Text = (Int32.Parse(attribArray[i]) + 1).ToString();
                    }
                    break;
                case "Human(Variant)":attributePoints = 2;
                    for (int i = 0; i < 6; i++)
                    {
                        btnMods[i].Visible = true;
                        btnMods[i].Enabled = true;
                    }
                     break;
                case "Elf":break;
                case "Dragonborn": break;
                case "Halfling": break;
                case "Dwarf": break;
                case "Tiefling": break;
                case "Half-Orc": break;
                case "Half-Elf": break;

            }
           
            
        }

        private void btnPlusAttribute_Click(object sender, EventArgs e)
        {
            if (attributePoints > 0)
            {
                attributePoints--;
                switch (((Button)sender).Name)
                {
                    case "btnPlusS":
                        txtAttribs[0].Text = ((Int32.Parse(txtAttribs[0].Text)) + 1).ToString();
                        break;
                    case "btnPlusD":
                        txtAttribs[1].Text = ((Int32.Parse(txtAttribs[1].Text)) + 1).ToString();
                        break;
                    case "btnPlusC":
                        txtAttribs[2].Text = ((Int32.Parse(txtAttribs[2].Text)) + 1).ToString();
                        break;
                    case "btnPlusI":
                        txtAttribs[3].Text = ((Int32.Parse(txtAttribs[3].Text)) + 1).ToString();
                        break;
                    case "btnPlusW":
                        txtAttribs[4].Text = ((Int32.Parse(txtAttribs[4].Text)) + 1).ToString();
                        break;
                    case "btnPlusCh":
                        txtAttribs[5].Text = ((Int32.Parse(txtAttribs[5].Text)) + 1).ToString();
                        break;
                    default: break;
                }
                if (attributePoints == 0)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        btnMods[i].Visible = false;
                    }
                }
                
               
            }
            
            
            

        }
    }

}