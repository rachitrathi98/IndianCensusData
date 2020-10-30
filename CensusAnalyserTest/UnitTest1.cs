using IndiaCensusDataDemo;
using IndiaCensusDataDemo.DTO;
using NUnit.Framework;
using System.Collections.Generic;

namespace CensusAnalyserTest
{
    public class Tests
    {
        public string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        public string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        public string indianStateCensusFilePath = @"C:\Users\rathi\source\repos\IndiaCensusDataDemo\IndiaCensusDataDemo\CSVFiles\IndiaStateCensusData.csv";
        public string wrongHeaderIndianCensusFilePath = @"C:\Users\rathi\source\repos\IndiaCensusDataDemo\IndiaCensusDataDemo\CSVFiles\WrongIndiaStateCensusData.csv";
        public string delimeterIndianCensusFilePath = @"C:\Users\rathi\source\repos\IndiaCensusDataDemo\IndiaCensusDataDemo\CSVFiles\DelimiterIndiaStateCensusData.csv";
        public string wrongIndianStateCensusFilePath = @"C:\Users\rathi\source\repos\IndiaCensusDataDemo\IndiaCensusDataDemo\CSVFiles\IndiaData.csv";
        public string wrongIndianStateCensusFileType = @"C:\Users\rathi\source\repos\IndiaCensusDataDemo\IndiaCensusDataDemo\CSVFiles\WrongIndiaStateCensusData.csv";
        public string indianStateCodeFilePath = @"C:\Users\rathi\source\repos\IndiaCensusDataDemo\IndiaCensusDataDemo\CSVFiles\IndiaStateCode.csv";
        public string wrongIndianStateCodeFileType = @"C:\Users\rathi\source\repos\IndiaCensusDataDemo\IndiaCensusDataDemo\CSVFiles\IndiaStateCode.txt";
        public string delimeterIndianStateCodeFilePath = @"C:\Users\rathi\source\repos\IndiaCensusDataDemo\IndiaCensusDataDemo\CSVFiles\DelimiterIndiaStateCode.csv";
        public string wrongHeaderStateCodeFilePath = @"C:\Users\rathi\source\repos\IndiaCensusDataDemo\IndiaCensusDataDemo\CSVFiles\WrongIndiaStateCode.csv";

        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecords;
        Dictionary<string, CensusDTO> stateRecords;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecords = new Dictionary<string, CensusDTO>();
            stateRecords = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenReadReturnCensusDataCount()
        {
            totalRecords = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            stateRecords = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(29, totalRecords.Count);
            Assert.AreEqual(37, stateRecords.Count);
        }

        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReadReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFilePath, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.Exception.FILE_NOT_FOUND, censusException.exception);
            Assert.AreEqual(CensusAnalyserException.Exception.FILE_NOT_FOUND, stateException.exception);
        }

        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenReadReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFileType, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.Exception.INCORRECT_HEADER, censusException.exception);
            Assert.AreEqual(CensusAnalyserException.Exception.INVALID_FILE_TYPE, stateException.exception);
        }

        [Test]
        public void GivenIndianCensusDataFileType_ButIncorrectDelimeter_WhenReadReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, delimeterIndianCensusFilePath, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, delimeterIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.Exception.INCORRECT_DELIMITER, censusException.exception);
            Assert.AreEqual(CensusAnalyserException.Exception.INCORRECT_DELIMITER, stateException.exception);
        }

        [Test]
        public void GivenIndianCensusDataFileType_ButIncorrectHeader_WhenReadReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongHeaderIndianCensusFilePath, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongHeaderStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.Exception.INCORRECT_HEADER, censusException.exception);
            Assert.AreEqual(CensusAnalyserException.Exception.INCORRECT_HEADER, stateException.exception);
        }
    }
}