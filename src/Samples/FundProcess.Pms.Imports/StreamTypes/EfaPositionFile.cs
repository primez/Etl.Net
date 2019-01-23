using System;

namespace FundProcess.Pms.Imports.StreamTypes
{
    public class EfaPositionFile
    {
        public string FundCode { get; set; }
        public string FundLongName { get; set; }
        public string SubFundCode { get; set; }
        public string SubFundName { get; set; }
        public string SubFundCurrency { get; set; }
        public DateTime ValuationDate { get; set; }
        public string IntrumentCode { get; set; }
        public string IntrumentCategory { get; set; }
        public string IntrumentName { get; set; }
        public string IntrumentIsin { get; set; }
        public string BloombergCode { get; set; }
        public string Category1 { get; set; }
        public string Category2 { get; set; }
        public decimal MarketValue { get; set; }
        public decimal MarketValueInInstrumentCurrency { get; set; }
        public decimal Quantity { get; set; }
    }
}