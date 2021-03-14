using System;
using System.IO;
using System.Threading.Tasks;
using MarampaApp;

namespace MarampaApp.Services
{
    public class DocumentService
    {
        private string GetPath(JenisDokumen jenis)
        {
            switch (jenis)
            {
                case JenisDokumen.Baptis:
                    return $"{AppContext.BaseDirectory}/documents/baptis";
                case JenisDokumen.Sidi:
                    return $"{AppContext.BaseDirectory}/documents/sidi";
                case JenisDokumen.Nikah:
                    return $"{AppContext.BaseDirectory}/documents/nikah";
                default:
                    return $"{AppContext.BaseDirectory}/Documents";

            }

        }

        public Task<Tuple<bool, string>> SaveDocument(JenisDokumen jenis, string berkas, byte[] data)
        {
            try
            {
                var fileName = $"{GetPath(jenis)}/{Guid.NewGuid()}.pdf";
                File.WriteAllBytes(fileName, data);
                RemoveDocument(jenis, berkas);
                return Task.FromResult(Tuple.Create(true, fileName));
            }
            catch (System.Exception ex)
            {
                throw new SystemException(ex.Message);
            }

        }

        private Task RemoveDocument(JenisDokumen jenis, string berkas)
        {
            var fileName = $"{GetPath(jenis)}/{berkas}";
            if (!string.IsNullOrEmpty(berkas) && File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            return Task.CompletedTask;
        }
    }





}