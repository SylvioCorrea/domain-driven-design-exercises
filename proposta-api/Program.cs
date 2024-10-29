using proposta_api.Dominio.Proposta.Handlers;
using proposta_api.Dominio.Proposta.Repositorio;

namespace proposta_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Configurações adicionais
            //var mappingConfiguration = new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new Mappings());
            //});

            //builder.Services.AddSingleton(mappingConfiguration.CreateMapper());

            builder.Services
                .AddScoped<GravacaoPropostaHandler>()
                .AddScoped<IPropostaRepository, PropostaRepositoryMock>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
