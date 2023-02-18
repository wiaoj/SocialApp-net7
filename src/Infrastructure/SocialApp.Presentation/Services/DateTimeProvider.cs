using SocialApp.Application.Common.Services;

namespace SocialApp.Persistence.Services;
public class DateTimeProvider : IDateTimeProvider {
    public DateTime UtcNow => DateTime.UtcNow;
}