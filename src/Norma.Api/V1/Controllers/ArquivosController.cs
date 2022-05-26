using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Norma.Api.Controllers;
using Norma.Api.ViewModels;
using Norma.Business.Intefaces;
using Norma.Business.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Norma.Api.V1.Controllers
{
    //[Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ArquivosController : MainController
    {
        private readonly IArquivosRepository _arquivosRepository;
        private readonly IArquivosService _arquivosService;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;

        public ArquivosController(INotificador notificador,
                                  IArquivosRepository arquivoRepository,
                                  IArquivosService arquivoService,
                                  IMapper mapper,
                                  IUser user,
                                  IWebHostEnvironment env) : base(notificador, user)
        {
            _arquivosRepository = arquivoRepository;
            _arquivosService = arquivoService;
            _mapper = mapper;
            _env = env;
        }

        [HttpPost("{idNorma:guid}")]
        public async Task<ActionResult> AdicionarAnexoNorma([FromForm] ArquivoViewModel file, Guid idNorma)
        {
            if (file.file != null)
            {
                // Envia os arquivos para wwwroot
                var nomeArquivo = Path.GetFileName(file.file.FileName);

                // Verifica se o arquivo é extensão .pdf
                string ext = Path.GetExtension(file.file.FileName);
                if (ext.ToLower() != ".pdf")
                    return NotFound();

                string caminhoArquivo = Path.Combine(_env.WebRootPath, "images", nomeArquivo);

                using (var fileSteam = new FileStream(caminhoArquivo, FileMode.Create))
                {
                    await file.file.CopyToAsync(fileSteam);
                }

                var arquivo = new Arquivo()
                {
                    Nome = file.file.FileName,
                    CaminhoArquivo = caminhoArquivo,
                    NormaId = idNorma
                };

                await _arquivosService.Adicionar(_mapper.Map<Arquivo>(arquivo));
            }
            else
                return NotFound();

            return Ok(new
            {
                success = true,
                nome = file.file.FileName,
                tamanho = file.file.Length,
                caminho = Path.Combine(_env.WebRootPath, "images", file.file.FileName)
            });
        }

        [HttpGet("{normaId:guid}")]
        public async Task<ActionResult> DownloadPdf(Guid normaId)
        {
            var arquivoModel = _mapper.Map<IEnumerable<Arquivo>>(await _arquivosRepository.ObterArquivoPorIdNorma(normaId));

            if (arquivoModel == null)
                return NotFound();

            return CustomResponse(arquivoModel);
        }
    }
}
