using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veronica.DAL.Repositories
{
    public class DollarRepository
    {
        public class Dollarmodel
        {
            public string Session { get; set; }
            public string Jobname { get; set; }
            public string Status { get; set; }
            public string Frequency { get; set; }
            public string Avgduration { get; set; }
            public string Description { get; set; }
            public string RunningOn { get; set; }

        }


        public virtual List<Dollarmodel> FetchActiveJob()
        {
            string er = "Name=" + "Atlasdev";
            EfContext context = new EfContext(er);
            var sql = @"
                    SELECT 
                    Session,
                    Jobname,
                    Status,
                    Frequency,
                    Avgduration,
                    Description,
                    RunningOn 
                    FROM DollarActiveJob
                ";
            sql = string.Format(sql);

            var data = context.Database.SqlQuery<Dollarmodel>(sql).ToList(); ;
            return data;
        }
    }
}
