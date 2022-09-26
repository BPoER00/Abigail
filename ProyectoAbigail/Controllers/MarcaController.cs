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
    public class MarcaController : ControllerBase
    {
        private readonly ConexionContext DbContext;

        public MarcaController(ConexionContext _DbContext)
        {
            this.DbContext = _DbContext;
        }

        [HttpGet("Get")]
        public async Task<Response> Get()
        {
            try
            {
                var marca = await this.DbContext.Marca
                .Where(x => x.Estatus == Marca.ESTADO_ACTIVO)
                .ToListAsync();

                if(marca.Count == 0)
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
                        Data = marca,
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
                var marca = await this.DbContext.Marca
                .Where(x => x.Id == id)
                .AsNoTracking()
                .AnyAsync();

                if(!marca)
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
                        Data = marca,
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
        public async Task<Response> post(Marca marca)
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
                    this.DbContext.Marca.Add(marca);
                    await this.DbContext.SaveChangesAsync();

                    return new Response{
                        Resultado = Mensajes.ESTADO_EXITOSO,
                        Data = marca,
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
        public async Task<Response> Put(int id, Marca marca)
        {
            try
            {
                if(marca.Id == 0)
                {
                    marca.Id = id;
                }
                else if(marca.Id != id)
                {
                    return new Response{
                        Resultado = Mensajes.ESTADO_FALLIDO,
                        Data = null,
                    };
                }

                if(!await this.DbContext.Marca.Where(x => x.Id == id).AsNoTracking().AnyAsync())
                {
                    return new Response{
                        Resultado = Mensajes.ESTADO_FALLIDO,
                        Data = null,
                        Messages = Mensajes.MensajeNoEncontrado
                    };
                }
                else
                {
                    this.DbContext.Entry(marca).State = EntityState.Modified;
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
                            Data = marca,
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
                var marca = await this.DbContext.Marca.FindAsync(id);
                if(marca.Estatus == Marca.ESTADO_INACTIVO)
                {
                    return new Response{
                        Resultado = Mensajes.ESTADO_FALLIDO,
                        Data = null,
                        Messages = Mensajes.YaDesactivado
                    };
                }
                else
                {
                    marca.Estatus = Marca.ESTADO_INACTIVO;
                    this.DbContext.Entry(marca).State = EntityState.Modified;
                    await this.DbContext.SaveChangesAsync();

                    return new Response{
                        Resultado = Mensajes.ESTADO_EXITOSO,
                        Data = marca,
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