using System.Collections.Generic;
using System.Threading.Tasks;
using MarampaApp.Models;
using System.Linq;
using System;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using MarampaApp.Server.Data;

namespace MarampaApp.Services
{
    public class KeluargaService
    {
        private ApplicationDbContext _dbContext;

        public KeluargaService(ApplicationDbContext db)
        {
            _dbContext = db;
        }

        public Task<IEnumerable<Keluarga>> Get()
        {
            var result = _dbContext.Keluarga
            .Include(x=>x.Rayon)
            .Include(x => x.Jemaat).Where(t => t.Jemaat.Any(t => t.HubunganKeluarga == HubunganKeluarga.KepalaKeluarga))
            .AsEnumerable();
            return Task.FromResult(result);
        }


        public Task<Keluarga> Get(int id)
        {
            return Task.FromResult(
                _dbContext.Keluarga
                .Include(x=>x.Rayon)
                .Include(x => x.Jemaat).ThenInclude(x=>x.Pekerjaan)
                .SingleOrDefault(x => x.Id == id));
        }

        internal async Task<Keluarga> Post(Keluarga model)
        {
            try
            {
                if (Valid(model))
                {

                    var kepala = model.Jemaat.FirstOrDefault();
                    if (kepala == null)
                        throw new SystemException("Kepala Keluarga Tiak Ditemukan");

                    kepala.HubunganKeluarga = HubunganKeluarga.KepalaKeluarga;
                    _dbContext.Entry(model.Rayon).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                    _dbContext.Keluarga.Add(model);

                    foreach (var item in model.Jemaat)
                    {
                        _dbContext.Entry(item.Pekerjaan).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
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

        internal async Task<bool> DeleteAnggota(int kkid, int id)
        {
            try
            {

                var jemaat = _dbContext.Jemaat.SingleOrDefault(x => x.Id == id);
                if (jemaat == null)
                    throw new SystemException("Data Jemaat Tidak Ditemukan");

                _dbContext.Jemaat.Remove(jemaat);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        internal async Task<Jemaat> TambahAnggota(int keluargaid, Jemaat model)
        {
            try
            {

                var keluarga = await Get(keluargaid);
                if (keluarga == null)
                    throw new SystemException("Data Keluarga Tidak Ditemukan");

                ICollection<ValidationResult> errorResult;
                if (ValidateModel.Validate(model, out errorResult))
                {
                    keluarga.Jemaat.Add(model);
                    await _dbContext.SaveChangesAsync();
                    return model;
                }
                else
                {
                    throw new ModelValidationException("Data Tidak Valid", errorResult);
                }

            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        private bool ValidJemaat(Jemaat model)
        {
            try
            {
                bool isValid = true;
                StringBuilder sb = new StringBuilder();
                if (string.IsNullOrEmpty(model.Nama))
                {
                    sb.Append($"- Nama Tidak Boleh Kosong, \n");
                    isValid = false;
                }

                if (model.HubunganKeluarga == HubunganKeluarga.None)
                {
                    sb.Append($"- Hubungan Dengan Kepala Keluarga Tidak Boleh Kosong, \n");
                    isValid = false;
                }

                if (model.TanggalLahir == null)
                {
                    sb.Append($"- Tanggal Lahir Tidak Boleh Kosong, \n");
                    isValid = false;
                }

                return isValid;

            }
            catch (System.Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        private bool Valid(Keluarga model)
        {
            try
            {
                bool isValid = true;
                StringBuilder sb = new StringBuilder();
                if (string.IsNullOrEmpty(model.NomorKartuKeluarga))
                {
                    sb.Append($"- Kepala Keluarga Tidak Boleh Kosong, \n");
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