using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        //Min class som Skapar en ny picturebox. Använde så jag kunde lägga till x och y property på pictures
        public class newPictures : PictureBox
        {
            private string _x;
            private string _y;
            public string xx
            {
                get { return _x; }
                set { _x = value; }
            }
            public string yy
            {
                get { return _y; }
                set { _y = value; }
            }
        }
        //Skapar pictures
        newPictures[,] pictures = new newPictures[3, 3];

        //ger standardvärden
        bool X = true;
        int i;
        int rad;
        string[,] check = new string[3, 3];
        int checkAntal = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //sköter storlek och placering av bilderna
            int x = 10;
            int y = 10;
            int width = this.ClientSize.Width;
            int height = this.ClientSize.Height;
            int picWidth = (width - 60) / 3;
            int picHeight = (height - 60) / 3;

            //Sätter ut och ger attributer till bilderna
            for (rad = 0; rad <3; rad++)
            {
                for (i = 0; i < 3; i++)
                {
                    pictures[rad, i] = new newPictures();
                    pictures[rad, i].Width = picWidth;
                    pictures[rad, i].Height = picHeight;
                    pictures[rad, i].Location = new Point(x, y);
                    pictures[rad, i].Image = Image.FromFile("Blanc.png");
                    pictures[rad, i].SizeMode = PictureBoxSizeMode.StretchImage;
                    pictures[rad, i].Tag = "White";
                    pictures[rad, i].xx = Convert.ToString(rad);
                    pictures[rad, i].yy = Convert.ToString(i);
                    this.Controls.Add(pictures[rad, i]);
                    x += picWidth + 10;
                    pictures[rad, i].Click += picture_Klick;

                }
                y += picHeight + 10;
                x = 10;
            }
        }
        //Om användaren klickar på en av knapparna
        private void picture_Klick(object sender, EventArgs e)
        {
            newPictures picture = (newPictures)sender;

            //Om användare X klickar
            if (X)
            {
                picture.Image = Image.FromFile("x.png");
                check[Convert.ToInt32(picture.xx), Convert.ToInt32(picture.yy)] = "X";
            }
            //Om använare O klickar
            else
            {
                picture.Image = Image.FromFile("o.png");
                check[Convert.ToInt32(picture.xx), Convert.ToInt32(picture.yy)] = "O";
            }
            
            //Om användare X vinner
            if ((check[0, 0] == "X" && check[1, 0] == "X" && check[2, 0] == "X") || (check[0, 1] == "X" && check[1, 1] == "X" && check[2, 1] == "X") || (check[0, 2] == "X" && check[1, 2] == "X" && check[2, 2] == "X") || (check[0, 0] == "X" && check[0, 1] == "X" && check[0, 2] == "X") || (check[1, 0] == "X" && check[1, 1] == "X" && check[1, 2] == "X") || (check[2, 0] == "X" && check[2, 1] == "X" && check[2, 2] == "X") || (check[0, 0] == "X" && check[1, 1] == "X" && check[2, 2] == "X") || (check[0, 2] == "X" && check[1, 1] == "X" && check[2, 0] == "X"))
            {
                MessageBox.Show("X Vinner!!!", "Vinnare");
                Application.Restart();
                Environment.Exit(0);
            }
            //Om användare O vinner
            if ((check[0, 0] == "O" && check[1, 0] == "O" && check[2, 0] == "O") || (check[0, 1] == "O" && check[1, 1] == "O" && check[2, 1] == "O") || (check[0, 2] == "O" && check[1, 2] == "O" && check[2, 2] == "O") || (check[0, 0] == "O" && check[0, 1] == "O" && check[0, 2] == "O") || (check[1, 0] == "O" && check[1, 1] == "O" && check[1, 2] == "O") || (check[2, 0] == "O" && check[2, 1] == "O" && check[2, 2] == "O") || (check[0, 0] == "O" && check[1, 1] == "O" && check[2, 2] == "O") || (check[0, 2] == "O" && check[1, 1] == "O" && check[2, 0] == "O"))
            {
                MessageBox.Show("O Vinner!!!", "Vinnare");
                Application.Restart();
                Environment.Exit(0);
            }

            //Kollar om det blir lika
            checkAntal += 1;
            if(checkAntal == 9)
            {
                MessageBox.Show("Lika", "Lika");
                Application.Restart();
                Environment.Exit(0);
            }

            X = !X;
            picture.Click -= picture_Klick;

        }
    }
}
