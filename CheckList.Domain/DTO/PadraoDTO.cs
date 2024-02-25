using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckList.Domain.DTO
{
    public class PadraoDTO
    {
        public bool Erro { get; set; } = false;
        public string? TextoErro { get; set; }

        public PadraoDTO() { }

        public PadraoDTO(bool erro, string? textoErro)
        {
            Erro = erro;
            TextoErro = textoErro;
        }
    }
}
