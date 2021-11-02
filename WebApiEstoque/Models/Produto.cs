using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApiEstoque.Models
{
    // Classe modelo que vai ser usada para criar o objeto e salvar no banco de dados.
    public class Produto
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Modelo { get; set; }
        [Required]
        public string Cor { get; set; }
        public int Quantidade { get; set; }
        [Required]
        public string Tamanho { get; set; }
        [Url] [Required]
        public string imageUrl { get; set; }
    }
}
