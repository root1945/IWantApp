using Flunt.Validations;

namespace IWantApp.Domain.Products;

public class Category : Entity
{
    public string Name { get; set; }
    public bool Active { get; set; }

    public Category(string name, string createdBy, string modifiedBy)
    {
        var contract = new Contract<Category>()
            .Requires()
            .IsNotNullOrEmpty(name, nameof(Name), "Name is required")
            .IsGreaterOrEqualsThan(name.Length, 3, nameof(Name), "Name must be at least 3 characters")
            .IsNotNullOrEmpty(createdBy, nameof(CreatedBy), "CreatedBy is required")
            .IsNotNullOrEmpty(modifiedBy, nameof(ModifiedBy), "ModifiedBy is required");
        AddNotifications(contract);
        Name = name;
        Active = true;
        CreatedBy = createdBy;
        ModifiedBy = modifiedBy;
        ModifiedOn = DateTime.UtcNow;
    }
}