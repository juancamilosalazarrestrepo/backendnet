﻿
using System.ComponentModel.DataAnnotations;

namespace backendnet.DTO
{
    public class CuestionarioDTO
    {
        [Required]
        public string? Nombre { get; set; }

        [Required]
        public string? Descripcion { get; set; }

        public List<PreguntaDTO>? listPreguntas { get; set; }
    }


    public class PreguntaDTO
    {

        [Required]
        public string? Descripcion { get; set; }


        public List<RespuestaDTO>? listRespuestas { get; set; }
    }

    public class RespuestaDTO
    {
        [Required]
        public string? Descripcion { get; set; }

        [Required]
        public bool EsCorrecta { get; set; }

    }


}