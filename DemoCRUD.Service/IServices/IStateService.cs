using DemoCRUD.DTO.ModelDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCRUD.Service.IServices
{
    public interface IStateService
    {
        Task<ResponseDto> GetStateList();
    }
}
