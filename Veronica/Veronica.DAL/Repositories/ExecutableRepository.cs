using Veronica.Models;
using System.Collections.Generic;
using System.Linq;

namespace Veronica.DAL.Repositories
{
    public class ExecutableRepository 
    {
         public virtual List<Executable> Fetch(int executionId,string name)
        {
            string er = "Name=" + name;
            EfContext context = new EfContext(er);
            var sql = @"
                    SELECT s.statistics_id	Id
	                    ,e.executable_name	Name
	                    ,e.package_name		PackageName
	                    ,e.package_path		PackagePath
	                    ,CAST(s.start_time AS DATETIME) StartTime
	                    ,CAST(s.end_time AS DATETIME) EndTime
	                    ,ISNULL(s.execution_duration /60000,0)	Duration
	                    ,CAST(s.execution_result AS INT)	ExecutionResult
	                    ,CAST(s.execution_value AS VARCHAR)	ExecutionValue
                    FROM catalog.executables e  with(nolock)
	                    LEFT JOIN catalog.executable_statistics s  with(nolock) ON s.executable_id = e.executable_id AND s.execution_id = e.execution_id
                    WHERE e.execution_id = {0}
                    ORDER BY e.executable_id DESC
                ";
            sql = string.Format(sql, executionId);
            
            var data = context.Database.SqlQuery<Executable>(sql).ToList(); ;
            return data;
        }
    }
}


