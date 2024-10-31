namespace Evolve.ITR.ServiceContract.Constants
{
    public static class ReasonConstants
    {
        public static Dictionary<string, string> Descriptions = new Dictionary<string, string>
        {
            { "AC", "PER INSTRUCTIONS FROM THE A/C" },
            { "CP", "CLIENT PRICING" },
            { "DA", "DRVR ADD INCOMPLETE/MISSING" },
            { "DN", "DRIVER NAME MISSING" },
            { "DP", "DRVR PHONE # INCOMPLETE/MSSG" },
            { "EX", "EXPANSION UNIT" },
            { "FI", "FEDERAL ID #/W9 MISSING"},
            { "FN", "FACTORY ORDER # ISSUE"},
            { "FO", "FUTURE ORDER"},
            { "IC", "INSURANCE CARD"},
            { "IN", "MOCO INVOICE MISSING"},
            { "MI", "MISCELLANEOUS(SEE R2R/NOTES)"},
            { "NM", "# MISSING - BUS LIC/CORP CODE/UBI"},
            { "PA", "POWER OF ATTORNEY"},
            { "PE", "PRINTING ERROR"},
            { "PI", "PRICING INFORMATION NEEDED"},
            { "PU", "POOL UNIT"},
            { "RA", "PO BOX UNACCEPTABLE FOR T&R"},
            { "RM", "RETURNED IN MAIL - SEE ITRAC MSG"},
            { "SD", "SELLING DEALER PROBLEM"},
            { "SP", "SHIP TO PROBLEM"},
            { "SS", "2ND STAGE MSO/INVOICE MISSING"},
            { "ST", "STATES NOT MATCHING"},
            { "TA", "TITLE ADD INCOMPLETE/MISSING"},
            { "VI", "VENDOR INVOICE NEEDED" }
        };
    }
}
