using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using A37_EPLAYERS.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace A37_EPLAYERS.Controllers
{
    public class NoticiasController : Controller
    {
        Noticias noticiasModel = new Noticias();

        public IActionResult Index()
        {
            ViewBag.Noticia = noticiasModel.ReadAll();
            return View();
        }
        public IActionResult Cadastrar(IFormCollection form)
        {
            Noticias novaNoticia   = new Noticias();
            novaNoticia.IdNoticia = Int32.Parse(form["IdNoticia"]);
            novaNoticia.Titulo     = form["Titulo"];
            novaNoticia.Texto     = form["Texto"];
            // Upload Início
            var file    = form.Files[0];
            var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Noticia");

            if(file != null)
            {
                if(!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))  
                {  
                    file.CopyTo(stream);  
                }
                novaNoticia.Imagem   = file.FileName;
            }
            else
            {
                novaNoticia.Imagem   = "padrao.png";
            }
            // Upload Final

            noticiasModel.Create(novaNoticia);
            ViewBag.Noticia = noticiasModel.ReadAll();

            return LocalRedirect("~/Equipe");
        }

         [Route("Noticias/{id}")]
        public IActionResult Excluir(int id)
        {
            noticiasModel.Delete(id);
            ViewBag.Noticia = noticiasModel.ReadAll();
            return LocalRedirect("~/Noticias");
        }
    }
}
