using Amaris.Library.DataAccess;
using Amaris.Library.Infraestructure.Repositories;
using Amaris.Library.Infraestructure.Services;
using Amaris.Library.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace Amaris.Library.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<LibraryContext>(opt =>
                                               opt.UseInMemoryDatabase("Library"));

            services.AddTransient<IBooksRepository, BooksRepository>();
            services.AddTransient<IBooksService, BooksService>();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder
                        .WithOrigins("*")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });

            services.AddApiVersioning(x =>
            {
                x.DefaultApiVersion = new ApiVersion(1, 0);
                x.AssumeDefaultVersionWhenUnspecified = true;
            });

            services.AddSwaggerGen();


            services.AddControllers().AddNewtonsoftJson();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env, IBooksRepository booksRepository)
        {
            await CreateSampleDataAsync(booksRepository);
            app.UseSwagger();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }

        private async Task CreateSampleDataAsync(IBooksRepository booksRepository)
        {
            var book = new Infraestructure.Entities.Book
            {
                Author = "Gabriel Garcia Marquez",
                Title = "Cien años de soledad",
                Year = 2020,
                Taken = true
            };
            await booksRepository.CreateAsync(book);

            book = new Infraestructure.Entities.Book
            {
                Author = "John Katzenbach",
                Title = "El psicoanalista",
                Year = 2002
            };
            await booksRepository.CreateAsync(book);

            book = new Infraestructure.Entities.Book
            {
                Author = "Harry Potter",
                Title = "JK Rowling",
                Year = 2005
            };
            await booksRepository.CreateAsync(book);
        }
    }
}
