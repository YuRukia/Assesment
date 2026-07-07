using Constants;

namespace Config;

public class CustomerProfile
{
    public readonly string firstName;
    public readonly string lastName;
    public readonly string postCode;

    public CustomerProfile
    (
        string firstName = Customer.FirstName, 
        string lastName = Customer.LastName, 
        string postCode = Customer.Postcode
    )
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.postCode = postCode;
    }
}