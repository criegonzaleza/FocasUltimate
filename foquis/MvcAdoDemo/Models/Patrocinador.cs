using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
   namespace MVCAdoDemo.Models{      
         public class Patrocinador { 
                      public int Run { get; set; } [Required]  
                      public string Name { get; set; } [Required]
                      public string Appellido { get; set; } [Required] 
                      public string Telefono { get; set; } [Required]  
                      public string Region { get; set; }        
                      public string Comuna { get; set; } 
                      public string Apoyo { get; set; } }    }