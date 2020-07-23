namespace WebAPI.Contracts.V1
{
    public class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root+"/"+Version;

        public static class Offices
        {
            public const string GetAll = Base+"/offices";
            public const string Get = Base + "/office/{officeId}";
            public const string Create = Base + "/office";
            public const string Update = Base + "/office/{officeId}";
            public const string Delete = Base + "/office/{officeId}";
        }

        public static class Users
        {
            public const string GetAll = Base + "/users";
            public const string Get = Base + "/user/{userId}";
            public const string Create = Base + "/user";
            public const string Update = Base + "/user/{userId}";
            public const string Delete = Base + "/user/{userId}";
        }
    }
}
