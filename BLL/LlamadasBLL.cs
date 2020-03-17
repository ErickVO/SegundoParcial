using Microsoft.EntityFrameworkCore;
using SegundoParcial.DAL;
using SegundoParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SegundoParcial.BLL
{
   public class LlamadasBLL
    {
        public static bool Guardar(Llamadas llamadas)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try 
            {
              if(db.Llamadas.Add(llamadas) != null)
                {
                    paso = (db.SaveChanges() > 0);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static bool Modificar(Llamadas llamadas)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                db.Database.ExecuteSqlRaw($"DELETE FROM LlamadasDetalle WHERE LlamadaId={llamadas.LlamadaId}");
                
                foreach(var item in llamadas.LlamadasDetalle)
                {
                    db.Entry(item).State = EntityState.Added;
                }

                db.Entry(llamadas).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static bool Eliminar(int id)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                var eliminar = db.Llamadas.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = (db.SaveChanges() > 0);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static Llamadas Buscar(int id)
        {
            Contexto db = new Contexto();
            Llamadas llamadas = new Llamadas();

            try
            {
                llamadas = db.Llamadas.Include(x => x.LlamadasDetalle)
                    .Where(x => x.LlamadaId == id)
                    .SingleOrDefault();
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return llamadas;
        }

    }
}
