using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MarampaWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MarampaWebApi.Services
{
    public class RayonService
    {

        private ApplicationDbContext _dbContext;

        public RayonService(ApplicationDbContext db)
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

                _dbContext.Rayon.Remove(old);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                throw new MySqlErrorException(ex);
            }
        }

        internal async Task<bool> Put(int id, Rayon model)
        {
            try
            {
                ICollection<ValidationResult> errorResult;
                if (ValidateModel.Validate(model, out errorResult))
                {
                    var old = await Get(id);
                    if (old == null)
                        throw new SystemException("Data Tidak Ditemukan !");

                    old.Ketua = model.Ketua;
                    old.Sekertaris = model.Sekertaris;
                    old.Bendahara = model.Bendahara;
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
                throw new MySqlErrorException(ex);
            }
        }

        internal async Task<Rayon> Post(Rayon model)
        {

            try
            {
                ICollection<ValidationResult> errorResult;
                if (ValidateModel.Validate(model, out errorResult))
                {
                    _dbContext.Rayon.Add(model);
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
                throw new MySqlErrorException(ex);
            }
        }

        internal Task<Rayon> Get(int id)
        {
            return Task.FromResult(
                _dbContext.Rayon
                .Include(x => x.Ketua)
                .Include(x => x.Sekertaris)
                .Include(x => x.Bendahara)
                .SingleOrDefault(x => x.Id == id));
        }

        internal Task<IEnumerable<Rayon>> Get()
        {
            return Task.FromResult(_dbContext.Rayon.ToArray().AsEnumerable());
        }
    }
}