using ShiftAPI.Services.CaesarCode;

namespace ShiftAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCaesar(new CaesarOptions()
                .AddAlphabet("English", "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz")
                .AddAlphabet("Russian", "ÀÁÂÃÄÅ¨ÆÇÈÊËÌÍÎÏÐÑÒÓÔ×Ö×ØÙÚÛÜÝÞßôáâãäå¸æçèêëìíîïðñòóôõö÷øùúûüýþÿ"));

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });
            }

            app.MapDefaultControllerRoute();

            app.Run();
        }
    }
}