﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int cR, cG, cB;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bmp;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                bmp = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = bmp;
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Color c = new Color();
            int mR, mG, mB;
            mR = 0; mG = 0; mB = 0;
            for (int i = e.X - 5; i < e.X + 5; i++)
                for (int j = e.Y - 5; j < e.Y + 5; j++)
                {
                    c = bmp.GetPixel(i, j);
                    mR = mR + c.R;
                    mG = mG + c.G;
                    mB = mB + c.B;
                }
            mR = mR / 100;
            mG = mG / 100;
            mB = mB / 100;
            textBox1.Text = mR.ToString();
            textBox2.Text = mG.ToString();
            textBox3.Text = mB.ToString();
            cR = mR;
            cG = mG;
            cB = mB;

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            con.ConnectionString = "server=LESS\\SQLEXPRESS;user=sa;pwd=123456;database=academico";
            cmd.Connection = con;
            cmd.CommandText = "insert into colores values('" +
                textBox4.Text + "'," + mR.ToString() + "," + mG.ToString()
                + "," + mB.ToString() + ",'" + textBox5.Text + "')";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    bmp2.SetPixel(i, j, Color.FromArgb(c.R, 0, 0));
                }
            pictureBox2.Image = bmp2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    bmp2.SetPixel(i, j, Color.FromArgb(0, c.G, 0));
                }
            pictureBox2.Image = bmp2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    bmp2.SetPixel(i, j, Color.FromArgb(0, 0, c.B));
                }
            pictureBox2.Image = bmp2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            int clR, clG, clB;
            string colorcambio;
            con.ConnectionString = "server=LESS\\SQLEXPRESS;user=sa;pwd=123456;database=academico";
            cmd.Connection = con;
            cmd.CommandText = "select * from colores";
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cR = dr.GetInt32(1);
                cG = dr.GetInt32(2);
                cB = dr.GetInt32(3);
                colorcambio = dr.GetString(4);
                bmp2 = new Bitmap(bmp.Width, bmp.Height);
                for (int i = 0; i < bmp.Width; i++)
                    for (int j = 0; j < bmp.Height; j++)
                    {
                        c = bmp.GetPixel(i, j);
                        if (((cR - 10 < c.R) && (c.R < cR + 10)) && ((cG - 10 < c.G) && (c.G < cG + 10))
                            && ((cB - 10 < c.B) && (c.B < cB + 10)))
                        {
                            clR = Convert.ToInt32(colorcambio.Substring(0, 2), 16);
                            clG = Convert.ToInt32(colorcambio.Substring(2, 2), 16);
                            clB = Convert.ToInt32(colorcambio.Substring(4, 2), 16);
                            textBox5.Text = clB.ToString();
                            if (colorcambio == "333dff")
                                bmp2.SetPixel(i, j, Color.FromArgb(clR, clG, clB));
                            if (colorcambio == "4d1f05")
                                bmp2.SetPixel(i, j, Color.FromArgb(clR, clG, clB));
                            if (colorcambio == "054d1a")
                                bmp2.SetPixel(i, j, Color.FromArgb(clR, clG, clB));
                        }
                        else
                            bmp2.SetPixel(i, j, Color.FromArgb(c.R, c.G, c.B));
                    }
                bmp = bmp2;
            }
            pictureBox2.Image = bmp2;
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            /*  Bitmap bmp = new Bitmap(pictureBox1.Image);
              Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
              int mmR, mmG, mmB;
              Color c = new Color();
              for (int i = 0; i < bmp.Width - 10; i = i + 10)
              {
                  for (int j = 0; j < bmp.Height - 10; j = j + 10)
                  {
                      mmR = 0; mmG = 0; mmB = 0;
                      for (int k = i; k < i + 10; k++)
                          for (int l = j; l < j + 10; l++)
                          {
                              c = bmp.GetPixel(k, l);
                              mmR = mmR + c.R;
                              mmG = mmG + c.G;
                              mmB = mmB + c.B;
                          }
                      mmR = mmR / 100;
                      mmG = mmG / 100;
                      mmB = mmB / 100;

                      if (((cR - 10 < mmR) && (mmR < cR + 10)) && ((cG - 10 < mmG) && (mmG < cG + 10))
                          && ((cB - 10 < mmB) && (mmB < cB + 10)))
                      {
                          for (int k = i; k < i + 10; k++)
                              for (int l = j; l < j + 10; l++)
                              {
                                  bmp2.SetPixel(k, l, Color.Yellow);
                              }
                      }
                      else
                      {
                          for (int k = i; k < i + 10; k++)
                              for (int l = j; l < j + 10; l++)
                              {
                                  c = bmp.GetPixel(k, l);
                                  bmp2.SetPixel(k, l, Color.FromArgb(c.R, c.G, c.B));
                              }
                      }
                  }
              }
              pictureBox2.Image = bmp2;
          }*/
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;

            // Obtén la lista de texturas a partir de una tabla en la base de datos
            List<string> texturas = ObtenerTexturasDesdeBD();

            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            int clR, clG, clB;
            string colorcambio;
            con.ConnectionString = "server=LESS\\SQLEXPRESS;user=sa;pwd=123456;database=academico";
            cmd.Connection = con;
            cmd.CommandText = "select * from colores";
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cR = dr.GetInt32(1);
                cG = dr.GetInt32(2);
                cB = dr.GetInt32(3);
                colorcambio = dr.GetString(4);
                bmp2 = new Bitmap(bmp.Width, bmp.Height);
                Graphics g = Graphics.FromImage(bmp2);
                for (int i = 0; i < bmp.Width; i++)
                {
                    for (int j = 0; j < bmp.Height; j++)
                    {
                        c = bmp.GetPixel(i, j);
                        if (((cR - 10 < c.R) && (c.R < cR + 10)) && ((cG - 10 < c.G) && (c.G < cG + 10))
                            && ((cB - 10 < c.B) && (c.B < cB + 10)))
                        {
                             string texturaAleatoria = ObtenerTexturaAleatoria(texturas);
                            Bitmap texturaBitmap = new Bitmap(texturaAleatoria);
                            g.DrawImage(texturaBitmap, i, j);
                        }
                        else
                        {
                            bmp2.SetPixel(i, j, Color.FromArgb(c.R, c.G, c.B));
                        }
                    }
                }
                g.Dispose();
                bmp = bmp2;
            }
            pictureBox2.Image = bmp2;
            con.Close();
        }

        private string ObtenerTexturaAleatoria(List<string> texturas)
        {
            throw new NotImplementedException();
        }

        private List<string> ObtenerTexturasDesdeBD()
        {
            List<string> texturas = new List<string>();

            string connectionString = "server=LESS\\SQLEXPRESS;user=sa;pwd=123456;database=academico";

            string query = "SELECT nombre_textura FROM texturas_table";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                           while (reader.Read())
                            {
                                string nombreTextura = reader.GetString(0);
                                texturas.Add(nombreTextura);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener las texturas desde la base de datos: " + ex.Message);
                    }
                }
            }

            return texturas;
        }
      

    }
    }
