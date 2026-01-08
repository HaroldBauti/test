using BLL.Interfaces;
using DAL.Interfaces;
using DTOs;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Implementation
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IGenericRepository<Usuario> _repo;

        public UsuarioService(IGenericRepository<Usuario> repo)
        {
            _repo = repo;
        }

        public async Task<UsuarioDto> Crear(UsuarioDto dto)
        {
            var entity = new Usuario
            {
                Id = dto.Id,
                Nombre = dto.Nombre
            };

            await _repo.Create(entity);

            return dto;
        }

        public async Task<List<UsuarioDto>> Listar()
        {
            var usuarios = await _repo.Query();

            return usuarios
                .Select(u => new UsuarioDto
                {
                    Id = u.Id,
                    Nombre = u.Nombre
                })
                .ToList();
        }
    }
}
