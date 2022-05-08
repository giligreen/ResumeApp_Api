using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BL;
using System.Net.Http;
using Microsoft.AspNetCore.Http;





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
        [HttpPost("api/[controller]/UploadResume")]
        public void UploadResume()
        {

            //שמירת הקובץ עצמו בשרת
            string path = "";
            Resume r = AddingResume.BuildNewResume(path);
            //DB - שמירה בקובץ ה
            AddingResume.SaveResumeInDB(r);
        }


        //[HttpPost("api/[controller]/UploadResume")]
        //public async Task<IActionResult> UploadResumeAsync([FromForm] IFormFile file)
        //{
        //    if (file == null || file.Length == 0)
        //    {
        //        return BadRequest();
        //    }

        //   //ReturnsVariable returnsV = new ReturnsVariable();


        //    using (var memoryStream = new MemoryStream())
        //    {
        //        await file.CopyToAsync(memoryStream);
        //        using (var image = Image.FromStream(memoryStream))
        //        {
        //            returnsV = manager.FunctionManager(image);

        //            if (returnsV.flg)
        //            {

        //                return Ok(ColorsListString);
        //            }
        //        }
        //        return BadRequest();
        //    }
        //}



        ////GET api/<controller>/5
        //[HttpGet("{subject}")]
        //public File[] SearchBySubject(string subject)
        //{
        //    File[] files = BL.SearchBySubject(subject);
        //    return files;
        //}



        //GET api/<controller>
        [HttpGet]
        public string SearchBySubject()
        {
            return "aaaa";
        }

    }
}
