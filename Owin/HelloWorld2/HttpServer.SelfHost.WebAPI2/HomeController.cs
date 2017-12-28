using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HttpServer.SelfHost.WebAPI2
{
    [RoutePrefix("home")]
    public class HomeController : ApiController
    {
        /// <summary>
        /// 上传文件 使用上传后的默认文件名称
        /// 默认名称是BodyPart_XXXXXX，BodyPart_加Guid码
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("Upload")]
        public async Task<string> Upload()
        {
            try
            {
                //web api 获取项目根目录下指定的文件下
                var root = @"E:\upload";
                var provider = new MultipartFormDataStreamProvider(root);

                //文件已经上传  但是文件没有后缀名  需要给文件添加后缀名
                await Request.Content.ReadAsMultipartAsync(provider);

                foreach (var file in provider.FileData)
                {
                    //这里获取含有双引号'" '
                    string filename = file.Headers.ContentDisposition.FileName.Trim('"');
                    //获取对应文件后缀名
                    string fileExt = filename.Substring(filename.LastIndexOf('.'));

                    FileInfo fileinfo = new FileInfo(file.LocalFileName);
                    //fileinfo.Name 上传后的文件路径 此处不含后缀名 
                    //修改文件名 添加后缀名
                    string newFilename = fileinfo.Name + fileExt;
                    //最后保存文件路径
                    string saveUrl = Path.Combine(root, newFilename);
                    fileinfo.MoveTo(saveUrl);
                }
                return "success";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("link")]
        // GET api/values 
        public IHttpActionResult Get()
        {
            return Ok(125);
        }
        // GET api/values/5 
        public string Get(int id)
        {
            return "value";
        }
        // POST api/values 
        public void Post([FromBody]string value)
        {
        }
        // PUT api/values/5 
        public void Put(int id, [FromBody]string value)
        {
        }
        // DELETE api/values/5 
        public void Delete(int id)
        {
        }
    }
}
