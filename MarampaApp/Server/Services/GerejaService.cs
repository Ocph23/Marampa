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
    public class GerejaService
    {

        private ApplicationDbContext _dbContext;

        public GerejaService(ApplicationDbContext db)
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

                _dbContext.Gereja.Remove(old);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        internal async Task<bool> Put(int id, Gereja model)
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

        internal async Task<Gereja> Post(Gereja model)
        {

            try
            {
                if (!_dbContext.Gereja.Any())
                {
                    ICollection<ValidationResult> errorResult;
                    if (ValidateModel.Validate(model, out errorResult))
                    {

                        _dbContext.Gereja.Add(model);
                        await _dbContext.SaveChangesAsync();
                        return model;
                    }
                    else
                    {
                        throw new ModelValidationException("Data Tidak Valid", errorResult);
                    }
                }
                else
                    throw new SystemException("Maaf Data Gereja Sudah Ada !");

            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        internal Task<Gereja> Get(int id)
        {
            return Task.FromResult(
                _dbContext.Gereja
                .SingleOrDefault(x => x.Id == id));
        }

        internal Task<IEnumerable<Gereja>> Get()
        {
            return Task.FromResult(_dbContext.Gereja.ToArray().AsEnumerable());
        }
    }
}