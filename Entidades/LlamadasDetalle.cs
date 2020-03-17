using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SegundoParcial.Entidades
{
    public class LlamadasDetalle
    {   
        [Key]
        public int Id { get; set; }
        public int LlamadaId { get; set; }
        public string Problema { get; set; }
        public string Solucion { get; set; }

        public LlamadasDetalle()
        {
            Id = 0;
            LlamadaId = 0;
            Problema = string.Empty;
            Solucion = string.Empty;
        } 

        public LlamadasDetalle(int llamadaId, string problema, string solucion)
        {
            LlamadaId = llamadaId;
            Problema = problema;
            Solucion = solucion;
        }
    }
}
