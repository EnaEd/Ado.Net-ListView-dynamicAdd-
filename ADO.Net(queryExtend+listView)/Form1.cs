using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO.Net_queryExtend_listView_
{
    public partial class Form1 : Form
    {
        ContextMenuStrip conMenu = new ContextMenuStrip();
        ListView lw = new ListView();

        public Form1()
        {
            InitializeComponent();
            TabControl.TabPageCollection tab=new TabControl.TabPageCollection(tbCntr);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtQuery == null || txtQuery.Text == "")
            {
                MessageBox.Show("string query is empty");
            }
            else
            {
                tbCntr.TabPages.Add(new TabPage("new page"));
                tbCntr.SelectTab(tbCntr.TabCount - 1);

                //DataGridView dg = new DataGridView();
                //dg.Dock = DockStyle.Fill;
               
                lw.Dock = DockStyle.Fill;
                ToolStripMenuItem viewDetailsMenu = new ToolStripMenuItem("Details");
                ToolStripMenuItem viewListMenu = new ToolStripMenuItem("List");
                conMenu.Items.AddRange(new []{ viewDetailsMenu,viewListMenu});
                lw.ContextMenuStrip = conMenu;
                viewDetailsMenu.Click += ViewDetailsMenu_Click;
                viewListMenu.Click += ViewListMenu_Click;


                tbCntr.SelectedTab.Controls.Add(lw);
                Model m = new Model();
                foreach (var item in m.Command(txtQuery.Text))
                {
                    lw.Items.Add(item);
                }
            }
        }

        private void ViewListMenu_Click(object sender, EventArgs e)
        {
            lw.View = View.List;
        }

        private void ViewDetailsMenu_Click(object sender, EventArgs e)
        {
            lw.View = View.Details;
        }
    }
}
