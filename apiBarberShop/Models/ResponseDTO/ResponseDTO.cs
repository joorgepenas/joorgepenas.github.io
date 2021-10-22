using Serilog;
using System;

namespace apiBarberShop.Models.ResponseDTO
{
    public class ResponseDTO
    {
        public int status { get; set; }
        public string description { get; set; }
        public object objModel { get; set; }
        public ResponseDTO Success(ResponseDTO obj, object objModel)
        {
            obj.description = "Transaction Sucessfully";
            obj.status = 1;
            obj.objModel = objModel;
            return obj;
        }
        public ResponseDTO Valid(ResponseDTO obj, object objModel, int status)
        {
            obj.description = "Transaction Sucessfully";
            obj.status = status;
            obj.objModel = objModel;
            return obj;
        }
        public ResponseDTO Failed(ResponseDTO obj, Exception e)
        {
            Log.Error("ERROR: Type {exception}, message {message}, cause {cause}", e.GetType(), e.Message, e.StackTrace);
            obj.description = e.Message;
            obj.status = 0;
            return obj;
        }
    }
}
