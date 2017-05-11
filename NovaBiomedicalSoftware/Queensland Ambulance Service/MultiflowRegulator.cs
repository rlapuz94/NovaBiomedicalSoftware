﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
namespace NovaBiomedicalSoftware.Queensland_Ambulance_Service
{
    public partial class MultiflowRegulator : MetroForm
    {
        public static List<string> parts = new List<string>();

        public bool multiflowregulatorTest_Submit;

        public static string assetNumberText, modelBoxText, makeBoxText, serialNumberText;
        public static string result1, result2, result3, result4;
        //comment box and item box
        public static string comments, items;

        public MultiflowRegulator()
        {
            InitializeComponent();
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            multiflowregulatorTest_Submit = false;
            this.Close();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            //check if the combobox are answered
            if (result_1.Text == null || result_2.SelectedItem == null || result_3.SelectedItem == null ||
                result_4.SelectedItem == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "", "You need to perform all test.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (assetNumber.Text == "")
                {
                    MetroFramework.MetroMessageBox.Show(this, "", "Fill in the asset number.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //visual
                    assetNumberText = assetNumber.Text;
                    serialNumberText = serialNumber.Text;
                    modelBoxText = modelBox.Text;
                    makeBoxText = makeBox.Text;
                    result1 = result_1.Text;
                    result2 = result_2.Text;
                    result3 = result_3.Text;
                    result4 = result_4.Text;

                    //comments box
                    comments = commentBox.Text;

                    multiflowregulatorTest_Submit = true;
                    this.Hide();
                }
            }
        }

        private void _addBtn_Click(object sender, EventArgs e)
        {
            if (_parts.Text != "")
            {
                parts.Add(_parts.Text.ToUpper());
                _parts.Text = "";
                MetroFramework.MetroMessageBox.Show(this, "", "Parts added to the list.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "", "Type the name of the part.", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}