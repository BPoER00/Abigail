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
    public class QrController : ControllerBase
    {
        private readonly ConexionContext DbContext;

        public QrController(ConexionContext _DbContext)
        {
            this.DbContext = _DbContext;
        }


        [HttpGet("Get/{Cui}")]    
        public async Task<Response> Get(String Cui)
        {
            try
            {
                var QrData = await (from ia in this.DbContext.Inmueble_Alquilados
                                    join p in this.DbContext.Persona on ia.Persona_Id equals p.Id
                                    join i in this.DbContext.Inmueble on ia.Inmueble_Id equals i.Id
                                    where Cui == p.Cui
                                    select new
                                    {
                                        Nombre_Completo = p.Nombre +" "+ p.Apellido,
                                        Cui = p.Cui,
                                        Destino = $"Casa No. {i.Numero_Inmueble}"
                                    }).SingleOrDefaultAsync();
                if(QrData == null)
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
                        Data = QrData,
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
    }
}