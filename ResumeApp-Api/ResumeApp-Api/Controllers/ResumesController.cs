using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BL;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using System.Drawing;
using Aspose.Words;
using DAL;

namespace ResumeApp_Api.Controllers
{
    [Route("api/[controller]")]
    public class ResumesController : Controller
    {
     
     
        [HttpPost("UploadResume")]
        public async Task<IActionResult> UploadingResumeAsync(IFormFile file)
        {
            if (file==null||file.Length <= 0)
                return BadRequest("Empty file");       
            //הסר כל מפרטי נתיב 
            var originalFileName = Path.GetFileName(file.FileName);
            var uniqueFileName = Path.Combine(@"my_files\", originalFileName);
            //צור נתיב קובץ ייחודי
            //var uniqueFileName = Path.GetRandomFileName();
            //uniqueFileName= Path.GetFileNameWithoutExtension(uniqueFileName);
            //uniqueFileName +=Path.GetExtension(originalFileName);
            //var uniqueFilePath = Path.Combine(@"my_files\", uniqueFileName);

            //שמור את הקובץ
            using (var stream = System.IO.File.Create(uniqueFileName))
            {
                await file.CopyToAsync(stream);
            }
            Resume r = AddingResume.BuildNewResume(uniqueFileName);
         
            //////DB - שמירה בקובץ ה
            AddingResume.SaveResumeInDB(r);
            return Ok($"Saved file {originalFileName} with size {file.Length / 1024m:#.00} KB, using unique name {uniqueFileName}");
        }



        //[HttpGet("search/{subject}")]
        //public IActionResult SearchResume(string subject)
        //{

        //    byte[] byteArray = Search.SearchBySubject(subject);
        //    if (byteArray != null)
        //    {
        //        return new FileContentResult(byteArray, "application/pdf");
        //    }
        //    else
        //        return StatusCode(500);
        //}

        [HttpGet("search/{subject}")]
        public ActionResult<string[]> SearchResume(string subject)
        {

            List<string> files = Search.SearchBySubject(subject);
            if (files.Count() > 0)
            {
                string[] filesArray = files.ToArray();
                return filesArray;
            }
            else
                return StatusCode(500);
        }





    }
}
