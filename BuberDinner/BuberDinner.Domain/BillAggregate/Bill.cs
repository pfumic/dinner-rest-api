using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using Price = BuberDinner.Domain.DinnerAggregate.ValueObjects.Price;

namespace BuberDinner.Domain.BillAggregateAggregate;

public sealed class Bill : AggregateRoot<BillId, string>
{
    public DinnerId DinnerId { get; }
    public GuestId GuestId { get; }
    public HostId HostId { get; }
    public Price Amount { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Bill(
        DinnerId dinnerId,
        GuestId guestId,
        HostId hostId,
        Price amount,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(BillId.Create(dinnerId, guestId))
    {
        DinnerId = dinnerId;
        GuestId = guestId;
        HostId = hostId;
        Amount = amount;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Bill Create(
        DinnerId dinnerId,
        GuestId guestId,
        HostId hostId,
        Price amount,
        DateTime createdDateTime,
        DateTime updatedDateTime)
    {
        // TODO: enforce invariants
        return new Bill(
            dinnerId,
            guestId,
            hostId,
            amount,
            createdDateTime,
            updatedDateTime);
    }
}