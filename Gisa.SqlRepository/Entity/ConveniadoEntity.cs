using Gisa.Domain;
using Gisa.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gisa.SqlRepository.Entity
{
    public class ConveniadoEntity : Conveniado
    {
        public ConveniadoEntity()
        {

        }

        public ConveniadoEntity(Conveniado conveniado)
        {
            this.Codigo = conveniado.Codigo;
            this.DataAlteracao = conveniado.DataAlteracao;
            this.DataInclusao = conveniado.DataInclusao;
            this.Endereco = conveniado.Endereco;
            this.Especialidades = conveniado.Especialidades;
            this.Identificador = conveniado.Identificador;
            this.Nome = conveniado.Nome;
            this.Prestadores = conveniado.Prestadores;
            this.Tipo = conveniado.Tipo;
        }

        public string TipoString { 
            get {
                return ((char)this.Tipo).ToString();
            } 
            set 
            {
                this.Tipo = (Enums.ConveniadoTipo)value.ToCharArray()[0];
            } 
        }

        public long EnderecoId { get; set; }

    }
}
