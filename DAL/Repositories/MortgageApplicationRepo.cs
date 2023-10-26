using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Repositories.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class MortgageApplicationRepo : IMortgageApplicationRepo
    {
        private readonly BuyersContext _db;

        public MortgageApplicationRepo(BuyersContext db)
        {
            _db = db;
        }

        public List<MortgageApplication> GetAllByBuyerId(int id)
        {
            return _db.Applications
                .Where(a => a.BuyerID == id)
                .ToList();
        }

        public MortgageApplication GetById(int id)
        {
            return _db.Applications.FirstOrDefault(h => h.ID == id);
        }

        public MortgageApplication Create(MortgageApplication application)
        {
            _db.Applications.Add(application);
            _db.SaveChanges();
            return application;
        }
    }
}
