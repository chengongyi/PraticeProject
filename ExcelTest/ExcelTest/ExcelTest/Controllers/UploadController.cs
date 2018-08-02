using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace ExcelTest.Controllers
{
    [RoutePrefix("Upload")]
    public class UploadController : ApiController
    {
        [Route("index")]
        [HttpPost]
        public string UploadFile()
        {
            HttpFileCollection filelist = HttpContext.Current.Request.Files;
            if (filelist == null || filelist.Count <= 0)
            {
                return string.Empty;
            }

            for (int index = 0; index < filelist.Count; index++)
            {
                var file = filelist[index]; 
                var filename = file.FileName;
                if (filename == "")
                {
                    continue;
                }
                file.SaveAs(@"E:\upload\" + filename);

                using (FileStream fs = File.OpenRead(@"E:\upload\" + filename)) //打开myxls.xls文件
                {

                    HSSFWorkbook wk = new HSSFWorkbook(fs); //把xls文件中的数据写入wk中
                    for (int i = 0; i < wk.NumberOfSheets; i++) //NumberOfSheets是myxls.xls中总共的表数
                    {
                        ISheet sheet = wk.GetSheetAt(i); //读取当前表数据
                        for (int j = 0; j <= sheet.LastRowNum; j++) //LastRowNum 是当前表的总行数
                        {
                            IRow row = sheet.GetRow(j); //读取当前行数据
                            if (row != null)
                            {
                                for (int k = 0; k <= row.LastCellNum; k++) //LastCellNum 是当前行的总列数
                                {
                                    ICell cell = row.GetCell(k); //当前表格
                                    if (cell != null)
                                    {

                                    }
                                }
                            }
                        }
                    }
                }

            }
            return "文件上传成功";
        }
    }
}
