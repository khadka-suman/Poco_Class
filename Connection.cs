using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using POCOGenerator.Extenders;


namespace POCOGenerator
{
	public partial class Connection : Form
	{
		public Connection()
		{
			InitializeComponent();
		}
		public string ConnectionString
		{
			get { return txtConnectionString.Text; }
			set { txtConnectionString.Text = value; }
		}

		public string DisplayName
		{
			get
			{
				var builder = new SqlConnectionStringBuilder(ConnectionString);
				return string.Format("{0} - {1}", builder.DataSource, builder.InitialCatalog);
			}
		}


		#region Event Handlers

		private void Connection_Load(object sender, EventArgs e)
		{
			if (txtConnectionString.Text.IsNullOrEmpty())
			{
				txtConnectionString.Text = @"data source=DELL\SQLLATEST;initial catalog=PrabhuIndiaSandBox;user id=sa;password=ktmnepal1;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework; providerName=System.Data.SqlClient";
			}
		}

		private void Connection_Activated(object sender, EventArgs e)
		{
			btnCancel.Focus();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				using (var con = new SqlConnection(txtConnectionString.Text))
				{
					con.Open();
				}
				DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Failed to validate connection string", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
        #endregion

        private void txtConnectionString_TextChanged(object sender, EventArgs e)
        {

        }
    }
}