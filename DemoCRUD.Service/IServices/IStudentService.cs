using DemoCRUD.DTO.ModelDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCRUD.Service.IServices
{
    public interface IStudentService
    {
        Task<ResponseDto> GetStudentList();
        Task<ResponseDto> DeleteStudent(int Id);

        Task<ResponseDto> CreateStudent(StudentsDto studentsDto);
        Task<ResponseDto> UpdateStudent(StudentsDto studentsDto);
        Task<ResponseDto> GetStudentInfoById(int id);
    }
}
