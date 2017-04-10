using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      OpenFileDialog open = new OpenFileDialog();
      if (open.ShowDialog() == DialogResult.OK)
      {
        textBox1.Text = open.FileName;

      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      string Connect = "Data Source=10.49.1.14;Initial Catalog=AisInfo;Persist Security Info=True;User ID=c3user;Password=12345";
      SqlConnection conn = new SqlConnection(Connect);
      SqlCommand Command = new SqlCommand();
      Command = conn.CreateCommand();
      Command.CommandType = CommandType.StoredProcedure;
      Command.CommandText = "[UpdateImageOgv]";
      Command.Parameters.Add("@id", SqlDbType.Int);
      Command.Parameters["@id"].Value = Convert.ToInt32(textBox2.Text);
      Command.Parameters.Add("@map", SqlDbType.VarBinary);

      FileStream fs = new FileStream(textBox1.Text,FileMode.Open,FileAccess.Read);

      BinaryReader br = new BinaryReader(fs);

      Command.Parameters["@map"].Value = br.ReadBytes((int)fs.Length);



      conn.Open();
      Command.ExecuteNonQuery();
      conn.Close();
      MessageBox.Show("Запись, успешно добавленна!");
    }
  }
}
