using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MarampaApp.Models;
using MarampaApp.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace MarampaApp.Services
{
    public class TahunPelayananService
    {

        private ApplicationDbContext _dbContext;

        public TahunPelayananService(ApplicationDbContext db)
        {
            _dbContext = db;
        }

        internal async Task<bool> Delete(int id)
        {
            try
            {
                var old = await Get(id);
                if (old == null)
                    throw new SystemException("Data Tidak Ditemukan !");

                _dbContext.TahunPelayanan.Remove(old);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        internal Task<TahunPelayanan> GetTahunPelayananActive()
        {
            var data = _dbContext.TahunPelayanan.SingleOrDefault(x => x.Aktif);
            return Task.FromResult(data);
        }

        internal async Task<bool> Put(int id, TahunPelayanan model)
        {
            try
            {
                ICollection<ValidationResult> errorResult;
                if (ValidateModel.Validate(model, out errorResult))
                {
                    var old = await Get(id);
                    if (old == null)
                        throw new SystemException("Data Tidak Ditemukan !");

                    _dbContext.Entry(old).CurrentValues.SetValues(model);
                    await _dbContext.SaveChangesAsync();
                    return true;
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

        internal async Task<TahunPelayanan> Post(TahunPelayanan model)
        {

            var trans = _dbContext.Database.BeginTransaction();

            try
            {
                ICollection<ValidationResult> errorResult;
                if (ValidateModel.Validate(model, out errorResult))
                {
                    await _dbContext.TahunPelayanan.ForEachAsync(x => x.Aktif = false);
                    _dbContext.TahunPelayanan.Add(model);
                    await _dbContext.SaveChangesAsync();
                    await trans.CommitAsync();
                    return model;
                }
                else
                {
                    throw new ModelValidationException("Data Tidak Valid", errorResult);
                }
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                throw new SystemException(ex.Message);
            }
        }

        internal Task<TahunPelayanan> Get(int id)
        {
            return Task.FromResult(
                _dbContext.TahunPelayanan
                .SingleOrDefault(x => x.Id == id));
        }

        internal Task<IEnumerable<TahunPelayanan>> Get()
        {
            return Task.FromResult(_dbContext.TahunPelayanan.ToArray().AsEnumerable());
        }
    }
}