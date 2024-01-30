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
    public class GenderService:IGenderService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;


        public GenderService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;

        }

        public async Task<ResponseDto> GetGenderList()
        {
            try
            {
                var genderInfo = await _db.tblGender.ToListAsync();

                if (genderInfo == null || !genderInfo.Any())
                {
                    return new ResponseDto { Success = false, Message = "No list of student found" };
                }

                var students = _mapper.Map<IEnumerable<GenderDto>>(genderInfo);

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
