using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Demo.WebApp.HealthChecks;

public class SampleHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        var isHealthy = DateTime.Now.Minute % 2 == 0;

        // ...

        if (isHealthy)
        {
            return Task.FromResult(HealthCheckResult.Healthy("Yeah, what's up?"));
        }

        return Task.FromResult(new HealthCheckResult(context.Registration.FailureStatus, "No, not feelin' it"));
    }
}