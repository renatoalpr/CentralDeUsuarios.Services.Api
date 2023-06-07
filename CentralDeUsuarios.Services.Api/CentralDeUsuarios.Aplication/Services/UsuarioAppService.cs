﻿using AutoMapper;
using CentralDeUsuario.Domain.Entities;
using CentralDeUsuario.Domain.Interfaces.Services;
using CentralDeUsuarios.Aplication.Commands;
using CentralDeUsuarios.Aplication.Interfaces;
using CentralDeUsuarios.Infra.Messages.Producers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDeUsuarios.Aplication.Services
{
    //implementação dos serviços de aplicação
    public class UsuarioAppService : IUsuarioAppService
    {
        //readonly é usuario para  quando é construtor esta abaixo a primeira dependencia
        //pra isso tive que fazer referencia ao projeto CentralDeUsuarioDomain 
        private readonly IUsuarioDomainServices? _usuarioDomainServices; // dependencia do dominio que é o fluxo princiapal
        private readonly MensageQueueProducer? _mensageQueueProducer; //MensageQueueProducer é o que escreve na mensageria
        private readonly IMapper? _mapper; //AutoMaper para fazer o depara dos obj


        // selecionei minhas dependencias toda e mandei adcionar parametros no construtor se o construtor já estiver eu ter que adcionar novos parametros
        public UsuarioAppService(IUsuarioDomainServices usuarioDomainServices, MensageQueueProducer? mensageQueueProducer, IMapper? mapper)
        {
            _usuarioDomainServices = usuarioDomainServices;
            _mensageQueueProducer = mensageQueueProducer;
            _mapper = mapper;
        }

        public void CriarUsuario(CriarUsuarioCommand command)
        {
            //com o Mapper podemos fazer assim
            var usuario = _mapper?.Map<Usuario>(command);// ele esta falando Mapper pega o command e dele me traz um usuario 



            //Sem o AutoMaper eu teria que fazer o Maper assim ou seja eu teria que preencher na mão tudo
            //var usuario = new Usuario
            //{
            //    Id = Guid.NewGuid(),
            //    Nome = command.Nome,
            //    Email = command.Email,
            //    Senha = command.Senha;
            //    DataHoraDeCriacao = DateTime.Now,
            //};
        }

        public void Dispose()
        {
            //Dispose para limpar sujeiras ou seja aquilo que injeta como dependencia depois joga fora
            _usuarioDomainServices?.Dispose();
        }
    }
}
