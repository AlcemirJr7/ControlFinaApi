namespace ControlFinaApi.Messages
{
    public static class ResponseErrorsMessages
    {
        public static string NotFound(string entityName, Guid id) => $"{entityName} with id: {id} not found.";
        public static string Command(string commandName, string entityName) => $"Error on try {commandName.ToLower()} {entityName}.";

    }
}
