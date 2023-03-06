using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolution.Entities.Abstract;

namespace TestSolution.Entities.Concrete
{

    public class Test :IEntity
    {
        [Key]
        public int Id { get; set; }
        public int SGKKOD { get; set; }
        public long TCKN { get; set; }
        public string Soyad { get; set; }
        public string Ad { get; set; }
        public string BabaAdi { get; set; }
        public string Tutar { get; set; }
    }
}
