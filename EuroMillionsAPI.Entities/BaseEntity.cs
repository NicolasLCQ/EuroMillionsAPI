namespace EuroMillionsAPI.Entities;

public abstract class BaseEntity
{  
    protected BaseEntity() { }

    public abstract int ID { get; set; }
}
