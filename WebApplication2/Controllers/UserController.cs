using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

using WebApplication2.Models;

using System.Data;
using System.Data.SqlClient;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.Web;
using Microsoft.AspNetCore.Authorization;

using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;


        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> ULlenadoIndicadores()
        {
            try
            {
                var Ojazn = HttpContext.Session.GetString("usuario");
                var obj = JsonSerializer.Deserialize<Users>(Ojazn);
                var att = obj.IdRol;
                switch (Int32.Parse(att))
                {
                    case 1:
                        return View();
                    case 2:
                        return View();
                    case 3:
                        return RedirectToAction("ULlenadoIndicadoresProd", "BdAccidentes");
                    case 4:
                        return RedirectToAction("ULlenadoIndicadoresMant", "BdAccidentes");
                    case 5:
                        return RedirectToAction("ULlenadoIndicadoresCal", "BdAccidentes");
                    case 6:
                        return RedirectToAction("ULlenadoIndicadoresSeg", "BdAccidentes");

                    default:
                        return View();

                }
            }
            catch(ArgumentNullException e)
            {
                await HttpContext.SignOutAsync();
                HttpContext.Session.Clear();
                return View();
            }
        }
        
        public IActionResult UPlandeAccion()
        {
            return View();
        }
        public IActionResult UDescargaExcel()
        {
            return View();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public IActionResult DescargarBD(object sender, EventArgs e, DescargaReporte DR)
        {
            List<DataTable> dt = new List<DataTable>();
            dt = DtReporte(DR);
            Console.WriteLine(dt.Count.ToString());
            int p ;
            if (dt.Count < 2)
            {
                p = 0;
            }
            else
            {
                p = 1;
            }
            //while (dt.Count > 0)
            //{
                Stream s = DataTableToExcel(dt[p], DR);
                if (s != null)
                {
                    var ofecha = System.DateTime.Now.ToString("yyyy-MM-dd");
                    MemoryStream ms = s as MemoryStream;
                    Response.Headers.Add("Content-Disposition", string.Format("attachment;filename= "
                       + HttpUtility.UrlEncode("Reporte-") + ofecha + "-Indicadores" + ".xlsx"));
                    //Response.ContentType = "application/vnd.ms-excel";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.Headers.Add("Content-Length", ms.ToArray().Length.ToString());
                    Response.Body.Write(ms.ToArray());
                    Response.CompleteAsync();
                    ms.Close();
                    ms.Dispose();
                //}
        }
            return View("UDescargaExcel");
        }
        public List<DataTable> DtReporte([Bind("Id,Indicador,Week,Region")] DescargaReporte dr)
        {
            SqlDataAdapter da;

            List<DataTable> Ldt = new List<DataTable>();
            DataTable dt1 = new DataTable();
            string strconn = "server=(localdb)\\Servidor; database = PruebaSQL; integrated security=True;";
            SqlConnection con = new SqlConnection(strconn);
            while (dr.Region.Contains("false")|| (dr.Indicador.Contains("false")))
            {
                dr.Region.Remove("false");
                dr.Indicador.Remove("false");
            }        
            foreach (String indi in dr.Indicador)
            {
                var indic = indi.ToString();
                if (indic == "false") { }
                else
                {
                    con.Open();
                    var SQLQuerty = "SELECT Week,[" + indic + "],Target,[Region] FROM ['BD-" + indic + "$']";
                    int Region = dr.Region.Count;
                    string SQLRegion = "";
                    switch (Region)
                    {
                        case 1:
                            SQLRegion = SQLQuerty + " WHERE Region ='" + dr.Region[0] + "'";
                            break;
                        case 2:
                            SQLRegion = SQLQuerty + " WHERE Region ='" + dr.Region[0] + "' OR Region = '" + dr.Region[1] + "'";
                            break;
                        case 3:
                            SQLRegion = SQLQuerty + " WHERE Region ='" + dr.Region[0] + "' OR Region = '" + dr.Region[1] +"' OR Region = '" + dr.Region[2] + "'";
                            break;
                        case 4:
                            SQLRegion = SQLQuerty + " WHERE Region ='" + dr.Region[0] + "' OR Region = '" + dr.Region[1] + "' OR Region = '" + dr.Region[2] + "' OR Region = '" + dr.Region[3] + "'";
                            break;
                    }
                    da = new SqlDataAdapter(SQLRegion, con);     
                            Ldt.Add(dt1);                
                            da.Fill(Ldt[dr.Indicador.IndexOf(indi)]);
       
                    da.Dispose();
                    con.Close();
                } 
            }            
            return Ldt;

        }
        public Stream DataTableToExcel(DataTable dt, [Bind("Id,Indicador,Week,Region")] DescargaReporte Dr)
        {      
                IRow headerRow = null;
                var KPI = new List<String> { };
                List<ISheet> sheets = new List<ISheet>();
            while (Dr.Indicador.Contains("false"))
            {
                Dr.Indicador.Remove("false");
            }
            for (int u = 0; u < Dr.Indicador.Count; u++)
                {
                    sheets.Add(null);
                }
                ISheet sheet = null;
                IWorkbook workbook = new XSSFWorkbook();
                MemoryStream ms = new MemoryStream();      
                for (int p = 0; p < Dr.Indicador.Count; p++)
            {             
                    sheets[p] = workbook.CreateSheet("Base de datos" + p.ToString());
                    headerRow = (XSSFRow)sheets[p].CreateRow(0);
                    var indi = Dr.Indicador[p];
               
                        foreach (DataColumn column in dt.Columns)
                            if (column.ColumnName.ToString() == indi.ToString())
                            {
                                headerRow.CreateCell(0).SetCellValue("Week");
                                headerRow.CreateCell(1).SetCellValue(Dr.Indicador[p].ToString());
                                headerRow.CreateCell(2).SetCellValue("Target");
                                headerRow.CreateCell(3).SetCellValue("Region");
                            }
                        int rowIndex = 1;
                        foreach (DataRow row in dt.Rows)
                        {
                    IRow dataRow = (XSSFRow)sheets[p].CreateRow(rowIndex);
                            foreach (DataColumn column1 in dt.Columns)
                                if (headerRow.GetCell(0).ToString() == "Week"
                                    && (column1.ColumnName == Dr.Indicador[p].ToString())
                                    && headerRow.GetCell(2).ToString() == "Target"
                                    && headerRow.GetCell(3).ToString() == "Region")
                                {
                                    if (/*column1.Ordinal == 1 ||*/ row[column1].ToString() != "")
                                    {
                                        dataRow.CreateCell(0).SetCellValue(row[0].ToString());
                                        if (p > 0)
                                        {
                                            dataRow.CreateCell(1).SetCellValue(row[p + 3].ToString());
                                        }
                                        else
                                        {
                                            dataRow.CreateCell(1).SetCellValue(row[1].ToString());
                                        }
                                        dataRow.CreateCell(2).SetCellValue(row[2].ToString());
                                        dataRow.CreateCell(3).SetCellValue(row[3].ToString());
                                        ++rowIndex;
             
                            }
                                }
                        }
                    
                for (int i = 0; i <= dt.Columns.Count; ++i)
                        sheets[p].AutoSizeColumn(i);
                }           
                workbook.Write(ms, true);
                ms.Flush();
                ms.Close();
                workbook = null;
                sheets = null;
                headerRow = null;
                return ms;
            
        }
        public IActionResult Login()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
