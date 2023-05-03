using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication2.Controllers
{
    
    public class ExcelController : Controller
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void DescargarBD(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            dt = DtAnormalidades();
            Stream s = DataTableToExcel(dt);
            if (s != null)
            {
                MemoryStream ms = s as MemoryStream;

                Response.Headers.Add("Content-Disposition", string.Format("attachment;filename= " + HttpUtility.UrlEncode("Prueba") + ".xlsx"));
                //Response.ContentType = "application/vnd.ms-excel";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.Headers.Add("Content-Length", ms.ToArray().Length.ToString());
                Response.Body.Write(ms.ToArray());
                Response.CompleteAsync();
                ms.Close();
                ms.Dispose();
            }
        }
        public DataTable DtAnormalidades()
        {
            DataTable dt = new DataTable();
            try
            {

                string strconn = "server=(localdb)\\Servidor; database = PruebaSQL; integrated security=True;";
                SqlConnection con = new SqlConnection(strconn);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT Week,[%Bajas PT],Target FROM ['BD-%Bajas PT$']", con);
                da.Fill(dt);
                da.Dispose();
                con.Close();
            }
            catch
            {

                //Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Error al extraer la base de datos');</script>");
            }
            return dt;
        }

        //Evento para crear el libro de excel.
        public Stream DataTableToExcel(DataTable dt)
        {
            IWorkbook workbook = new XSSFWorkbook();
            MemoryStream ms = new MemoryStream();
            ISheet sheet = workbook.CreateSheet("BaseDeDatos");
            IRow headerRow = (XSSFRow)sheet.CreateRow(0);
            try
            {

                foreach (DataColumn column in dt.Columns)
                    headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                int rowIndex = 1;

                foreach (DataRow row in dt.Rows)
                {
                    IRow dataRow = (XSSFRow)sheet.CreateRow(rowIndex);
                    foreach (DataColumn column in dt.Columns)
                        dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                    ++rowIndex;
                }

                for (int i = 0; i <= dt.Columns.Count; ++i)
                    sheet.AutoSizeColumn(i);
                workbook.Write(ms,true);
                ms.Flush();

            }

            catch (Exception ex)
            {
                return null;
            }

            finally
            {
                ms.Close();
                sheet = null;
                headerRow = null;
                workbook = null;
            }

            return ms;
        }
    }
    }
