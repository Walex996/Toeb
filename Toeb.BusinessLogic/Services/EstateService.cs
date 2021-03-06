﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Toeb.DataAccess.EF;
using Toeb.DataAccess.Repositories;
using Toeb.Model.ViewModels;

namespace Toeb.BusinessLogic.Services
{
    public interface IEstateService
    {
        void Create(EstateModel model);
        void Update(EstateModel model);
        void Delete(int id);
        IEnumerable<EstateItem> GetAll();
        EstateModel GetById(int id);
        EstateItem GetDetails(int id);
    }
    public class EstateService: IEstateService
    {
        private readonly IEstateRepository _estateRepository;

        public EstateService(IEstateRepository estateRepository)
        {
            _estateRepository = estateRepository;
        }

        public void Create(EstateModel model)
        {
            try
            {
                if (_estateRepository.NameExist(model))
                    throw new Exception("Estate already exist");

                //var estate = new Estate()
                //{
                //    Name = model.Name,
                //    Address = model.Address,
                //    City = model.City

                //};
                var estate = Mapper.Map<EstateModel, Estate>(model);
                _estateRepository.Insert(estate);
            }
            catch (Exception ec)
            {
                throw new Exception(ec.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var estate = _estateRepository.Find(id);
                if(estate == null) throw new Exception("Estate not found");

                _estateRepository.Delete(id);
            }
            catch (Exception ec)
            {

                throw new Exception(ec.Message);
            }
        }

        public void Update(EstateModel model)
        {
            try
            {
                if(_estateRepository.NameExist(model))
                    throw new Exception("Estate already Exist");

                var estate = _estateRepository.Find(model.Id);
                if (estate == null)
                {
                    throw new Exception("Estate not found");
                }

                //estate.Name = model.Name;
                //estate.Address = model.Address;
                //estate.City = model.City;
                Mapper.Map(model, estate);
                _estateRepository.Update(estate);
            }
            catch (Exception ec)
            {

                throw new Exception(ec.Message);
            }

        }

        public IEnumerable<EstateItem> GetAll()
        {
            //return _estateRepository.GetAll().Select(c => new EstateItem()
            //{
            //    Id = c.Id,
            //    Name = c.Name,
            //    City = c.City,

            //});
            var entities = _estateRepository.Table.ToList();
            return Mapper.Map<IEnumerable<Estate>, IEnumerable<EstateItem>>(entities);

        }

        public EstateModel GetById(int id)
        {
            try
            {
                var estate = _estateRepository.Find(id);
                if(estate == null) throw new Exception("Estate not found");

                //return new EstateModel() {Id = estate.Id, Name = estate.Name};
                return Mapper.Map<Estate, EstateModel>(estate);
            }
            catch (Exception ec)
            {

                throw new Exception(ec.Message);
            }
        }

        public EstateItem GetDetails(int id)
        {
            try
            {
                var estate = _estateRepository.Find(id);
                if(estate == null) throw new Exception("Estate not found");

                //return new EstateItem()
                //{
                //    Id = estate.Id,
                //    Name = estate.Name,

                //};
                return Mapper.Map<Estate, EstateItem>(estate);
            }
            catch (Exception ec)
            {

                throw new Exception(ec.Message);
            }
        }
    }
}
