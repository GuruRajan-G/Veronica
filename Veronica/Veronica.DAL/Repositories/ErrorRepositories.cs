using System;
using System.Collections.Generic;
using System.Linq;
using Veronica.Models;
using Veronica.DAL.Enums;

namespace Veronica.DAL.Repositories
{
    public class ErrorRepositories
    {
        private class KpiDTO
        {
            public int ? StatusId { get; set; }
            public int ? RowCount { get; set; }
        }
        public virtual List<AtlaserrorModel> FetchErrorList(string server)
        {
            string er = "Name=" + server;
            EfContext context = new EfContext(er);
            var sql = @"
                    SELECT 
                    UniqueIDError,
                    Description ,
                    CAST(SysBeginDateTime AS varchar(max)) as SysBeginDateTime,
                    MachineName ,                    
                    AppName ,
                    TransactionID ,
                    BucketID
                    FROM tblError e WITH(NOLOCK)
                    WHERE SysBeginDateTime >(SELECT CAST(GETDATE() as DATE))                    
                    ORDER BY e.SysBeginDateTime DESC
                ";
            sql = string.Format(sql);

            var data = context.Database.SqlQuery<AtlaserrorModel>(sql).ToList(); ;
            return data;
        }
        public virtual List<AtlaserrorCount> FetchErrorKPI(string server)
        {
            string er = "Name=" + server;
            EfContext context = new EfContext(er);
            var sql = @"
                         SELECT 
                            CASE
                            WHEN AppName='External Services'
                            THEN 0 
                            WHEN AppName='Auth Service'
                            THEN 1
                            WHEN AppName='Batch Rules Processor'
                            THEN 2
                            WHEN AppName='HCATReferralReprocessor'
                            THEN 3
                            WHEN AppName='HITService'
                            THEN 4
                            WHEN AppName='PDW Batch Rules Processor'
                            THEN 5
                            WHEN AppName='NTAReprocessorTask'
                            THEN 6
                            WHEN AppName='Pharmacy Service'
                            THEN 7
                            WHEN AppName='PDW RuleAction Transfer'
                            THEN 8
                            WHEN AppName='MonitorBatchWorkFlow'
                            THEN 9
                            WHEN AppName='AutoCaseReprocesor'
                            THEN 10
                            WHEN AppName='AutoTaskReprocesor'
                            THEN 11
                            WHEN AppName='CoreSparkProcessor'
                            THEN 12        
                            WHEN AppName='NTAReprocessor'                    
                            THEN 6
                            WHEN AppName IS NULL
                            THEN 13
                            WHEN AppName='BatchJobLogging'
                            THEN 15
                            END AS StatusId, 
                            COUNT(1) as [RowCount] 
                            FROM tblError e WITH(NOLOCK)
                            WHERE  e.SysBeginDateTime >(SELECT CAST(GETDATE() as DATE))
                            GROUP BY e.AppName
                            UNION 
			                SELECT 14 AS StatusId,
			                COUNT(1) as [RowCount] 
                            FROM tblError e WITH(NOLOCK)
                            WHERE  e.SysBeginDateTime >(SELECT CAST(GETDATE() as DATE))";
            sql = string.Format(sql);

            var data = context.Database.SqlQuery<KpiDTO>(sql).Select(k => new AtlaserrorCount
            {
                RowCount = k.RowCount,
                ExecutionStatus = Enum.GetName(typeof(AtlasApps), k.StatusId)
            })
            .ToList();
            return data;
        }
    }
}
