﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using login.models;
using login.Services;
using login.Misc;
using login.validator;
namespace login
{
    public partial class Szerk : Form
    {
        public MdTermekek termekek;
        RktServ rs;
        int id;
        int _Sid;
        public Szerk(MdTermekek termekek)
        {
            
            rs = new RktServ();
            this.termekek = termekek;
            InitializeComponent();
           
            button1.DialogResult = DialogResult.OK;
            
            NameHolder.setText(termekek.getTNev());

            PriceHolder.setText(termekek.getTar().ToString());
           
            AmmountHolder.setText(termekek.getTkeszl().ToString());
            
            UnitHolder.setText(termekek.getMert());
            
            CodeHolder.setText(termekek.getTkatkod().ToString());

           
            VonCodeHolder.setText(termekek.getTvonkod().ToString());
            dateTimePicker1.Value = termekek.getSzavido();

            
         
            

            bool eg = false;
            if (termekek.getTegalizalte() == true)
            {
                eg = true;
                checkBox1.CheckState=CheckState.Checked;

            }
           


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
      
            if (_Sid == rs.getLastId())
            {
                
                return;
                
            }
          
         /*
                NameHolder.Text = termekek.getTNev();

             PriceHolder.Text = termekek.getTar().ToString();
            
        
                AmmountHolder.Text = termekek.getTkeszl().ToString();
          
    
                UnitHolder.Text = termekek.getMert();
          
  
    
                CodeHolder.Text = termekek.getTkatkod().ToString();

  
                VonCodeHolder.Text = termekek.getTvonkod().ToString();
           */ 
            
            id =termekek.getTkod();
            termekek.setTnev(NameHolder.Text);
            if (PriceHolder.onlyNumber())
            {
                termekek.setTar(Convert.ToInt32(PriceHolder.Text));
            }
            else {
                
            }
            if (AmmountHolder.onlyNumber())
            {
                termekek.setTkeszl(Convert.ToInt32(AmmountHolder.Text));
            }
            else
            {
                //errorprovider
            }
            if (CodeHolder.onlyNumber())
            {

                termekek.setTkatkod(Convert.ToInt32(CodeHolder.Text));
            }
            else
            {
                //errorprovider
            }

            if (VonCodeHolder.onlyNumber())
            {
                termekek.setTvonkod(Convert.ToInt32(VonCodeHolder.Text));
            }
            else { }
            if (checkBox1.Checked)
            {
                termekek.setTegaliz(true);
            
            }
            else { termekek.setTegaliz(false); }
            termekek.setTSzavido(dateTimePicker1.Value);
            
           

           
            

            this.Close();
            

        }
        public DataTable raktnak()
        {
            return rs.modifyData(id, termekek);
        }
        public Szerk(int Sid)
        {
            rs = new RktServ();
            _Sid = Sid;
            InitializeComponent();
            /*
            foreach (PlaceHolderTextBox p in Controls)
            {
                p.styleSetter();
            }*/
      
            button1.DialogResult = DialogResult.OK;
            NameHolder.PlaceHolderText = "Termék neve";
            PriceHolder.PlaceHolderText = "Termék ára";
            AmmountHolder.PlaceHolderText = "Termék mennyisége";
            UnitHolder.PlaceHolderText = "Termék mértékegysége";
            CodeHolder.PlaceHolderText = "Termék kategória kódja";
            VonCodeHolder.PlaceHolderText = "Termék vonalkódja";


        }

       
        public DataTable addNewItem()
        {
            bool eg = false;
            if (checkBox1.Checked)
            {
                eg = true;

            }
            else { eg = false; }

            


            MdTermekek t = new MdTermekek(_Sid, NameHolder.Text, Convert.ToInt32(PriceHolder.Text), Convert.ToInt32(AmmountHolder.Text), UnitHolder.Text, Convert.ToInt32(CodeHolder.Text), Convert.ToInt32(VonCodeHolder.Text), dateTimePicker1.Value, eg);
            return rs.addNewItem(id,t);
        }

        private void backGroundBox1_Click(object sender, EventArgs e)
        {

        }

        private void Szerk_Load(object sender, EventArgs e)
        {

        }
    }
}
