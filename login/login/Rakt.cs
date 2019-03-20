﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using login.Reporitorys.Rakt;
using login.Services;
using login.models;
using login.validator;
using login.Services.fleh;

namespace login
{
    public partial class Rakt : Form
    {
        us user;
        RktServ rs = new RktServ();
        CustomerService cs = new CustomerService();
        string uname;
        public Rakt(string uname)
        {
            user = new us();
            InitializeComponent();
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.uname = uname;
            dataGridView1.MultiSelect = false;
            placeHolderTextBox1.setPlaceHolder("keresés név alapján");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource= rs.feltolt();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 1)
                {
                    dataGridView1.ClearSelection();
                    return;
                }
                bool teg = false;

                if (dataGridView1.SelectedRows[0].Cells[8].Value.ToString() == "True") { teg = true; }
                MdTermekek termekek = new MdTermekek(
                    Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())
                    , dataGridView1.SelectedRows[0].Cells[1].Value.ToString()
                    , Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value.ToString())
                    , Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value.ToString())
                    , dataGridView1.SelectedRows[0].Cells[4].Value.ToString()
                    , Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[5].Value.ToString())
                    , Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[6].Value.ToString())
                    , Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[7].Value.ToString())
                    , teg);
                Szerk sz = new Szerk(termekek);
                sz.ShowDialog();
                if (sz.DialogResult == DialogResult.OK)
                {
                    try
                    {

                        dataGridView1.DataSource = null;

                        dataGridView1.DataSource = sz.raktnak();
                    }
                    catch (Exception d) {  }
                    /*rs.modifyData(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()), termekek);*/
                }
            }
            catch (Exception a) { MessageBox.Show("nem jelöltél ki semmit");
                button1_Click(sender, e);
            }
        }

        private void Rakt_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 1)
            {
                dataGridView1.ClearSelection();
                return;
            }
            bool teg = false;
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            if (dataGridView1.SelectedRows[0].Cells[8].Value.ToString() == "True") { teg = true; }
            MdTermekek termekek = new MdTermekek(
                Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())
                , dataGridView1.SelectedRows[0].Cells[1].Value.ToString()
                , Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value.ToString())
                , Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value.ToString())
                , dataGridView1.SelectedRows[0].Cells[4].Value.ToString()
                , Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[5].Value.ToString())
                , Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[6].Value.ToString())
                , Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[7].Value.ToString())
                , teg);
            rs.moveToNotImportant(termekek, id);
        }

        private void button4_Click(object sender, EventArgs e)
        {

            
            int id=rs.getLastId();
          

            Szerk sz = new Szerk(id);
           
            sz.ShowDialog();
            if (sz.DialogResult == DialogResult.OK)
            {
                try
                {

                    dataGridView1.DataSource = null;

                    dataGridView1.DataSource = sz.addNewItem();
                }
                catch (Exception d) {  }
                
            }


        }

        private void newPartnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = cs.getLastId();
            AddUsers au = new AddUsers(id);
            au.ShowDialog();
            if (au.DialogResult == DialogResult.OK)
            {
                au.addNewUser();
                

               

               
                
                
                
            }

        }

        private void partnersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Carriers c = new Carriers();
            c.ShowDialog();
        }

        private void placeHolderTextBox1_TextChanged(object sender, EventArgs e)
        {
            
            IgnoreEmptyOrWhiteSpace ieows = new IgnoreEmptyOrWhiteSpace();
            
            if (ieows.isNull(placeHolderTextBox1.Text))
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource =
                 rs.SzurNevAlapjan("");


                return;
            }
            
            
            dataGridView1.DataSource = null;
            
            dataGridView1.DataSource= rs.SzurNevAlapjan(placeHolderTextBox1.Text);
            
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customers c = new Customers();
           
            if (user.getRights(uname) == "rak")
                c.Show();
            else return;
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addRktUser aru = new addRktUser();

            
            if (user.getRights(uname) == "admin")
            {
                aru.ShowDialog();
                if (aru.DialogResult == DialogResult.OK)
                {
                    aru.addNewUser();








                }
            }
            else return;
        }
    }
}
