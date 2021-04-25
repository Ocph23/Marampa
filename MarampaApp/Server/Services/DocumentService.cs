using System;
using System.IO;
using System.Threading.Tasks;
using MarampaApp;
using MarampaApp.Models;
using Microsoft.AspNetCore.Hosting;

namespace MarampaApp.Services
{
    public class DocumentService
    {
        private string basePath ;

        public DocumentService(IWebHostEnvironment env)
        {
            basePath = Path.Combine(env.ContentRootPath,
                          "documents");
        }

        private string GetPath(Type jenis)
        {
            switch (jenis.Name)
            {
                case "Baptis":
                    return "/baptis";
                case "Sidi":
                    return "/sidi";
                case "Nikah":
                    return "/nikah";
                default:
                    return "/";
            }
        }

        public Task<Tuple<bool, string>> SaveDocument(Type jenis, EntityWithBerkas berkas)
        {
            try
            {
                var fileName = $"{GetPath(jenis)}/{Guid.NewGuid()}.pdf";
                File.WriteAllBytes($"{basePath}{fileName}", berkas.DataBerkas);
                RemoveDocument(berkas.Berkas);
                return Task.FromResult(Tuple.Create(true, fileName));
            }
            catch (System.Exception ex)
            {
                throw new SystemException(ex.Message);
            }

        }

        private Task RemoveDocument(string berkas)
        {
            var fileName = $"{basePath}/{berkas}";
            if (!string.IsNullOrEmpty(berkas) && File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            return Task.CompletedTask;
        }
    }





}