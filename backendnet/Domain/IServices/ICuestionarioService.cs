﻿using backendnet.Domain.Models;

namespace backendnet.Domain.IServices
{
    public interface ICuestionarioService
    {
        Task CreateCuestionario(Cuestionario cuestionario);
        Task<List<Cuestionario>> GetListCuestionarioByUser(int idUsuario);
        Task<Cuestionario> GetCuestionario(int idCuestionario);
        Task<Cuestionario> BuscarCuestionario(int idCuestionario);
        Task EliminarCuestionario(Cuestionario cuestionario);
    }
}
