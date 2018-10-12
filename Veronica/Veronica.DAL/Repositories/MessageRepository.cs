using Veronica.Models;
using System.Collections.Generic;
using System.Linq;

namespace Veronica.DAL.Repositories
{
    public class MessageRepository
    {
        public virtual List<Message> Fetch(int executionId, MessageType messageType,string name)
        {
            string er = "Name=" + name;
            EfContext context = new EfContext(er);
            var sql = @"
                    SELECT 
	                    event_message_id                        Id
	                    ,CAST(message_time AS DATETIME)			Time
	                    ,message				                MessageText
	                    ,message_source_name	                Source
	                    ,ISNULL(subcomponent_name,'')	        Component
                    FROM catalog.event_messages m with(nolock)
                    WHERE operation_id = {0}
	                    AND m.message_type = {1}
                ";
            sql = string.Format(sql, executionId, (int)messageType);
            var data = context.Database.SqlQuery<Message>(sql).ToList(); ;
            return data;
        }
    }
}
