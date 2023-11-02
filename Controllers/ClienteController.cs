using ApiGestionCliente.ContextDB;
using ApiGestionCliente.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace ApiGestionCliente.Controllers
{
    [ApiController]
    [Route("apiGesClient")]
    public class ClienteController : ControllerBase
    {
        private List<Client>? data = null;

        [HttpGet]
        [Route("get")]
        public dynamic getClient() 
        {
            using (var db = new DatabaseContext())
            {
                db.Database.EnsureCreated();
                data = db.Clients.ToList();
            }
            return data;
        }

        [HttpGet]
        [Route("get/{id}")]
        public dynamic getClient(string id)
        {
            if (string.IsNullOrEmpty(id) || !int.TryParse(id, out _))
            {
                return BadRequest("El ID no es válido.");
            }
            List<Client> lstClient = getClient();
            lstClient = lstClient.FindAll(w => w.Id == int.Parse(id));
            return new
            {
                status = lstClient.Any(w => lstClient.Count() > 0) == true ? StatusCodes.Status200OK : StatusCodes.Status404NotFound,
                message = lstClient.Any(w => lstClient.Count() > 0) == true ? "Existe" : "No existe",
                register = lstClient
            };
        }


        [HttpPost]
        [Route("create")]
        public dynamic create(Client client)
        {
            string token = Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value.ToString();
            if (token != "autorizado") 
            { 
                return BadRequest("Token incorrecto.");
            }
            try
            {
                using (var db = new DatabaseContext())
                {
                    db.Database.EnsureCreated();
                    db.Clients.Add(client);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                string msg = e.InnerException == null ? "Error en apertura de base de datos" : e.InnerException.Message.ToString();
                return BadRequest(msg.ToString());
                throw;
            }
            return new
            {
                success = true,
                message = "cliente registrado correctamente.",
                create = client
            };
        }

        [HttpPut]
        [Route("update/{id}")]
        public dynamic UpdateClient(string id, Client client)
        {
            string token = Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value.ToString();
            if (token != "autorizado")
            {
                return BadRequest("Token incorrecto.");
            }
            if (string.IsNullOrEmpty(id) || !int.TryParse(id, out _))
            {
                return BadRequest("El ID no es válido.");
            }
            try
            {
                using (var db = new DatabaseContext())
                {
                    db.Database.EnsureCreated();
                    var tb = db.Clients.Find(int.Parse(id));
                    if (tb == null)
                    {
                        return BadRequest("El ID del cliente no existe");
                    }
                    tb.Id = int.Parse(id);  
                    tb.Rut = client.Rut;
                    tb.Nombre = client.Nombre;
                    tb.ApePaterno = client.ApePaterno;
                    tb.ApeMaterno = client.ApeMaterno;
                    tb.Email = client.Email;
                    tb.Celular = client.Celular;
                    tb.Empresa = client.Empresa;
                    db.SaveChanges();
                }
                return new
                {
                    success = true,
                    message = "cliente actualizado correctamente.",
                    create = client
                };
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message.ToString());
                throw;
            }
        }
    }
}
