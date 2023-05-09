using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ProjetoBD.Application;
using ProjetoBD.Application.Interfaces;
using ProjetoBD.Application.Mappers;
using ProjetoBD.Domain.Core.Interfaces.Repositories;
using ProjetoBD.Domain.Core.Interfaces.Services;
using ProjetoBD.Infrastructure.Data;
using ProjetoBD.Services;
using Raven.Client.Documents;
using System.Reflection.Metadata;

namespace ProjetoBD.Infrastructure.CrossCutting.Ioc
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRavenDb(this IServiceCollection servicesCollection)
        {
            servicesCollection.TryAddSingleton<IDocumentStore>(ctx =>
            {
                var store = new DocumentStore
                {
                    Urls = new string[] { "http://127.0.0.1:8080/" },
                    Database = "ProjetoBD"
                };
                store.Initialize();
                return store;
            }); 

            return servicesCollection;
        }

        public static IServiceCollection AddAutoMapper(this IServiceCollection servicesCollection)
        {
            var mappingConfig = new MapperConfiguration(nc =>
            {
                nc.AddProfile(new DtoToModelMappingToMusic());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            servicesCollection.AddSingleton(mapper);

            return servicesCollection;
        }

        public static IServiceCollection AddDomainServices(this IServiceCollection servicesCollection)
        {
            servicesCollection.TryAddScoped<IMusicService, MusicService>();
            return servicesCollection;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection servicesCollection)
        {
            servicesCollection.TryAddScoped<IMusicApplication, MusicApplication>();
            return servicesCollection;
        }
        public static IServiceCollection AddRepositories(this IServiceCollection servciceCollection)
        {
            servciceCollection.TryAddSingleton<IMusicRepository, MusicRepository>();
            return servciceCollection;
        }
    }
}
