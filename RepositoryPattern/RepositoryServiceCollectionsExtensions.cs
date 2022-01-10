using RepositoryPattern;
using RepositoryPattern.ImplXml;
using System;
using System.Collections.Generic;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RepositoryServiceCollectionsExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, Dictionary<string, Action<RepositortOptions>> configureOptionsDic)
        {
            foreach (var item in configureOptionsDic)
            {
                services.AddOptions().Configure(item.Key, item.Value);
            }
            
            return services
                .AddScoped<IStudentRepository, StudentRepository>()
                .AddScoped<ITeacherRepository, TeacherRepository>();
        }
    }
}
