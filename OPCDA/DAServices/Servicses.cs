using CsvHelper;
using OpcCom;
using OPCDA.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ConfigDB.DBContext;
using ConfigDB.Entity;
using System.Diagnostics;

namespace OPCDA.DAServices
{
    public class Servicses
    {
       public async Task SaveNodeServiceAsync(string machineName,string filePath)
        {
            List<DANodeInfoModel> nodeInfos=new List<DANodeInfoModel>();

            //using (var reader = new StreamReader("./NodeFiles/Core1.csv"))
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<DANodeInfoMap>();

                //SqlLiteDBContext sqlLite = new SqlLiteDBContext();
                await foreach (var item in csv.GetRecordsAsync<DANodeInfo>())
                {
                    nodeInfos.Add(new DANodeInfoModel()
                    {
                        Address = item.Address,
                        Tag_Name = item.Tag_Name,
                        MachineName = machineName

                    });
                    
                }
            }


            using SqlLiteDBContext sqlLite = new SqlLiteDBContext();
            await sqlLite.dANodeInfoModels.AddRangeAsync(nodeInfos);
            //var res = sqlLite.SaveChanges();

           var res = await sqlLite.SaveChangesAsync();
               
            

        }
    }
}
