using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using ExcelDataReader;
using Microsoft.EntityFrameworkCore;
using MultiStore.Models;

namespace MultiStore.Data
{
    public class ExcelReader
    {
        public List<MultiStoreModel> ReadExcel(string filePath)
        {
            List<MultiStoreModel> multiStoreModels = new List<MultiStoreModel>();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    // Deleta base de dados anterior
                    using (var db = new DatabaseContext())
                    {
                        db.Database.ExecuteSqlRaw("TRUNCATE TABLE stage.MultiStore");
                    }
                    // Lê a linha dos nomes das colunas para não dar erro de converter string pra int
                    reader.Read();

                    // Lê as linhas seguintes do arquivo
                    while (reader.Read())
                    {
                        MultiStoreModel multiStoreModel = new MultiStoreModel
                        {
                            RowID = Convert.ToInt32(reader.GetValue(0)),
                            OrderID = reader.GetString(1),
                            OrderDate = Convert.ToInt32(reader.GetValue(2)),
                            ShipDate = Convert.ToInt32(reader.GetValue(3)),
                            ShipMode = reader.GetString(4),
                            CustomerID = reader.GetString(5),
                            CustomerName = reader.GetString(6),
                            CustomerAge = Convert.ToInt32(reader.GetValue(7)),
                            CustomerBirthday = reader.GetString(8),
                            CustomerState = reader.GetString(9),
                            Segment = reader.GetString(10),
                            Country = reader.GetString(11),
                            City = reader.GetString(12),
                            State = reader.GetString(13),
                            RegionalManagerID = reader.GetString(14),
                            RegionalManager = reader.GetString(15),
                            PostalCode = Convert.ToInt32(reader.GetValue(16)),
                            Region = reader.GetString(17),
                            ProductID = reader.GetString(18),
                            Category = reader.GetString(19),
                            SubCategory = reader.GetString(20),
                            ProductName = reader.GetString(21),
                            Sales = Convert.ToDecimal(reader.GetValue(22)),
                            Quantity = Convert.ToInt32(reader.GetValue(23)),
                            Discount = Convert.ToDecimal(reader.GetValue(24)),
                            Profit = Convert.ToDecimal(reader.GetValue(25))
                        };

                        multiStoreModels.Add(multiStoreModel);
                    }
                }
            }

            // Move o arquivo com o nome alterado
            string today = DateTime.Now.ToString("yyyy-MM-dd");
            string processedFolder = Path.Combine(Path.GetDirectoryName("C:\\IagoTestes\\MultiStore\\MultiStore\\Arquivos\\"), "ArquivosProcessados");
            Directory.CreateDirectory(processedFolder);
            string processedFilePath = Path.Combine(processedFolder, $"stage_MultiStore-{today}.xlsx");
            File.Move(filePath, processedFilePath);

            using (var db = new DatabaseContext())
            {
                ImportLog importLog = new ImportLog
                {
                    OriginalFileName = Path.GetFileName(filePath),
                    CurrentFileName = Path.GetFileName(processedFilePath),
                    ImportDate = DateTime.Now
                };
                db.ImportLogs.Add(importLog);
                db.SaveChanges();
            }

            return multiStoreModels;
        }
    }
}
