using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using System.Data;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class BdAccidentesController : Controller
    {
        private readonly PruebaSQLContext _context;

        public BdAccidentesController(PruebaSQLContext context)
        {
            _context = context;
        }
        // GET: BdAccidentes
        public async Task<IActionResult> Index()
        {
            return View(await _context.BdAccidentes.ToListAsync());
        }

        // GET: BdAccidentes/Details/5
        public async Task<IActionResult> Details(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bdAccidente = await _context.BdAccidentes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bdAccidente == null)
            {
                return NotFound();
            }

            return View(bdAccidente);
        }

        // GET: BdAccidentes/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NúmeroDeEventos")] BdAccidente bdAccidente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bdAccidente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bdAccidente);
        }

        public IEnumerable<Targets> Targets()
        {
            var ofecha = System.DateTime.Now.ToString("dd/MM/yyyy");
            var T = _context.Target
                .Where(t => t.trmonths.trweek.trdates.Fecha == ofecha)
                .ToList();
            return T;
        }
        [Authorize(Roles = "1,2,3")]
        public IActionResult ULlenadoIndicadoresProdRT()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "1,2,3")]
        public async Task<IActionResult> ULlenadoIndicadoresProdRT([Bind("BALON,BUBULUBU2,BUBULUBU,CANASTA,CAVEMIL,CHOCORETA" +
            ",DUVALIN,DUVALINTETRA,GRANILLO,KRANKY,LUNETA,MONEDA,MULTICAV,PALETONLC,PALETAPAYASO,SIMA" +
            ",CBALON,CBUBULUBU2,CBUBULUBU,CCANASTA,CCAVEMIL,CCHOCORETA" +
            ",CDUVALIN,CDUVALINTETRA,CGRANILLO,CKRANKY,CLUNETA,CMONEDA,CMULTICAV,CPALETONLC,CPALETAPAYASO,CSIMA")] BdIndicadoresPorLineaRT bdindicadoresporlineaRT)
        {
            if (ModelState.IsValid)
            {
                var ofecha = System.DateTime.Now.ToString("dd/MM/yyyy");
                TrDates oTrdate = _context.TrDates.Where(x => x.Fecha == ofecha).Single();
                bdindicadoresporlineaRT.BALON.Week = oTrdate.Week;
                bdindicadoresporlineaRT.BALON.Línea = "BALON";
                bdindicadoresporlineaRT.BALON.Region = "Toluca";
                bdindicadoresporlineaRT.BALON.IdSem = Int32.Parse(bdindicadoresporlineaRT.BALON.Week.Substring(6, 2));
                _context.Add(bdindicadoresporlineaRT.BALON);
                bdindicadoresporlineaRT.BUBULUBU2.Week = oTrdate.Week;
                bdindicadoresporlineaRT.BUBULUBU2.Línea = "BUBULUBU 2";
                bdindicadoresporlineaRT.BUBULUBU2.Region = "Toluca";
                bdindicadoresporlineaRT.BUBULUBU2.IdSem = Int32.Parse(bdindicadoresporlineaRT.BUBULUBU2.Week.Substring(6, 2));
                bdindicadoresporlineaRT.BUBULUBU2.Id = bdindicadoresporlineaRT.BALON.Id + 1;
                _context.Add(bdindicadoresporlineaRT.BUBULUBU2);
                bdindicadoresporlineaRT.BUBULUBU.Week = oTrdate.Week;
                bdindicadoresporlineaRT.BUBULUBU.Línea = "BUBULUBU";
                bdindicadoresporlineaRT.BUBULUBU.Region = "Toluca";
                bdindicadoresporlineaRT.BUBULUBU.IdSem = Int32.Parse(bdindicadoresporlineaRT.BUBULUBU.Week.Substring(6, 2));
                bdindicadoresporlineaRT.BUBULUBU.Id = bdindicadoresporlineaRT.BUBULUBU2.Id + 1;
                _context.Add(bdindicadoresporlineaRT.BUBULUBU);
                bdindicadoresporlineaRT.CANASTA.Week = oTrdate.Week;
                bdindicadoresporlineaRT.CANASTA.Línea = "CANASTA";
                bdindicadoresporlineaRT.CANASTA.Region = "Toluca";
                bdindicadoresporlineaRT.CANASTA.IdSem = Int32.Parse(bdindicadoresporlineaRT.CANASTA.Week.Substring(6, 2));
                bdindicadoresporlineaRT.CANASTA.Id = bdindicadoresporlineaRT.BUBULUBU.Id + 1;
                _context.Add(bdindicadoresporlineaRT.CANASTA);
                bdindicadoresporlineaRT.CHOCORETA.Week = oTrdate.Week;
                bdindicadoresporlineaRT.CHOCORETA.Línea = "CHOCORETA";
                bdindicadoresporlineaRT.CHOCORETA.Region = "Toluca";
                bdindicadoresporlineaRT.CHOCORETA.IdSem = Int32.Parse(bdindicadoresporlineaRT.CHOCORETA.Week.Substring(6, 2));
                bdindicadoresporlineaRT.CHOCORETA.Id = bdindicadoresporlineaRT.BUBULUBU.Id + 1;
                _context.Add(bdindicadoresporlineaRT.CHOCORETA);
                bdindicadoresporlineaRT.DUVALIN.Week = oTrdate.Week;
                bdindicadoresporlineaRT.DUVALIN.Línea = "DUVALIN";
                bdindicadoresporlineaRT.DUVALIN.Region = "Toluca";
                bdindicadoresporlineaRT.DUVALIN.IdSem = Int32.Parse(bdindicadoresporlineaRT.DUVALIN.Week.Substring(6, 2));
                bdindicadoresporlineaRT.DUVALIN.Id = bdindicadoresporlineaRT.CHOCORETA.Id + 1;
                _context.Add(bdindicadoresporlineaRT.DUVALIN);
                bdindicadoresporlineaRT.DUVALINTETRA.Week = oTrdate.Week;
                bdindicadoresporlineaRT.DUVALINTETRA.Línea = "DUVALIN TETRA";
                bdindicadoresporlineaRT.DUVALINTETRA.Region = "Toluca";
                bdindicadoresporlineaRT.DUVALINTETRA.IdSem = Int32.Parse(bdindicadoresporlineaRT.DUVALINTETRA.Week.Substring(6, 2));
                bdindicadoresporlineaRT.DUVALINTETRA.Id = bdindicadoresporlineaRT.DUVALIN.Id + 1;
                _context.Add(bdindicadoresporlineaRT.DUVALINTETRA);
                bdindicadoresporlineaRT.GRANILLO.Week = oTrdate.Week;
                bdindicadoresporlineaRT.GRANILLO.Línea = "GRANILLO";
                bdindicadoresporlineaRT.GRANILLO.Region = "Toluca";
                bdindicadoresporlineaRT.GRANILLO.IdSem = Int32.Parse(bdindicadoresporlineaRT.GRANILLO.Week.Substring(6, 2));
                bdindicadoresporlineaRT.GRANILLO.Id = bdindicadoresporlineaRT.DUVALINTETRA.Id + 1;
                _context.Add(bdindicadoresporlineaRT.GRANILLO);
                bdindicadoresporlineaRT.KRANKY.Week = oTrdate.Week;
                bdindicadoresporlineaRT.KRANKY.Línea = "KRANKY";
                bdindicadoresporlineaRT.KRANKY.Region = "Toluca";
                bdindicadoresporlineaRT.KRANKY.IdSem = Int32.Parse(bdindicadoresporlineaRT.KRANKY.Week.Substring(6, 2));
                bdindicadoresporlineaRT.KRANKY.Id = bdindicadoresporlineaRT.GRANILLO.Id + 1;
                _context.Add(bdindicadoresporlineaRT.KRANKY);
                bdindicadoresporlineaRT.LUNETA.Week = oTrdate.Week;
                bdindicadoresporlineaRT.LUNETA.Línea = "LUNETA";
                bdindicadoresporlineaRT.LUNETA.Region = "Toluca";
                bdindicadoresporlineaRT.LUNETA.IdSem = Int32.Parse(bdindicadoresporlineaRT.LUNETA.Week.Substring(6, 2));
                bdindicadoresporlineaRT.LUNETA.Id = bdindicadoresporlineaRT.KRANKY.Id + 1;
                _context.Add(bdindicadoresporlineaRT.LUNETA);
                bdindicadoresporlineaRT.MONEDA.Week = oTrdate.Week;
                bdindicadoresporlineaRT.MONEDA.Línea = "MONEDA";
                bdindicadoresporlineaRT.MONEDA.Region = "Toluca";
                bdindicadoresporlineaRT.MONEDA.IdSem = Int32.Parse(bdindicadoresporlineaRT.MONEDA.Week.Substring(6, 2));
                bdindicadoresporlineaRT.MONEDA.Id = bdindicadoresporlineaRT.LUNETA.Id + 1;
                _context.Add(bdindicadoresporlineaRT.MONEDA);
                bdindicadoresporlineaRT.MULTICAV.Week = oTrdate.Week;
                bdindicadoresporlineaRT.MULTICAV.Línea = "MULTICAVEMIL";
                bdindicadoresporlineaRT.MULTICAV.Region = "Toluca";
                bdindicadoresporlineaRT.MULTICAV.IdSem = Int32.Parse(bdindicadoresporlineaRT.MULTICAV.Week.Substring(6, 2));
                bdindicadoresporlineaRT.MULTICAV.Id = bdindicadoresporlineaRT.MONEDA.Id + 1;
                _context.Add(bdindicadoresporlineaRT.MULTICAV);
                bdindicadoresporlineaRT.PALETONLC.Week = oTrdate.Week;
                bdindicadoresporlineaRT.PALETONLC.Línea = "PALETON LC";
                bdindicadoresporlineaRT.PALETONLC.Region = "Toluca";
                bdindicadoresporlineaRT.PALETONLC.IdSem = Int32.Parse(bdindicadoresporlineaRT.PALETONLC.Week.Substring(6, 2));
                bdindicadoresporlineaRT.PALETONLC.Id = bdindicadoresporlineaRT.MULTICAV.Id + 1;
                _context.Add(bdindicadoresporlineaRT.PALETONLC);
                bdindicadoresporlineaRT.PALETAPAYASO.Week = oTrdate.Week;
                bdindicadoresporlineaRT.PALETAPAYASO.Línea = "PALETA PAYASO";
                bdindicadoresporlineaRT.PALETAPAYASO.Region = "Toluca";
                bdindicadoresporlineaRT.PALETAPAYASO.IdSem = Int32.Parse(bdindicadoresporlineaRT.PALETAPAYASO.Week.Substring(6, 2));
                bdindicadoresporlineaRT.PALETAPAYASO.Id = bdindicadoresporlineaRT.PALETONLC.Id + 1;
                _context.Add(bdindicadoresporlineaRT.PALETAPAYASO);
                bdindicadoresporlineaRT.SIMA.Week = oTrdate.Week;
                bdindicadoresporlineaRT.SIMA.Línea = "SIMA";
                bdindicadoresporlineaRT.SIMA.Region = "Toluca";
                bdindicadoresporlineaRT.SIMA.IdSem = Int32.Parse(bdindicadoresporlineaRT.SIMA.Week.Substring(6, 2));
                bdindicadoresporlineaRT.SIMA.Id = bdindicadoresporlineaRT.PALETAPAYASO.Id + 1;
                _context.Add(bdindicadoresporlineaRT.SIMA);
                //<------CAPACIDAD UTILIZADA POR LINEA--->
                bdindicadoresporlineaRT.CBALON.Week = oTrdate.Week;
                bdindicadoresporlineaRT.CBALON.Línea = "BALON";
                bdindicadoresporlineaRT.CBALON.Region = "Toluca";
                bdindicadoresporlineaRT.CBALON.IdSem = Int32.Parse(bdindicadoresporlineaRT.CBALON.Week.Substring(6, 2));
                _context.Add(bdindicadoresporlineaRT.CBALON);
                bdindicadoresporlineaRT.CBUBULUBU2.Week = oTrdate.Week;
                bdindicadoresporlineaRT.CBUBULUBU2.Línea = "BUBULUBU 2";
                bdindicadoresporlineaRT.CBUBULUBU2.Region = "Toluca";
                bdindicadoresporlineaRT.CBUBULUBU2.IdSem = Int32.Parse(bdindicadoresporlineaRT.CBUBULUBU2.Week.Substring(6, 2));
                bdindicadoresporlineaRT.CBUBULUBU2.Id = bdindicadoresporlineaRT.CBALON.Id + 1;
                _context.Add(bdindicadoresporlineaRT.CBUBULUBU2);
                bdindicadoresporlineaRT.CBUBULUBU.Week = oTrdate.Week;
                bdindicadoresporlineaRT.CBUBULUBU.Línea = "BUBULUBU";
                bdindicadoresporlineaRT.CBUBULUBU.Region = "Toluca";
                bdindicadoresporlineaRT.CBUBULUBU.IdSem = Int32.Parse(bdindicadoresporlineaRT.CBUBULUBU.Week.Substring(6, 2));
                bdindicadoresporlineaRT.CBUBULUBU.Id = bdindicadoresporlineaRT.CBUBULUBU2.Id + 1;
                _context.Add(bdindicadoresporlineaRT.CBUBULUBU);
                bdindicadoresporlineaRT.CCANASTA.Week = oTrdate.Week;
                bdindicadoresporlineaRT.CCANASTA.Línea = "CANASTA";
                bdindicadoresporlineaRT.CCANASTA.Region = "Toluca";
                bdindicadoresporlineaRT.CCANASTA.IdSem = Int32.Parse(bdindicadoresporlineaRT.CCANASTA.Week.Substring(6, 2));
                bdindicadoresporlineaRT.CCANASTA.Id = bdindicadoresporlineaRT.CBUBULUBU.Id + 1;
                _context.Add(bdindicadoresporlineaRT.CCANASTA);
                bdindicadoresporlineaRT.CCHOCORETA.Week = oTrdate.Week;
                bdindicadoresporlineaRT.CCHOCORETA.Línea = "CHOCORETA";
                bdindicadoresporlineaRT.CCHOCORETA.Region = "Toluca";
                bdindicadoresporlineaRT.CCHOCORETA.IdSem = Int32.Parse(bdindicadoresporlineaRT.CCHOCORETA.Week.Substring(6, 2));
                bdindicadoresporlineaRT.CCHOCORETA.Id = bdindicadoresporlineaRT.CBUBULUBU.Id + 1;
                _context.Add(bdindicadoresporlineaRT.CCHOCORETA);
                bdindicadoresporlineaRT.CDUVALIN.Week = oTrdate.Week;
                bdindicadoresporlineaRT.CDUVALIN.Línea = "DUVALIN";
                bdindicadoresporlineaRT.CDUVALIN.Region = "Toluca";
                bdindicadoresporlineaRT.CDUVALIN.IdSem = Int32.Parse(bdindicadoresporlineaRT.CDUVALIN.Week.Substring(6, 2));
                bdindicadoresporlineaRT.CDUVALIN.Id = bdindicadoresporlineaRT.CCHOCORETA.Id + 1;
                _context.Add(bdindicadoresporlineaRT.CDUVALIN);
                bdindicadoresporlineaRT.CDUVALINTETRA.Week = oTrdate.Week;
                bdindicadoresporlineaRT.CDUVALINTETRA.Línea = "DUVALIN TETRA";
                bdindicadoresporlineaRT.CDUVALINTETRA.Region = "Toluca";
                bdindicadoresporlineaRT.CDUVALINTETRA.IdSem = Int32.Parse(bdindicadoresporlineaRT.CDUVALINTETRA.Week.Substring(6, 2));
                bdindicadoresporlineaRT.CDUVALINTETRA.Id = bdindicadoresporlineaRT.CDUVALIN.Id + 1;
                _context.Add(bdindicadoresporlineaRT.CDUVALINTETRA);
                bdindicadoresporlineaRT.CGRANILLO.Week = oTrdate.Week;
                bdindicadoresporlineaRT.CGRANILLO.Línea = "GRANILLO";
                bdindicadoresporlineaRT.CGRANILLO.Region = "Toluca";
                bdindicadoresporlineaRT.CGRANILLO.IdSem = Int32.Parse(bdindicadoresporlineaRT.CGRANILLO.Week.Substring(6, 2));
                bdindicadoresporlineaRT.CGRANILLO.Id = bdindicadoresporlineaRT.CDUVALINTETRA.Id + 1;
                _context.Add(bdindicadoresporlineaRT.CGRANILLO);
                bdindicadoresporlineaRT.CKRANKY.Week = oTrdate.Week;
                bdindicadoresporlineaRT.CKRANKY.Línea = "KRANKY";
                bdindicadoresporlineaRT.CKRANKY.Region = "Toluca";
                bdindicadoresporlineaRT.CKRANKY.IdSem = Int32.Parse(bdindicadoresporlineaRT.CKRANKY.Week.Substring(6, 2));
                bdindicadoresporlineaRT.CKRANKY.Id = bdindicadoresporlineaRT.CGRANILLO.Id + 1;
                _context.Add(bdindicadoresporlineaRT.CKRANKY);
                bdindicadoresporlineaRT.CLUNETA.Week = oTrdate.Week;
                bdindicadoresporlineaRT.CLUNETA.Línea = "LUNETA";
                bdindicadoresporlineaRT.CLUNETA.Region = "Toluca";
                bdindicadoresporlineaRT.CLUNETA.IdSem = Int32.Parse(bdindicadoresporlineaRT.CLUNETA.Week.Substring(6, 2));
                bdindicadoresporlineaRT.CLUNETA.Id = bdindicadoresporlineaRT.CKRANKY.Id + 1;
                _context.Add(bdindicadoresporlineaRT.CLUNETA);
                bdindicadoresporlineaRT.CMONEDA.Week = oTrdate.Week;
                bdindicadoresporlineaRT.CMONEDA.Línea = "MONEDA";
                bdindicadoresporlineaRT.CMONEDA.Region = "Toluca";
                bdindicadoresporlineaRT.CMONEDA.IdSem = Int32.Parse(bdindicadoresporlineaRT.CMONEDA.Week.Substring(6, 2));
                bdindicadoresporlineaRT.CMONEDA.Id = bdindicadoresporlineaRT.CLUNETA.Id + 1;
                _context.Add(bdindicadoresporlineaRT.CMONEDA);
                bdindicadoresporlineaRT.CMULTICAV.Week = oTrdate.Week;
                bdindicadoresporlineaRT.CMULTICAV.Línea = "MULTICAVEMIL";
                bdindicadoresporlineaRT.CMULTICAV.Region = "Toluca";
                bdindicadoresporlineaRT.CMULTICAV.IdSem = Int32.Parse(bdindicadoresporlineaRT.CMULTICAV.Week.Substring(6, 2));
                bdindicadoresporlineaRT.CMULTICAV.Id = bdindicadoresporlineaRT.CMONEDA.Id + 1;
                _context.Add(bdindicadoresporlineaRT.CMULTICAV);
                bdindicadoresporlineaRT.CPALETONLC.Week = oTrdate.Week;
                bdindicadoresporlineaRT.CPALETONLC.Línea = "PALETON LC";
                bdindicadoresporlineaRT.CPALETONLC.Region = "Toluca";
                bdindicadoresporlineaRT.CPALETONLC.IdSem = Int32.Parse(bdindicadoresporlineaRT.CPALETONLC.Week.Substring(6, 2));
                bdindicadoresporlineaRT.CPALETONLC.Id = bdindicadoresporlineaRT.CMULTICAV.Id + 1;
                _context.Add(bdindicadoresporlineaRT.CPALETONLC);
                bdindicadoresporlineaRT.CPALETAPAYASO.Week = oTrdate.Week;
                bdindicadoresporlineaRT.CPALETAPAYASO.Línea = "PALETA PAYASO";
                bdindicadoresporlineaRT.CPALETAPAYASO.Region = "Toluca";
                bdindicadoresporlineaRT.CPALETAPAYASO.IdSem = Int32.Parse(bdindicadoresporlineaRT.CPALETAPAYASO.Week.Substring(6, 2));
                bdindicadoresporlineaRT.CPALETAPAYASO.Id = bdindicadoresporlineaRT.CPALETONLC.Id + 1;
                _context.Add(bdindicadoresporlineaRT.CPALETAPAYASO);
                bdindicadoresporlineaRT.CSIMA.Week = oTrdate.Week;
                bdindicadoresporlineaRT.CSIMA.Línea = "SIMA";
                bdindicadoresporlineaRT.CSIMA.Region = "Toluca";
                bdindicadoresporlineaRT.CSIMA.IdSem = Int32.Parse(bdindicadoresporlineaRT.CSIMA.Week.Substring(6, 2));
                bdindicadoresporlineaRT.CSIMA.Id = bdindicadoresporlineaRT.CPALETAPAYASO.Id + 1;
                _context.Add(bdindicadoresporlineaRT.CSIMA);
                //<------CAPACIDAD UTILIZADA POR LINEA--->
                await _context.SaveChangesAsync();

                ViewData["message"] = $"Se han cargado los datos Correctamente! " ;
                return View("ULlenadoIndicadoresProdRT");
            }
            return View(bdindicadoresporlineaRT);
        }
        [Authorize(Roles = "1,2,3")]
        public IActionResult ULlenadoIndicadoresProdRSLP()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "1,2,3")]
        public async Task<IActionResult> ULlenadoIndicadoresProdRSLP([Bind(
            "BOSSAR,BSCHOCOLATE,BSCONFITADO,BUBULUBU,CAJETAGRANEL,CAJETAPET" +
            ",CHICLOSO,GOMAS,PALETAPAYASO,PALETONCOR,PECOSITA"+
            ",CBOSSAR,CBSCHOCOLATE,CBSCONFITADO,CBUBULUBU,CCAJETAGRANEL,CCAJETAPET" +
            ",CCHICLOSO,CGOMAS,CPALETAPAYASO,CPALETONCOR,CPECOSITA"
            )] BdIndicadoresPorLineaSLP bdindicadoresporlineaSLP)
        {
            if (ModelState.IsValid)
            {
                var ofecha = System.DateTime.Now.ToString("dd/MM/yyyy");
                TrDates oTrdate = _context.TrDates.Where(x => x.Fecha == ofecha).Single();
                bdindicadoresporlineaSLP.BOSSAR.Week = oTrdate.Week;
                bdindicadoresporlineaSLP.BOSSAR.Línea = "BOSSAR";
                bdindicadoresporlineaSLP.BOSSAR.Region = "San Luis Potosi";
                bdindicadoresporlineaSLP.BOSSAR.IdSem = Int32.Parse(bdindicadoresporlineaSLP.BOSSAR.Week.Substring(6, 2));
                _context.Add(bdindicadoresporlineaSLP.BOSSAR);
                bdindicadoresporlineaSLP.BSCHOCOLATE.Week = oTrdate.Week;
                bdindicadoresporlineaSLP.BSCHOCOLATE.Línea = "BSCHOCOLATE";
                bdindicadoresporlineaSLP.BSCHOCOLATE.Region = "San Luis Potosi";
                bdindicadoresporlineaSLP.BSCHOCOLATE.IdSem = Int32.Parse(bdindicadoresporlineaSLP.BSCHOCOLATE.Week.Substring(6, 2));
                bdindicadoresporlineaSLP.BSCHOCOLATE.Id = bdindicadoresporlineaSLP.BOSSAR.Id + 1;
                _context.Add(bdindicadoresporlineaSLP.BSCHOCOLATE);
                bdindicadoresporlineaSLP.BSCONFITADO.Week = oTrdate.Week;
                bdindicadoresporlineaSLP.BSCONFITADO.Línea = "BSCONFITADO";
                bdindicadoresporlineaSLP.BSCONFITADO.Region = "San Luis Potosi";
                bdindicadoresporlineaSLP.BSCONFITADO.IdSem = Int32.Parse(bdindicadoresporlineaSLP.BSCONFITADO.Week.Substring(6, 2));
                bdindicadoresporlineaSLP.BSCONFITADO.Id = bdindicadoresporlineaSLP.BSCHOCOLATE.Id + 1;
                _context.Add(bdindicadoresporlineaSLP.BSCONFITADO);
                bdindicadoresporlineaSLP.BUBULUBU.Week = oTrdate.Week;
                bdindicadoresporlineaSLP.BUBULUBU.Línea = "BUBULUBU";
                bdindicadoresporlineaSLP.BUBULUBU.Region = "San Luis Potosi";
                bdindicadoresporlineaSLP.BUBULUBU.IdSem = Int32.Parse(bdindicadoresporlineaSLP.BUBULUBU.Week.Substring(6, 2));
                bdindicadoresporlineaSLP.BUBULUBU.Id = bdindicadoresporlineaSLP.BSCONFITADO.Id + 1;
                _context.Add(bdindicadoresporlineaSLP.BUBULUBU);
                bdindicadoresporlineaSLP.CAJETAGRANEL.Week = oTrdate.Week;
                bdindicadoresporlineaSLP.CAJETAGRANEL.Línea = "CAJETAGRANEL";
                bdindicadoresporlineaSLP.CAJETAGRANEL.Region = "San Luis Potosi";
                bdindicadoresporlineaSLP.CAJETAGRANEL.IdSem = Int32.Parse(bdindicadoresporlineaSLP.CAJETAGRANEL.Week.Substring(6, 2));
                bdindicadoresporlineaSLP.CAJETAGRANEL.Id = bdindicadoresporlineaSLP.BUBULUBU.Id + 1;
                _context.Add(bdindicadoresporlineaSLP.CAJETAGRANEL);
                bdindicadoresporlineaSLP.CAJETAPET.Week = oTrdate.Week;
                bdindicadoresporlineaSLP.CAJETAPET.Línea = "CAJETAPET";
                bdindicadoresporlineaSLP.CAJETAPET.Region = "San Luis Potosi";
                bdindicadoresporlineaSLP.CAJETAPET.IdSem = Int32.Parse(bdindicadoresporlineaSLP.CAJETAPET.Week.Substring(6, 2));
                bdindicadoresporlineaSLP.CAJETAPET.Id = bdindicadoresporlineaSLP.CAJETAGRANEL.Id + 1;
                _context.Add(bdindicadoresporlineaSLP.CAJETAPET);
                bdindicadoresporlineaSLP.CHICLOSO.Week = oTrdate.Week;
                bdindicadoresporlineaSLP.CHICLOSO.Línea = "CHICLOSO";
                bdindicadoresporlineaSLP.CHICLOSO.Region = "San Luis Potosi";
                bdindicadoresporlineaSLP.CHICLOSO.IdSem = Int32.Parse(bdindicadoresporlineaSLP.CHICLOSO.Week.Substring(6, 2));
                bdindicadoresporlineaSLP.CHICLOSO.Id = bdindicadoresporlineaSLP.CAJETAPET.Id + 1;
                _context.Add(bdindicadoresporlineaSLP.CHICLOSO);
                bdindicadoresporlineaSLP.GOMAS.Week = oTrdate.Week;
                bdindicadoresporlineaSLP.GOMAS.Línea = "GOMAS";
                bdindicadoresporlineaSLP.GOMAS.Region = "San Luis Potosi";
                bdindicadoresporlineaSLP.GOMAS.IdSem = Int32.Parse(bdindicadoresporlineaSLP.GOMAS.Week.Substring(6, 2));
                bdindicadoresporlineaSLP.GOMAS.Id = bdindicadoresporlineaSLP.CHICLOSO.Id + 1;
                _context.Add(bdindicadoresporlineaSLP.GOMAS);
                bdindicadoresporlineaSLP.PALETAPAYASO.Week = oTrdate.Week;
                bdindicadoresporlineaSLP.PALETAPAYASO.Línea = "PALETAPAYASO";
                bdindicadoresporlineaSLP.PALETAPAYASO.Region = "San Luis Potosi";
                bdindicadoresporlineaSLP.PALETAPAYASO.IdSem = Int32.Parse(bdindicadoresporlineaSLP.PALETAPAYASO.Week.Substring(6, 2));
                bdindicadoresporlineaSLP.PALETAPAYASO.Id = bdindicadoresporlineaSLP.GOMAS.Id + 1;
                _context.Add(bdindicadoresporlineaSLP.PALETAPAYASO);
                bdindicadoresporlineaSLP.PALETONCOR.Week = oTrdate.Week;
                bdindicadoresporlineaSLP.PALETONCOR.Línea = "PALETONCO";
                bdindicadoresporlineaSLP.PALETONCOR.Region = "San Luis Potosi";
                bdindicadoresporlineaSLP.PALETONCOR.IdSem = Int32.Parse(bdindicadoresporlineaSLP.PALETONCOR.Week.Substring(6, 2));
                bdindicadoresporlineaSLP.PALETONCOR.Id = bdindicadoresporlineaSLP.PALETAPAYASO.Id + 1;
                _context.Add(bdindicadoresporlineaSLP.PALETONCOR);
                bdindicadoresporlineaSLP.PECOSITA.Week = oTrdate.Week;
                bdindicadoresporlineaSLP.PECOSITA.Línea = "PECOSITA";
                bdindicadoresporlineaSLP.PECOSITA.Region = "San Luis Potosi";
                bdindicadoresporlineaSLP.PECOSITA.IdSem = Int32.Parse(bdindicadoresporlineaSLP.PECOSITA.Week.Substring(6, 2));
                bdindicadoresporlineaSLP.PECOSITA.Id = bdindicadoresporlineaSLP.PALETONCOR.Id + 1;
                _context.Add(bdindicadoresporlineaSLP.PECOSITA);
                //<------CAPACIDAD UTILIZADA POR LINEA--->
                bdindicadoresporlineaSLP.CBOSSAR.Week = oTrdate.Week;
                bdindicadoresporlineaSLP.CBOSSAR.Línea = "BOSSAR";
                bdindicadoresporlineaSLP.CBOSSAR.Region = "San Luis Potosi";
                bdindicadoresporlineaSLP.CBOSSAR.IdSem = Int32.Parse(bdindicadoresporlineaSLP.CBOSSAR.Week.Substring(6, 2));
                _context.Add(bdindicadoresporlineaSLP.CBOSSAR);
                bdindicadoresporlineaSLP.CBSCHOCOLATE.Week = oTrdate.Week;
                bdindicadoresporlineaSLP.CBSCHOCOLATE.Línea = "BSCHOCOLATE";
                bdindicadoresporlineaSLP.CBSCHOCOLATE.Region = "San Luis Potosi";
                bdindicadoresporlineaSLP.CBSCHOCOLATE.IdSem = Int32.Parse(bdindicadoresporlineaSLP.CBSCHOCOLATE.Week.Substring(6, 2));
                bdindicadoresporlineaSLP.CBSCHOCOLATE.Id = bdindicadoresporlineaSLP.CBOSSAR.Id + 1;
                _context.Add(bdindicadoresporlineaSLP.CBSCHOCOLATE);
                bdindicadoresporlineaSLP.CBSCONFITADO.Week = oTrdate.Week;
                bdindicadoresporlineaSLP.CBSCONFITADO.Línea = "BSCONFITADO";
                bdindicadoresporlineaSLP.CBSCONFITADO.Region = "San Luis Potosi";
                bdindicadoresporlineaSLP.CBSCONFITADO.IdSem = Int32.Parse(bdindicadoresporlineaSLP.CBSCONFITADO.Week.Substring(6, 2));
                bdindicadoresporlineaSLP.CBSCONFITADO.Id = bdindicadoresporlineaSLP.CBSCHOCOLATE.Id + 1;
                _context.Add(bdindicadoresporlineaSLP.CBSCONFITADO);
                bdindicadoresporlineaSLP.CBUBULUBU.Week = oTrdate.Week;
                bdindicadoresporlineaSLP.CBUBULUBU.Línea = "BUBULUBU";
                bdindicadoresporlineaSLP.CBUBULUBU.Region = "San Luis Potosi";
                bdindicadoresporlineaSLP.CBUBULUBU.IdSem = Int32.Parse(bdindicadoresporlineaSLP.CBUBULUBU.Week.Substring(6, 2));
                bdindicadoresporlineaSLP.CBUBULUBU.Id = bdindicadoresporlineaSLP.CBSCONFITADO.Id + 1;
                _context.Add(bdindicadoresporlineaSLP.CBUBULUBU);
                bdindicadoresporlineaSLP.CCAJETAGRANEL.Week = oTrdate.Week;
                bdindicadoresporlineaSLP.CCAJETAGRANEL.Línea = "CAJETAGRANE";
                bdindicadoresporlineaSLP.CCAJETAGRANEL.Region = "San Luis Potosi";
                bdindicadoresporlineaSLP.CCAJETAGRANEL.IdSem = Int32.Parse(bdindicadoresporlineaSLP.CCAJETAGRANEL.Week.Substring(6, 2));
                bdindicadoresporlineaSLP.CCAJETAGRANEL.Id = bdindicadoresporlineaSLP.CBUBULUBU.Id + 1;
                _context.Add(bdindicadoresporlineaSLP.CCAJETAGRANEL);
                bdindicadoresporlineaSLP.CCAJETAPET.Week = oTrdate.Week;
                bdindicadoresporlineaSLP.CCAJETAPET.Línea = "CAJETAPET";
                bdindicadoresporlineaSLP.CCAJETAPET.Region = "San Luis Potosi";
                bdindicadoresporlineaSLP.CCAJETAPET.IdSem = Int32.Parse(bdindicadoresporlineaSLP.CCAJETAPET.Week.Substring(6, 2));
                bdindicadoresporlineaSLP.CCAJETAPET.Id = bdindicadoresporlineaSLP.CCAJETAGRANEL.Id + 1;
                _context.Add(bdindicadoresporlineaSLP.CAJETAPET);
                bdindicadoresporlineaSLP.CCHICLOSO.Week = oTrdate.Week;
                bdindicadoresporlineaSLP.CCHICLOSO.Línea = "CHICLOSO";
                bdindicadoresporlineaSLP.CCHICLOSO.Region = "San Luis Potosi";
                bdindicadoresporlineaSLP.CCHICLOSO.IdSem = Int32.Parse(bdindicadoresporlineaSLP.CCHICLOSO.Week.Substring(6, 2));
                bdindicadoresporlineaSLP.CCHICLOSO.Id = bdindicadoresporlineaSLP.CCAJETAPET.Id + 1;
                _context.Add(bdindicadoresporlineaSLP.CCHICLOSO);
                bdindicadoresporlineaSLP.CGOMAS.Week = oTrdate.Week;
                bdindicadoresporlineaSLP.CGOMAS.Línea = "GOMAS";
                bdindicadoresporlineaSLP.CGOMAS.Region = "San Luis Potosi";
                bdindicadoresporlineaSLP.CGOMAS.IdSem = Int32.Parse(bdindicadoresporlineaSLP.CGOMAS.Week.Substring(6, 2));
                bdindicadoresporlineaSLP.CGOMAS.Id = bdindicadoresporlineaSLP.CCHICLOSO.Id + 1;
                _context.Add(bdindicadoresporlineaSLP.CGOMAS);
                bdindicadoresporlineaSLP.CPALETAPAYASO.Week = oTrdate.Week;
                bdindicadoresporlineaSLP.CPALETAPAYASO.Línea = "PALETAPAYASO";
                bdindicadoresporlineaSLP.CPALETAPAYASO.Region = "San Luis Potosi";
                bdindicadoresporlineaSLP.CPALETAPAYASO.IdSem = Int32.Parse(bdindicadoresporlineaSLP.CPALETAPAYASO.Week.Substring(6, 2));
                bdindicadoresporlineaSLP.CPALETAPAYASO.Id = bdindicadoresporlineaSLP.CGOMAS.Id + 1;
                _context.Add(bdindicadoresporlineaSLP.CPALETAPAYASO);
                bdindicadoresporlineaSLP.CPALETONCOR.Week = oTrdate.Week;
                bdindicadoresporlineaSLP.CPALETONCOR.Línea = "PALETONCOR";
                bdindicadoresporlineaSLP.CPALETONCOR.Region = "San Luis Potosi";
                bdindicadoresporlineaSLP.CPALETONCOR.IdSem = Int32.Parse(bdindicadoresporlineaSLP.CPALETONCOR.Week.Substring(6, 2));
                bdindicadoresporlineaSLP.CPALETONCOR.Id = bdindicadoresporlineaSLP.CPALETAPAYASO.Id + 1;
                _context.Add(bdindicadoresporlineaSLP.CPALETONCOR);
                bdindicadoresporlineaSLP.CPECOSITA.Week = oTrdate.Week;
                bdindicadoresporlineaSLP.CPECOSITA.Línea = "PECOSITA";
                bdindicadoresporlineaSLP.CPECOSITA.Region = "San Luis Potosi";
                bdindicadoresporlineaSLP.CPECOSITA.IdSem = Int32.Parse(bdindicadoresporlineaSLP.CPECOSITA.Week.Substring(6, 2));
                bdindicadoresporlineaSLP.CPECOSITA.Id = bdindicadoresporlineaSLP.CPALETONCOR.Id + 1;
                _context.Add(bdindicadoresporlineaSLP.CPECOSITA);
                //<------CAPACIDAD UTILIZADA POR LINEA--->
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(bdindicadoresporlineaSLP);
        }
        [Authorize(Roles = "1,2,3")]
        public IActionResult ULlenadoIndicadoresProdMTH()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "1,2,3")]
        public async Task<IActionResult> ULlenadoIndicadoresProdMTH([Bind(
            "MACARRON,OBLEAKAULITZ1,OBLEAKAULITZ3,PALETA" +
            ",CMACARRON,COBLEAKAULITZ1,COBLEAKAULITZ3,CPALETA"
            )] BdIndicadoresPorLineaMTH bdindicadoresporlineaMTH)
        {
            if (ModelState.IsValid)
            {
                var ofecha = System.DateTime.Now.ToString("dd/MM/yyyy");
                TrDates oTrdate = _context.TrDates.Where(x => x.Fecha == ofecha).Single();
                bdindicadoresporlineaMTH.MACARRON.Week = oTrdate.Week;
                bdindicadoresporlineaMTH.MACARRON.Línea = "MACARRON";
                bdindicadoresporlineaMTH.MACARRON.Region = "Matehuala";
                bdindicadoresporlineaMTH.MACARRON.IdSem = Int32.Parse(bdindicadoresporlineaMTH.MACARRON.Week.Substring(6, 2));
                _context.Add(bdindicadoresporlineaMTH.MACARRON);
                bdindicadoresporlineaMTH.OBLEAKAULITZ1.Week = oTrdate.Week;
                bdindicadoresporlineaMTH.OBLEAKAULITZ1.Línea = "OBLEA KAULITZ 1";
                bdindicadoresporlineaMTH.OBLEAKAULITZ1.Region = "Matehuala";
                bdindicadoresporlineaMTH.OBLEAKAULITZ1.IdSem = Int32.Parse(bdindicadoresporlineaMTH.OBLEAKAULITZ1.Week.Substring(6, 2));
                bdindicadoresporlineaMTH.OBLEAKAULITZ1.Id = bdindicadoresporlineaMTH.MACARRON.Id + 1;
                _context.Add(bdindicadoresporlineaMTH.OBLEAKAULITZ1);
                bdindicadoresporlineaMTH.OBLEAKAULITZ3.Week = oTrdate.Week;
                bdindicadoresporlineaMTH.OBLEAKAULITZ3.Línea = "OBLEA KAULITZ 3";
                bdindicadoresporlineaMTH.OBLEAKAULITZ3.Region = "Matehuala";
                bdindicadoresporlineaMTH.OBLEAKAULITZ3.IdSem = Int32.Parse(bdindicadoresporlineaMTH.OBLEAKAULITZ3.Week.Substring(6, 2));
                bdindicadoresporlineaMTH.OBLEAKAULITZ3.Id = bdindicadoresporlineaMTH.OBLEAKAULITZ1.Id + 1;
                _context.Add(bdindicadoresporlineaMTH.OBLEAKAULITZ3);
                bdindicadoresporlineaMTH.PALETA.Week = oTrdate.Week;
                bdindicadoresporlineaMTH.PALETA.Línea = "PALETA";
                bdindicadoresporlineaMTH.PALETA.Region = "Matehuala";
                bdindicadoresporlineaMTH.PALETA.IdSem = Int32.Parse(bdindicadoresporlineaMTH.PALETA.Week.Substring(6, 2));
                bdindicadoresporlineaMTH.PALETA.Id = bdindicadoresporlineaMTH.OBLEAKAULITZ3.Id + 1;
                _context.Add(bdindicadoresporlineaMTH.PALETA);

                //<------CAPACIDAD UTILIZADA POR LINEA--->
                bdindicadoresporlineaMTH.CMACARRON.Week = oTrdate.Week;
                bdindicadoresporlineaMTH.CMACARRON.Línea = "MACARRON";
                bdindicadoresporlineaMTH.CMACARRON.Region = "Matehuala";
                bdindicadoresporlineaMTH.CMACARRON.IdSem = Int32.Parse(bdindicadoresporlineaMTH.CMACARRON.Week.Substring(6, 2));
                _context.Add(bdindicadoresporlineaMTH.CMACARRON);
                bdindicadoresporlineaMTH.COBLEAKAULITZ1.Week = oTrdate.Week;
                bdindicadoresporlineaMTH.COBLEAKAULITZ1.Línea = "OBLEA KAULITZ 1";
                bdindicadoresporlineaMTH.COBLEAKAULITZ1.Region = "Matehuala";
                bdindicadoresporlineaMTH.COBLEAKAULITZ1.IdSem = Int32.Parse(bdindicadoresporlineaMTH.COBLEAKAULITZ1.Week.Substring(6, 2));
                bdindicadoresporlineaMTH.COBLEAKAULITZ1.Id = bdindicadoresporlineaMTH.CMACARRON.Id + 1;
                _context.Add(bdindicadoresporlineaMTH.COBLEAKAULITZ1);
                bdindicadoresporlineaMTH.COBLEAKAULITZ3.Week = oTrdate.Week;
                bdindicadoresporlineaMTH.COBLEAKAULITZ3.Línea = "OBLEA KAULITZ 3";
                bdindicadoresporlineaMTH.COBLEAKAULITZ3.Region = "Matehuala";
                bdindicadoresporlineaMTH.COBLEAKAULITZ3.IdSem = Int32.Parse(bdindicadoresporlineaMTH.COBLEAKAULITZ3.Week.Substring(6, 2));
                bdindicadoresporlineaMTH.COBLEAKAULITZ3.Id = bdindicadoresporlineaMTH.COBLEAKAULITZ1.Id + 1;
                _context.Add(bdindicadoresporlineaMTH.COBLEAKAULITZ3);
                bdindicadoresporlineaMTH.CPALETA.Week = oTrdate.Week;
                bdindicadoresporlineaMTH.CPALETA.Línea = "PALETA";
                bdindicadoresporlineaMTH.CPALETA.Region = "Matehuala";
                bdindicadoresporlineaMTH.CPALETA.IdSem = Int32.Parse(bdindicadoresporlineaMTH.CPALETA.Week.Substring(6, 2));
                bdindicadoresporlineaMTH.CPALETA.Id = bdindicadoresporlineaMTH.COBLEAKAULITZ3.Id + 1;
                _context.Add(bdindicadoresporlineaMTH.CPALETA);
                //<------CAPACIDAD UTILIZADA POR LINEA--->
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(bdindicadoresporlineaMTH);
        }
        [Authorize(Roles = "1,2,3")]
        public IActionResult ULlenadoIndicadoresProdDV()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ULlenadoIndicadoresProdDV([Bind(
            "COMBO,CUPIDO,DEDO22,ELOTE,EUROMECC1,GOMAS,MALVAVISCO,MANGO,RELLERINDO,RISANDIA" +
            ",SANDIBROCHA,TAKIS,TARRITO,MANITAC3,MANI,BROCHA" +
            ",CCOMBO,CCUPIDO,CDEDO22,CELOTE,CEUROMECC1,CGOMAS,CMALVAVISCO,CMANGO,CRELLERINDO,CRISANDIA" +
            ",CSANDIBROCHA,CTAKIS,CTARRITO,CMANITAC3,CMANI,CBROCHA"
            )] BdIndicadoresPorLineaDV bdindicadoresporlineaDV)
        {
            if (ModelState.IsValid)
            {
                var ofecha = System.DateTime.Now.ToString("dd/MM/yyyy");
                TrDates oTrdate = _context.TrDates.Where(x => x.Fecha == ofecha).Single();
                bdindicadoresporlineaDV.COMBO.Week = oTrdate.Week;
                bdindicadoresporlineaDV.COMBO.Línea = "COMBO";
                bdindicadoresporlineaDV.COMBO.Region = "Jalisco";
                bdindicadoresporlineaDV.COMBO.IdSem = Int32.Parse(bdindicadoresporlineaDV.COMBO.Week.Substring(6, 2));
                _context.Add(bdindicadoresporlineaDV.COMBO);
                bdindicadoresporlineaDV.CUPIDO.Week = oTrdate.Week;
                bdindicadoresporlineaDV.CUPIDO.Línea = "CUPIDO";
                bdindicadoresporlineaDV.CUPIDO.Region = "Jalisco";
                bdindicadoresporlineaDV.CUPIDO.IdSem = Int32.Parse(bdindicadoresporlineaDV.CUPIDO.Week.Substring(6, 2));
                bdindicadoresporlineaDV.CUPIDO.Id = bdindicadoresporlineaDV.COMBO.Id + 1;
                _context.Add(bdindicadoresporlineaDV.CUPIDO);
                bdindicadoresporlineaDV.DEDO22.Week = oTrdate.Week;
                bdindicadoresporlineaDV.DEDO22.Línea = "DEDO 22";
                bdindicadoresporlineaDV.DEDO22.Region = "Jalisco";
                bdindicadoresporlineaDV.DEDO22.IdSem = Int32.Parse(bdindicadoresporlineaDV.DEDO22.Week.Substring(6, 2));
                bdindicadoresporlineaDV.DEDO22.Id = bdindicadoresporlineaDV.CUPIDO.Id + 1;
                _context.Add(bdindicadoresporlineaDV.DEDO22);
                bdindicadoresporlineaDV.ELOTE.Week = oTrdate.Week;
                bdindicadoresporlineaDV.ELOTE.Línea = "ELOTE";
                bdindicadoresporlineaDV.ELOTE.Region = "Jalisco";
                bdindicadoresporlineaDV.ELOTE.IdSem = Int32.Parse(bdindicadoresporlineaDV.ELOTE.Week.Substring(6, 2));
                bdindicadoresporlineaDV.ELOTE.Id = bdindicadoresporlineaDV.DEDO22.Id + 1;
                _context.Add(bdindicadoresporlineaDV.ELOTE);
                bdindicadoresporlineaDV.EUROMECC1.Week = oTrdate.Week;
                bdindicadoresporlineaDV.EUROMECC1.Línea = "EUROMEC C1";
                bdindicadoresporlineaDV.EUROMECC1.Region = "Jalisco";
                bdindicadoresporlineaDV.EUROMECC1.IdSem = Int32.Parse(bdindicadoresporlineaDV.EUROMECC1.Week.Substring(6, 2));
                bdindicadoresporlineaDV.EUROMECC1.Id = bdindicadoresporlineaDV.ELOTE.Id + 1;
                _context.Add(bdindicadoresporlineaDV.EUROMECC1);
                bdindicadoresporlineaDV.GOMAS.Week = oTrdate.Week;
                bdindicadoresporlineaDV.GOMAS.Línea = "GOMAS";
                bdindicadoresporlineaDV.GOMAS.Region = "Jalisco";
                bdindicadoresporlineaDV.GOMAS.IdSem = Int32.Parse(bdindicadoresporlineaDV.GOMAS.Week.Substring(6, 2));
                bdindicadoresporlineaDV.GOMAS.Id = bdindicadoresporlineaDV.EUROMECC1.Id + 1;
                _context.Add(bdindicadoresporlineaDV.GOMAS);
                bdindicadoresporlineaDV.MALVAVISCO.Week = oTrdate.Week;
                bdindicadoresporlineaDV.MALVAVISCO.Línea = "MALVAVISCO";
                bdindicadoresporlineaDV.MALVAVISCO.Region = "Jalisco";
                bdindicadoresporlineaDV.MALVAVISCO.IdSem = Int32.Parse(bdindicadoresporlineaDV.MALVAVISCO.Week.Substring(6, 2));
                bdindicadoresporlineaDV.MALVAVISCO.Id = bdindicadoresporlineaDV.GOMAS.Id + 1;
                _context.Add(bdindicadoresporlineaDV.ELOTE);
                bdindicadoresporlineaDV.MANGO.Week = oTrdate.Week;
                bdindicadoresporlineaDV.MANGO.Línea = "MANGO";
                bdindicadoresporlineaDV.MANGO.Region = "Jalisco";
                bdindicadoresporlineaDV.MANGO.IdSem = Int32.Parse(bdindicadoresporlineaDV.MANGO.Week.Substring(6, 2));
                bdindicadoresporlineaDV.MANGO.Id = bdindicadoresporlineaDV.MALVAVISCO.Id + 1;
                _context.Add(bdindicadoresporlineaDV.MANGO);
                bdindicadoresporlineaDV.RELLERINDO.Week = oTrdate.Week;
                bdindicadoresporlineaDV.RELLERINDO.Línea = "RELLERINDO";
                bdindicadoresporlineaDV.RELLERINDO.Region = "Jalisco";
                bdindicadoresporlineaDV.RELLERINDO.IdSem = Int32.Parse(bdindicadoresporlineaDV.RELLERINDO.Week.Substring(6, 2));
                bdindicadoresporlineaDV.RELLERINDO.Id = bdindicadoresporlineaDV.MANGO.Id + 1;
                _context.Add(bdindicadoresporlineaDV.RELLERINDO);
                bdindicadoresporlineaDV.RISANDIA.Week = oTrdate.Week;
                bdindicadoresporlineaDV.RISANDIA.Línea = "RISANDÍA";
                bdindicadoresporlineaDV.RISANDIA.Region = "Jalisco";
                bdindicadoresporlineaDV.RISANDIA.IdSem = Int32.Parse(bdindicadoresporlineaDV.RISANDIA.Week.Substring(6, 2));
                bdindicadoresporlineaDV.RISANDIA.Id = bdindicadoresporlineaDV.RELLERINDO.Id + 1;
                _context.Add(bdindicadoresporlineaDV.RISANDIA);
                bdindicadoresporlineaDV.SANDIBROCHA.Week = oTrdate.Week;
                bdindicadoresporlineaDV.SANDIBROCHA.Línea = "SANDIBROCHA";
                bdindicadoresporlineaDV.SANDIBROCHA.Region = "Jalisco";
                bdindicadoresporlineaDV.SANDIBROCHA.IdSem = Int32.Parse(bdindicadoresporlineaDV.SANDIBROCHA.Week.Substring(6, 2));
                bdindicadoresporlineaDV.SANDIBROCHA.Id = bdindicadoresporlineaDV.RISANDIA.Id + 1;
                _context.Add(bdindicadoresporlineaDV.SANDIBROCHA);
                bdindicadoresporlineaDV.TAKIS.Week = oTrdate.Week;
                bdindicadoresporlineaDV.TAKIS.Línea = "TAKIS";
                bdindicadoresporlineaDV.TAKIS.Region = "Jalisco";
                bdindicadoresporlineaDV.TAKIS.IdSem = Int32.Parse(bdindicadoresporlineaDV.TAKIS.Week.Substring(6, 2));
                bdindicadoresporlineaDV.TAKIS.Id = bdindicadoresporlineaDV.SANDIBROCHA.Id + 1;
                _context.Add(bdindicadoresporlineaDV.TAKIS);
                bdindicadoresporlineaDV.TARRITO.Week = oTrdate.Week;
                bdindicadoresporlineaDV.TARRITO.Línea = "TARRITO";
                bdindicadoresporlineaDV.TARRITO.Region = "Jalisco";
                bdindicadoresporlineaDV.TARRITO.IdSem = Int32.Parse(bdindicadoresporlineaDV.TARRITO.Week.Substring(6, 2));
                bdindicadoresporlineaDV.TARRITO.Id = bdindicadoresporlineaDV.TAKIS.Id + 1;
                _context.Add(bdindicadoresporlineaDV.TARRITO);
                bdindicadoresporlineaDV.MANITAC3.Week = oTrdate.Week;
                bdindicadoresporlineaDV.MANITAC3.Línea = "MANITA C3";
                bdindicadoresporlineaDV.MANITAC3.Region = "Jalisco";
                bdindicadoresporlineaDV.MANITAC3.IdSem = Int32.Parse(bdindicadoresporlineaDV.MANITAC3.Week.Substring(6, 2));
                bdindicadoresporlineaDV.MANITAC3.Id = bdindicadoresporlineaDV.TARRITO.Id + 1;
                _context.Add(bdindicadoresporlineaDV.MANITAC3);
                bdindicadoresporlineaDV.MANI.Week = oTrdate.Week;
                bdindicadoresporlineaDV.MANI.Línea = "MANI";
                bdindicadoresporlineaDV.MANI.Region = "Jalisco";
                bdindicadoresporlineaDV.MANI.IdSem = Int32.Parse(bdindicadoresporlineaDV.MANI.Week.Substring(6, 2));
                bdindicadoresporlineaDV.MANI.Id = bdindicadoresporlineaDV.MANITAC3.Id + 1;
                _context.Add(bdindicadoresporlineaDV.MANI);
                bdindicadoresporlineaDV.BROCHA.Week = oTrdate.Week;
                bdindicadoresporlineaDV.BROCHA.Línea = "BROCHA";
                bdindicadoresporlineaDV.BROCHA.Region = "Jalisco";
                bdindicadoresporlineaDV.BROCHA.IdSem = Int32.Parse(bdindicadoresporlineaDV.BROCHA.Week.Substring(6, 2));
                bdindicadoresporlineaDV.BROCHA.Id = bdindicadoresporlineaDV.MANI.Id + 1;
                _context.Add(bdindicadoresporlineaDV.BROCHA);

                //<------CAPACIDAD UTILIZADA POR LINEA--->
                bdindicadoresporlineaDV.CCOMBO.Week = oTrdate.Week;
                bdindicadoresporlineaDV.CCOMBO.Línea = "COMBO";
                bdindicadoresporlineaDV.CCOMBO.Region = "Jalisco";
                bdindicadoresporlineaDV.CCOMBO.IdSem = Int32.Parse(bdindicadoresporlineaDV.CCOMBO.Week.Substring(6, 2));
                _context.Add(bdindicadoresporlineaDV.CCOMBO);
                bdindicadoresporlineaDV.CCUPIDO.Week = oTrdate.Week;
                bdindicadoresporlineaDV.CCUPIDO.Línea = "CUPIDO";
                bdindicadoresporlineaDV.CCUPIDO.Region = "Jalisco";
                bdindicadoresporlineaDV.CCUPIDO.IdSem = Int32.Parse(bdindicadoresporlineaDV.CCUPIDO.Week.Substring(6, 2));
                bdindicadoresporlineaDV.CCUPIDO.Id = bdindicadoresporlineaDV.CCOMBO.Id + 1;
                _context.Add(bdindicadoresporlineaDV.CCUPIDO);
                bdindicadoresporlineaDV.CDEDO22.Week = oTrdate.Week;
                bdindicadoresporlineaDV.CDEDO22.Línea = "DEDO 22";
                bdindicadoresporlineaDV.CDEDO22.Region = "Jalisco";
                bdindicadoresporlineaDV.CDEDO22.IdSem = Int32.Parse(bdindicadoresporlineaDV.CDEDO22.Week.Substring(6, 2));
                bdindicadoresporlineaDV.CDEDO22.Id = bdindicadoresporlineaDV.CCUPIDO.Id + 1;
                _context.Add(bdindicadoresporlineaDV.CDEDO22);
                bdindicadoresporlineaDV.CELOTE.Week = oTrdate.Week;
                bdindicadoresporlineaDV.CELOTE.Línea = "ELOTE";
                bdindicadoresporlineaDV.CELOTE.Region = "Jalisco";
                bdindicadoresporlineaDV.CELOTE.IdSem = Int32.Parse(bdindicadoresporlineaDV.CELOTE.Week.Substring(6, 2));
                bdindicadoresporlineaDV.CELOTE.Id = bdindicadoresporlineaDV.CDEDO22.Id + 1;
                _context.Add(bdindicadoresporlineaDV.CELOTE);
                bdindicadoresporlineaDV.CEUROMECC1.Week = oTrdate.Week;
                bdindicadoresporlineaDV.CEUROMECC1.Línea = "EUROMEC C1";
                bdindicadoresporlineaDV.CEUROMECC1.Region = "Jalisco";
                bdindicadoresporlineaDV.CEUROMECC1.IdSem = Int32.Parse(bdindicadoresporlineaDV.CEUROMECC1.Week.Substring(6, 2));
                bdindicadoresporlineaDV.CEUROMECC1.Id = bdindicadoresporlineaDV.CELOTE.Id + 1;
                _context.Add(bdindicadoresporlineaDV.CEUROMECC1);
                bdindicadoresporlineaDV.CGOMAS.Week = oTrdate.Week;
                bdindicadoresporlineaDV.CGOMAS.Línea = "GOMAS";
                bdindicadoresporlineaDV.CGOMAS.Region = "Jalisco";
                bdindicadoresporlineaDV.CGOMAS.IdSem = Int32.Parse(bdindicadoresporlineaDV.CGOMAS.Week.Substring(6, 2));
                bdindicadoresporlineaDV.CGOMAS.Id = bdindicadoresporlineaDV.CEUROMECC1.Id + 1;
                _context.Add(bdindicadoresporlineaDV.CGOMAS);
                bdindicadoresporlineaDV.CMALVAVISCO.Week = oTrdate.Week;
                bdindicadoresporlineaDV.CMALVAVISCO.Línea = "MALVAVISCO";
                bdindicadoresporlineaDV.CMALVAVISCO.Region = "Jalisco";
                bdindicadoresporlineaDV.CMALVAVISCO.IdSem = Int32.Parse(bdindicadoresporlineaDV.CMALVAVISCO.Week.Substring(6, 2));
                bdindicadoresporlineaDV.CMALVAVISCO.Id = bdindicadoresporlineaDV.CGOMAS.Id + 1;
                _context.Add(bdindicadoresporlineaDV.CELOTE);
                bdindicadoresporlineaDV.CMANGO.Week = oTrdate.Week;
                bdindicadoresporlineaDV.CMANGO.Línea = "MANGO";
                bdindicadoresporlineaDV.CMANGO.Region = "Jalisco";
                bdindicadoresporlineaDV.CMANGO.IdSem = Int32.Parse(bdindicadoresporlineaDV.CMANGO.Week.Substring(6, 2));
                bdindicadoresporlineaDV.CMANGO.Id = bdindicadoresporlineaDV.CMALVAVISCO.Id + 1;
                _context.Add(bdindicadoresporlineaDV.MANGO);
                bdindicadoresporlineaDV.CRELLERINDO.Week = oTrdate.Week;
                bdindicadoresporlineaDV.CRELLERINDO.Línea = "RELLERINDO";
                bdindicadoresporlineaDV.CRELLERINDO.Region = "Jalisco";
                bdindicadoresporlineaDV.CRELLERINDO.IdSem = Int32.Parse(bdindicadoresporlineaDV.CRELLERINDO.Week.Substring(6, 2));
                bdindicadoresporlineaDV.CRELLERINDO.Id = bdindicadoresporlineaDV.CMANGO.Id + 1;
                _context.Add(bdindicadoresporlineaDV.CRELLERINDO);
                bdindicadoresporlineaDV.CRISANDIA.Week = oTrdate.Week;
                bdindicadoresporlineaDV.CRISANDIA.Línea = "RISANDÍA";
                bdindicadoresporlineaDV.CRISANDIA.Region = "Jalisco";
                bdindicadoresporlineaDV.CRISANDIA.IdSem = Int32.Parse(bdindicadoresporlineaDV.CRISANDIA.Week.Substring(6, 2));
                bdindicadoresporlineaDV.CRISANDIA.Id = bdindicadoresporlineaDV.CRELLERINDO.Id + 1;
                _context.Add(bdindicadoresporlineaDV.CRISANDIA);
                bdindicadoresporlineaDV.CSANDIBROCHA.Week = oTrdate.Week;
                bdindicadoresporlineaDV.CSANDIBROCHA.Línea = "SANDIBROCHA";
                bdindicadoresporlineaDV.CSANDIBROCHA.Region = "Jalisco";
                bdindicadoresporlineaDV.CSANDIBROCHA.IdSem = Int32.Parse(bdindicadoresporlineaDV.CSANDIBROCHA.Week.Substring(6, 2));
                bdindicadoresporlineaDV.CSANDIBROCHA.Id = bdindicadoresporlineaDV.CRISANDIA.Id + 1;
                _context.Add(bdindicadoresporlineaDV.CSANDIBROCHA);
                bdindicadoresporlineaDV.CTAKIS.Week = oTrdate.Week;
                bdindicadoresporlineaDV.CTAKIS.Línea = "TAKIS";
                bdindicadoresporlineaDV.CTAKIS.Region = "Jalisco";
                bdindicadoresporlineaDV.CTAKIS.IdSem = Int32.Parse(bdindicadoresporlineaDV.CTAKIS.Week.Substring(6, 2));
                bdindicadoresporlineaDV.CTAKIS.Id = bdindicadoresporlineaDV.CSANDIBROCHA.Id + 1;
                _context.Add(bdindicadoresporlineaDV.CTAKIS);
                bdindicadoresporlineaDV.CTARRITO.Week = oTrdate.Week;
                bdindicadoresporlineaDV.CTARRITO.Línea = "TARRITO";
                bdindicadoresporlineaDV.CTARRITO.Region = "Jalisco";
                bdindicadoresporlineaDV.CTARRITO.IdSem = Int32.Parse(bdindicadoresporlineaDV.CTARRITO.Week.Substring(6, 2));
                bdindicadoresporlineaDV.CTARRITO.Id = bdindicadoresporlineaDV.CTAKIS.Id + 1;
                _context.Add(bdindicadoresporlineaDV.CTARRITO);
                bdindicadoresporlineaDV.CMANITAC3.Week = oTrdate.Week;
                bdindicadoresporlineaDV.CMANITAC3.Línea = "MANITA C3";
                bdindicadoresporlineaDV.CMANITAC3.Region = "Jalisco";
                bdindicadoresporlineaDV.CMANITAC3.IdSem = Int32.Parse(bdindicadoresporlineaDV.CMANITAC3.Week.Substring(6, 2));
                bdindicadoresporlineaDV.CMANITAC3.Id = bdindicadoresporlineaDV.CTARRITO.Id + 1;
                _context.Add(bdindicadoresporlineaDV.CMANITAC3);
                bdindicadoresporlineaDV.CMANI.Week = oTrdate.Week;
                bdindicadoresporlineaDV.CMANI.Línea = "MANI";
                bdindicadoresporlineaDV.CMANI.Region = "Jalisco";
                bdindicadoresporlineaDV.CMANI.IdSem = Int32.Parse(bdindicadoresporlineaDV.CMANI.Week.Substring(6, 2));
                bdindicadoresporlineaDV.CMANI.Id = bdindicadoresporlineaDV.CMANITAC3.Id + 1;
                _context.Add(bdindicadoresporlineaDV.CMANI);
                bdindicadoresporlineaDV.CBROCHA.Week = oTrdate.Week;
                bdindicadoresporlineaDV.CBROCHA.Línea = "BROCHA";
                bdindicadoresporlineaDV.CBROCHA.Region = "Jalisco";
                bdindicadoresporlineaDV.CBROCHA.IdSem = Int32.Parse(bdindicadoresporlineaDV.CBROCHA.Week.Substring(6, 2));
                bdindicadoresporlineaDV.CBROCHA.Id = bdindicadoresporlineaDV.CMANI.Id + 1;
                _context.Add(bdindicadoresporlineaDV.CBROCHA);
                //<------CAPACIDAD UTILIZADA POR LINEA--->
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(bdindicadoresporlineaDV);
        }
        [Authorize(Roles = "1,2,3")]
        public IActionResult ULlenadoIndicadoresProd()
        {
            var ofecha = System.DateTime.Now.ToString("dd/MM/yyyy");
            var ofecha2 = System.DateTime.Now.ToString("dd-MM-yyyy");
            TrDates oTrdate = _context.TrDates.Where(x => x.Fecha == ofecha).Single();
            var Ojazn = HttpContext.Session.GetString("usuario");
            var obj = JsonSerializer.Deserialize<Users>(Ojazn);
            var reg = obj.Region;
            ViewData["message"] = $" " + ofecha2 + "       "+ oTrdate.Week.Substring(0,8) +"      " + reg ;
            return View();
        }
        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 409715200)]
        [RequestSizeLimit(409715200)]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "1,2,3")]
        public async Task<IActionResult> ULlenadoIndicadoresProd(IFormFile filevariacion, IFormFile fileeficacias, [Bind("BDAccidente,BDBajasPt,BDBarredura" +
            ",BdCapUtilizada,BDCuadroBásico,BdDesperdiciosEmpaque,BdDesperdiciosTotale,BdEficaci" +
            ",BdPesoProducidoPesoPagado,BdProductividadLaboral,BdToneladasProducida,BdValorDeLaProducción,BdVariaciónDeLaOrden")]
             Mixmodel mixmodel, [FromServices] IHostingEnvironment oHostingEnviroment)
        {
            var ofecha = System.DateTime.Now.ToString("dd/MM/yyyy");
            var ofecha2 = System.DateTime.Now.ToString("dd-MM-yyyy");
            TrDates oTrdate = _context.TrDates.Where(x => x.Fecha == ofecha).Single();
            var Ojazn = HttpContext.Session.GetString("usuario");
            var obj = JsonSerializer.Deserialize<Users>(Ojazn);
            var reg = obj.Region;
            var T = Targets();
            List<Targets> tar = new List<Targets>();
            tar = T
                .Where(t => t.Region == reg)
                .ToList();
            mixmodel.BDAccidente.Week = oTrdate.Week;
            mixmodel.BDAccidente.Indicador = "Accidentes";
            mixmodel.BDAccidente.Target = tar.Where(t => t.Indicador == mixmodel.BDAccidente.Indicador)
                                             .Single()
                                             .Value;
            mixmodel.BDAccidente.IdSem = Int32.Parse(mixmodel.BDAccidente.Week.Substring(6, 2));
            mixmodel.BDAccidente.Region = reg;
            var anyBdAccidentes = _context.BdAccidentes.Where(x => x.Week == oTrdate.Week && x.Region == reg).FirstOrDefault();
            if (anyBdAccidentes != null) {
                ViewData["message"] = $"Ya se han cargado los datos de esta semana";
               return View();
            }
            _context.Add(mixmodel.BDAccidente);
            //<----BajasPt------>
            mixmodel.BDBajasPt.Week = oTrdate.Week;
            mixmodel.BDBajasPt.Indicador = "%Bajas PT";
            mixmodel.BDBajasPt.Target = tar.Where(t => t.Indicador == mixmodel.BDBajasPt.Indicador)
                                           .Single()
                                           .Value;
            mixmodel.BDBajasPt.IdSem = Int32.Parse(mixmodel.BDBajasPt.Week.Substring(6, 2));
            mixmodel.BDBajasPt.Region = mixmodel.BDAccidente.Region;
            _context.Add(mixmodel.BDBajasPt);
            //<----BajasPt------>
            //<----Barredura------>
            mixmodel.BDBarredura.Week = oTrdate.Week;
            mixmodel.BDBarredura.Indicador = "%Barredura";
            mixmodel.BDBarredura.Target = tar.Where(t => t.Indicador == mixmodel.BDBarredura.Indicador)
                                             .Single()
                                             .Value;
            mixmodel.BDBarredura.IdSem = Int32.Parse(mixmodel.BDBarredura.Week.Substring(6, 2));
            mixmodel.BDBarredura.Region = mixmodel.BDAccidente.Region;
            _context.Add(mixmodel.BDBarredura);
            //<----Barredura------>
            //<----CapUtilizada------>
            mixmodel.BdCapUtilizada.Week = oTrdate.Week;
            mixmodel.BdCapUtilizada.Indicador = "%Capacidad Utilizada";
            mixmodel.BdCapUtilizada.Target = tar.Where(t => t.Indicador == "Capacidad Utilizada")
                                                .Single()
                                                .Value;
            mixmodel.BdCapUtilizada.IdSem = Int32.Parse(mixmodel.BdCapUtilizada.Week.Substring(6, 2));
            mixmodel.BdCapUtilizada.Region = mixmodel.BDAccidente.Region;
            _context.Add(mixmodel.BdCapUtilizada);
            //<----CapUtilizada------>
            //<----CuadroBásico------>
            mixmodel.BDCuadroBásico.Week = oTrdate.Week;
            mixmodel.BDCuadroBásico.Indicador = "Cuadro básico";
            mixmodel.BDCuadroBásico.Target = tar.Where(t => t.Indicador == mixmodel.BDCuadroBásico.Indicador)
                                                .Single()
                                                .Value;
            mixmodel.BDCuadroBásico.IdSem = Int32.Parse(mixmodel.BDCuadroBásico.Week.Substring(6, 2));
            mixmodel.BDCuadroBásico.Region = mixmodel.BDAccidente.Region;
            _context.Add(mixmodel.BDCuadroBásico);
            //<----CuadroBásico------>
            //<----DesperdiciosEmpaques------>
            mixmodel.BdDesperdiciosEmpaque.Week = oTrdate.Week;
            mixmodel.BdDesperdiciosEmpaque.Indicador = "Desperdicios Empaque";
            mixmodel.BdDesperdiciosEmpaque.Target = tar.Where(t => t.Indicador == mixmodel.BdDesperdiciosEmpaque.Indicador)
                                                       .Single()
                                                       .Value;
            mixmodel.BdDesperdiciosEmpaque.IdSem = Int32.Parse(mixmodel.BdDesperdiciosEmpaque.Week.Substring(6, 2));
            mixmodel.BdDesperdiciosEmpaque.Region = mixmodel.BDAccidente.Region;
            _context.Add(mixmodel.BdDesperdiciosEmpaque);
            //<----DesperdiciosEmpaques------>
            //<----DesperdiciosTotales------>
            mixmodel.BdDesperdiciosTotale.Week = oTrdate.Week;
            mixmodel.BdDesperdiciosTotale.Indicador = "Desperdicios Totales";
            mixmodel.BdDesperdiciosTotale.Target = tar.Where(t => t.Indicador == mixmodel.BdDesperdiciosTotale.Indicador)
                                                      .Single()
                                                      .Value;
            mixmodel.BdDesperdiciosTotale.IdSem = Int32.Parse(mixmodel.BdDesperdiciosTotale.Week.Substring(6, 2));
            mixmodel.BdDesperdiciosTotale.Region = mixmodel.BDAccidente.Region;
            _context.Add(mixmodel.BdDesperdiciosTotale);
            //<----DesperdiciosTotales------>
            //<----Eficacia------>
            mixmodel.BdEficaci.Week = oTrdate.Week;
            mixmodel.BdEficaci.Indicador = "Eficacia";
            mixmodel.BdEficaci.Target = tar.Where(t => t.Indicador == mixmodel.BdEficaci.Indicador)
                                           .Single()
                                           .Value;
            mixmodel.BdEficaci.IdSem = Int32.Parse(mixmodel.BdEficaci.Week.Substring(6, 2));
            mixmodel.BdEficaci.Region = mixmodel.BDAccidente.Region;
            _context.Add(mixmodel.BdEficaci);
            //<----Eficacia------>
            //<----PesoProducidoPesoPagado------>
            mixmodel.BdPesoProducidoPesoPagado.Week = oTrdate.Week;
            mixmodel.BdPesoProducidoPesoPagado.Indicador = "Peso producido Peso pagado";
            mixmodel.BdPesoProducidoPesoPagado.Target = tar.Where(t => t.Indicador == mixmodel.BdPesoProducidoPesoPagado.Indicador)
                                                           .Single()
                                                           .Value;
            mixmodel.BdPesoProducidoPesoPagado.IdSem = Int32.Parse(mixmodel.BdPesoProducidoPesoPagado.Week.Substring(6, 2));
            mixmodel.BdPesoProducidoPesoPagado.Region = mixmodel.BDAccidente.Region;
            _context.Add(mixmodel.BdPesoProducidoPesoPagado);
            //<----PesoProducidoPesoPagado------>
            //<----ProductividadLaborals------>
            mixmodel.BdProductividadLaboral.Week = oTrdate.Week;
            mixmodel.BdProductividadLaboral.Indicador = "Productividad Laboral";
            mixmodel.BdProductividadLaboral.Target = tar.Where(t => t.Indicador == "Productividad laboral")
                                                        .Single()
                                                        .Value;
            mixmodel.BdProductividadLaboral.IdSem = Int32.Parse(mixmodel.BdProductividadLaboral.Week.Substring(6, 2));
            mixmodel.BdProductividadLaboral.Region = mixmodel.BDAccidente.Region;
            _context.Add(mixmodel.BdProductividadLaboral);
            //<----ProductividadLaborals------>
            //<----Toneladas Producidas------>
            mixmodel.BdToneladasProducida.Week = oTrdate.Week;
            mixmodel.BdToneladasProducida.Indicador = "Toneladas Producidas";
            mixmodel.BdToneladasProducida.Target = tar.Where(t => t.Indicador == mixmodel.BdToneladasProducida.Indicador)
                                                      .Single()
                                                      .Value;
            mixmodel.BdToneladasProducida.IdSem = Int32.Parse(mixmodel.BdToneladasProducida.Week.Substring(6, 2));
            mixmodel.BdToneladasProducida.Region = mixmodel.BDAccidente.Region;
            _context.Add(mixmodel.BdToneladasProducida);
            //<----Toneladas Producidas------>
            //<----VariaciónDeLaOrdens------>
            mixmodel.BdVariaciónDeLaOrden.Week = oTrdate.Week;
            mixmodel.BdVariaciónDeLaOrden.Indicador = "Variación de la orden de la producción";
            mixmodel.BdVariaciónDeLaOrden.Target = 98.20;
                mixmodel.BdVariaciónDeLaOrden.IdSem = Int32.Parse(mixmodel.BdVariaciónDeLaOrden.Week.Substring(6, 2));
                mixmodel.BdVariaciónDeLaOrden.Region = mixmodel.BDAccidente.Region;
                _context.Add(mixmodel.BdVariaciónDeLaOrden);
                //<----VariaciónDeLaOrdens------>
                //<----Valor de la producción------>
                mixmodel.BdValorDeLaProducción.Week = oTrdate.Week;
                mixmodel.BdValorDeLaProducción.Indicador = "Valor de la producción";
                mixmodel.BdValorDeLaProducción.Target = tar.Where(t => t.Indicador == mixmodel.BdValorDeLaProducción.Indicador)
                                                           .Single()
                                                           .Value;
                mixmodel.BdValorDeLaProducción.IdSem = Int32.Parse(mixmodel.BdValorDeLaProducción.Week.Substring(6, 2));
                mixmodel.BdValorDeLaProducción.Region = mixmodel.BDAccidente.Region;
                _context.Add(mixmodel.BdValorDeLaProducción);
                
                //<----Valor de la producción------>
                await _context.SaveChangesAsync();
                var j = 1;
                var r = mixmodel.BdValorDeLaProducción.IdSem;
            if (filevariacion != null || fileeficacias != null)
            {
                if (mixmodel.BDAccidente.Region == "Toluca")
                {
                    string fileName = $"{oHostingEnviroment.WebRootPath}\\ImagProduccion\\Variacion de la orden de produccion por linea\\RT\\{ofecha2}_"
                                      + $"{String.Format("{0:00}", r)}_"
                                      + $"{j++}" + ".jpg";

                    using (FileStream fileStream = System.IO.File.Create(fileName))
                    {
                        filevariacion.CopyTo(fileStream);
                        fileStream.Flush();
                    }
                    string fileName1 = $"{oHostingEnviroment.WebRootPath}\\ImagProduccion\\Eficacias Críticas\\RT\\{ofecha2}_"
                                      + $"{String.Format("{0:00}", r)}_"
                                      + $"{j++}" + ".jpg";
                    using (FileStream fileStream1 = System.IO.File.Create(fileName1))
                    {
                        fileeficacias.CopyTo(fileStream1);
                        fileStream1.Flush();
                    }
                    return RedirectToAction(nameof(ULlenadoIndicadoresProdRT));
                }
                if (mixmodel.BDAccidente.Region == "Jalisco")
                {
                    string fileName = $"{oHostingEnviroment.WebRootPath}\\ImagProduccion\\Variacion de la orden de produccion por linea\\DV\\{ofecha2}_"
                                      + $"{String.Format("{0:00}", r)}_"
                                      + $"{j++}" + ".jpg";

                    using (FileStream fileStream = System.IO.File.Create(fileName))
                    {
                        filevariacion.CopyTo(fileStream);
                        fileStream.Flush();
                    }
                    string fileName1 = $"{oHostingEnviroment.WebRootPath}\\ImagProduccion\\Eficacias Críticas\\DV\\{ofecha2}_"
                                      + $"{String.Format("{0:00}", r)}_"
                                      + $"{j++}" + ".jpg";
                    using (FileStream fileStream1 = System.IO.File.Create(fileName1))
                    {
                        fileeficacias.CopyTo(fileStream1);
                        fileStream1.Flush();
                    }
                    return RedirectToAction(nameof(ULlenadoIndicadoresProdDV));
                }
                if (mixmodel.BDAccidente.Region == "San Luis Potosi")
                {
                    string fileName = $"{oHostingEnviroment.WebRootPath}\\ImagProduccion\\Variacion de la orden de produccion por linea\\RSLP\\{ofecha2}_"
                                      + $"{String.Format("{0:00}", r)}_"
                                      + $"{j++}" + ".jpg";

                    using (FileStream fileStream = System.IO.File.Create(fileName))
                    {
                        filevariacion.CopyTo(fileStream);
                        fileStream.Flush();
                    }
                    string fileName1 = $"{oHostingEnviroment.WebRootPath}\\ImagProduccion\\Eficacias Críticas\\RSLP\\{ofecha2}_"
                                      + $"{String.Format("{0:00}", r)}_"
                                      + $"{j++}" + ".jpg";
                    using (FileStream fileStream1 = System.IO.File.Create(fileName1))
                    {
                        fileeficacias.CopyTo(fileStream1);
                        fileStream1.Flush();
                    }
                    return RedirectToAction(nameof(ULlenadoIndicadoresProdRSLP));
                }
                if (mixmodel.BDAccidente.Region == "Matehuala")
                {
                    string fileName = $"{oHostingEnviroment.WebRootPath}\\ImagProduccion\\Variacion de la orden de produccion por linea\\RMTH\\{ofecha2}_"
                                      + $"{String.Format("{0:00}", r)}_"
                                      + $"{j++}" + ".jpg";

                    using (FileStream fileStream = System.IO.File.Create(fileName))
                    {
                        filevariacion.CopyTo(fileStream);
                        fileStream.Flush();
                    }
                    string fileName1 = $"{oHostingEnviroment.WebRootPath}\\ImagProduccion\\Eficacias Críticas\\RMTH\\{ofecha2}_"
                                      + $"{String.Format("{0:00}", r)}_"
                                      + $"{j++}" + ".jpg";
                    using (FileStream fileStream1 = System.IO.File.Create(fileName1))
                    {
                        fileeficacias.CopyTo(fileStream1);
                        fileStream1.Flush();
                    }
                    return RedirectToAction(nameof(ULlenadoIndicadoresProdMTH));
                }
            }
                return RedirectToAction(nameof(Index));
        }
        [Authorize]
        public IActionResult UPlandeAccion()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> UPlandeAccion([Bind("AccidentesPa" +
            ",Q1,Q2,Q3,Q4,Q5" )]
             MixmodelPA mixmodelPA)
        {
            if (ModelState.IsValid)
            {
                var ofecha = System.DateTime.Now.ToString("dd/MM/yyyy");
                TrDates oTrdate = _context.TrDates.Where(x => x.Fecha == ofecha).Single();

                mixmodelPA.AccidentesPa.WeekPA = oTrdate.Week;
                mixmodelPA.AccidentesPa.Semana = Int32.Parse(oTrdate.Week.Substring(6, 2));
                mixmodelPA.AccidentesPa.Causa = "Q1: "+ mixmodelPA.Q1 + "\n" + 
                                                "Q2: "+ mixmodelPA.Q2 +"\n" +
                                                "Q3: "+ mixmodelPA.Q3 +"\n" +
                                                "Q4: "+ mixmodelPA.Q4 + "\n" +
                                                "Q5: "+ mixmodelPA.Q5 + "\n" ;
                _context.Add(mixmodelPA.AccidentesPa);
                await _context.SaveChangesAsync();
                ViewData["message"] = $"Se ha cargado el Plan de Acción Correctamente";
                return View("UPlandeAccion");

            }
            return View(mixmodelPA);
        }

        [Authorize(Roles = "1,2,6")]
        public IActionResult ULlenadoIndicadoresSeg()
        {
            var ofecha = System.DateTime.Now.ToString("dd/MM/yyyy");
            var ofecha2 = System.DateTime.Now.ToString("dd-MM-yyyy");
            TrDates oTrdate = _context.TrDates.Where(x => x.Fecha == ofecha).Single();
            var Ojazn = HttpContext.Session.GetString("usuario");
            var obj = JsonSerializer.Deserialize<Users>(Ojazn);
            var reg = obj.Region;
            ViewData["message"] = $" " + ofecha2 + "       " + oTrdate.Week.Substring(0, 8) + "      " + reg;
            return View();
        }

        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 409715200)]
        [RequestSizeLimit(409715200)]
        [Authorize(Roles = "1,2,6")]
        public async Task<IActionResult> ULlenadoIndicadoresSeg(IFormFile file, IFormFile file1,
            [FromServices] IHostingEnvironment oHostingEnviroment, BdAccidente bdAccidente
            , BdSupervisionesSanitarias bdSupervisionesSanitarias)
        {
            var Ojazn = HttpContext.Session.GetString("usuario");
            var obj = JsonSerializer.Deserialize<Users>(Ojazn);
            var reg = obj.Region;
            var ofecha = System.DateTime.Now.ToString("dd/MM/yyyy");
            var ofecha2 = System.DateTime.Now.ToString("dd-MM-yyyy");
            TrDates oTrdate = _context.TrDates.Where(x => x.Fecha == ofecha).Single();
            bdSupervisionesSanitarias.Region = reg;
            var k = oTrdate.Week;
            var sem = Int32.Parse(k.Substring(6, 2));
            var j = 1;
            if (bdSupervisionesSanitarias.Region == "N")
            {
                return View(nameof(ULlenadoIndicadoresSeg));
            }
            if (bdSupervisionesSanitarias.Region == "Toluca")
            {
                string fileName = $"{oHostingEnviroment.WebRootPath}\\ImagSega\\Cumplimiento al programa maestro de limpieza\\RT\\{ofecha2}_"
                                      + $"{String.Format("{0:00}", sem)}_"
                                      + $"{j++}" + ".jpg";
                using (FileStream fileStream = System.IO.File.Create(fileName))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                }
                string fileName1 = $"{oHostingEnviroment.WebRootPath}\\ImagSega\\Supervisiones Sistemáticas Sanitarias\\RT\\{ofecha2}_"
                                      + $"{String.Format("{0:00}", sem)}_"
                                      + $"{j++}" + ".jpg";
                using (FileStream fileStream1 = System.IO.File.Create(fileName1))
                {
                    file.CopyTo(fileStream1);
                    fileStream1.Flush();
                }
            }
            if (bdSupervisionesSanitarias.Region == "San Luis Potosi")
            {
                string fileName = $"{oHostingEnviroment.WebRootPath}\\ImagSega\\Cumplimiento al programa maestro de limpieza\\RSLP\\{ofecha2}_"
                                      + $"{String.Format("{0:00}", sem)}_"
                                      + $"{j++}" + ".jpg";

                using (FileStream fileStream = System.IO.File.Create(fileName))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                }
                string fileName1 = $"{oHostingEnviroment.WebRootPath}\\ImagSega\\Supervisiones Sistemáticas Sanitarias\\RSLP\\{ofecha2}_"
                                      + $"{String.Format("{0:00}", sem)}_"
                                      + $"{j++}" + ".jpg";
                using (FileStream fileStream1 = System.IO.File.Create(fileName1))
                {
                    file.CopyTo(fileStream1);
                    fileStream1.Flush();
                }
            }
            if (bdSupervisionesSanitarias.Region == "Jalisco")
            {
                string fileName = $"{oHostingEnviroment.WebRootPath}\\ImagSega\\Cumplimiento al programa maestro de limpieza\\DV\\{ofecha2}_"
                                      + $"{String.Format("{0:00}", sem)}_"
                                      + $"{j++}" + ".jpg";

                using (FileStream fileStream = System.IO.File.Create(fileName))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                }
                string fileName1 = $"{oHostingEnviroment.WebRootPath}\\ImagSega\\Supervisiones Sistemáticas Sanitarias\\DV\\{ofecha2}_"
                                      + $"{String.Format("{0:00}", sem)}_"
                                      + $"{j++}" + ".jpg";
                using (FileStream fileStream1 = System.IO.File.Create(fileName1))
                {
                    file.CopyTo(fileStream1);
                    fileStream1.Flush();
                }
            }
            if (bdSupervisionesSanitarias.Region == "Matehuala")
            {
                string fileName = $"{oHostingEnviroment.WebRootPath}\\ImagSega\\Cumplimiento al programa maestro de limpieza\\RMTH\\{ofecha2}_"
                                      + $"{String.Format("{0:00}", sem)}_"
                                      + $"{j++}" + ".jpg";

                using (FileStream fileStream = System.IO.File.Create(fileName))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                }
                string fileName1 = $"{oHostingEnviroment.WebRootPath}\\ImagSega\\Supervisiones Sistemáticas Sanitarias\\RMTH\\{ofecha2}_"
                                      + $"{String.Format("{0:00}", sem)}_"
                                      + $"{j++}" + ".jpg";
                using (FileStream fileStream1 = System.IO.File.Create(fileName1))
                {
                    file.CopyTo(fileStream1);
                    fileStream1.Flush();
                }
                await _context.SaveChangesAsync();
            }
            ViewData["message"] = $" " + ofecha2 + "       " + oTrdate.Week.Substring(0, 8) + "      " + reg;
            ViewData["message1"] = $"Las imagenes se han cargado con éxito!.";
            return View("ULlenadoIndicadoresSeg");

        }
        [Authorize(Roles = "1,2,5")]
        public IActionResult ULlenadoIndicadoresCal()
        {
            var ofecha = System.DateTime.Now.ToString("dd/MM/yyyy");
            var ofecha2 = System.DateTime.Now.ToString("dd-MM-yyyy");
            TrDates oTrdate = _context.TrDates.Where(x => x.Fecha == ofecha).Single();
            var Ojazn = HttpContext.Session.GetString("usuario");
            var obj = JsonSerializer.Deserialize<Users>(Ojazn);
            var reg = obj.Region;
            ViewData["message"] = $" " + ofecha2 + "       " + oTrdate.Week.Substring(0, 8) + "      " + reg;
            return View();
        }
        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 409715200)]
        [RequestSizeLimit(409715200)]
        [Authorize(Roles = "1,2,5")]
        public async Task<IActionResult> ULlenadoIndicadoresCal(IFormFile fileCalifProd, IFormFile fileCPCPKPeso, IFormFile fileCPCPKProceso, IFormFile fileRechazosPT
            , [Bind("BDQuejasA,BDQuejasB,BDQuejasC,BDQuejasTotale")]
             MixmodelCal mixmodelcal, [FromServices] IHostingEnvironment oHostingEnviroment, BdCPyCPKdeProceso bdcpycpkdeproceso
            , BdCPyCPKdePeso bdcpycpkdepeso, BdCalificaciondeProducto bdcalificaciondeproducto, BdRechazosdePT bdrechazosdept)
        {
            var Ojazn = HttpContext.Session.GetString("usuario");
            var obj = JsonSerializer.Deserialize<Users>(Ojazn);
            var reg = obj.Region;
            var T = Targets();
            List<Targets> tar = new List<Targets>();
            tar = T
                .Where(t => t.Region == reg)
                .ToList();
            var ofecha = System.DateTime.Now.ToString("dd/MM/yyyy");
            var ofecha2 = System.DateTime.Now.ToString("dd-MM-yyyy");
            TrDates oTrdate = _context.TrDates.Where(x => x.Fecha == ofecha).Single();
            var k = oTrdate.Week;
            var sem = Int32.Parse(k.Substring(6, 2));
            var j = 1;

            //<----QuejasA------>
            mixmodelcal.BDQuejasA.Region = reg;
            mixmodelcal.BDQuejasA.Week = oTrdate.Week;
            mixmodelcal.BDQuejasA.Indicador = "Quejas A";
            mixmodelcal.BDQuejasA.Target = tar.Where(t => t.Indicador == "Quejas A")
                                              .Single()
                                              .Value;
            mixmodelcal.BDQuejasA.IdSem = Int32.Parse(mixmodelcal.BDQuejasA.Week.Substring(6, 2));
            var anyBdQuejasA = _context.BdQuejasA.Where(x => x.Week == oTrdate.Week && x.Region == reg).FirstOrDefault();
            if (anyBdQuejasA != null)
            {
                ViewData["message"] = $"Ya se han cargado los datos de esta semana";
                return View();
            }
            _context.Add(mixmodelcal.BDQuejasA);
            //<----QuejasA------>
            //<----QuejasB------>
            mixmodelcal.BDQuejasB.Week = oTrdate.Week;
            mixmodelcal.BDQuejasB.Indicador = "Quejas B";
            mixmodelcal.BDQuejasB.Target = tar.Where(t => t.Indicador == mixmodelcal.BDQuejasA.Indicador)
                                              .Single()
                                              .Value;
            mixmodelcal.BDQuejasB.IdSem = Int32.Parse(mixmodelcal.BDQuejasB.Week.Substring(6, 2));
            mixmodelcal.BDQuejasB.Region = mixmodelcal.BDQuejasA.Region;
            _context.Add(mixmodelcal.BDQuejasB);
            //<----QuejasB------>
            //<----QuejasC------>
            mixmodelcal.BDQuejasC.Week = oTrdate.Week;
            mixmodelcal.BDQuejasC.Indicador = "Quejas C";
            mixmodelcal.BDQuejasC.Target = tar.Where(t => t.Indicador == mixmodelcal.BDQuejasC.Indicador)
                                              .Single()
                                              .Value;
            mixmodelcal.BDQuejasC.IdSem = Int32.Parse(mixmodelcal.BDQuejasC.Week.Substring(6, 2));
            mixmodelcal.BDQuejasC.Region = mixmodelcal.BDQuejasA.Region;
            _context.Add(mixmodelcal.BDQuejasC);
            //<----QuejasC------>
            //<----QuejasTotales------>
            mixmodelcal.BDQuejasTotale.Week = oTrdate.Week;
            mixmodelcal.BDQuejasTotale.Indicador = "Quejas Totales";
            mixmodelcal.BDQuejasTotale.Target = tar.Where(t => t.Indicador == mixmodelcal.BDQuejasC.Indicador)
                                                .Single()
                                                .Value;
            mixmodelcal.BDQuejasTotale.IdSem = Int32.Parse(mixmodelcal.BDQuejasTotale.Week.Substring(6, 2));
            mixmodelcal.BDQuejasTotale.Region = mixmodelcal.BDQuejasA.Region;
            _context.Add(mixmodelcal.BDQuejasTotale);
            await _context.SaveChangesAsync();
            //<----QuejasTotales------>
            if (mixmodelcal.BDQuejasA.Region == "Toluca")
            {
                if (fileCalifProd != null)
                {
                    string fileName = $"{oHostingEnviroment.WebRootPath}\\ImagCalidad\\Calificación de Producto\\RT\\{ofecha2}_"
                                      + $"{String.Format("{0:00}", sem)}_"
                                      + $"{j++}" + ".jpg";
                    using (FileStream fileStream = System.IO.File.Create(fileName))
                    {
                        fileCalifProd.CopyTo(fileStream);
                        fileStream.Flush();
                    }
                }
                if (fileCPCPKPeso != null)
                {
                    string fileName1 = $"{oHostingEnviroment.WebRootPath}\\ImagCalidad\\CP y CPK de Peso\\RT\\{ofecha2}_"
                                          + $"{String.Format("{0:00}", sem)}_"
                                          + $"{j++}" + ".jpg";
                    using (FileStream fileStream1 = System.IO.File.Create(fileName1))
                    {
                        fileCPCPKPeso.CopyTo(fileStream1);
                        fileStream1.Flush();
                    }
                }
                if(fileCPCPKProceso != null) 
                { 
                    string fileName2 = $"{oHostingEnviroment.WebRootPath}\\ImagCalidad\\CP y CPK de Proceso\\RT\\{ofecha2}_"
                          + $"{String.Format("{0:00}", sem)}_"
                          + $"{j++}" + ".jpg";
                    using (FileStream fileStream2 = System.IO.File.Create(fileName2))
                    {
                        fileCPCPKProceso.CopyTo(fileStream2);
                        fileStream2.Flush();
                    }
                }
                if (fileRechazosPT != null)
                {
                    string fileName3 = $"{oHostingEnviroment.WebRootPath}\\ImagCalidad\\Rechazos de PT\\RT\\{ofecha2}_"
                          + $"{String.Format("{0:00}", sem)}_"
                          + $"{j++}" + ".jpg";
                    using (FileStream fileStream3 = System.IO.File.Create(fileName3))
                    {
                        fileRechazosPT.CopyTo(fileStream3);
                        fileStream3.Flush();
                    }
                }
            }
            if (mixmodelcal.BDQuejasA.Region == "San Luis Potosí")
            {
                if (fileCalifProd != null)
                {
                    string fileName = $"{oHostingEnviroment.WebRootPath}\\ImagCalidad\\Calificación de Producto\\RSLP\\{ofecha2}_"
                                      + $"{String.Format("{0:00}", sem)}_"
                                      + $"{j++}" + ".jpg";
                    using (FileStream fileStream = System.IO.File.Create(fileName))
                    {
                        fileCalifProd.CopyTo(fileStream);
                        fileStream.Flush();
                    }
                }
                if (fileCPCPKPeso != null)
                {
                    string fileName1 = $"{oHostingEnviroment.WebRootPath}\\ImagCalidad\\CP y CPK de Peso\\RSLP\\{ofecha2}_"
                                          + $"{String.Format("{0:00}", sem)}_"
                                          + $"{j++}" + ".jpg";
                    using (FileStream fileStream1 = System.IO.File.Create(fileName1))
                    {
                        fileCPCPKPeso.CopyTo(fileStream1);
                        fileStream1.Flush();
                    }
                }
                if (fileCPCPKProceso != null)
                {
                    string fileName2 = $"{oHostingEnviroment.WebRootPath}\\ImagCalidad\\CP y CPK de Proceso\\RSLP\\{ofecha2}_"
                          + $"{String.Format("{0:00}", sem)}_"
                          + $"{j++}" + ".jpg";
                    using (FileStream fileStream2 = System.IO.File.Create(fileName2))
                    {
                        fileCPCPKProceso.CopyTo(fileStream2);
                        fileStream2.Flush();
                    }
                }
                if (fileRechazosPT != null)
                {
                    string fileName3 = $"{oHostingEnviroment.WebRootPath}\\ImagCalidad\\Rechazos de PT\\RSLP\\{ofecha2}_"
                          + $"{String.Format("{0:00}", sem)}_"
                          + $"{j++}" + ".jpg";
                    using (FileStream fileStream3 = System.IO.File.Create(fileName3))
                    {
                        fileRechazosPT.CopyTo(fileStream3);
                        fileStream3.Flush();
                    }
                }
            }
            if (mixmodelcal.BDQuejasA.Region == "Jalisco")
            {
                if (fileCalifProd != null)
                {
                    string fileName = $"{oHostingEnviroment.WebRootPath}\\ImagCalidad\\Calificación de Producto\\DV\\{ofecha2}_"
                                      + $"{String.Format("{0:00}", sem)}_"
                                      + $"{j++}" + ".jpg";
                    using (FileStream fileStream = System.IO.File.Create(fileName))
                    {
                        fileCalifProd.CopyTo(fileStream);
                        fileStream.Flush();
                    }
                }
                if (fileCPCPKPeso != null)
                {
                    string fileName1 = $"{oHostingEnviroment.WebRootPath}\\ImagCalidad\\CP y CPK de Peso\\DV\\{ofecha2}_"
                                          + $"{String.Format("{0:00}", sem)}_"
                                          + $"{j++}" + ".jpg";
                    using (FileStream fileStream1 = System.IO.File.Create(fileName1))
                    {
                        fileCPCPKPeso.CopyTo(fileStream1);
                        fileStream1.Flush();
                    }
                }
                if (fileCPCPKProceso != null)
                {
                    string fileName2 = $"{oHostingEnviroment.WebRootPath}\\ImagCalidad\\CP y CPK de Proceso\\DV\\{ofecha2}_"
                          + $"{String.Format("{0:00}", sem)}_"
                          + $"{j++}" + ".jpg";
                    using (FileStream fileStream2 = System.IO.File.Create(fileName2))
                    {
                        fileCPCPKProceso.CopyTo(fileStream2);
                        fileStream2.Flush();
                    }
                }
                if (fileRechazosPT != null)
                {
                    string fileName3 = $"{oHostingEnviroment.WebRootPath}\\ImagCalidad\\Rechazos de PT\\DV\\{ofecha2}_"
                          + $"{String.Format("{0:00}", sem)}_"
                          + $"{j++}" + ".jpg";
                    using (FileStream fileStream3 = System.IO.File.Create(fileName3))
                    {
                        fileRechazosPT.CopyTo(fileStream3);
                        fileStream3.Flush();
                    }
                }
            }
            if (mixmodelcal.BDQuejasA.Region == "Matehuala")
            {
                if (fileCalifProd != null)
                {
                    string fileName = $"{oHostingEnviroment.WebRootPath}\\ImagCalidad\\Calificación de Producto\\RMTH\\{ofecha2}_"
                                      + $"{String.Format("{0:00}", sem)}_"
                                      + $"{j++}" + ".jpg";
                    using (FileStream fileStream = System.IO.File.Create(fileName))
                    {
                        fileCalifProd.CopyTo(fileStream);
                        fileStream.Flush();
                    }
                }
                if (fileCPCPKPeso != null)
                {
                    string fileName1 = $"{oHostingEnviroment.WebRootPath}\\ImagCalidad\\CP y CPK de Peso\\RMTH\\{ofecha2}_"
                                          + $"{String.Format("{0:00}", sem)}_"
                                          + $"{j++}" + ".jpg";
                    using (FileStream fileStream1 = System.IO.File.Create(fileName1))
                    {
                        fileCPCPKPeso.CopyTo(fileStream1);
                        fileStream1.Flush();
                    }
                }
                if (fileCPCPKProceso != null)
                {
                    string fileName2 = $"{oHostingEnviroment.WebRootPath}\\ImagCalidad\\CP y CPK de Proceso\\RMTH\\{ofecha2}_"
                          + $"{String.Format("{0:00}", sem)}_"
                          + $"{j++}" + ".jpg";
                    using (FileStream fileStream2 = System.IO.File.Create(fileName2))
                    {
                        fileCPCPKProceso.CopyTo(fileStream2);
                        fileStream2.Flush();
                    }
                }
                if (fileRechazosPT != null)
                {
                    string fileName3 = $"{oHostingEnviroment.WebRootPath}\\ImagCalidad\\Rechazos de PT\\RMTH\\{ofecha2}_"
                          + $"{String.Format("{0:00}", sem)}_"
                          + $"{j++}" + ".jpg";
                    using (FileStream fileStream3 = System.IO.File.Create(fileName3))
                    {
                        fileRechazosPT.CopyTo(fileStream3);
                        fileStream3.Flush();
                    }
                }
            }
            ViewData["message"] = $"Files uploaded Succesful.";
            return View("ULlenadoIndicadoresCal");

        }
        [Authorize(Roles = "1,2,4")]
        public IActionResult ULlenadoIndicadoresMant()
        {
            var ofecha = System.DateTime.Now.ToString("dd/MM/yyyy");
            var ofecha2 = System.DateTime.Now.ToString("dd-MM-yyyy");
            TrDates oTrdate = _context.TrDates.Where(x => x.Fecha == ofecha).Single();
            var Ojazn = HttpContext.Session.GetString("usuario");
            var obj = JsonSerializer.Deserialize<Users>(Ojazn);
            var reg = obj.Region;
            ViewData["message"] = $" " + ofecha2 + "       " + oTrdate.Week.Substring(0, 8) + "      " + reg;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "1,2,4")]
        public async Task<IActionResult> ULlenadoIndicadoresMant([Bind("BDMantenimientoCompletado,BDIpfm")]
             MixmodelMant mixmodelmant)
        {
            var Ojazn = HttpContext.Session.GetString("usuario");
            var obj = JsonSerializer.Deserialize<Users>(Ojazn);
            var reg = obj.Region;
            var T = Targets();
            List<Targets> tar = new List<Targets>();
            tar = T
                .Where(t => t.Region == reg)
                .ToList();
            if (ModelState.IsValid)
            {
                //var model = new Mixmodel { BDBajasPt = bdBajasPt, BDAccidente = bdAccidente };
                //BdAccidente existe = _context.BdAccidentes.Where(x => x.Week == bdAccidente.Week).First();
                mixmodelmant.BDMantenimientoCompletado.Region = reg;
                var ofecha = System.DateTime.Now.ToString("dd/MM/yyyy");
                TrDates oTrdate = _context.TrDates.Where(x => x.Fecha == ofecha).Single();
                mixmodelmant.BDMantenimientoCompletado.Week = oTrdate.Week;
                mixmodelmant.BDMantenimientoCompletado.Indicador = "Mantenimiento Completado";
                mixmodelmant.BDMantenimientoCompletado.Target = tar.Where(t => t.Indicador == mixmodelmant.BDMantenimientoCompletado.Indicador)
                                                                   .Single()
                                                                   .Value;
                mixmodelmant.BDMantenimientoCompletado.IdSem = Int32.Parse(mixmodelmant.BDMantenimientoCompletado.Week.Substring(6, 2));
                var anyBdMantenimiento = _context.BdMantenimientoCompletado.Where(x => x.Week == oTrdate.Week && x.Region == reg).FirstOrDefault();
                if (anyBdMantenimiento != null)
                {
                    ViewData["message"] = $"Ya se han cargado los datos de esta semana";
                    return View();
                }
                //BdAccidente oId = _context.BdAccidentes.Where(x => x.Week == "Semana52 22" && x.Region == "Toluca").Single();
                //bdAccidente.Id = oId.Id++;
                _context.Add(mixmodelmant.BDMantenimientoCompletado);
                //<----Ipfms------>
                mixmodelmant.BDIpfm.Week = oTrdate.Week;
                mixmodelmant.BDIpfm.Indicador = "%IPFM";
                mixmodelmant.BDIpfm.Target = tar.Where(t => t.Indicador == mixmodelmant.BDIpfm.Indicador)
                                                .Single()
                                                .Value;
                mixmodelmant.BDIpfm.IdSem = Int32.Parse(mixmodelmant.BDMantenimientoCompletado.Week.Substring(6, 2));
                mixmodelmant.BDIpfm.Region = mixmodelmant.BDMantenimientoCompletado.Region;
                _context.Add(mixmodelmant.BDIpfm);
                await _context.SaveChangesAsync();
                //<----Ipfms------>
                ViewData["message"] = $"Se han caragado los datos correctamente";
                return View(mixmodelmant);

            }
            return View(mixmodelmant);
        }


        // GET: BdAccidentes/Edit/5
        public async Task<IActionResult> Edit(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bdAccidente = await _context.BdAccidentes.FindAsync(id);
            if (bdAccidente == null)
            {
                return NotFound();
            }
            return View(bdAccidente);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(double id, [Bind("Id,Week,NúmeroDeEventos,Region,IdSem,Target,Indicador")] BdAccidente bdAccidente)
        {
            if (id != bdAccidente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bdAccidente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BdAccidenteExists(bdAccidente.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bdAccidente);
        }

        // GET: BdAccidentes/Delete/5
        public async Task<IActionResult> Delete(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bdAccidente = await _context.BdAccidentes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bdAccidente == null)
            {
                return NotFound();
            }

            return View(bdAccidente);
        }

        // POST: BdAccidentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(double id)
        {
            var bdAccidente = await _context.BdAccidentes.FindAsync(id);
            _context.BdAccidentes.Remove(bdAccidente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BdAccidenteExists(double id)
        {
            return _context.BdAccidentes.Any(e => e.Id == id);
        }
    }
}
