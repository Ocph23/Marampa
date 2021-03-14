using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MarampaApp.Client
{
    public static class HttpHelper
    {
        static 	JsonSerializerOptions jsonOptions = new()
                {
                    ReferenceHandler = ReferenceHandler.Preserve,
                    PropertyNamingPolicy= JsonNamingPolicy.CamelCase    ,
                    MaxDepth = 0, WriteIndented  =true
    };

        public static StringContent GenerateHttpContent(object data)
        {
            var json = JsonSerializer.Serialize(data,jsonOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return content;
        }


        public static async Task<string> Error(HttpResponseMessage response)
        {
            try
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return $"'{response.RequestMessage.RequestUri.LocalPath}'  Tidak Ditemukan";
                var content = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(content))
                    throw new SystemException();

                if (content.Contains("message"))
                {
                    var error = JsonSerializer.Deserialize<ErrorMessage>(content,jsonOptions);
                    return error.Message;
                }
                return content;
            }
            catch (Exception)
            {
                return "Maaf Terjadi Kesalahan, Silahkan Ulangi Lagi Nanti";
            }
        }

        public static async Task<T> GetResult<T>(HttpResponseMessage response)
        {
            try
            {
                var content = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    return default(T);
                }

                if (string.IsNullOrEmpty(content))
                    throw new SystemException("Data Tidak Ada");
                Debug.WriteLine(content);
                var data = JsonSerializer.Deserialize<T>(content, jsonOptions);
                return data;
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }


    }



    public class ErrorMessage
    {
        public string Message { get; set; }
    }

    public static class RestServiceExtention
    {

        public static async Task<T> GetResult<T>(this HttpResponseMessage response)
        {
            try
            {
                string stringContent = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(stringContent))
                    return default;
                var result = JsonSerializer.Deserialize<T>(stringContent);
                return result;
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

    }
}
