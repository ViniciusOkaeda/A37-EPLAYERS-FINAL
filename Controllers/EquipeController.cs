using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using A37_EPLAYERS.Models;
using Microsoft.AspNetCore.Http;

namespace A37_EPLAYERS.Controllers
{
    public class EquipeController : Controller
    {

        Equipe equipeModel = new Equipe();
        public IActionResult Index()
        {
            ViewBag.Equipes = equipeModel.ReadAll();
            return View();
        }
        public IActionResult Cadastrar(IFormCollection form)
        {
            Equipe novaEquipe   = new Equipe();
            novaEquipe.IdEquipe = Int32.Parse(form["IdEquipe"]);
            novaEquipe.Nome     = form["Nome"];
            novaEquipe.Imagem   = form["Imagem"];

            equipeModel.Create(novaEquipe);            
            ViewBag.Equipes = equipeModel.ReadAll();

            return LocalRedirect("~/Equipe");
        }
    }
}

