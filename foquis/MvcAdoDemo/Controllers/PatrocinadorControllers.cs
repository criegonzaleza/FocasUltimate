using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc; 
using MVCAdoDemo.Models;

    namespace MVCAdoDemo.Controllers  {  
        public class PatrocinadorController : Controller {  
            PatrocinadorDataAccessLayer objpatrocinador = new PatrocinadorDataAccessLayer();
            public IActionResult Index() { List<Patrocinador> lstPatrocinador = new List<Patrocinador>();
            lstPatrocinador = objpatrocinador.GetAllPatrocinador().ToList(); 
            return View(lstPatrocinador); }  }  }

[HttpGet]  public IActionResult Create()  {  return View();  } 
[HttpPost]  [ValidateAntiForgeryToken]
public IActionResult Create([Bind] Patrocinador patrocinador)  {  if (ModelState.IsValid)   
   { objpatrocinador.AddPatrocinador(patrocinador); 
   return RedirectToAction("Index");}  
    return View(Patrocinador);  }  

[HttpGet]  public IActionResult Edit(int? id)  {if (id == null) {return NotFound(); } 
Patrocinador patrocinador = objpatrocinador.GetPatrocinadorData(id);
        if (patrocinador == null)      { return NotFound(); } return View(patrocinador); } 
[HttpPost]  [ValidateAntiForgeryToken] 
public IActionResult Edit(int id, [Bind]Patrocinador patrocinador)  { if (id != patrocinador.ID) 
     {  return NotFound(); }  
         if (ModelState.IsValid)  {  objpatrocinador.Updatepatrocinador(patrocinador);
                   return RedirectToAction("Index");  }    
                     return View(patrocinador);  }


[HttpGet]  public IActionResult Details(int? id)  { if (id == null) { return NotFound();}
Patrocinador patrocinador = objpatrocinador.GetPatrocinadorData(id); 
    if (patrocinador == null) {  return NotFound(); } 
         return View(patrocinador);  }


[HttpGet]  public IActionResult Delete(int? id)  { if (id == null) {  return NotFound();}
Patrocinador patrocinador = objpatrocinador.GetPatrocinadorData(id); 
       if (patrocinador == null)  { return NotFound();}
             return View(patrocinador);  } 
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken] 
public IActionResult DeleteConfirmed(int? id) 
 { objpatrocinador.DeletePatrocinador(id); return RedirectToAction("Index");  }
