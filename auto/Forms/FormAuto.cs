﻿using auto.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace auto.Forms
{
    public partial class FormAuto : Form
    {
        public FormAuto()
        {
            InitializeComponent();

            LoadBd();
        }

        public void LoadBd()
        {
            listView1.LargeImageList = imageList1;
            imageList1.Images.Clear();
            listView1.Items.Clear();
            // получаем все файлы

            //List<string> files = Directory.GetFiles(".\\packages\\Foto", "*" + ".jpg").ToList();
            
            imageList1.ImageSize = new Size(250,250);
            Brands brands = new Brands();
            Images images = new Images();
            //Automobiles auto = new Automobiles();
            // перебор полученных файлов
            int i = 0;
            EntitiesAutomobiles entitiesAutomobiles = new EntitiesAutomobiles();
            foreach (Automobiles auto in entitiesAutomobiles.Automobiles)
            {
                try
                {
                    imageList1.Images.Add(Image.FromFile(auto.Images.
                        Where(x=>x.idAuto==auto.idAuto)
                        .Select(x=>x.image).FirstOrDefault()));
                }
                catch
                {
                    MessageBox.Show(
                        "Файл не открывается",
                        "Сообщение",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);
                    continue;
                }
                // установка названия файла
                ListViewItem lvi = new ListViewItem();
                //lvi.Text = file.Remove(0, file.LastIndexOf('\\') + 1);
                lvi.Text = auto.Brands.nameBrand + "   " + auto.Models.nameModel;
                lvi.ImageIndex = i; // установка картинки для файла
                i++;
                // добавляем элемент в ListView
                listView1.Items.Add(lvi);

            }
        }
    }
}