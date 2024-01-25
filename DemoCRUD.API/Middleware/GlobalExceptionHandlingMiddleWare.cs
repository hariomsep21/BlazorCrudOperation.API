
using DemoCRUD.DTO.ModelDtos;
using System.Net;
using System.Text.Json;

namespace DemoCRUD.API.Middleware
{
    public class GlobalExceptionHandlingMiddleWare
    {
        private readonly RequestDelegate _next;
        public GlobalExceptionHandlingMiddleWare(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var response = context.Response;
            ResponseDto exModel = new ResponseDto();
            switch (exception)
            {
                case ApplicationException ex:
                    exModel.ResponseCode = (int)HttpStatusCode.BadRequest;
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    exModel.Message = "Application exception occur. Please try after some time ";
                    break;
                case FileNotFoundException ex:
                    exModel.ResponseCode = (int)HttpStatusCode.NotFound;
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    exModel.Message = "The request resource is not found";
                    break;
                default:
                    exModel.ResponseCode = (int)HttpStatusCode.InternalServerError;
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    exModel.Message = "Internal server error.Please retry after some time ";
                    break;

            }
            var exResult =JsonSerializer.Serialize(exModel);
            await context.Response.WriteAsync(exResult);
        }
    }
}
