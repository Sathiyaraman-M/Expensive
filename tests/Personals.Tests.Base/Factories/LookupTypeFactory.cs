using Personals.Common.Enums;
using Personals.LookupTypes.Entities;
using Personals.Tests.Base.Services;

namespace Personals.Tests.Base.Factories;

public static class LookupTypeFactory
{
    private static readonly StubTimeProvider TimeProvider = new();

    public static LookupType Create(Guid id, LookupTypeCategory category, Guid userId, string code = "CODE",
        string name = "Look-up Type")
    {
        return new LookupType
        {
            Id = id,
            Category = category,
            Code = code,
            Name = name,
            UserId = userId,
            CreatedByUserName = "Test User",
            CreatedByUserId = userId,
            CreatedOnDate = TimeProvider.Now,
        };
    }
}