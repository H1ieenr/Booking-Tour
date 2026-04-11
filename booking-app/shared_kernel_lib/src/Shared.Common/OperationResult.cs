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

        public static OperationResult<T> Created(T data, string message = "Đã tạo thành công") 
            => new() { IsSuccess = true, Data = data, Message = message, OperationType = OperationType.Create };

        public static OperationResult<T> Updated(T data, string message = "Đã cập nhật thành công") 
            => new() { IsSuccess = true, Data = data, Message = message, OperationType = OperationType.Update };

        public static OperationResult<T> Deleted(string message = "Đã xóa thành công") 
            => new() { IsSuccess = true, Message = message, OperationType = OperationType.Delete };

        public static OperationResult<T> Failure(string message, string? code = null, List<string>? errors = null) 
            => new() { IsSuccess = false, Message = message, Code = code, Errors = errors ?? new(), OperationType = OperationType.InternalError };
    
    }
}