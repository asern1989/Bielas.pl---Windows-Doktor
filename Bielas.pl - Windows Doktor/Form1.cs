using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bielas.pl___Windows_Doktor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.dataGridView1.Rows.Add("1", "Sieć", "ping 1.1.1.1 -t");
            this.dataGridView1.Rows.Add("2", "Sieć", "tracert 1.1.1.1");
            this.dataGridView1.Rows.Add("3", "Sieć", "ipconfig /all");
            this.dataGridView1.Rows.Add("4", "Sieć", "ipconfig /renew");
            this.dataGridView1.Rows.Add("999", "Windows", "Szybka Pomoc");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Thread t1 = new Thread(start);
            //t1.Start();
            progressBar1.Visible = true;
            dataGridView1.Enabled = false;
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            PowerShell ps = PowerShell.Create();
            ps.Runspace = runspace;
            switch (Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value))
            {
                case 1: System.Diagnostics.Process.Start("cmd.exe", "/K ping 1.1.1.1 -t"); break;
                case 2: System.Diagnostics.Process.Start("cmd.exe", "/K tracert 1.1.1.1"); break;
                case 3: System.Diagnostics.Process.Start("cmd.exe", "/K ipconfig /all"); break;
                case 4: System.Diagnostics.Process.Start("cmd.exe", "/K ipconfig /renew"); break;



                case 999: System.Diagnostics.Process.Start("quickassist.exe", ""); break;
                default:
                    MessageBox.Show("No i popsułeś!");
                    break;


            }
            //Collection<PSObject> results = ps.Invoke();
            //runspace.Close();
            //StringBuilder stringBuilder = new StringBuilder();
            //listBox1.Items.Clear();
            //foreach (PSObject obj in results) listBox1.Items.Add(obj.ToString());
            Thread t2 = new Thread(stop);
            t2.Start();

        }
    
        public void start()
        {
            progressBar1.Invoke(new Action(delegate(){progressBar1.Visible = true;}));
            dataGridView1.Invoke(new Action(delegate(){dataGridView1.Enabled = false;}));            
        }
        void stop()
        {
            progressBar1.Invoke(new Action(delegate () { progressBar1.Visible = false; }));
            dataGridView1.Invoke(new Action(delegate () { dataGridView1.Enabled = true; }));
        }
    }
}
