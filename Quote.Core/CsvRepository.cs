using System;
using System.Collections.Generic;
using System.IO;

namespace Quote.Core
{
    public class CsvRepository : IRepository
    {
        private List<Lender> Lenders { get; set; }

        public CsvRepository(string location)
        {
            Lenders = new List<Lender>();

            try
            {
                
                using (var sr = new StreamReader(location))
                {
                    sr.ReadLine();
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var lender = line.Split(',');

                        Lenders.Add(new Lender
                        {
                            Name = lender[0],
                            Rate = Convert.ToDouble(lender[1]),
                            Available = Convert.ToInt32(lender[2])
                        });
                    }
                }
            }
            catch (Exception)
            {
                // send to logger service
            }
        }

        public IEnumerable<Lender> GetLenders()
        {
            return Lenders;
        }
    }
}