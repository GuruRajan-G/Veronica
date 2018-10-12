using Veronica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Veronica.DAL.Enums;

namespace Veronica.DAL.Repositories
{
    public class KpiRepository 
    {
        private class KpiDTO
        {
            public int StatusId { get; set; }
            public int RowCount { get; set; }
        }

        public virtual List<KPI> Fetch(string name)
        {
            string er = "Name=" + name;
            EfContext context = new EfContext(er);
            var sql = @"
                SELECT 0 StatusId, COUNT(*) [RowCount] 
                FROM catalog.executions  with(nolock)
                UNION ALL SELECT [Status] StatusId, COUNT(*) [RowCount] 
                FROM catalog.executions with(nolock) 
                WHERE created_time>(SELECT CAST(GETDATE() AS DATE))
                GROUP BY [status]";
          
            var data = context.Database.SqlQuery<KpiDTO>(sql).Select(k => new KPI
            {
                RowCount = k.RowCount,
                ExecutionStatus = Enum.GetName(typeof(ExecutionStatus), k.StatusId)
            })
            .ToList();
            return data;
        }
    }
}
