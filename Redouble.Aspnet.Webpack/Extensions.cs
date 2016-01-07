using Microsoft.AspNet.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Redouble.Aspnet.Webpack
{   
   public static class Extensions {
      public static void AddWebpack(this IServiceCollection services, 
         string configPath = "webpack.config.js",
         string publicPath = "/",
         string webRoot = "wwwroot") 
      {
         var options = new WebpackOptions();
         options.ConfigPath = configPath;
         options.PublicPath = publicPath;
         options.WebRoot = webRoot;
         
         services.AddSingleton<WebpackOptions>(options);
         services.AddSingleton<IWebpackService, WebpackService>();
      }

      public static void UseWebpackHotReload(this IApplicationBuilder app) {
         app.UseMiddleware<WebpackHotReload>();
      }

      public static void UseWebpackDevServer(this IApplicationBuilder app) {
         app.UseMiddleware<WebpackDevServer>();
      }
   }
}