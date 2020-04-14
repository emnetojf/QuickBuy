using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickBuy.Dominio.Contratos;
using QuickBuy.Dominio.Entidades;
using System;

namespace QuickBuy.Web.Controllers
{
    [Route("api/[controller]")]

    public class PedidoController : Controller
    {
        
        private readonly IPedidoRepositorio _pedidoRepositorio;
        private IHttpContextAccessor _httpContextAccessor;
        private IWebHostEnvironment _webHostEnvironment;

        public PedidoController(IPedidoRepositorio pedidoRepositorio,
                                IHttpContextAccessor httpContextAccessor,
                                IWebHostEnvironment webHostEnvironment)
        {
            _pedidoRepositorio  = pedidoRepositorio;
            _httpContextAccessor = httpContextAccessor;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Json(_pedidoRepositorio.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody] Pedido pedido)
        {
            try
            {
                _pedidoRepositorio.Adicionar(pedido);
                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPost("Deletar")]
        public IActionResult Deletar([FromBody] Pedido pedido)
        {
            try
            {
                // Produto recebido do FromBody com a propriedade ID > 0
                _pedidoRepositorio.Remover(pedido);
                return Json(_pedidoRepositorio.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}