using System.Data;

namespace ConferenceRegistrationWinForm
{
    public partial class Form1 : Form
    {
        private DBConnect connect = new DBConnect();
        private Registration reg = new Registration();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connect.OpenDB();
            DisplayRegistration();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                reg.firstname= txtFirstname.Text;
                reg.lastname= txtLastname.Text;
                reg.address= txtAddress.Text;
                reg.contactno= txtContactno.Text;
                connect.InsertRegistration(reg);
                MessageBox.Show("You have submitted successfully.");
                ClearFields();
                DisplayRegistration();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }

        public void DisplayRegistration()
        {
            connect.OpenDB();
            DataTable dt = new DataTable();
            dt = connect.ReadRegistrationRecord();
            dataGridViewRegistration.DataSource = dt;
        }

        private void ClearFields()
        {
            txtFirstname.Text = string.Empty;
            txtLastname.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtContactno.Text = string.Empty;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}