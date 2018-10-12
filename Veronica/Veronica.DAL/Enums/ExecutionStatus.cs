using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veronica.DAL.Enums
{
    public enum ExecutionStatus
    {
        all,
        created,
        running,
        cancelled,
        failed,
        pending,
        ended_unexpectedly,
        succeeded,
        stopping,
        completed,
    }

    public enum AtlasApps
    {
        ExternalServices,
        AuthService,
        BatchRulesProcessor,
        HCATReferralReprocessor,
        HITService,
        PDWBatchRulesProcessor,
        NTAReprocessorTask,
        PharmacyService,
        PDWRuleActionTransfer,
        MonitorBatchWorkFlow,
        AutoCaseReprocesor,
        AutoTaskReprocesor,
        CoreSparkProcessor,
        NULL,
        All,
        BatchJobLogging,

    }
}
