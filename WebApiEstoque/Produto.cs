using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiEstoque
{
    public class Produto
    {
        public int ID { get; set; }
        public string nome { get; set; }
        public string modelo { get; set; }
        public string cor { get; set; }
        public double tamanho { get; set; }
        public int quantidade { get; set; }
        public string imageUrl { get; set; }
    }
}
