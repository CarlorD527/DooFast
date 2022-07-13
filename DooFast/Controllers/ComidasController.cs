using CapaEntidades;
using CapaEntidades.ComidaEntities;
using CapaNegocio;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.UI.WebControls;

namespace DooFast.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ComidasController : ApiController
    {
        //credenciales cloudinary

        Cloudinary cloudinary;
        const string CLOUD_NAME = "dxmoosvrj";
        const string API_KEY = "621764434599565";
        const string API_SECRET = "jVlMgTRHNI8dSzsI8Sm19_eZRoM";

        // GET: api/Comidas
        public List<List<ComidaBEforList>> Get()
        {
            ComidaBl obj = new ComidaBl();
            _ = new List<ComidaBEforList>();

            List<List<ComidaBEforList>> lstComidas = obj.listarComidas();

            return lstComidas;
        }

        // GET: api/Comidas/5
        public List<ComidaBEforList> Get(int id)
        {
            ComidaBl obj = new ComidaBl();
            _ = new List<ComidaBEforList>();

            List<ComidaBEforList> comida = obj.listarComida(id);

            return comida;
        }

        // POST: api/Comidas
        public async Task<HttpResponseMessage> Post()
        {
            Account account = new Account(CLOUD_NAME, API_KEY, API_SECRET);
            cloudinary = new Cloudinary(account);

            ComidaBl obj = new ComidaBl();

             Dictionary<string, object> dict = new Dictionary<string, object>();


            try
            {
             
                var httpRequest = HttpContext.Current.Request;

                
                foreach (string file in httpRequest.Files)
                {
                    string ruta;
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
         
                    var postedFile = httpRequest.Files[file];
                    if (postedFile != null && postedFile.ContentLength > 0)
                    {

                        int MaxContentLength = 1024 * 1024 * 1; //Size = 1 MB

                        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };
                        var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                        var extension = ext.ToLower();
                        if (!AllowedFileExtensions.Contains(extension))
                        {

                            var message = string.Format("Please Upload image of type .jpg,.gif,.png.");

                            dict.Add("error", message);
                            return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                        }
                        else if (postedFile.ContentLength > MaxContentLength)
                        {

                            var message = string.Format("Please Upload a file upto 1 mb.");

                            dict.Add("error", message);
                            return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                        }
                        else
                        {
                            int seed = (int)DateTime.Now.Ticks;
                            //Guardando imagen
                            var filePath = HttpContext.Current.Server.MapPath("~/Foodimage/" + seed.ToString() + extension);
                            postedFile.SaveAs(filePath);
                            //subiendo a cloudinary
                            var uploadParams = new ImageUploadParams()
                            {
                                File = new FileDescription(filePath)
                            };

                            var uploadResult = cloudinary.Upload(uploadParams);

                            //Obteniendo ruta de la imagen de cloudinary que se acaba de subir
                            ruta = uploadResult.SecureUri.ToString();

                            ComidaBe comida = new ComidaBe();

                            comida.nombreComida = HttpContext.Current.Request.Form["nombreComida"];
                            comida.precio = Convert.ToDouble(HttpContext.Current.Request.Form["precio"]);
                            comida.costo = Convert.ToDouble(HttpContext.Current.Request.Form["costo"]);
                            comida.idCategoria = Convert.ToInt32(HttpContext.Current.Request.Form["idCategoria"]);
                            comida.imagen = ruta;

                            obj.Add(comida);
                            var message1 = string.Format("Image Updated Successfully." + ruta);
                            return Request.CreateErrorResponse(HttpStatusCode.Created, message1);
                        }
                    }

                }
                var res = string.Format("Please Upload a image.");
                dict.Add("error", res);
                return Request.CreateResponse(HttpStatusCode.NotFound, dict);
            }
            catch (Exception ex)
            {
                var res = string.Format("some Message");
                throw (ex);
                dict.Add("error", res);
                return Request.CreateResponse(HttpStatusCode.NotFound, dict);
            }

        }

        // PUT: api/Comidas/5
        public async Task<HttpResponseMessage> Put()
        {
           

            ComidaBl obj = new ComidaBl();

            Account account = new Account(CLOUD_NAME, API_KEY, API_SECRET);
            cloudinary = new Cloudinary(account);

            Dictionary<string, object> dict = new Dictionary<string, object>();
            try
            {

                var httpRequest = HttpContext.Current.Request;


                foreach (string file in httpRequest.Files)
                {
                    string ruta;
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

                    var postedFile = httpRequest.Files[file];
                    if (postedFile != null && postedFile.ContentLength > 0)
                    {

                        int MaxContentLength = 1024 * 1024 * 1; //Size = 1 MB

                        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };
                        var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                        var extension = ext.ToLower();
                        if (!AllowedFileExtensions.Contains(extension))
                        {

                            var message = string.Format("Please Upload image of type .jpg,.gif,.png.");

                            dict.Add("error", message);
                            return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                        }
                        else if (postedFile.ContentLength > MaxContentLength)
                        {

                            var message = string.Format("Please Upload a file upto 1 mb.");

                            dict.Add("error", message);
                            return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                        }
                        else
                        {
                            int seed = (int)DateTime.Now.Ticks;
                            //Guardando imagen
                            var filePath = HttpContext.Current.Server.MapPath("~/Foodimage/" + seed.ToString() + extension);
                            postedFile.SaveAs(filePath);
                            //subiendo a cloudinary
                            var uploadParams = new ImageUploadParams()
                            {
                                File = new FileDescription(filePath)
                            };

                            var uploadResult = cloudinary.Upload(uploadParams);

                            //Obteniendo ruta de la imagen de cloudinary que se acaba de subir
                            ruta = uploadResult.SecureUri.ToString();

                            ComidaBEforUpdate comida = new ComidaBEforUpdate();

                            comida.idComida = Convert.ToInt32(HttpContext.Current.Request.Form["idComida"]);
                            comida.idCategoria = Convert.ToInt32(HttpContext.Current.Request.Form["idCategoria"]);
                            comida.nombreComida = HttpContext.Current.Request.Form["nombreComida"];
                            comida.precio = Convert.ToDouble(HttpContext.Current.Request.Form["precio"]);
                            comida.costo = Convert.ToDouble(HttpContext.Current.Request.Form["costo"]);
                            comida.imagen = ruta;

                            obj.Update(comida);
                            var message1 = string.Format("Image Updated Successfully." + ruta);
                            return Request.CreateErrorResponse(HttpStatusCode.Created, message1);
                        }
                    }

                }
                var res = string.Format("Please Upload a image.");
                dict.Add("error", res);
                return Request.CreateResponse(HttpStatusCode.NotFound, dict);
            }
            catch (Exception ex)
            {
                var res = string.Format("some Message");
                throw (ex);
                dict.Add("error", res);
                return Request.CreateResponse(HttpStatusCode.NotFound, dict);
            }
        }

        // DELETE: api/Comidas/5
        public string Delete(int id)
        {
            

            ComidaBl obj = new ComidaBl();

            try
            {
                obj.Delete(id);
                return  "Comida eliminada con exito!";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Algo salio mal!";
            }
        }
    }
}
