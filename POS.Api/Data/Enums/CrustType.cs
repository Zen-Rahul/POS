using System.ComponentModel;
using System;

namespace POS.Api.Data.Enums
{
    [DefaultValue(CrustType.HandTossed)]
    public enum CrustType
    {
        None,
        HandTossed,
        CheeseBrust,
        WheatThin,
        FreshPan
    }
}