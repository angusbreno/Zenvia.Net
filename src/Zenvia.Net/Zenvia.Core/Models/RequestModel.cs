using RestSharp;
using System;
using Zenvia.Validation;

namespace Zenvia.Models
{
    public abstract class RequestModel<TModel> where TModel : IValidate
    {
        public RequestModel(TModel model)
        {
            Data = model;
        }

        public TModel Data { get; set; }

        public void Validate()
        {
            if (Data == null)
            {
                throw new Exception("Data is null");
            }

            Data.Validate();
        }

        public abstract void Bind(IRestRequest request);
    }
}
