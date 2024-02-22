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
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepo _repo;
        private readonly IMapper _mapper;
        public DepartmentService(IMapper mapper,IDepartmentRepo repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public bool Create(DepartmentDto dto)
        {
            return _repo.Add(_mapper.Map<Department>(dto));
        }

        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }

        public List<DepartmentDto> getAll()
        {
            return _mapper.Map<List<DepartmentDto>>(_repo.GetAll().OrderByDescending(x=>x.DepartmentId));
        }

        public DepartmentDto GetById(int id)
        {
            return _mapper.Map<DepartmentDto>(_repo.GetById(id));
        }

        public bool Update(DepartmentDto dto)
        {
            return _repo.Update(_mapper.Map<Department>(dto));
        }
    }
}
