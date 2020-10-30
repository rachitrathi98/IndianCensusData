using System.IO;

namespace IndiaCensusDataDemo
{
    public class CensusAdapter
    {
        public string[] GetCensusData(string csvFilePath, string dataHeaders)
        {
            string[] censusData;
            if (!File.Exists(csvFilePath))
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.Exception.FILE_NOT_FOUND);
            if (Path.GetExtension(csvFilePath) != ".csv")
                throw new CensusAnalyserException("Invalid file type", CensusAnalyserException.Exception.INVALID_FILE_TYPE);
            censusData = File.ReadAllLines(csvFilePath);
            if (censusData[0] != dataHeaders)
            {
                throw new CensusAnalyserException("Incorrect header in Data", CensusAnalyserException.Exception.INCORRECT_HEADER);
            }
            return censusData;
        }
    }
}