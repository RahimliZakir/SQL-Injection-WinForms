using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Project.WindowsFormsApp
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        const string cString = "Data Source=.\\SQLEXPRESS;Initial Catalog=SQL-Injection-DB;User ID=sa;password=query;MultipleActiveResultSets=True;";
        private void button_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cString);
            //* Bu halda ise "SQL Injection" chalishacaq!
            SqlCommand cmd = new SqlCommand($@"INSERT INTO [dbo].[Person]([Name], [Surname], [Age])
                                                      VALUES('{nameTextBox.Text}', '{surnameTextBox.Text}', {ageTextBox.Text})", con);

            //* Parameters ile yazdigimiz zaman "SQL Injection" chalishmayacaq!
            //SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Person]([Name], [Surname], [Age])
            //                                          VALUES(@name, @surname, @age)", con);

            con.Open();

            //* Parameters ile yazdigimiz zaman "SQL Injection" chalishmayacaq!
            //cmd.Parameters.AddWithValue("@name", nameTextBox.Text);

            //* Add ile yazdigimiz zaman "Type"-i da gostermeliyik
            //cmd.Parameters.Add(new SqlParameter
            //{
            //    SqlDbType = SqlDbType.NVarChar,
            //    ParameterName = "@surname",
            //    Value = surnameTextBox.Text
            //});

            //cmd.Parameters.AddWithValue("@age", ageTextBox.Text);

            cmd.ExecuteNonQuery();

            cmd.Dispose();
            con.Close();

            MessageBox.Show("Yeni məlumat əlavə olundu!", "Uğurlu!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
