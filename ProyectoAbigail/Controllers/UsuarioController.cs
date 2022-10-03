using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoAbigail.Models;
using ProyectoAbigail.Models.viewModels;
using ProyectoAbigail.Resources;

namespace ProyectoAbigail.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ConexionContext DbContext;

        public UsuarioController(ConexionContext _DbContext)
        {
            this.DbContext = _DbContext;
        }

        [HttpGet("Get")]
        public async Task<Response> Get()
        {
            try
            {
                List<UsuarioViewModel> Lista = await this.DbContext.Usuario
                .Include(x => x.Rol)
                .Where(x => x.Estatus == UsuarioViewModel.ESTADO_ACTIVO)
                .Select(x => new UsuarioViewModel(){
                    Id = x.Id,
                    User = x.User,
                    Correo = x.Correo,
                    Rol_Id = x.Rol_Id,
                    Fecha_commit = x.Fecha_commit,
                    Hora_commit = x.Hora_commit,
                    Rol = x.Rol
                }).ToListAsync();

                if(Lista.Count == 0)
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
                        Data = Lista,
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
                var Usuario = await this.DbContext.Usuario
                .Include(x => x.Rol)
                .Select(x => new UsuarioViewModel(){
                    Id = x.Id,
                    User = x.User,
                    Correo = x.Correo,
                    Rol_Id = x.Rol_Id,
                    Fecha_commit = x.Fecha_commit,
                    Hora_commit = x.Hora_commit,
                    Rol = x.Rol
                }).AnyAsync();

                if(!Usuario)
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
                        Data = Usuario,
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
        public async Task<Response> post(Usuario usuario)
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
                    if(await this.DbContext.Usuario.Where(x => x.User == usuario.User).AnyAsync())
                    {
                        return new Response{
                            Resultado = Mensajes.ESTADO_FALLIDO,
                            Data = null,
                            Messages = Mensajes.UsuarioRegistrado
                        };
                    }
                    else
                    {
                        HashedPassword password = HashHelper.Hash(usuario.Password);
                        usuario.Password = password.Password;
                        usuario.Estatus = Usuario.ESTADO_ACTIVO;
                        usuario.Sal = password.Salt;

                        this.DbContext.Usuario.Add(usuario);
                        await this.DbContext.SaveChangesAsync();

                        return new Response{
                            Resultado =  Mensajes.ESTADO_EXITOSO,
                            Data = usuario.Id,
                            Messages = Mensajes.DatosGuardatos
                        };
                    }
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
        public async Task<Response> Put(int id, Usuario usuario)
        {
            try
            {
                if(usuario.Id == 0)
                {
                    usuario.Id = id;
                }
                else if(usuario.Id != id)
                {
                    return new Response{
                        Resultado = Mensajes.ESTADO_FALLIDO,
                        Data = null,
                    };
                }

                if(!await this.DbContext.Reporte.Where(x => x.Id == id).AsNoTracking().AnyAsync())
                {
                    return new Response{
                        Resultado = Mensajes.ESTADO_FALLIDO,
                        Data = null,
                        Messages = Mensajes.MensajeNoEncontrado
                    };
                }
                else
                {
                    HashedPassword password = HashHelper.Hash(usuario.Password);
                    usuario.Password = password.Password;
                    usuario.Estatus = Usuario.ESTADO_ACTIVO;
                    usuario.Sal = password.Salt;

                    this.DbContext.Entry(usuario).State = EntityState.Modified;
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
                            Data = usuario,
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
                var usuario = await this.DbContext.Usuario.FindAsync(id);
                if(usuario.Estatus == Usuario.ESTADO_INACTIVO)
                {
                    return new Response{
                        Resultado = Mensajes.ESTADO_FALLIDO,
                        Data = null,
                        Messages = Mensajes.YaDesactivado
                    };
                }
                else
                {
                    usuario.Estatus = Usuario.ESTADO_INACTIVO;
                    this.DbContext.Entry(usuario).State = EntityState.Modified;
                    await this.DbContext.SaveChangesAsync();

                    return new Response{
                        Resultado = Mensajes.ESTADO_EXITOSO,
                        Data = usuario,
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