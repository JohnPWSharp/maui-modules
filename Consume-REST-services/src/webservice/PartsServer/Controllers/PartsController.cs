using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using PartsService.Models;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace PartsService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PartsController : BaseController
    {
        [HttpGet]
        public ActionResult Get()
        {
            var authorized = CheckAuthorization();
            if (!authorized)
            {
                return Unauthorized();
            }
            Console.WriteLine("GET /api/parts");
            return new JsonResult(UserParts);
        }

        [HttpGet("{isbn}")]
        public ActionResult Get(string isbn)
        {
            var authorized = CheckAuthorization();
            if (!authorized)
            {
                return Unauthorized();
            }

            if (string.IsNullOrEmpty(isbn))
                return this.BadRequest();

            isbn = isbn.ToUpperInvariant();
            Console.WriteLine($"GET /api/parts/{isbn}");
            var userParts = UserParts;
            var part = userParts.SingleOrDefault(x => x.PartID == isbn);

            if (part == null)
            {
                return this.NotFound();
            }
            else
            {
                return this.Ok(part);
            }
        }

        [HttpPut("{isbn}")]
        public HttpResponseMessage Put(string isbn, [FromBody] Part part)
        {
            try
            {
                var authorized = CheckAuthorization();
                if (!authorized)
                {
                    return new HttpResponseMessage(HttpStatusCode.Unauthorized);
                }

                if (!ModelState.IsValid)
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }

                if (string.IsNullOrEmpty(part.PartID))
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }

                Console.WriteLine($"PUT /api/parts/{isbn}");
                Console.WriteLine(JsonSerializer.Serialize(part));


                var userParts = UserParts;
                var existingParts = userParts.SingleOrDefault(x => x.PartID == isbn);
                if (existingParts != null)
                {
                    existingParts.Suppliers = part.Suppliers;
                    existingParts.PartType = part.PartType;
                    existingParts.PartAvailableDate = part.PartAvailableDate;
                    existingParts.PartName = part.PartName;
                }

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] Part part)
        {
            try
            {
                var authorized = CheckAuthorization();
                if (!authorized)
                {
                    return new HttpResponseMessage(HttpStatusCode.Unauthorized);
                }

                if (!string.IsNullOrWhiteSpace(part.PartID))
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
                Console.WriteLine($"POST /api/parts");
                Console.WriteLine(JsonSerializer.Serialize(part));

                part.PartID = PartsFactory.CreatePartID();

                if (!ModelState.IsValid)
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }

                var userParts = UserParts;

                if(userParts.Count >= 10)
                {
                    return new HttpResponseMessage(HttpStatusCode.TooManyRequests);
                }

                if (userParts.Any(x => x.PartID == part.PartID))
                {
                    return new HttpResponseMessage(HttpStatusCode.Conflict);
                }

                userParts.Add(part);

                var json = JsonSerializer.Serialize(part);
                
                HttpContext.Response.ContentType = "application/json";
                var resp = new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new StringContent(json)
                };

                resp.Headers.Location = new UriBuilder(Request.Scheme, Request.Host.Host, Request.Host.Port ?? -1, part.PartID).Uri;

                return resp;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);

            }
        }

        [HttpDelete]
        [Route("{isbn}")]
        public HttpResponseMessage Delete(string isbn)
        {
            try
            {
                var authorized = CheckAuthorization();
                if (!authorized)
                {
                    return new HttpResponseMessage(HttpStatusCode.Unauthorized);
                }

                var userParts = UserParts;
                var existingParts = userParts.SingleOrDefault(x => x.PartID == isbn);

                if (existingParts == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
                Console.WriteLine($"POST /api/parts/{isbn}");
                userParts.RemoveAll(x => x.PartID == isbn);

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
    }
}