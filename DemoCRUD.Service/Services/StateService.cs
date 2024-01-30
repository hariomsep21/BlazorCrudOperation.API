using AutoMapper;
using DemoCRUD.Data.DataContext;
using DemoCRUD.DTO.ModelDtos;
using DemoCRUD.Model.Models;
using DemoCRUD.Service.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCRUD.Service.Services
{
    public class StateService:IStateService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;


        public StateService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;

        }

        public async Task<ResponseDto> GetStateList()
        {
            try
            {
                var stateInfo = await _db.tblState.ToListAsync();

                if (stateInfo == null || !stateInfo.Any())
                {
                    return new ResponseDto { Success = false, Message = "No list of student found" };
                }

                var students = _mapper.Map<IEnumerable<StateDto>>(stateInfo);

                return new ResponseDto
                {
                    Success = true,
                    Data = students
                };
            }
            catch (Exception ex)
            {

                return new ResponseDto
                {
                    Success = false,
                    Message = $"Internal Server Error:{ex.Message}",
                };
            }
        }
    }
}
