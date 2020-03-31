using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickBuy.Dominio.Contratos;
using QuickBuy.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace QuickBuy.Web.Controllers
{
    [ApiController]    
    [Route("api/[controller]")]
    
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private IHttpContextAccessor _httpContextAccessor;
        private IHostingEnvironment _hostingEnvironment;

        public ProdutoController(IProdutoRepositorio produtoRepositorio, 
                                 IHttpContextAccessor httpContextAccessor,
                                 IHostingEnvironment hostingEnvironment)
        {
            _produtoRepositorio = produtoRepositorio;
            _httpContextAccessor = httpContextAccessor;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Json(_produtoRepositorio.ObterTodos());
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody] Produto produto)
        {
            try
            {
                produto.Validate();

                if (!produto.Validado)
                {
                    return BadRequest(produto.ObterMsgValidacao());
                }

                if (produto.IdProd > 0)
                {
                    _produtoRepositorio.Atualizar(produto);
                }
                else
                {
                    _produtoRepositorio.Adicionar(produto);
                }

                return Created("api/produto", produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPost("Deletar")]
        public IActionResult Deletar([FromBody] Produto produto)
        {
            try
            {
               // Produto recebido do FromBody com a propriedade ID > 0
                _produtoRepositorio.Remover(produto);
                return Json(_produtoRepositorio.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }



        [HttpPost("enviarArq")]
        public IActionResult enviarArq()
        {
            try
            {
                var formFile = _httpContextAccessor.HttpContext.Request.Form.Files["arqEnviado"];
                var nomeArq = formFile.FileName;
                var extArq = nomeArq.Split(".").Last();
                string novoNomeArq = GerarNovoNomeArq(nomeArq, extArq);

                var pastaArq = _hostingEnvironment.WebRootPath + "\\arquivos\\";
                var nomeCompleto = pastaArq + novoNomeArq;

                using (var streamArquivo = new FileStream(nomeCompleto, FileMode.Create))
                {
                    formFile.CopyTo(streamArquivo);
                }

                return Json(novoNomeArq);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        private static string GerarNovoNomeArq(string nomeArq, string extArq)
        {
            var nomeCompacto = Path.GetFileNameWithoutExtension(nomeArq).Take(10).ToArray();
            var novoNomeArq = new string(nomeCompacto).Replace(" ", "-") + "." + extArq;
            novoNomeArq = $"{novoNomeArq}_{DateTime.Now.Day}-{DateTime.Now.Month}-{DateTime.Now.Year}-{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}.{extArq}";
            return novoNomeArq;
        }
    }
}
