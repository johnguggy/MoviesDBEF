using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business
{
    public class Calc
    {
        public double GetTax(int Price)
        {
            const double TaxRate = 0.08;
            double Tax = Price * TaxRate;
            return Tax;
        }
        public double GetTotal(int Price)
        {
            const double TaxRate = 0.08;
            double Total = (Price * TaxRate) + Price;
            return Total;
        }
    }
}
