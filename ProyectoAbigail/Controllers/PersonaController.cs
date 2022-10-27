using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoAbigail.Models;
using ProyectoAbigail.Resources;

namespace ProyectoAbigail.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly ConexionContext DbContext;

        public PersonaController(ConexionContext _DbContext)
        {
            this.DbContext = _DbContext;
        }

        [HttpGet("Get")]
        public async Task<Response> Get()
        {
            try
            {
                var persona = await (from p in this.DbContext.Persona
                              join e in this.DbContext.Etnia on p.Etnia_Id equals e.Id
                              join g in this.DbContext.Genero on p.Genero_Id equals g.Id
                              join c in this.DbContext.Estado_Civil on p.Estado_Civil_Id equals c.Id
                              select new
                              {
                                Nombre_Completo = p.Nombre +" "+ p.Apellido,
                                Cui = p.Cui,
                                Telefono = p.Telefono,
                                Fecha_Nacimiento = p.Fecha_Nacimiento.ToString("ddMMyyyy"),
                                Genero_Id = p.Genero_Id,
                                Genero = g.Nombre,
                                Estado_Civil_Id = p.Estado_Civil_Id,
                                Estado_Civil = c.Nombre,
                                Etnia_Id = p.Etnia_Id,
                                Etnia = e.Nombre
                              }).ToListAsync();
                if(persona == null)
                {
                    return new Response{
                        Resultado = Mensajes.ESTADO_FALLIDO,
                        Data = null,
                        Messages = Mensajes.MensajeNoEncontrado
                    };
                }
                else
                {
                    return new Response{
                        Resultado = Mensajes.ESTADO_EXITOSO,
                        Data = persona,
                        Messages = Mensajes.MensajeEncontrado,
                    };
                }
                
            }catch(Exception e)
            {
                    return new Response{
                        Resultado = Mensajes.ESTADO_FALLIDO,
                        Data = null,
                        Messages = $"Error: {e.Message}"
                    };
            }
        }
    
        [HttpGet("Get/{id}")]
        public async Task<Response> Get(int? id)
        {
            try
            {
                var persona = await (from p in this.DbContext.Persona
                              join e in this.DbContext.Etnia on p.Etnia_Id equals e.Id
                              join g in this.DbContext.Genero on p.Genero_Id equals g.Id
                              join c in this.DbContext.Estado_Civil on p.Estado_Civil_Id equals c.Id
                              where p.Id == id
                              select new
                              {
                                Nombre_Completo = p.Nombre +" "+ p.Apellido,
                                Cui = p.Cui,
                                Telefono = p.Telefono,
                                Fecha_Nacimiento = p.Fecha_Nacimiento.ToString("dd-MM-yyyy"),
                                Genero_Id = p.Genero_Id,
                                Genero = g.Nombre,
                                Estado_Civil_Id = p.Estado_Civil_Id,
                                Estado_Civil = c.Nombre,
                                Etnia_Id = p.Etnia_Id,
                                Etnia = e.Nombre
                              }).SingleOrDefaultAsync();

                if(persona == null)
                {
                    return new Response{
                        Resultado = Mensajes.ESTADO_FALLIDO,
                        Data = null,
                        Messages = Mensajes.MensajeNoEncontrado
                    };
                }
                else
                {
                    return new Response{
                        Resultado = Mensajes.ESTADO_EXITOSO,
                        Data = persona,
                        Messages = Mensajes.MensajeEncontrado,
                    };
                }
            }catch(Exception e)
            {
                    return new Response{
                        Resultado = Mensajes.ESTADO_FALLIDO,
                        Data = null,
                        Messages = $"Error: {e.Message}"
                    };
            }
        }

        [HttpPost("Post")]
        public async Task<Response> post(Persona persona)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return new Response{
                        Resultado = Mensajes.ESTADO_FALLIDO,
                        Data = null,
                        Messages = Mensajes.ModeloInvalido                       
                    };
                }
                else
                {
                    this.DbContext.Persona.Add(persona);
                    await this.DbContext.SaveChangesAsync();

                    return new Response{
                        Resultado = Mensajes.ESTADO_EXITOSO,
                        Data = persona,
                        Messages = Mensajes.DatosGuardatos
                    };
                }
            }
            catch(Exception e)
            {
                    return new Response{
                        Resultado = Mensajes.ESTADO_FALLIDO,
                        Data = null,
                        Messages = $"Error: {e.Message}"
                    };
            }
        }
    
        [HttpPut("Put/{id}")]    
        public async Task<Response> Put(int id, Persona persona)
        {
            try
            {
                if(persona.Id == 0)
                {
                    persona.Id = id;
                }
                else if(persona.Id != id)
                {
                    return new Response{
                        Resultado = Mensajes.ESTADO_FALLIDO,
                        Data = null,
                    };
                }

                if(!await this.DbContext.Persona.Where(x => x.Id == id).AsNoTracking().AnyAsync())
                {
                    return new Response{
                        Resultado = Mensajes.ESTADO_FALLIDO,
                        Data = null,
                        Messages = Mensajes.MensajeNoEncontrado
                    };
                }
                else
                {
                    this.DbContext.Entry(persona).State = EntityState.Modified;
                    if(!ModelState.IsValid)
                    {
                        return new Response{
                            Resultado = Mensajes.ESTADO_FALLIDO,
                            Data = null,
                            Messages = Mensajes.ModeloInvalido
                        };                        
                    }
                    else
                    {
                        await this.DbContext.SaveChangesAsync();
                        return new Response{
                            Resultado = Mensajes.ESTADO_EXITOSO,
                            Data = persona,
                            Messages = Mensajes.DatosActualizados
                        };
                    }
                }

            }catch(Exception e)
            {
                return new Response{
                    Resultado = Mensajes.ESTADO_FALLIDO,
                    Data = null,
                    Messages = $"Error: {e.Message}"
                };
            }
        }
    
        [HttpDelete("Delete/{id}")]
        public async Task<Response> Delete(int? id)
        {
            try
            {
                var persona = await this.DbContext.Persona.FindAsync(id);
                if(persona.Estatus == Persona.ESTADO_INACTIVO)
                {
                    return new Response{
                        Resultado = Mensajes.ESTADO_FALLIDO,
                        Data = null,
                        Messages = Mensajes.YaDesactivado
                    };
                }
                else
                {
                    persona.Estatus = Persona.ESTADO_INACTIVO;
                    this.DbContext.Entry(persona).State = EntityState.Modified;
                    await this.DbContext.SaveChangesAsync();

                    return new Response{
                        Resultado = Mensajes.ESTADO_EXITOSO,
                        Data = persona,
                        Messages = Mensajes.Desactivado
                    };

                }
            }catch(Exception e)
            {
                return new Response{
                    Resultado = Mensajes.ESTADO_FALLIDO,
                    Data = null,
                    Messages = $"Error: {e.Message}"
                };
            }
        }        
    }
}