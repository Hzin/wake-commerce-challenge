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

            [HttpGet]
            public async Task<ActionResult<List<Product>>> Get()
            {
                try
                {
                    var products = await _context.Products.ToListAsync();
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

            /*[HttpGet("consultar")]
            public async Task<ActionResult<Product>> Consulta([FromHeader(Name = "X-Page-Index")] string? pageIndex, [FromHeader(Name = "X-Page-Size")] string? pageSize, string? nome, bool? ativo)
            {
                try
                {
                    var page = new PageParameters(pageIndex, pageSize);
                    var product = await _context.GetByFilterAsync(page, nome, ativo);
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
            }*/

            [HttpPost]
            public async Task<ActionResult<Product>> Create([FromBody] Product product)
            {
                try
                {
                    var productExists = await _context.Products.FirstOrDefaultAsync(p => p.Name == product.Name);
                    if (productExists != null)
                        return BadRequest(new { message = $"Produto {product.Name} já está cadastrado." });

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
                        throw new Exception("As informações enviadas estão divergentes.");

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
