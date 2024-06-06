using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Plugin.Maui.Audio;

namespace EMJI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            //app.UseResponseCompression(); app.MapHub<ChatHub>("/chathub");
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
            // Initialize the .NET MAUI Community Toolkit MediaElement by adding the below line of code
            .UseMauiCommunityToolkitMediaElement()
            // After initializing the .NET MAUI Community Toolkit, optionally add additional fonts
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddSingleton(AudioManager.Current);
            //builder.Services.AddRazorComponenets().AddInteractiveServerComponenets().AddHubOptions(options => { options.{OPTION} = {VALUE}; });
            /**builder.Services.AddSingleton<TodoListPage>();
            builder.Services.AddTransient<TodoItemPage>();

            builder.Services.AddSingleton<TodoItemDatabase>();*/

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug(); 
#endif

            return builder.Build();
        }
    }
}
