using Shop.Applicationn.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Applicationn.IServices
{
    public interface INotiService 
    {
        List<NotificationDto> getAll(int id);
        List<NotificationDto> getAll();
        NotificationDto GetById(int id);
        bool Create(NotificationDto dto);
        bool Update(NotificationDto dto);
        bool Delete(int id);
    }
}
