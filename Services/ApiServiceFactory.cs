public static class ApiServiceFactory
{
    private static ApiService? _service;

    public static ApiService Create(string apiUrl)
    {
        if (_service is null)
        {
            _service = new ApiService(apiUrl);
        }

        return _service;
    }
}