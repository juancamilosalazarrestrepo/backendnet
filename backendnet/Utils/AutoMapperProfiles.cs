

using backendnet.Domain.Models;
using backendnet.DTO;
using AutoMapper;

namespace backendnet.Utils
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CuestionarioDTO, Cuestionario>();
            CreateMap<PreguntaDTO, Pregunta>();
            CreateMap<RespuestaDTO, Respuesta>();

            
        }
                
    }
}
