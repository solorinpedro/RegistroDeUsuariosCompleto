using System;
using System.Collections.Generic;
using System.Text;
using RegistroDeUsuarios.DAL;
using Microsoft.EntityFrameworkCore;
using RegistroDeUsuarios.Entidades;
using System.Linq;
using System.Linq.Expressions;

namespace RegistroDeUsuarios.BLL
{
    public class RolesBLL
    {
        public static bool Guardar(Roles role)
        {
            if (!Existe(role.RollD))
            {
                return Insertar(role);
            }
            else
            {
                return Modificar(role);
            }
        }
        private static bool Insertar(Roles role)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                db.rol.Add(role);
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }
        public static bool Modificar(Roles role)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                db.Entry(role).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
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
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var role = db.rol.Find(id);

                if (role != null)
                {
                    db.rol.Remove(role);
                    paso = db.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }
        public static Roles Buscar(int id)
        {
            Contexto db = new Contexto();
            Roles role;

            try
            {
                role = db.rol.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return role;
        }
        public static bool Existe(int id)
        {
            Contexto db = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = db.rol.Any(r => r.RollD == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return encontrado;
        }
        public static bool Existe_Descripcion(string descripcion)
        {
            Contexto db = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = db.rol.Any(r => r.Descripcion == descripcion);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return encontrado;
        }
        public static List<Roles> GetList(Expression<Func<Roles, bool>> criterio)
        {
            List<Roles> lista = new List<Roles>();
            Contexto db = new Contexto();

            try
            {
                lista = db.rol.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return lista;
        }
        public static List<Roles> GetRoles()
        {
            List<Roles> lista = new List<Roles>();
            Contexto db = new Contexto();
            try
            {
                lista = db.rol.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return lista;
        }
    }
}
