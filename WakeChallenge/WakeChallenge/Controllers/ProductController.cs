using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WakeChallenge.CORE.Entities;
using WakeChallenge.INFRASTRUCTURE.Context;

namespace WakeChallenge.Controllers
{
    [ApiController]
    [Route("produtos")]
    public class ProductController : ControllerBase
    {
            private ApplicationDbContext _context;

            public ProductController(ApplicationDbContext context)
            {
                _context = context;
            }

        public enum ProductOrderBy
        {
            Name,
            Value,
            Stock
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get(
            [FromQuery] string? name,
            [FromQuery] ProductOrderBy? orderBy)
        {
            try
            {
                var query = _context.Products.AsQueryable();
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(p => p.Name.ToLower().Contains(name.ToLower()));
                }

                if (orderBy.HasValue)
                {
                    query = orderBy switch
                    {
                        ProductOrderBy.Name => query.OrderBy(p => p.Name),
                        ProductOrderBy.Value => query.OrderBy(p => p.Value),
                        ProductOrderBy.Stock => query.OrderBy(p => p.Stock),
                        _ => query // Caso padr�o, n�o faz nada
                    };
                }

                var products = await query.ToListAsync();
                if (products == null)
                {
                    return StatusCode(204, products);
                }

                return Ok(products);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }


        [HttpGet("{productId}")]
            public async Task<ActionResult<Product>> Get([FromRoute] int productId)
            {
                try
                {
                    var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == productId);

                    if (product == null)
                    {
                        return StatusCode(204, product);
                    }

                    return Ok(product);
                }
                catch (Exception e)
                {
                    return NotFound(e.Message);
                }
            }

            [HttpPost]
            public async Task<ActionResult<Product>> Create([FromBody] Product product)
            {
                try
                {
                    var productExists = await _context.Products.FirstOrDefaultAsync(p => p.Name == product.Name);
                    if (productExists != null)
                        return BadRequest(new { message = $"Produto {product.Name} j� est� cadastrado." });

                    _context.Add(product);
                    await _context.SaveChangesAsync();

                return Ok(product);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            [HttpPut("{productId}")]
            public async Task<ActionResult<Product>> Update([FromRoute] int productId, [FromBody] Product product)
            {
                try
                {
                    if (productId != product.ProductId)
                        throw new Exception("As informa��es enviadas est�o divergentes.");

                    _context.Update(product);
                    await _context.SaveChangesAsync();

                    return Ok(product);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            [HttpDelete("{productId}")]
            public async Task<ActionResult> Delete([FromRoute] int productId)
            {
                try
                {
                    var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
                
                if (product == null)
                    return NotFound();

                    _context.Products.Remove(product);
                    await _context.SaveChangesAsync();

                    return Ok();
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
        }
}
