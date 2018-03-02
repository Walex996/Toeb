using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Toeb.DataAccess.EF;
using Toeb.DataAccess.Repositories;
using Toeb.Model.ViewModels;

namespace Toeb.BusinessLogic.Services
{
    public interface IComplaintService
    {
        void Create(ComplaintModel model);
        void Update(ComplaintModel model);
        void Delete(int id);
        IEnumerable<ComplaintItem> GetAll();
        ComplaintModel GetById(int id);
        ComplaintItem GetDetails(int id);
    }
    public class ComplaintService: IComplaintService
    {
        private readonly IComplaintRepository _complaintRepository;

        public ComplaintService(IComplaintRepository complaintRepository)
        {
            _complaintRepository = complaintRepository;
        }

        public void Create(ComplaintModel model)
        {
            try
            {
                if (_complaintRepository.NameExist(model))
                {
                    throw new Exception("Complaint Already exist");
                }

                var complaint = Mapper.Map<ComplaintModel, Complaint>(model);
                _complaintRepository.Insert(complaint);
            }
            catch (Exception ec)
            {

                throw new Exception(ec.Message);
            }
        }

        public void Update(ComplaintModel model)
        {
            try
            {
                if (_complaintRepository.NameExist(model))
                {
                    throw new Exception("Complaint already exist");
                }
                var complaint = _complaintRepository.Find(model.Id);
                if (complaint == null) throw new Exception("Complaint not found");

                Mapper.Map(model, complaint);
                _complaintRepository.Update(complaint);
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
                var complaint = _complaintRepository.Find(id);
                if(complaint == null) throw new Exception("Complaint not found");

                _complaintRepository.Delete(complaint);
            }
            catch (Exception ec)
            {

                throw new Exception(ec.Message);
            }
        }

        public IEnumerable<ComplaintItem> GetAll()
        {
            var complaint = _complaintRepository.Table.ToList();
            return Mapper.Map<IEnumerable<Complaint>, IEnumerable<ComplaintItem>>(complaint);
        }

        public ComplaintModel GetById(int id)
        {
            try
            {
                var complaint = _complaintRepository.Find(id);
                if(complaint == null) throw new Exception("Complaint not found");

                return Mapper.Map<Complaint, ComplaintModel>(complaint);
            }
            catch (Exception ec)
            {

                throw new Exception(ec.Message);
            }
        }

        public ComplaintItem GetDetails(int id)
        {
            try
            {
                var complaint = _complaintRepository.Find(id);
                if (complaint == null) throw new Exception("Complaint not found");

                return Mapper.Map<Complaint, ComplaintItem>(complaint);
            }
            catch (Exception ec)
            {

                throw new Exception(ec.Message);
            }
        }
    }
}
