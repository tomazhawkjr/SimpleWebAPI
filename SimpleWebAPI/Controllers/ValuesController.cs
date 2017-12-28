using SimpleWebAPI.API.Infrastructure.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SimpleWebAPI.Entities;
using SimpleWebAPI.API.Infrastructure.Http;
using SimpleWebAPI.BLL;


    
namespace SimpleWebAPI.Controllers
{
    [RoutePrefix("api/Values")]
    public class ValuesController : BaseApiController
    {

        // GET api/Values/Get
        [Route("Get")]
        public ServiceHttpResult Get(int id)
        {
            ValuesBusiness valuesBusiness = new ValuesBusiness();

            try
            {
                Values value = valuesBusiness.Get(id);

                if (value != null)
                {
                    return this.Success(string.Empty, value);
                }
                else{
                    return this.Error("Nenhum valor encontrado com este Id.");
                }

                
            }
            catch (Exception e)
            {
                return this.Error("Um erro ocorreu", e);
            }

      
        }

   
        [Route("Add")]
        // POST api/Values/Add
        public ServiceHttpResult Add(string value)
        {
            try
            {
                ValuesBusiness valuesBusiness = new ValuesBusiness();

                Values valueAdd = new Values { Value = value };
                valuesBusiness.Insert(valueAdd);

                return this.Success("Value added.", valueAdd);
            }
            catch (Exception e)
            {
                return this.Error("Um erro ocorreu", e);
                
            }
        }

    }
}
