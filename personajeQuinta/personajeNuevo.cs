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
        Random rnd = new Random();
     


        public personajeNuevo()
        {
            InitializeComponent();

            txtAttribs = new List<TextBox>(new TextBox[] { attTextStr,attTextDex,attTextCon,attTextInt,attTextWis,attTextCha });
            lblMods = new List<Label>(new Label[] { lblModStr, lblModDex, lblModCon, lblModInt, lblModWis, lblModCha });
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
            int[] dados = { };


           

            for (int i = 0; i < 4; i++)
            {
                dados[i] = rnd.Next(1, 6);
            }
            for (int i = 0; i < 4; i++)
            {
                if (dados[i] < dados[i + 1])
                {
                    dados[i] = dados[i] ^ dados[i + 1];
                    dados[i+1] = dados[i] ^ dados[i + 1];
                    dados[i] = dados[i] ^ dados[i + 1];
                }
            }
            
            
            //txtAttribs[i].Text = ((rnd.Next(1, 6)) + (rnd.Next(1, 6)) + (rnd.Next(1, 6)) + (rnd.Next(1, 6))).ToString();

        }
    }

}