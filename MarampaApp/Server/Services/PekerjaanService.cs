using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MarampaApp.Models;
using MarampaApp.Server.Data;

namespace MarampaApp.Services
{
    public class PekerjaanService
    {

        private ApplicationDbContext _dbContext;

        public PekerjaanService(ApplicationDbContext db)
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

                _dbContext.Pekerjaan.Remove(old);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        internal async Task<bool> Put(int id, Pekerjaan model)
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

        internal async Task<Pekerjaan> Post(Pekerjaan model)
        {

            try
            {
                ICollection<ValidationResult> errorResult;
                if (ValidateModel.Validate(model, out errorResult))
                {
                    _dbContext.Pekerjaan.Add(model);
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

        internal Task<Pekerjaan> Get(int id)
        {
            return Task.FromResult(_dbContext.Pekerjaan.SingleOrDefault(x => x.Id == id));
        }

        internal Task<IEnumerable<Pekerjaan>> Get()
        {
            return Task.FromResult(_dbContext.Pekerjaan.AsEnumerable());
        }
    }
}