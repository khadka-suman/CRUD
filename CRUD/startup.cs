namespace CRUD
{
    public class startup
    {
        public void ConfigureService(IServiceCollection services)
        {
            services.AddSingleton<ILogger>();

        }
    }

}
