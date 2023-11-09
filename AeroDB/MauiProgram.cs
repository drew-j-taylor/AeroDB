using Microsoft.Extensions.Logging;
using AeroDB.View;
using AeroDB.ViewModel;
using AeroDB.Model;
using AeroDB.Service;

namespace AeroDB
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
            builder.Services.AddSingleton<UserService>();
            builder.Services.AddSingleton<PartService>();
            builder.Services.AddTransient<Login>();
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<Home>();
            builder.Services.AddTransient<HomeViewModel>();

            builder.Services.AddTransient<View.Part>();
            builder.Services.AddTransient<PartInfo>();
            builder.Services.AddTransient<PartEdit>();
            builder.Services.AddTransient<PartViewModel>();

            //builder.Services.AddTransient<ChildListViewModel>();
            //builder.Services.AddTransient<ChildList>();

            return builder.Build();
        }
    }
}