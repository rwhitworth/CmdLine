
//CommandLine Test program - For testing the CmdLine lib for Parsing command line options
//Copyright (C) 2011 Ryan Whitworth (lithron@gmail.com; me@ryanwhitworth.com)

//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.

//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.

//You should have received a copy of the GNU General Public License
//along with this program.  If not, see <http://www.gnu.org/licenses/>.

//Please contact the author if you wish to see this library released under
//a different licensing scheme.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CmdLine;

namespace CommandLine_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            { }
            else
            {
                CmdLineParser cmd = new CmdLineParser(textBox1.Text);
                var results = cmd.commands;
                foreach (var item in results)
                {
                    textBox2.AppendText(item.ToString() + "\n");
                }

                foreach (var item in results)
                {
                    if (item.ToString().IndexOf("t=") == 0)
                    {
                        String t = String.Empty;
                        t = item.ToString().Substring(2);
                        textBox3.AppendText(String.Format("-t= defined as {0}\n", t));
                    }
                    if (item.ToString().IndexOf("fin=") == 0)
                    {
                        String t = String.Empty;
                        t = item.ToString().Substring(4);
                        textBox3.AppendText(String.Format("-fin= defined as {0}\n", t));
                    }
                    if (item.ToString().Contains("al"))
                    {
                        textBox3.AppendText("-al defined\n");
                    }
                    if (item.ToString().Contains("b"))
                    {
                        textBox3.AppendText("-b defined\n");
                    }
                    if (item.ToString().Contains("type"))
                    {
                        textBox3.AppendText("-type defined\n");
                    }
                    if (item.ToString().Contains("car"))
                    {
                        textBox3.AppendText("-car defined\n");
                    }


                }
                

            }

        }
    }
}
