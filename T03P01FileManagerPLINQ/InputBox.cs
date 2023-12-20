using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T02P02FileManager
{
    public partial class InputBox : Form
    {
        public InputBox()
        {
            InitializeComponent();

            bOk.DialogResult = DialogResult.OK;
            bCancel.DialogResult = DialogResult.Cancel;
        }

        public string GetAnswer()
        {
            return tbAnswer.Text;
        }
    }
}
