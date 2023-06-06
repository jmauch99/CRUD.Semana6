using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDSemana6.Models
{
    public class CaminhaoModel
    {
        [Key]
        public int Id{ get; set; }
        [Required(ErrorMessage ="Digite o nome do Caminhão")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite a descrição do Caminhão")]
        public string Descricao{ get; set; }
        public DateTime Data  { get; set; }
    }
}
