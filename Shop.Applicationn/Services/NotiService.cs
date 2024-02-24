using AutoMapper;
using Shop.Applicationn.Dto;
using Shop.Applicationn.IServices;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;
using Shop.Infrastructure.Migrations;
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
        private readonly IUserRepo _userRepo;
        public NotiService(IMapper mapper, INotiRepo repo,IUserRepo userRepo)
        {
            _mapper = mapper;
            _repo = repo;
            _userRepo = userRepo;
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
        public List<NotiUser> getAll()
        {
            var query = from noti in _repo.GetAll().Where(x=>x.Status==0).OrderByDescending(x => x.NotificationId) join
                      user in _userRepo.GetAll() on noti.UserIdComment equals user.UserId
                        select new NotiUser
                        {
                            Avatar=user.Avatar,
                            UserId=noti.UserId,
                            FullName=user.FullName,
                            NewsId=noti.NewsId,
                            PostId=noti.PostId,
                            NotificationId=noti.NotificationId,
                            Status=noti.Status,
                            UserIdComment=noti.UserIdComment,
                        };
                      
            return query.ToList();
        }

        public NotificationDto GetById(int id)
        {
            return _mapper.Map<NotificationDto>(_repo.GetById(id));
        }

        public bool SeenNoti(int id)
        {
            var notis = _mapper.Map<List<NotificationDto>>(_repo.GetAll().Where(x => x.UserId == id));
            foreach (var item in notis)
            {
                item.Status = 1;
                _repo.Update(_mapper.Map<Notification>(item));
            }
            return true;
        }

        public bool Update(NotificationDto dto)
        {
            return _repo.Update(_mapper.Map<Notification>(dto));
        }
    }
}
