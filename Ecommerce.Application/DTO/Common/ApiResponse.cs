using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DTO.Common
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = null!;

        public int StatusCode { get; set; }

        public T? Data { get; set; }

        /// <summary>
        /// 200 OK - Used for successful requests that return data (e.g., GET, PUT, PATCH).
        /// </summary>

        public static ApiResponse<T> SuccessResponse(T data,string message="Success")
        {
            return new ApiResponse<T>()
            {
                Success = true,
                Message = message,
                Data = data,
                StatusCode = 200
            };
        }

        /// <summary>
        /// 201 Created - Used when a new resource is successfully created (e.g., POST).
        /// </summary>
        public static ApiResponse<T> CreatedResponse(T? data, string message)
        {
            return new ApiResponse<T>()
            {
                Success = true,
                Message = message,
                Data = data,
                StatusCode = 201
            };
        }
        /// <summary>
        /// 204 No Content - Used when a request is successful, but there is nothing to return (e.g., DELETE).
        /// </summary>
        public static ApiResponse<T> NoContentResponse(string message = "Success with no content.")
        {
            return new ApiResponse<T>
            {
                Success = true,
                StatusCode = 204,
                Message = message,
                Data = default
            };
        }

        /// <summary>
        /// 400 Bad Request - Used when the client sends invalid data or a malformed request.
        /// </summary>
        public static ApiResponse<T> BadRequestResponse(string message = "Bad request.")
        {
            return new ApiResponse<T>
            {
                Success = false,
                StatusCode = 400,
                Message = message,
                Data = default
            };
        }

        /// <summary>
        /// 409 Bad Request - Used when the client sends invalid data or a malformed request.
        /// </summary>
        public static ApiResponse<T> ConflictResponse(string message = "Conflict")
        {
            return new ApiResponse<T>
            {
                Success = false,
                StatusCode = 409,
                Message = message,
                Data = default
            };
        }

        /// <summary>
        /// 401 Unauthorized - Used when authentication is required and has failed or hasn't been provided.
        /// </summary>
        public static ApiResponse<T> UnauthorizedResponse(string message = "Unauthorized access.")
        {
            return new ApiResponse<T>
            {
                Success = false,
                StatusCode = 401,
                Message = message,
                Data = default
            };
        }

        /// <summary>
        /// 403 Forbidden - Used when the client is authenticated but does not have permission to access the resource.
        /// </summary>
        public static ApiResponse<T> ForbiddenResponse(string message = "Access forbidden.")
        {
            return new ApiResponse<T>
            {
                Success = false,
                StatusCode = 403,
                Message = message,
                Data = default
            };
        }

        /// <summary>
        /// 404 Not Found - Used when the requested resource cannot be found on the server.
        /// </summary>
        public static ApiResponse<T> NotFoundResponse(string message = "Resource not found.")
        {
            return new ApiResponse<T>
            {
                Success = false,
                StatusCode = 404,
                Message = message,
                Data = default
            };
        }

        /// <summary>
        /// 500 Internal Server Error - Used when something goes wrong unexpectedly on your server.
        /// </summary>
        public static ApiResponse<T> FailureResponse(string message = "An internal server error occurred.", int statusCode = 500)
        {
            return new ApiResponse<T>
            {
                Success = false,
                StatusCode = statusCode,
                Message = message,
                Data = default
            };
        }

    }
}
