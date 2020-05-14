namespace WeatherApi.Model
{
    public sealed class APIConstants
    {
        internal const string WeatherAPIBaseUrl = "https://openweathermap.org/"; // should be in secrets
        internal const string ApiUrl = "data/2.5/weather?q={0}&appid=439d4b804bc8187953eb36d2a8c26a02";
    }
}
