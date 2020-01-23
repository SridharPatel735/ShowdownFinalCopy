using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media; 

namespace GameTemplateTest
{
    public partial class DifficultySetting : UserControl
    {
        //Creating the lists and boolean for the color
        public static List<Image> player1 = new List<Image>();
        public static List<Image> player2 = new List<Image>();
        public static Boolean color;

        public DifficultySetting()
        {
            InitializeComponent();
        }
        private void image1_Click(object sender, EventArgs e)
        {
            //Setting the values for each player
            color = true;
            player1.Add(Properties.Resources.marco_left);
            player1.Add(Properties.Resources.marco_right);

            player2.Add(Properties.Resources.marco2_Left);
            player2.Add(Properties.Resources.marco2_Right);
            MainForm.ChangeScreen(this, "GameScreen");
        }
        private void image2_Click(object sender, EventArgs e)
        {
            //Setting the values for each player
            color = false;
            player2.Add(Properties.Resources.marco_left);
            player2.Add(Properties.Resources.marco_right);

            player1.Add(Properties.Resources.marco2_Left);
            player1.Add(Properties.Resources.marco2_Right);
            MainForm.ChangeScreen(this, "GameScreen");
        }
    }
}
