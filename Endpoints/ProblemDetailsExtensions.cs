using Flunt.Notifications;

namespace IWantApp.Endpoints;

public static class ProblemDetailsExtensions
{
    public static Dictionary<string, string[]> ConvertToProblemDetails(this IReadOnlyCollection<Notification> notifications)
    {
        return notifications
            .GroupBy(g => g.Key)
            .ToDictionary(k => k.Key, v => v.Select(s => s.Message).ToArray());
    }
}