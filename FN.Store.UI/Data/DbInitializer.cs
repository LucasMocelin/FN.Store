using FN.Store.UI.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace FN.Store.UI.Data
{
    internal class DbInitializer : CreateDatabaseIfNotExists<FNStoreDataContext>
    {


        protected override void Seed(FNStoreDataContext context)
        {
            var alimento = new TipoDeProduto() { Nome = "Alimento" };
            var veiculos = new TipoDeProduto() { Nome = "Veiculos" };
            var higiene = new TipoDeProduto() { Nome = "Higiene" };
            
            //Gera os produtos para gravar no BANCO
            var produtos = new List<Produto>() {
            new Produto(){ Nome="Picanha", Preco = 70.5M, Qtde = 150, TipoDeProduto = alimento},
            new Produto(){ Nome="Desinfetante", Preco = 70.5M, Qtde = 150,TipoDeProduto = alimento},
            new Produto(){ Nome="Pasta de dente", Preco = 9.5M, Qtde = 150,TipoDeProduto = higiene},
            new Produto(){ Nome="Caroo", Preco = 70000.5M, Qtde = 10,TipoDeProduto = veiculos}
           };
            context.Produtos.AddRange(produtos);
            context.SaveChanges();
        }


    }
}