using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalReport.CrystalReport.Report;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CrystalReport
{
    public partial class _Default : Page
    {
        protected void CRV_Load(object sender, EventArgs e)
        {
            MultipleReports report = new MultipleReports();
            report.DataSourceConnections.Clear();
            report.Database.Tables["Category"].SetDataSource(GetCategoryTable());
            CRV.ReportSource = report;
        }

        private DataTable GetCategoryTable()
        {
            string sql = "SELECT * FROM Category";
            return GetAll(sql);
        }

        private void ReportFromStoreProcedure()
        {
            CRBidDetails report = new CRBidDetails();

            report.DataSourceConnections.Clear();
            CRV.ReportSource = report;
        }

        private void ReportFromDBTable()
        {
            CRCategory report = new CRCategory();
            report.DataSourceConnections.Clear();
            report.Database.Tables["Category"].SetDataSource(GetCategoryTable());
            CRV.ReportSource = report;
        }

        public void ReportFromStaticData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name", typeof(string));
            dt.Rows.Add(2, "category 1");
            CRCategory report = new CRCategory();
            report.Database.Tables["Category"].SetDataSource(dt);
            CRV.ReportSource = null;
            CRV.ReportSource = report;

        }

        public DataTable GetAll(string sql)
        {
            DataTable dt = new DataTable();
            string conn = ConfigurationManager.ConnectionStrings["BidMeConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand(sql))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public DataTable GetAllFromStoreProcedure(string sql)
        {
            DataTable dt = new DataTable();
            string conn = ConfigurationManager.ConnectionStrings["BidMeConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand(sql))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;

                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            using (ReportDocument rd = new ReportDocument())
            {
                rd.Load(Server.MapPath("~/CrystalReport/Report/MultipleReports.rpt"));
                rd.Database.Tables["Category"].SetDataSource(GetAll("SELECT * FROM Category"));
                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "MultpleReport.pdf");
                rd.ExportToDisk(ExportFormatType.PortableDocFormat, @"D:\Multiple.pdf");
                Response.End();
            }
        }

        private void ExportToDisk()
        {
            using (ReportDocument rd = new ReportDocument())
            {
                rd.Load(Server.MapPath("~/CrystalReport/Report/MultipleReports.rpt"));
                rd.Database.Tables["Category"].SetDataSource(GetAll("SELECT * FROM Category"));
                rd.ExportToDisk(ExportFormatType.PortableDocFormat, @"D:\Multiple.pdf");
                Response.End();
            }
        }
    }
}