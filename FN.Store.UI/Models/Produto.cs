using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FN.Store.UI.Models
{
    //INFORMAÇÕES DO PRODUTOS
    [Table(nameof(Produto))] // DEFINE O NOME NA TABELA DO BANCO
    public class Produto : Entity
    {

        [Required]//not Null
        [Column(TypeName = "varchar")] //Define que as informações são em varchar
        [StringLength(100)]//Define o tamanho maximo do varchar
        public String Nome { get; set; }


        [Column(TypeName = "money")] //Define que é valor referente a Dinheiro
        public decimal Preco { get; set; }

        [Column("Quantidade")] //Define o Nome do campo
        public short Qtde { get; set; }

        //grava o ID do tipo de produto
        public int TipoDeProdutoId { get; set; }
        [ForeignKey("TipoDeProdutoId")] //estabelece o relacionamento entre duas tabelas

        public virtual TipoDeProduto TipoDeProduto { get; set; } //cria o vinculo coma  tabela
    }
}
