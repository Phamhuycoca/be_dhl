using AutoMapper;
using Microsoft.AspNetCore.Http;
using Shop.Applicationn.Dto;
using Shop.Applicationn.IServices;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucTap.Application.Helper;

namespace Shop.Applicationn.Services
{
    public class NewsContentService : INewsContentService
    {
        private readonly INewsContentRepo _repo;
        private readonly IMapper _mapper;
        private readonly IImageNewsRepo _imageNewsRepo;
        public NewsContentService(INewsContentRepo repo, IMapper mapper, IImageNewsRepo imageNewsRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _imageNewsRepo = imageNewsRepo;
        }

        public bool Create(NewsContentDto dto, IList<IFormFile> listFile,string url)
        {
            try
            {
                var newsContentEntity = _mapper.Map<NewsContent>(dto);
                if (_repo.Add(newsContentEntity))
                {
                    var id = _repo.GetAll().LastOrDefault().NewsContentId;
                    foreach (var file in listFile)
                    {
                        string path = ServiceImage.createImage(file);
                        if (!string.IsNullOrEmpty(path))
                        {
                            ImageNews image = new ImageNews()
                            {
                                NewsContentId = id,
                                ImageNewsUrl = path,
                                UrlApi = url
                            };
                            _imageNewsRepo.Add(image);
                        }
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }

        public bool Delete(int id)
        {
            var listImage=_imageNewsRepo.GetAll().Where(x=>x.NewsContentId== id).ToList();
            if (listImage != null)
            {
                foreach(var image in listImage)
                {
                    ServiceImage.deleteImage(image.ImageNewsUrl);
                    _imageNewsRepo.Delete(image.ImageNewsId);
                }
            }
            return _repo.Delete(id);
        }

        public List<NewsContentDto> getAll(int id)
        {
            return _mapper.Map<List<NewsContentDto>>(_repo.GetAll().Where(x=>x.NewsId==id));
        }

        public NewsContentDto GetById(int id)
        {
            return _mapper.Map<NewsContentDto>(_repo.GetById(id));
        }

        public bool Update(NewsContentDto dto, List<ImageNewsDto> ImageContentList, IList<IFormFile> listFile, string url)
        {
            try
            {
                 _repo.Update(_mapper.Map<NewsContent>(dto));
                if(ImageContentList != null)
                {
                    foreach (var item in ImageContentList)
                    {
                        ServiceImage.deleteImage(item.ImageNewsUrl);
                        _imageNewsRepo.Delete(item.ImageNewsId);
                    }
                }
                foreach (var file in listFile)
                {
                    string path = ServiceImage.createImage(file);
                    if (!string.IsNullOrEmpty(path))
                    {
                        ImageNews image = new ImageNews()
                        {
                            NewsContentId = dto.NewsContentId,
                            ImageNewsUrl = path,
                            UrlApi = url
                        };
                        _imageNewsRepo.Add(image);
                    }
                }
                //return _repo.Update(_mapper.Map<NewsContent>(dto));
                return true;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }
    }
}
