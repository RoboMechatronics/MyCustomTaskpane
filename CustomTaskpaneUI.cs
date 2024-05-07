using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CustomTaskpane
{
    [ProgId(CreateCustomTaskpane.PROG_ID)]
    public partial class CustomTaskpaneUI : UserControl
    {
        public CustomTaskpaneUI()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            CreateHolePattern.Main();
        }
    }
}
