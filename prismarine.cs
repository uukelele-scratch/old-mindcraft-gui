using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mindcraft_Installer
{
    public partial class prismarine : Form
    {
        public prismarine()
        {
            InitializeComponent();
            viewer.Source = new Uri("http://localhost:3000");
        }
    }
}
