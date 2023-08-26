using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendnet.Domain.Models
{
    public class Respuesta
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName ="varchar(50)")]
        public string? Descripcion { get; set; }
        [Required]
        public bool EsCorrecta { get; set; }
        public int PReguntaId { get; set; }
        public Pregunta? Pregunta { get; set; }
    }
}
