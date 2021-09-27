using System;
using System.ComponentModel.DataAnnotations;

namespace FN.Store.UI.Models
{  //Pega as informações que se tem em comum nos campos 
    public class Entity
    {
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        
        [Key]//DEFINE QUE id e a PrimaryKey
        public int Id { get; set; }
    }
}
