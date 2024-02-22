using AutoMapper;
using Shop.Applicationn.Dto;
using Shop.Applicationn.IServices;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Applicationn.Services
{
    public class NotiService:INotiService
    {
        private readonly INotiRepo _repo;
        private readonly IMapper _mapper;
        public NotiService(IMapper mapper, INotiRepo repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public bool Create(NotificationDto dto)
        {
            return _repo.Add(_mapper.Map<Notification>(dto));
        }

        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }

        public List<NotificationDto> getAll(int id)
        {
            return _mapper.Map<List<NotificationDto>>(_repo.GetAll().Where(x=>x.UserId==id).OrderByDescending(x => x.NotificationId));
        }
        public List<NotificationDto> getAll()
        {
            return _mapper.Map<List<NotificationDto>>(_repo.GetAll().OrderByDescending(x => x.NotificationId));
        }

        public NotificationDto GetById(int id)
        {
            return _mapper.Map<NotificationDto>(_repo.GetById(id));
        }

        public bool Update(NotificationDto dto)
        {
            return _repo.Update(_mapper.Map<Notification>(dto));
        }
    }
}
