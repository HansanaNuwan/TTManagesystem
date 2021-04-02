using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTManagesyst
{
    public partial class ManageStudent : Form
    {
        public ManageStudent()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string ys = CBYearSem.Text;
            string pg = CBProgramme.Text;
            string gn = Convert.ToString(NMGroupNo.Value);
            string sgn = Convert.ToString(NMSubGroupNo.Value);

            lblGroupID.Text = "Group ID "+ys + "." + pg + "." + gn;

            lblSGroupID.Text = "Sub Group ID "+ys + "." + pg + "." + gn + "."+ sgn;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
