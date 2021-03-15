using Autofac.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AnketForm
{
    public partial class Form1 : Form
    {
        string name;
        
       public List<string> language = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.SelectionMode = SelectionMode.One;
            listBox1.DisplayMember = "Name";
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {

            if (NameTxtbox.Text!="")
            {
            if (EnglishChck.Checked) language.Add(EnglishChck.Text);
            else if (RussianChck.Checked) language.Add(RussianChck.Text);
            else if (TurkishChck.Checked) language.Add(TurkishChck.Text);
            if (EnglishChck.Checked == false) language.Remove(EnglishChck.Text);
            if (RussianChck.Checked == false) language.Remove(RussianChck.Text);
            if (TurkishChck.Checked == false) language.Remove(TurkishChck.Text);

            name = NameTxtbox.Text;

            listBox1.Items.Add(new User
            {
                Name = NameTxtbox.Text,
                Surname = SurnameTxtbox.Text,
                Email = EmailTxtbox.Text,
                PhoneNum = PhoneBox.Text,
                Gender = ReturnChecked(),
                Language = language,
                Skills = skillsTxtBox.Text,
                Education = EducationTxtBox.Text,
                Brith = dateTimePicker1.Value
            });
            NameTxtbox.Text = string.Empty;
            SurnameTxtbox.Text = string.Empty;
            EmailTxtbox.Text = string.Empty;
            PhoneBox.Text = string.Empty;
            skillsTxtBox.Text = string.Empty;
            EducationTxtBox.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Hey you must write your name first!!");
            }
            
        }

        private void FemaleRdbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                RadioButton rb = (RadioButton)sender;
            }
        }
        private string ReturnChecked()
        {
            string CheckedInRadiobuttons;
            if (MaleRdbtn.Checked == true)
            {
                CheckedInRadiobuttons = MaleRdbtn.Text;
                return CheckedInRadiobuttons;
            }
            if (FemaleRdbtn.Checked == true)
            {
                CheckedInRadiobuttons = FemaleRdbtn.Text;
                return CheckedInRadiobuttons;

            }
            if (OtherRdbtn.Checked == true)
            {
                CheckedInRadiobuttons = OtherRdbtn.Text;
                return CheckedInRadiobuttons;
            }
            try
            {

                throw new InvalidCastException();
            }
            catch (Exception ex)
            {

                return (ex.Message);
            }

        }
        private void OtherRdbtn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void MaleRdbtn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (listBox1.Text != "")
            {


                FileHelper.JsonSerialize(name, listBox1.SelectedItem as User);
                NameTxtbox.Text = string.Empty;
                SurnameTxtbox.Text = string.Empty;
                EmailTxtbox.Text = string.Empty;
                PhoneBox.Text = "";
                skillsTxtBox.Text = string.Empty;
                EducationTxtBox.Text = string.Empty;
                EnglishChck.Checked = false;
                TurkishChck.Checked = false;
                RussianChck.Checked = false;
                MaleRdbtn.Checked = false;
                FemaleRdbtn.Checked = false;
                OtherRdbtn.Checked = false;
            }
            else
            {
                MessageBox.Show("First you must add something to list!!!");
            }

        }
        private void LoadBtn_Click(object sender, EventArgs e)
        {
            if (listBox1.Text != "")
            {
                var obj = listBox1.SelectedItem as User;
                var p = FileHelper.JsonDeserialize((obj)?.Name);
                var a = ReturnChecked();
                try
                {
                    NameTxtbox.Text = p.Name;
                    SurnameTxtbox.Text = p.Surname;
                    EmailTxtbox.Text = p.Surname;
                    PhoneBox.Text = p.PhoneNum;
                    skillsTxtBox.Text = p.Skills;
                    EducationTxtBox.Text = p.Education;

                    foreach (var item in language)
                    {
                        if (item == EnglishChck.Text)
                            EnglishChck.Checked = true;
                        if (item == TurkishChck.Text)
                            TurkishChck.Checked = true;
                        if (item == RussianChck.Text)
                            RussianChck.Checked = true;
                    }
                    if (a == MaleRdbtn.Text)
                        MaleRdbtn.Checked = true;
                    if (a == FemaleRdbtn.Text)
                        MaleRdbtn.Checked = true;
                    if (a == OtherRdbtn.Text)
                        MaleRdbtn.Checked = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
            else MessageBox.Show("Hey what I must to load???");
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if (listBox1.Text != "")
            {

                listBox1.Items.Remove(listBox1.SelectedItem);
            }

            else {
                MessageBox.Show("Your list is empty what I must to remove????");
            }
        }
    }
}
