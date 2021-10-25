using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiEstoque
{
    public class Produto
    {
        int ID { get; set; }
        string nome { get; set; }
        string modelo { get; set; }
        string cor { get; set; }
        double tamanho { get; set; }
        int quantidade { get; set; }
        string imageUrl { get; set; }
    }
}
