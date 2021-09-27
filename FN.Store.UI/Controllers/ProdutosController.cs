using FN.Store.UI.Data;
using FN.Store.UI.Models;
using System.Linq;
using System.Web.Mvc;

namespace FN.Store.UI.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly FNStoreDataContext _ctx = new FNStoreDataContext();
        // readonly não deixa gerar uma nova instancia para _ctx
        // para não sobreescrever oque está na memoria.

        public ViewResult Index() // busca os dados do produto
        {
            var produtos = _ctx.Produtos.ToList();  //ToList gera um select e puxa os dados

            return View(produtos);
        }
        [HttpGet] // pagina de Add ou Edit,

        public ViewResult AddEdit(int? id)
        {
            Produto produto = new Produto();
            if (id != null)
            {
                produto = _ctx.Produtos.Find(id);
            }

            var tipos = _ctx.TipoDeProdutos.ToList();
            ViewBag.Tipos = tipos;
            return View(produto);

        }

        [HttpPost] //Ação de salvar de add e edit
        public ActionResult AddEdit(Produto produto)
        {
            //TODO: VALIDAR
            if (produto.Id == 0)
            {
                _ctx.Produtos.Add(produto); //comando para adicionar o produto
            }
            else
            {
                _ctx.Entry(produto).State = System.Data.Entity.EntityState.Modified;
            }

            _ctx.SaveChanges(); // efetiva no banco


            return RedirectToAction("Index"); //busca os dados do produto dentro do Controler

        }

        public ActionResult Delprod(int id) //remover produto
        {
            var produto = _ctx.Produtos.Find(id);
            if (produto == null) //validação de erro
            {
                return HttpNotFound();
            }

            _ctx.Produtos.Remove(produto); //Comando para remover produto
            _ctx.SaveChanges(); // comando para salvar as mudanças
            return null;

        }

        //Libera as informações contidas na memoria e corta conexao coma base
        //override garante que vai ser executado.
        protected override void Dispose(bool disposing)
        {
            _ctx.Dispose();
        }

    }
}
