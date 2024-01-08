using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.UserAggregate.ValueObjects;

public sealed class UserId : AggregateRootId<Guid>
{
    private UserId(Guid value)
    {
        Value = value;
    }

    public override Guid Value { get; protected set; }

    public static UserId CreateUnique()
    {
        return new UserId(new Guid());
    }

    public static UserId Create(Guid userId)
    {
        return new UserId(userId);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}