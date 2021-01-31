using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MarampaApp.Client
{
    public static class HttpHelper
    {

        public static StringContent GenerateHttpContent(object data)
        {
            var json = JsonConvert.SerializeObject(data);
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
                    var error = JsonConvert.DeserializeObject<ErrorMessage>(content);
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

                var data = JsonConvert.DeserializeObject<T>(content);
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
                var result = JsonConvert.DeserializeObject<T>(stringContent);
                return result;
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

    }
}
