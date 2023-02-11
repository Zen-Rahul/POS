using System.ComponentModel;
using System;

namespace POS.Api.Data.Enums
{
    [DefaultValue(PizzaSize.Small)]
    public enum PizzaSize
    {
        None,
        Small,
        Medium,
        Large,
    }
}