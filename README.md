# Net-6-Project
logger service will contain four methods for logging:
•	Info messages
•	Debug messages
•	Warning messages
•	And error messages

Install the NLog library in our LoggerService project. 
NLog is a logging platform for the .NET which will help us create and log our messages.
Implement logger
public class LoggerManager : ILoggerManager
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        public void LogDebug(string message) => logger.Debug(message);
        public void LogError(string message) => logger.Error(message);
        public void LogInfo(string message) => logger.Info(message);
        public void LogWarn(string message) => logger.Warn(message);
    }

•	builder.Services.AddSingleton will create the service the first time you request it and then every subsequent request is calling the same instance of the service. This means that all components are sharing the same service every time they need it. You are using the same instance always
•	builder.Services.AddScoped will create the service once per request. That means whenever we send the HTTP request towards the application, a new instance of the service is created
•	builder.Services.AddTransient will create the service each time the application request it. This means that if during one request towards our application, multiple components need the service, this service will be created again for every single component which needs it

Net 6 We can see three main changes from Latest:
•	Top-level statements
•	Implicit using directives
•	And there is no usage of the Startup class
Cors policy
public static void ConfigureCors(this IServiceCollection services)
{
      services.AddCors(options =>
      {
          options.AddPolicy("CorsPolicy",
              builder => builder.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
      });
}
We are using the basic settings for adding CORS policy because for this project allowing any origin, method, and header is quite enough. But we can be more restrictive with those settings if we want. Instead of the AllowAnyOrigin() method which allows requests from any source, we could use the WithOrigins("http://www.something.com") which will allow requests just from the specified source. Also, instead of AllowAnyMethod() that allows all HTTP methods,  we can use WithMethods("POST", "GET") that will allow only specified HTTP methods. Furthermore, we can make the same changes for the AllowAnyHeader() method by using, for example, the WithHeaders("accept", "content-type") method to allow only specified headers.
app.UseForwardedHeaders will forward proxy headers to the current request. This will help us during the Linux deployment.
app.UseStaticFiles() enables using static files for the request. If we don’t set a path to the static files, it will use a wwwroot folder in our solution explorer by default.

What is a Repository pattern and why should we use it?
we create an abstraction layer between the data access and the business logic layer of an application. 
By using it, we are promoting a more loosely coupled approach to access our data from the database.
 Also, the code is cleaner and easier to maintain and reuse. 
Data access logic is in a separate class, or sets of classes called a repository, with the responsibility of persisting the application’s business model.
Repository User Classes
user classes that will inherit this abstract class. Every user class will have its own interface, for additional model-specific methods. Furthermore, by inheriting from the RepositoryBase class they will have access to all the methods from the RepositoryBase. This way, we are separating the logic, that is common for all our repository user classes and also specific for every user class itself.
Creating a Repository Wrapper
Let’s imagine if inside a controller we need to collect all the Owners and to collect only the certain Accounts (for example Domestic ones). We would need to instantiate OwnerRepository and AccountRepository classes and then call the FindAll and FindByCondition methods.
Maybe it’s not a problem when we have only two classes, but what if we need logic from 5 different classes or even more. Having that in mind, let’s create a wrapper around our repository user classes. Then place it into the IOC and finally inject it inside the controller’s constructor. Now, with that wrappers instance, we may call any repository class we need.
AutoMapper is a library that helps us map different objects. To install it, we have to type this command in the Package Manager Console window:
PM> Install-Package AutoMapper.Extensions.Microsoft.DependencyInjection
After the installation, we have to register it in the Program class
builder.Services.AddAutoMapper(typeof(Program));
Now, we have to create a mapping profile class to tell AutoMapper how to execute mapping actions. So, let’s create a new class MappingProfile in the main project and modify it:
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Owner, OwnerDto>();
    }
}

 [FromUri] attribute wouldn’t recommend that at all due to the security reasons and complexity of the request.
