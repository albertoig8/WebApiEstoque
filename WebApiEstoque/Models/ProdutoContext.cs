using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// Importando o Entity Framework para usar o DbContext.
using Microsoft.EntityFrameworkCore;

namespace WebApiEstoque.Models
{
    // Classe de contexto.
    // : significa que essa classe esta extendendo a classe DbContext.
    // Essa classe é filha da Classe DbContext.
    public class ProdutoContext : DbContext
    {
        // Definindo o método construtor ProdutoContext.
        // Esta recebendo como parametro o DbContextOptions que esta recebendo uma opção como contexto que é o ProdutoContext.
        public ProdutoContext(DbContextOptions<ProdutoContext> options) : base(options)
        {
        }


        // Setando os Items Produtos
        public DbSet<Produto> ProdutoItems { get; set; }
    }
}
