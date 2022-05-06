using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;





// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ResumeApp_Api.Controllers
{
    [Route("api/[controller]")]
    public class ResumesController : Controller
    {
        // GET: api/<controller>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}


        // PUT api/<controller>/
        [HttpPut("api/[controller]")]
        //public void UploadResume(FileStream f)
        //{
        //    //שמירת הקובץ עצמו בשרת
        //    string path;
        //  // BL.Resume r= BL.AddingResume.BuildNewResume(path);
        //    //DB - שמירה בקובץ ה 
        //   // BL.AddingResume.SaveResumeInDB(r);
        //}

        //GET api/<controller>/5
        [HttpGet("{subject}")]
        public File[] SearchBySubject(string subject)
        { 
            File[] files = BL.SearchBySubject(subject);
               return files;
       }
        

    }
}
