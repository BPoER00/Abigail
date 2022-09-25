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
    public class EntradaSalidaController : ControllerBase
    {
        private readonly ConexionContext DbContext;

        public EntradaSalidaController(ConexionContext _DbContext)
        {
            this.DbContext = _DbContext;
        }

        [HttpGet("Get")]
        public async Task<Response> Get()
        {
            try
            {
                var entradaSalida = await this.DbContext.Entrada_Salida
                .Include(x => x.Persona).Include(x => x.Vehiculo)
                .ToListAsync();

                if(entradaSalida.Count == 0)
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
                        Data = entradaSalida,
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
                var entradaSalida = await this.DbContext.Entrada_Salida
                .Include(x => x.Persona).Include(x => x.Vehiculo)
                .Where(x => x.Id == id)
                .AsNoTracking()
                .AnyAsync();

                if(!entradaSalida)
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
                        Data = entradaSalida,
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
        public async Task<Response> post(Entrada_Salida entradaSalida)
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
                    this.DbContext.Entrada_Salida.Add(entradaSalida);
                    await this.DbContext.SaveChangesAsync();
                    return new Response{
                        Resultado = Mensajes.ESTADO_EXITOSO,
                        Data = entradaSalida,
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
        public async Task<Response> Put(int id, Entrada_Salida entradaSalida)
        {
            try
            {
                if(entradaSalida.Id == 0)
                {
                    entradaSalida.Id = id;
                }
                else if(entradaSalida.Id != id)
                {
                    return new Response{
                        Resultado = Mensajes.ESTADO_FALLIDO,
                        Data = null,
                        Messages = Mensajes.IdInvalido
                    };
                }

                if(!await this.DbContext.Entrada_Salida.Where(x => x.Id == id).AsNoTracking().AnyAsync())
                {
                    return new Response{
                        Resultado = Mensajes.ESTADO_FALLIDO,
                        Data = null,
                        Messages = Mensajes.MensajeNoEncontrado
                    };
                }
                else
                {
                    this.DbContext.Entry(entradaSalida).State = EntityState.Modified;
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
                            Data = entradaSalida,
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
                var entradaSalida = await this.DbContext.Entrada_Salida.FindAsync(id);

                    this.DbContext.Entry(entradaSalida).State = EntityState.Modified;
                    await this.DbContext.SaveChangesAsync();

                    return new Response{
                        Resultado = Mensajes.ESTADO_EXITOSO,
                        Data = entradaSalida,
                        Messages = Mensajes.Desactivado
                    };
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