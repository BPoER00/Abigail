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
    public class Inmueble_AlquiladoController : ControllerBase
    {
        private readonly ConexionContext DbContext;

        public Inmueble_AlquiladoController(ConexionContext _DbContext)
        {
            this.DbContext = _DbContext;
        }

        [HttpGet("Get")]
        public async Task<Response> Get()
        {
            try
            {
                var inmueble_Alquilados = await this.DbContext.Inmueble_Alquilados
                .Include(x => x.Persona).Include(x => x.Inmueble)
                .Where(x => x.Estatus == Inmueble_Alquilado.ESTADO_ACTIVO)
                .ToListAsync();

                if(inmueble_Alquilados.Count == 0)
                {
                    return new Response{
                        Resultado = Mensajes.ESTADO_EXITOSO,
                        Data = null,
                        Messages = Mensajes.MensajeNoEncontrado
                    };
                }
                else
                {
                    return new Response{
                        Resultado = Mensajes.ESTADO_EXITOSO,
                        Data = inmueble_Alquilados,
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
                var inmueble_Alquilados = await this.DbContext.Inmueble_Alquilados
                .Include(x => x.Persona).Include(x => x.Inmueble)
                .Where(x => x.Id == id)
                .AsNoTracking()
                .AnyAsync();

                if(!inmueble_Alquilados)
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
                        Data = inmueble_Alquilados,
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
        public async Task<Response> post(Inmueble_Alquilado inmueble_Alquilados)
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
                    this.DbContext.Inmueble_Alquilados.Add(inmueble_Alquilados);
                    await this.DbContext.SaveChangesAsync();

                    return new Response{
                        Resultado = Mensajes.ESTADO_EXITOSO,
                        Data = inmueble_Alquilados,
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
        public async Task<Response> Put(int id, Inmueble_Alquilado inmueble_Alquilados)
        {
            try
            {
                if(inmueble_Alquilados.Id == 0)
                {
                    inmueble_Alquilados.Id = id;
                }
                else if(inmueble_Alquilados.Id != id)
                {
                    return new Response{
                        Resultado = Mensajes.ESTADO_FALLIDO,
                        Data = null,
                    };
                }

                if(!await this.DbContext.Inmueble_Alquilados.Where(x => x.Id == id).AsNoTracking().AnyAsync())
                {
                    return new Response{
                        Resultado = Mensajes.ESTADO_FALLIDO,
                        Data = null,
                        Messages = Mensajes.MensajeNoEncontrado
                    };
                }
                else
                {
                    this.DbContext.Entry(inmueble_Alquilados).State = EntityState.Modified;
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
                            Data = inmueble_Alquilados,
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
                var inmueble_Alquilados = await this.DbContext.Inmueble_Alquilados.FindAsync(id);
                if(inmueble_Alquilados.Estatus == Inmueble_Alquilado.ESTADO_INACTIVO)
                {
                    return new Response{
                        Resultado = Mensajes.ESTADO_FALLIDO,
                        Data = null,
                        Messages = Mensajes.YaDesactivado
                    };
                }
                else
                {
                    inmueble_Alquilados.Estatus = Inmueble_Alquilado.ESTADO_INACTIVO;
                    this.DbContext.Entry(inmueble_Alquilados).State = EntityState.Modified;
                    await this.DbContext.SaveChangesAsync();

                    return new Response{
                        Resultado = Mensajes.ESTADO_EXITOSO,
                        Data = inmueble_Alquilados,
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