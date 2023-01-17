using Flunt.Notifications;
using Microsoft.AspNetCore.Identity;

namespace IWantApp.Endpoints;

public static class ProblemDetailsExtensions
{
    public static Dictionary<string, string[]> ConvertToProblemDetails(this IReadOnlyCollection<Notification> notifications)
    {
        return notifications
            .GroupBy(g => g.Key)
            .ToDictionary(k => k.Key, v => v.Select(s => s.Message).ToArray());
    }
    public static Dictionary<string, string[]> ConvertToProblemDetails(this IEnumerable<IdentityError> error)
    {
        return error
            .GroupBy(g => g.Code)
            .ToDictionary(k => k.Key, v => v.Select(s => s.Description).ToArray());
    }
}