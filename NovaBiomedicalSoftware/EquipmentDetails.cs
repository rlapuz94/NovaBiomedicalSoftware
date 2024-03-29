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
using System.Text.RegularExpressions;

namespace NovaBiomedicalSoftware
{
    public partial class EquipmentDetails : MetroForm
    {
        public static string assetNumber, serialNumber, location, model, manufacturer, type;

        public EquipmentDetails()
        {
            InitializeComponent();

            if (MainMenu.PerformElectricalSafetyTest == true)
            {
                typeBox.Visible = true;
                metroLabel1.Visible = true;
            }
            if (MainMenu.PerformBothTest == true)
            {
                typeBox.Visible = true;
                metroLabel1.Visible = true;
            }
            if (MainMenu.PerformPerformanceTest == true)
            {
                typeBox.Visible = false;
                metroLabel1.Visible = false;
            }
            if (MainMenu.PerformQAS == true)
            {
                typeBox.Visible = false;
                metroLabel1.Visible = false;
            }
        }

        private void validation()
        {
            if (MainMenu.PerformElectricalSafetyTest == true || MainMenu.PerformBothTest == true)
            {
                if (_assetNumberBox.Text == "" || _serialNumberBox.Text == "" || _locationBox.Text == "" || _modelBox.Text == "" ||
                _manufacturerBox.Text == "" || typeBox.Text == "")
                {
                    MetroFramework.MetroMessageBox.Show(this, "", "Please fill all the details required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    assetNumber = _assetNumberBox.Text;
                    serialNumber = _serialNumberBox.Text;
                    location = _locationBox.Text;
                    model = _modelBox.Text;
                    type = typeBox.Text;
                    manufacturer = _manufacturerBox.Text;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                if (_assetNumberBox.Text == "" || _serialNumberBox.Text == "" || _locationBox.Text == "" || _modelBox.Text == "" ||
                _manufacturerBox.Text == "")
                {
                    MetroFramework.MetroMessageBox.Show(this, "", "Please fill all the details required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    assetNumber = _assetNumberBox.Text;
                    serialNumber = _serialNumberBox.Text;
                    location = _locationBox.Text;
                    model = _modelBox.Text;
                    manufacturer = _manufacturerBox.Text;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            validation();
            
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            _assetNumberBox.Text = "";
            _serialNumberBox.Text = "";
            _locationBox.Text = "";
            _modelBox.Text = "";
            _manufacturerBox.Text = "";

            _assetNumberBox.Focus();
        }



        //Main Menu KeyDowns
        #region mainMenu_keyDowns
        public void assetNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                _serialNumberBox.Focus();
        }

        private void _assetNumberBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"^[!#$%&'()*+,./:;?@[\]^_]*$");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void _serialNumberBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"^[!#$%&'()*+,./:;?@[\]^_]*$");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void _modelBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"^[!#$%&'()*+,./:;?@[\]^_]*$");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void _manufacturerBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"^[!#$%&'()*+,./:;?@[\]^_]*$");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void _locationBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"^[!#$%&'()*+,./:;?@[\]^_]*$");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void typeBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                validation();
        }

        public void serialNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                _modelBox.Focus();
        }

        public void model_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                _manufacturerBox.Focus();
        }

        private void manufacturer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                _locationBox.Focus();
        }
        private void _locationBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (MainMenu.PerformElectricalSafetyTest == true || MainMenu.PerformBothTest)
            {
                if (e.KeyCode == Keys.Enter)
                    typeBox.Focus();
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                    validation();
            }


        }
        #endregion
    }
}
