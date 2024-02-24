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
    public class PostService : IPostService
    {
        private readonly IPostRepo _repo;
        private readonly IMapper _mapper;
        private readonly IImagePostRepo _imagePostRepo;
        private readonly IUserRepo _userRepo;
        public PostService(IPostRepo repo, IMapper mapper, IImagePostRepo imagePostRepo, IUserRepo userRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _imagePostRepo = imagePostRepo;
            _userRepo = userRepo;
        }

        public bool Create(PostDto dto, IList<IFormFile> listFile, string url)
        {
            try
            {
                var newsContentEntity = _mapper.Map<Post>(dto);
                if (_repo.Add(newsContentEntity))
                {
                    var id = _repo.GetAll().LastOrDefault().PostId;
                    foreach (var file in listFile)
                    {
                        string path = ServiceImage.createImage(file);
                        if (!string.IsNullOrEmpty(path))
                        {
                            ImagePost image = new ImagePost()
                            {
                                PostId = id,
                                ImagePostUrl = path,
                                UrlApi = url
                            };
                            _imagePostRepo.Add(image);
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
            var listImage = _imagePostRepo.GetAll().Where(x => x.PostId == id).ToList();
            if (listImage != null)
            {
                foreach (var image in listImage)
                {
                    ServiceImage.deleteImage(image.ImagePostUrl);
                    _imagePostRepo.Delete(image.ImagePostId);
                }
            }
            return _repo.Delete(id);
        }

        public List<PostDto> getAll(int id)
        {
            return _mapper.Map<List<PostDto>>(_repo.GetAll().Where(x => x.UserId == id).OrderByDescending(x=>x.PostId));
        }
        public List<PostDto> getAlls()
        {
            return _mapper.Map<List<PostDto>>(_repo.GetAll().Where(x => x.IsStatus == false).OrderByDescending(x => x.PostId));
        }
        public List<Post_User_Dto> getAll()
        {
            var query = from post in _repo.GetAll().Where(x => x.IsStatus == true).OrderByDescending(x => x.PostId)
                        join
                       user in _userRepo.GetAll() on post.UserId equals user.UserId
                        select new Post_User_Dto
                        {
                            PostId = post.PostId,
                            FullName = user.FullName,
                            PostTittle = post.PostTittle,
                            PostContent = post.PostContent,
                            PostDate = post.PostDate,
                            IsStatus = post.IsStatus,
                            UserId= user.UserId
                        };
            return _mapper.Map<List<Post_User_Dto>>(query.OrderByDescending(x => x.PostId));
        }

        public Post_User_Dto GetById(int id)
        {
            var post = _repo.GetById(id);

            if (post == null)
            {
                return null;
            }

            var user = _userRepo.GetById(post.UserId);

            if (user == null)
            {
                return null;
            }

            var postUserDto = new Post_User_Dto
            {
                PostId = post.PostId,
                FullName = user.FullName,
                PostTittle = post.PostTittle,
                PostContent = post.PostContent,
                PostDate = post.PostDate,
                IsStatus = post.IsStatus,
                UserId = user.UserId
            };
            return _mapper.Map<Post_User_Dto>(postUserDto);
        }

        public bool Update(PostDto dto, List<ImagePostDto> ImagePostDtoList, IList<IFormFile> listFile, string url)
        {
            try
            {
                _repo.Update(_mapper.Map<Post>(dto));
                if (ImagePostDtoList != null)
                {
                    foreach (var item in ImagePostDtoList)
                    {
                        ServiceImage.deleteImage(item.ImagePostUrl);
                        _imagePostRepo.Delete(item.ImagePostId);
                    }
                }
                foreach (var file in listFile)
                {
                    string path = ServiceImage.createImage(file);
                    if (!string.IsNullOrEmpty(path))
                    {
                        ImagePost image = new ImagePost()
                        {
                            PostId = dto.PostId,
                            ImagePostUrl = path,
                            UrlApi = url
                        };
                        _imagePostRepo.Add(image);
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
