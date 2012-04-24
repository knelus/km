using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using km.client;

namespace km
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KmConnection con = new KmConnection("http://localhost/km/");
            con.auth("mark","wachtpas");

            KmDocumentList documentlist = new KmDocumentList(con);


            listBox1.DataSource = documentlist.list;



        }


        private void button2_Click(object sender, EventArgs e)
        {
            KmDocument doc = (KmDocument)listBox1.SelectedItem;
            doc.interested();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            KmConnection con = new KmConnection("http://localhost/km/");
            con.auth("mark", "wachtpas");

            KmInterestList documentlist = new KmInterestList(con);


            listBox1.DataSource = documentlist.list;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            KmConnection con = new KmConnection("http://localhost/km/");
            con.auth("mark", "wachtpas");
            KmUserList userlist = new KmUserList(con);
            listBox3.DataSource = userlist.list;
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            KmUser user = (KmUser)listBox3.SelectedItem;
            MessageBox.Show(""+user.getCommonInterest());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            KmConnection con = new KmConnection("http://localhost/km/");
            con.auth("mark", "wachtpas");
            KmUser user = new KmUser(con);
            user.username = "mark.smit";
            user.password = "wachtpas";
            user.save();

        }

        private void button6_Click(object sender, EventArgs e)
        {

            KmDocument doc = (KmDocument)listBox1.SelectedItem;
    

                doc.delete();
    
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            KmUser user = (KmUser)listBox3.SelectedItem;
            user.delete();
        }
    }
}
