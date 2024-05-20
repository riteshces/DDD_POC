namespace POC_Invoicemgmt.Common
{
    public class ApiResponse<T>
    {
        public string Status { get; set; }
        public int ResponseCode { get; set; }

        public T Data { get; set; }

        public ApiResponse(string status, int responsecode, T data)
        {
            Status = status;
            ResponseCode = responsecode;
            Data = data;
        }
    }
}
