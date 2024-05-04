using System;
using System.Collections.Generic;
using MultiStore.Data;
using MultiStore.Models;

namespace MultiStore.Services
{
    public class ETLService
    {
        private readonly DatabaseContext _dbContext;
        private readonly ExcelReader _excelReader;

        public ETLService(DatabaseContext dbContext, ExcelReader excelReader)
        {
            _dbContext = dbContext;
            _excelReader = excelReader;
        }

        public void ExecuteETL(string filePath)
        {
            // Le os dados do arquivo
            List<MultiStoreModel> multiStoreModels = _excelReader.ReadExcel(filePath);

            // Insere os dados no banco
            _dbContext.MultiStore.AddRange(multiStoreModels);
            _dbContext.SaveChanges();
        }
    }
}
