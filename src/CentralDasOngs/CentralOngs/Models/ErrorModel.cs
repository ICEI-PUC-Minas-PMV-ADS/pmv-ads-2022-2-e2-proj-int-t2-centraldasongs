using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CentralOngs.Models
{
    public class ErrorModel : ModelError
    {
        public ErrorModel(Exception exception) : base(exception)
        {
        }
    }
}
