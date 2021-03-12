using System.Collections.Generic;
using System.Threading.Tasks;
using MarampaApp.Models;
using System.Linq;
using System;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MarampaApp.Server.Data;

namespace MarampaApp.Services
{
    public class JemaatService
    {
        private ApplicationDbContext _dbContext;

        public JemaatService(ApplicationDbContext db)
        {
            _dbContext = db;
        }

        public Task<IEnumerable<Jemaat>> Get()
        {
            var result = _dbContext.Jemaat
            .Include(x=>x.Keluarga)
            .AsEnumerable();
            return Task.FromResult(result);
        }


        public Task<Jemaat> Get(int id)
        {
            return Task.FromResult(_dbContext.Jemaat.Where(x=>x.Id==id).Include(x=>x.Keluarga).FirstOrDefault());
        }

        public async Task<Jemaat> Post(Jemaat model)
        {
            try
            {
                if (Valid(model))
                {
                    _dbContext.Jemaat.Add(model);
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