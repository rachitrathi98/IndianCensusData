using IndiaCensusDataDemo.DataDAO;
using IndiaCensusDataDemo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndiaCensusDataDemo
{
    public class IndianCensusAdapter : CensusAdapter
    {
        string[] censusData;
        Dictionary<string, CensusDTO> datamap;
        public Dictionary<string, CensusDTO> LoadCensusData(string csvFilePath, string dataHeaders)
        {
            datamap = new Dictionary<string, CensusDTO>();
            censusData = GetCensusData(csvFilePath, dataHeaders);
            foreach (string data in censusData.Skip(1))
            {
                if (!data.Contains(","))
                {
                    throw new CensusAnalyserException("File Containers Wrong Delimiter", CensusAnalyserException.Exception.INCORRECT_DELIMITER);
                }
                string[] coloumn = data.Split(",");
                if (csvFilePath.Contains("IndiaStateCode.csv"))
                    datamap.Add(coloumn[1], new CensusDTO(new StateCodeDataDAO(coloumn[0], coloumn[1], coloumn[2], coloumn[3])));
                if (csvFilePath.Contains("IndiaStateCensusData.csv"))
                    datamap.Add(coloumn[1], new CensusDTO(new CensusDataDAO(coloumn[0], coloumn[1], coloumn[2], coloumn[3])));
            }
            return datamap.ToDictionary(p => p.Key, p => p.Value);
        }

    }
}