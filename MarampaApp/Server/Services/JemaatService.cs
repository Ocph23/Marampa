using System.Collections.Generic;
using System.Threading.Tasks;
using MarampaApp.Models;
using System.Linq;
using System;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MarampaApp.Server.Data;
using System.Diagnostics;

namespace MarampaApp.Services
{
    public class JemaatService
    {
        private DocumentService _documentService;
        private ApplicationDbContext _dbContext;

        public JemaatService(DocumentService documentService, ApplicationDbContext db)
        {
            _documentService = documentService;
            _dbContext = db;
        }

        public Task<IEnumerable<Jemaat>> Get()
        {
            var result = _dbContext.Jemaat
            .Include(x => x.Keluarga)
            .AsEnumerable();
            return Task.FromResult(result);
        }


        public Task<Jemaat> Get(int id)
        {

            Debug.WriteLine("Test");
            return Task.FromResult(_dbContext.Jemaat.Where(x => x.Id == id)
            .Include(x => x.Pekerjaan)
            .Include(x => x.Baptis)
            .Include(x => x.Sidi)
            .Include(x => x.Nikah)
            .Include(x => x.Keluarga)
            .ThenInclude(x=>x.Rayon).FirstOrDefault());
        }

        internal Task<IEnumerable<Jemaat>> GetByParam(string param)
        {
            return Task.FromResult(_dbContext.Jemaat.Where(x => x.Nama.ToLower().Contains(param.ToLower()) || x.NIK.ToLower().Contains(param.ToLower()))
            .Include(x => x.Pekerjaan)
            .Include(x => x.Baptis)
            .Include(x => x.Sidi)
            .Include(x => x.Nikah)
            .Include(x => x.Keluarga)
            .ThenInclude(x => x.Rayon).AsEnumerable());
        }

        public async Task<Jemaat> Post(Jemaat model)
        {
            try
            {
                if (Valid(model))
                {
                    _dbContext.Jemaat.Add(model);
                    _dbContext.Entry(model.Pekerjaan).State = EntityState.Unchanged;
                    await _dbContext.SaveChangesAsync();
                    return model;
                }

                throw new SystemException("Data Tidak Valid !");
            }
            catch (System.Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        internal async Task<Jemaat> Put(int id, Jemaat model)
        {
            try
            {
                var jemaat = _dbContext.Jemaat.Where(x => x.Id == id).FirstOrDefault();
                if (jemaat == null)
                    throw new SystemException("Data Jemaat tidak ditemukan !");

                if (ValidateJemaat(model))
                {
                    jemaat.HubunganKeluarga = model.HubunganKeluarga;
                    jemaat.JenisKelamin = model.JenisKelamin;
                    jemaat.Nama = model.Nama;
                    jemaat.NIK = model.NIK;
                    jemaat.Pekerjaan = model.Pekerjaan;
                    jemaat.StatusJemaat = model.StatusJemaat;
                    jemaat.StatusPernikahan = model.StatusPernikahan;
                    jemaat.TanggalLahir = model.TanggalLahir;
                    jemaat.Updated = DateTime.Now;

                    await _dbContext.SaveChangesAsync();
                    return jemaat;
                }
                throw new SystemException("Data Tidak Valid !");
            }
            catch (System.Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

      

        public async Task<Baptis> PutBaptis(int idjemaat, Baptis model)
        {
            try
            {
                var jemaat = _dbContext.Jemaat.Where(x => x.Id == idjemaat).FirstOrDefault();
                if (jemaat == null)
                    throw new SystemException("Data Jemaat tidak ditemukan !");

                if (ValidSuratBaptis(model))
                {
                    if (model.DataBerkas != null && model.DataBerkas.Count() > 0)
                    {
                        var documentResult = await _documentService.SaveDocument(typeof(Baptis), model);
                        if (documentResult.Item1)
                        {
                            model.Berkas = documentResult.Item2;
                        }
                    }

                    if (model.Id <= 0)
                       {
                           model.Id= idjemaat;
                            _dbContext.Baptis.Add(model);
                       }
                    else
                    {
                        var baptis = _dbContext.Baptis.Where(x => x.Id == model.Id).FirstOrDefault();
                        if (baptis == null)
                            throw new SystemException("Data Baptis Tidak Ditemukan");
                        _dbContext.Entry(baptis).CurrentValues.SetValues(model);
                    }
                    await _dbContext.SaveChangesAsync();
                    return model;
                }

                throw new SystemException("Data Tidak Valid !");
            }
            catch (System.Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        public async Task<Sidi> PutSidi(int idjemaat, Sidi model)
        {
            try
            {
                var jemaat = _dbContext.Jemaat.Where(x => x.Id == idjemaat).FirstOrDefault();
                if (jemaat == null)
                    throw new SystemException("Data Jemaat tidak ditemukan !");

                if (ValidSuratSidi(model))
                {
                    if (model.DataBerkas != null && model.DataBerkas.Count() > 0)
                    {
                        var documentResult = await _documentService.SaveDocument(model.GetType(), model);
                        if (documentResult.Item1)
                        {
                            model.Berkas = documentResult.Item2;
                        }
                    }

                    if (model.Id <= 0)
                    {
                        model.Id = idjemaat;
                        _dbContext.Sidi.Add(model);
                    }
                    else
                    {
                        var sidi = _dbContext.Sidi.Where(x => x.Id == model.Id).FirstOrDefault();
                        if (sidi== null)
                            throw new SystemException("Data Baptis Tidak Ditemukan");
                        _dbContext.Entry(sidi).CurrentValues.SetValues(model);
                    }
                    await _dbContext.SaveChangesAsync();
                    return model;
                }

                throw new SystemException("Data Tidak Valid !");
            }
            catch (System.Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }
        public async Task<Nikah> PutNikah(int idjemaat, Nikah model)
        {
            try
            {
                var jemaat = _dbContext.Jemaat.Where(x => x.Id == idjemaat).FirstOrDefault();
                if (jemaat == null)
                    throw new SystemException("Data Jemaat tidak ditemukan !");

                if (ValidSuratNikah(model))
                {
                    if (model.DataBerkas != null && model.DataBerkas.Count() > 0)
                    {
                        var documentResult = await _documentService.SaveDocument(model.GetType(), model);
                        if (documentResult.Item1)
                        {
                            model.Berkas = documentResult.Item2;
                        }
                    }

                    if (model.Id <= 0)
                    {
                        model.Id = idjemaat;
                        _dbContext.Nikah.Add(model);
                    }
                    else
                    {
                        var nikah = _dbContext.Nikah.Where(x => x.Id == model.Id).FirstOrDefault();
                        if (nikah== null)
                            throw new SystemException("Data Baptis Tidak Ditemukan");
                        _dbContext.Entry(nikah).CurrentValues.SetValues(model);
                    }
                    await _dbContext.SaveChangesAsync();
                    return model;
                }

                throw new SystemException("Data Tidak Valid !");
            }
            catch (System.Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }


        private bool ValidateJemaat(Jemaat model)
        {
            try
            {
                bool isValid = true;
                StringBuilder sb = new StringBuilder();
                if (string.IsNullOrEmpty(model.Nama))
                {
                    sb.Append($"- Nomor Surat Tidak Boleh Kosong, \n");
                    isValid = false;
                }
                return isValid;

            }
            catch (System.Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        private bool ValidSuratBaptis(Baptis model)
        {
            try
            {
                bool isValid = true;
                StringBuilder sb = new StringBuilder();
                if (string.IsNullOrEmpty(model.NomorSurat))
                {
                    sb.Append($"- Nomor Surat Tidak Boleh Kosong, \n");
                    isValid = false;
                }
                return isValid;

            }
            catch (System.Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }
        private bool ValidSuratSidi(Sidi model)
        {
            try
            {
                bool isValid = true;
                StringBuilder sb = new StringBuilder();
                if (string.IsNullOrEmpty(model.NomorSurat))
                {
                    sb.Append($"- Nomor Surat Tidak Boleh Kosong, \n");
                    isValid = false;
                }
                return isValid;

            }
            catch (System.Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }


        private bool ValidSuratNikah(Nikah model)
        {
            try
            {
                bool isValid = true;
                StringBuilder sb = new StringBuilder();
                if (string.IsNullOrEmpty(model.NomorSurat))
                {
                    sb.Append($"- Nomor Surat Tidak Boleh Kosong, \n");
                    isValid = false;
                }
                return isValid;

            }
            catch (System.Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        private bool Valid(Jemaat model)
        {
            try
            {
                bool isValid = true;
                StringBuilder sb = new StringBuilder();
                if (string.IsNullOrEmpty(model.Nama))
                {
                    sb.Append($"- Nama Jemaat Tidak Boleh Kosong, \n");
                    isValid = false;
                }
                return isValid;

            }
            catch (System.Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }
    }
}