using APM.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Http.OData;

namespace APMWebAPI.Controllers
{
    [EnableCorsAttribute("http://localhost:62806","*","*")]
    public class ProductsController : ApiController
    {
        // GET: api/Products
        [EnableQuery()]
        [ResponseType(typeof(Product))]
        //public IQueryable<Product> Get()
        public IHttpActionResult Get()
        {
            try
                {
                var productRepository = new ProductRepository();
                return Ok(productRepository.Retrieve().AsQueryable());
                }
            catch (Exception ex)
                {

               return InternalServerError(ex);
                }
        }

        //// GET: api/Products
        //public IEnumerable<Product> Get(string search)
        //    {
        //    var productRepository = new ProductRepository();
        //    var products = productRepository.Retrieve();

        //    return products.Where(p=>p.ProductCode.Contains(search));
        //    }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        [Authorize()]
        public IHttpActionResult Get(int id)
        {
            try
                {
                //throw new ArgumentException("This is a test");
                Product product;
                var productRepository = new ProductRepository();
                if (id > 0)
                    {
                    var products = productRepository.Retrieve();
                    product = products.FirstOrDefault(p => p.ProductId == id);
                    if (product == null)
                        {
                        return NotFound();
                        }
                    }
                else
                    {
                    product = productRepository.Create();
                    }
                return Ok(product);
                }
            catch (Exception ex)
                {

              return InternalServerError(ex);
                }
        }

        // POST: api/Products
        public IHttpActionResult Post([FromBody]Product product)
            {
            try
                {
                if (product == null)
                    {
                    return BadRequest("Product can note ne Null");
                    }
                if (!ModelState.IsValid)
                    {
                    return BadRequest(ModelState);
                    }
                var productRepository = new ProductRepository();
                var newProduct = productRepository.Save(product);
                if (newProduct == null)
                    {
                    return Conflict();
                    }
                return Created<Product>(Request.RequestUri + newProduct.ProductId.ToString(), newProduct);
                }
            catch (Exception ex)
                {

                return InternalServerError(ex);
                }
        }

        // PUT: api/Products/5
        public IHttpActionResult Put(int id, [FromBody]Product product)
        {
            try
                {
                if (product == null)
                    {
                    return BadRequest("Product can not be null");
                    }
                if (!ModelState.IsValid)
                    {
                    return BadRequest(ModelState);
                    }
                var productRepository = new ProductRepository();
                var updateProduct = productRepository.Save(id, product);
                if (updateProduct == null)
                    {
                    return NotFound();
                    }
                return Ok();
                }
            catch (Exception ex)
                {

                return InternalServerError(ex);
                }
            }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
