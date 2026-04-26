namespace Shared.Common
{
    public class OperationResult<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public string? Code { get; set; }
        public T? Data { get; set; }
        public OperationType OperationType { get; set; }
        public List<string> Errors { get; set; } = new();
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public static OperationResult<T> Success(T data, string message = "Thành công") 
            => new() { IsSuccess = true, Data = data, Message = message, OperationType = OperationType.Read };

        public static OperationResult<T> Created(T data, string message = "Thêm thành công") 
            => new() { IsSuccess = true, Data = data, Message = message, OperationType = OperationType.Create };

        public static OperationResult<T> Updated(T data, string message = "Cập nhật thành công") 
            => new() { IsSuccess = true, Data = data, Message = message, OperationType = OperationType.Update };

        public static OperationResult<T> Deleted(string message = "Xóa thành công") 
            => new() { IsSuccess = true, Message = message, OperationType = OperationType.Delete };
        public static OperationResult<T> Nodata(T data, string message = "Không có dữ liệu! ") 
            => new() { IsSuccess = false, Data = data, Message = message, Code = "NOT_FOUND", OperationType = OperationType.InternalError };
    
        public static OperationResult<T> Failure(string message = "Có lỗi xảy ra! ", string? code = null, List<string>? errors = null) 
            => new() { IsSuccess = false, Message = message, Code = code, Errors = errors ?? new(), OperationType = OperationType.InternalError };
    
    }
}