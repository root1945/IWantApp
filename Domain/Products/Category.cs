using Flunt.Validations;

namespace IWantApp.Domain.Products;

public class Category : Entity
{
    public string Name { get; private set; }
    public bool Active { get; private set; }

    public Category(string name, string createdBy, string modifiedBy)
    {
        Name = name;
        Active = true;
        CreatedBy = createdBy;
        ModifiedBy = modifiedBy;
        ModifiedOn = DateTime.UtcNow;
        Validate();
    }
    
    private void Validate()
    {
        var contract = new Contract<Category>()
            .Requires()
            .IsNotNullOrEmpty(Name, nameof(Name), "Name is required")
            .IsGreaterOrEqualsThan(Name.Length, 3, nameof(Name), "Name must be at least 3 characters")
            .IsNotNullOrEmpty(CreatedBy, nameof(CreatedBy), "CreatedBy is required")
            .IsNotNullOrEmpty(ModifiedBy, nameof(ModifiedBy), "ModifiedBy is required");
        AddNotifications(contract);
    }

    public void EditInfo(string name, bool active, string modifiedBy)
    {
        Active = active;
        Name = name;
        ModifiedBy = modifiedBy;
        ModifiedOn = DateTime.UtcNow;
        Validate();
    }
}