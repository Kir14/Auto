﻿using auto.DataBase;
using auto.Forms;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace auto
{
    public partial class MainMenu : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private IconButton currentSubBtn;
        private Panel leftBorderSubBtn;
        private Form currentChildForm;

        private string user;
        private int idUser=0;

        public MainMenu()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            addBtn.Visible = false;
            iconButtonOrders.Visible = false;
            iconButtonUsers.Visible = false;

            CustomizaDesign();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            leftBorderSubBtn = new Panel();
            leftBorderSubBtn.Size = new Size(7, 60);
            panelSubAuto.Controls.Add(leftBorderSubBtn);
            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            menuStrip1.Visible = false;


        }

        //SubMenu
        private void CustomizaDesign()
        {
            panelSubAuto.Visible = false;
        }

        private void HideSubMenu()
        {
            if (panelSubAuto.Visible == true)
                panelSubAuto.Visible = false;
        }

        private void ShowSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                HideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }


        //Structs
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(95, 77, 221);
        }

        //For Menu Button
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Icon Current CHild Form
                iconCorrectChildForm.IconChar = currentBtn.IconChar;
                iconCorrectChildForm.IconColor = color;
                labelTitleChildForm.Text = currentBtn.Text;
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        //For Sub Button
        private void ActivateSubButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableSubButton();
                //Button
                currentSubBtn = (IconButton)senderBtn;
                currentSubBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentSubBtn.ForeColor = color;
                currentSubBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentSubBtn.IconColor = color;
                currentSubBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentSubBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                leftBorderSubBtn.BackColor = color;
                leftBorderSubBtn.Location = new Point(0, currentSubBtn.Location.Y);
                leftBorderSubBtn.Visible = true;
                leftBorderSubBtn.BringToFront();
                //Icon Current CHild Form
                iconCorrectChildForm.IconChar = currentBtn.IconChar;
                iconCorrectChildForm.IconColor = color;
                
            }
        }

        private void DisableSubButton()
        {
            if (currentSubBtn != null)
            {
                currentSubBtn.BackColor = Color.FromArgb(20, 22, 70);
                currentSubBtn.ForeColor = Color.Gainsboro;
                currentSubBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentSubBtn.IconColor = Color.Gainsboro;
                currentSubBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentSubBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        public void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                //open only form
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDekstop.Controls.Add(childForm);
            panelDekstop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            //labelTitleChildForm.Text = childForm.Text;
        }

        private void iconButtonAuto_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new FormAuto(idUser));
            ShowSubMenu(panelSubAuto);
        }


        private void bntBuzinesClass_Click(object sender, EventArgs e)
        {
            ActivateSubButton(sender, RGBColors.color2);
            OpenChildForm(new FormAuto(idUser,"Бизнес"));
        }


        private void btnEkoClasss_Click(object sender, EventArgs e)
        {
            ActivateSubButton(sender, RGBColors.color2);
            OpenChildForm(new FormAuto(idUser,"Средний"));
        }

        private void iconButtonUsers_Click(object sender, EventArgs e)
        {
            HideSubMenu();
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new FormUsers());

        }

        private void iconButtonOrders_Click(object sender, EventArgs e)
        {
            HideSubMenu();
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new FormOrders());
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null)
                currentChildForm.Close();
            HideSubMenu();
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            DisableSubButton();
            leftBorderBtn.Visible = false;
            leftBorderSubBtn.Visible = false;
            iconCorrectChildForm.IconChar = IconChar.Home;
            iconCorrectChildForm.IconColor = Color.Violet;
            labelTitleChildForm.Text = "Главная";
        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximaze_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void btnMinimaze_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        //Remove transparent border in maximized state
        private void FormMainMenu_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                FormBorderStyle = FormBorderStyle.None;
            else
                FormBorderStyle = FormBorderStyle.Sizable;
        }

        private void btnEkoClasss_Click_1(object sender, EventArgs e)
        {
            ActivateSubButton(sender, RGBColors.color2);
            OpenChildForm(new FormAuto(idUser, "Эконом"));
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            HideSubMenu();
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new FormAdd());
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfoUser info = new InfoUser();
            info.setIdUser(0);
            menuStrip1.Visible = false;
            user = "";
            idUser = 0;
            btnSignin.Visible = true;
        }

        public void Login(string name, int id)
        {
            user = name;
            idUser = id;
            EntitiesAutomobiles automobiles = new EntitiesAutomobiles();
            Users users = automobiles.Users.Where(x => x.idUser == idUser).FirstOrDefault();
            nameToolStripMenuItem.Text = name;
            menuStrip1.Visible = true;
            btnSignin.Visible = false;

            if(users.admin.Value)
            {
                addBtn.Visible = true;
                iconButtonOrders.Visible = true;
                iconButtonUsers.Visible = true;
                iconRent.Visible = false;
            }
            else
            {
                addBtn.Visible = false;
                iconButtonOrders.Visible = false;
                iconButtonUsers.Visible = false;
                iconRent.Visible = true;
            }
        }

        private void btnSignin_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin(this);
            login.Show();
        }

        private void iconRent_Click(object sender, EventArgs e)
        {
            HideSubMenu();
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new FormRent());
        }
    }
}
