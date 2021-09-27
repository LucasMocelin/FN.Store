using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


//criando caixa de seleção para tipo de produtos
namespace FN.Store.UI.Models
{
    [Table(nameof(TipoDeProduto))]
                              //Define de onde deriva as informações, 
    public class TipoDeProduto:Entity
    {
       
        [Required, Column(TypeName ="varchar"), StringLength(100) ]
        public string Nome { get; set; } //nome do tipo do produto
        
        public virtual ICollection<Produto> Produtos { get; set; } // faz a relação de tipo de produto com o produto
    }
}
