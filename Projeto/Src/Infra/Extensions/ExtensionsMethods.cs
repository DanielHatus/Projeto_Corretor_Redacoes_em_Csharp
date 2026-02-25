using Src.Core.Port;
using Src.Infra.Persistence.Repository.Contract;
using Src.Infra.Persistence.Repository.Implementation;

public static class ExtensionsMethods{

    public static void AddInstances(this WebApplicationBuilder builder){
        builder.Services.AddScoped<IUserRepository,UserRepositoryImpl>();

        builder.Services.AddScoped<UserSqlPort,UserSqlAdapter>();
        builder.Services.AddScoped<EmailValidatorPort,EmailValidatorAdapter>();

        builder.Services.AddSingleton<BCryptPort,BCryptAdapter>();
    }
    
}