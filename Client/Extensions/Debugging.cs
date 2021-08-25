using System.Text.Json;

namespace PizzaParlor.Client.Extensions
{
    public static class Debugging
    {
        public static string ToJson(this object obj) => JsonSerializer.Serialize(obj, obj.GetType());
    }
}
