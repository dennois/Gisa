﻿using Gisa.Domain;
using Gisa.Domain.Interfaces.Repository;
using Gisa.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gisa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        #region [ Construtor ]
        
        public ConsultaController(IConsultaService consultaService)
        {
            _consultaService = consultaService;
        }

        #endregion

        #region [ Membros ]

        readonly IConsultaService _consultaService;

        #endregion

        #region [ Métodos ]

        /// <summary>
        /// Recupera os detalhes de uma consulta
        /// </summary>
        /// <param name="id">Identificador da consulta</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Consulta>> Get(long id)
        {
            var consulta = await _consultaService.RecuperarPorIdAsync(id);
            return consulta != null ? (ActionResult)Ok(consulta) : NoContent();
        }

        /// <summary>
        /// Reponsável por solicitar o agendamento de consulta
        /// </summary>
        /// <param name="value">Dados da consulta</param>
        [HttpPost]
        public async Task<ActionResult<Consulta>> Post([FromBody] Consulta consulta)
        {
            try
            {
                consulta = await _consultaService.AgendarAsync(consulta);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return consulta != null && consulta.Identificador > 0 ? (ActionResult)Ok(consulta) : BadRequest("Ocorreu um erro ao salvar a consulta, tente novamente!");
        }

        /// <summary>
        /// Reponsável por atualizar as informações da consulta
        /// </summary>
        /// <param name="value">Dados da consulta</param>
        [HttpPut("{id}")]
        public async void Put([FromBody] Consulta value)
        {
            await _consultaService.AtualizarAsync(value);
        }

        #endregion
    }
}