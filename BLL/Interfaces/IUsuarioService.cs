using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDto> Crear(UsuarioDto dto);
        Task<List<UsuarioDto>> Listar();
    }
}
