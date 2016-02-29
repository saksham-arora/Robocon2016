﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Robocon2015
{
    public partial class Match : Form
    {
        String matchtype;
        String redteam;
        String blueteam;
        String redname;
        String bluename;
        String game;
              

        public Match(String r, String b, String m,String g)
        {
            InitializeComponent();
            redteam = r;
            blueteam = b;
            matchtype = m;
            game = g;
         
        }


        private void Match_Load(object sender, EventArgs e)
        {
            lbl_red.Text = redteam;
            //lbl_redScore.Text = "";
            lbl_blue.Text = blueteam;
            //lbl_blueScore.Text = "";
            //lbl_matchtype.Text = matchtype;
            //MessageBox.Show(Entry.game);
            label3.Text = game;
            string constring = @"ENVY\SQLEXPRESS;Initial Catalog=Robocon2016db;Integrated Security=True;Pooling=False";
            string Query = "select * from RoboconTable where CollegeDisplayName='" + lbl_red.Text + "';";
            SqlConnection conDataBase = new SqlConnection(constring);
            SqlCommand cmdDataBase = new SqlCommand(Query, conDataBase);
            SqlDataReader myReader;
      
            try
            {

                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                RedTeamImage.SizeMode = PictureBoxSizeMode.StretchImage;
                while (myReader.Read())
                {
                    if(matchtype=="Final")
                    {
                        redname = (String)(myReader["CollegeName"]);
                    }
                    else
                    {
                        redname = lbl_red.Text;
                    }
                    
                    byte[] imgg = (byte[])(myReader["CollegeImage"]);
                    if (imgg == null)
                    {
                        RedTeamImage.Image = null;
                    }
                    else
                    {
                        MemoryStream mstream = new MemoryStream(imgg);
                        RedTeamImage.Image = System.Drawing.Image.FromStream(mstream);

                    }
                }
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            string Query2 = "select * from RoboconTable where CollegeDisplayName='" + lbl_blue.Text + "';";
            SqlConnection conDataBase2 = new SqlConnection(constring);
            SqlCommand cmdDataBase2 = new SqlCommand(Query2, conDataBase2);
            SqlDataReader myReader2;
            try
            {

                conDataBase2.Open();
                myReader2 = cmdDataBase2.ExecuteReader();
                BlueTeamImage.SizeMode = PictureBoxSizeMode.StretchImage;
                while (myReader2.Read())
                {
                    if (matchtype == "Final")
                    {
                        bluename = (String)(myReader2["CollegeName"]);
                    }
                    else
                    {
                        bluename = lbl_blue.Text;
                    }
                    
                    byte[] imgg2 = (byte[])(myReader2["CollegeImage"]);
                    if (imgg2 == null)
                    {
                        BlueTeamImage = null;
                    }
                    else
                    {
                        MemoryStream mstream2 = new MemoryStream(imgg2);
                        BlueTeamImage.Image = System.Drawing.Image.FromStream(mstream2);

                    }
                }
                
            }

            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message);

            }

        }


        private void btn_show_Click(object sender, EventArgs e)
        {
           // label1.Text = " ";
            label1.Text = textBox1.Text;
            label1.Visible = true;

            //label2.Text = " ";
            label2.Text = textBox2.Text;
            label2.Visible = true;
        }

        private void redWinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (matchtype == "Final")
            {
                Form winner = new Winner(redname);
                winner.Show();
                this.Close();
            }
           /* else
            {
                Form winner = new Winner(redname);
                winner.Show();
                this.Close();
            }*/
        }

        private void blueWinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (matchtype == "Final")
            {
                Form winner = new Winner(bluename);
                winner.Show();
                this.Close();
            }
            /*else
            {
                Form winner = new Winner(redname);
                winner.Show();
                this.Close();
            }*/
        }

        private void btn_tscore_Click(object sender, EventArgs e)
        {
            lbl_totalscore.Visible = lbl_totalscore.Visible ? false : true;
        }

        private void RedTeamImage_Click(object sender, EventArgs e)
        {

        }

        private void txt_red_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
