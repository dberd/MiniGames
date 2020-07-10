using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kurs1
{
  public partial class FormMain : Form
  {
    public FormMain()
    {
      InitializeComponent();
    }

    private void DurakButton_Click(object sender, EventArgs e)
    {
      DialogResult result = MessageBox.Show("Вы готовы начать игру", "Дурак классический", MessageBoxButtons.YesNo);
      if (result == DialogResult.Yes)
      {
        Form Form2 = new FormDurK();
        Form2.Show();
        this.Hide();
      }
      
    }
  }
}
