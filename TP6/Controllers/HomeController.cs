using Microsoft.AspNetCore.Mvc;

namespace TP6.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    { 
        ViewBag.detallePartido = BD.ListarPartidos();
        return View();
    }
    public IActionResult VerDetallePartido(int idPartido)
    { 
        ViewBag.detallePartido = BD.VerInfoPartido(idPartido);
        ViewBag.detalleCandidato = BD.ListarCandidatos(idPartido);
        return View("VerDetallePartido");
    }
    public IActionResult VerDetalleCandidato(int idCandidato)
    { 
        ViewBag.detalleCandidato = BD.VerInfoCandidato(idCandidato);
        return View("VerDetalleCandidato");
    }
    public IActionResult AgregarCandidato(int idPartido)
    { 
        ViewBag.idPartido = idPartido;
        return View("AgregarCandidato");
    }

    [HttpPost]
    public IActionResult GuardarCandidato(Candidato candidato)
    { 
        BD.AgregarCandidato(candidato);
        return RedirectToAction("VerDetallePartido", new { idPartido = candidato.IdPartido});
    }
    public IActionResult EliminarCandidato(int IdCandidato, int IdPartido)
    { 
        BD.EliminarCandidato(IdCandidato);
        return RedirectToAction("VerDetallePartido", new { IdPartido = IdPartido});
    }
    public IActionResult Elecciones()
    { 
        return View("Elecciones");
    }
    public IActionResult Creditos()
    { 
        return View("Creditos");
    }
}
