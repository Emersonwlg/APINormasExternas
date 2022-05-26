using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Norma.Api.Controllers;
using Norma.Api.ViewModels;
using Norma.Business.Intefaces;
using Norma.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Norma.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class NormasExternasController : MainController
    {
        private readonly INormaExternaRepository _normaExternaRepository;
        private readonly INormaExternaService _normaExternaService;
        private readonly IArquivosRepository _arquivoRepository;
        private readonly IArquivosService _arquivoService;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ILogger<NormasExternasController> _logger;

        public NormasExternasController(INotificador notificador,
                                  INormaExternaRepository normaExternaRepository,
                                  INormaExternaService normaExternaService,
                                  IArquivosRepository arquivosRepository,
                                  IArquivosService arquivosService,
                                  IEmailSender emailSender,
                                  IMapper mapper,
                                  IConfiguration configuration,
                                  IUser user,
                                  ILogger<NormasExternasController> logger) : base(notificador, user)
        {
            _normaExternaRepository = normaExternaRepository;
            _normaExternaService = normaExternaService;
            _arquivoRepository = arquivosRepository;
            _arquivoService = arquivosService;
            _emailSender = emailSender;
            _mapper = mapper;
            _configuration = configuration;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<NormaExternaViewModel>> ObterTodas()
        {
            return _mapper.Map<IEnumerable<NormaExternaViewModel>>(await _normaExternaRepository.ObterTodos());
        }

        [Authorize(Policy = "PodeLer")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<NormaExternaViewModel>> ObterPorId(Guid id)
        {
            _logger.LogInformation("Obtendo norma por id!");

            var normasViewModel = _mapper.Map<NormaExternaViewModel>(await _normaExternaRepository.ObterPorId(id));

            if (normasViewModel == null) return NotFound();


            _logger.LogInformation("Finalizando o processo!");

            return normasViewModel;
        }

        [Authorize(Policy = "PodeEscrever")]
        [HttpPost]
        public async Task<ActionResult<NormaExternaViewModel>> GravarNorma(NormaExternaViewModel normaExternaiewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _normaExternaService.Adicionar(_mapper.Map<NormaExterna>(normaExternaiewModel));

            // Envia e-mail aos usuários que uma nova norma 
            string destinatario = _configuration["EmailSettings:ToEmail"];

            await _emailSender.SendEmailAsync(destinatario, "Alerta de Nova Versão de Norma Regulamentadora", MontarHtml(normaExternaiewModel));

            return CustomResponse(normaExternaiewModel);
        }

        [Authorize(Policy = "PodeEscrever")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, NormaExternaViewModel normaExternaViewModel)
        {
            var normasAtualizar = await _normaExternaRepository.ObterPorId(id);

            if (normasAtualizar == null) return NotFound();

            await _normaExternaService.Atualizar(normasAtualizar);

            return CustomResponse(normasAtualizar);
        }

        [Authorize(Policy = "PodeExcluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<NormaExternaViewModel>> Excluir(Guid id)
        {
            var normasExcluir = await _normaExternaRepository.ObterPorId(id);
            var arquivoExcluir = await _arquivoRepository.ObterArquivoPorIdNorma(id);

            if (arquivoExcluir == null) return NotFound();

            foreach (var arquivo in arquivoExcluir)
            {
                await _arquivoService.Remover(arquivo);
            }

            await _normaExternaService.Remover(normasExcluir);

            return CustomResponse(normasExcluir);
        }

        private string MontarHtml(NormaExternaViewModel normas)
        {
            string htmlString = string.Empty;

            return htmlString = string.Format("<html>" +
                                                "<body>" +
                                                "<p style='font-weight: bold;'>Prezados,</p>" +
                                                "<p style='font-weight: bold;'>Foi disponibilizado a seguinte nova norma regulamentadora:</p>" +
                                                "<table style='width: 70%; border-collapse: collapse; border: 1px solid black;'>" +
                                                    "<tr style='background-color: #00ffff;'>" +
                                                        "<th style='border: 1px solid black; padding: 5px;'>Código</th>" +
                                                        "<th style='border: 1px solid black; padding: 5px;'>Título</th>" +
                                                        "<th style='border: 1px solid black; padding: 5px;'>Comitê</th>" +
                                                    "</tr>" +
                                                     "<tr>" +
                                                        "<td style='border: 1px solid black; padding: 5px;'>{0}</td>" +
                                                        "<td style='border: 1px solid black; padding: 5px;'>{1}</td>" +
                                                        "<td style='border: 1px solid black; padding: 5px;'>{2}</td>" +
                                                    "</tr>" +
                                                "</table>" +
                                                "<p>Atenciosamente,</br></p>" +
                                                "</body>" +
                                             "</html>", normas.Codigo, normas.Titulo, normas.Comite);
        }
    }
}