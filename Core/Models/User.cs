using Core.Models.Base;

namespace Core.Models;

public class User : BaseEntity
{
    public string Code { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public int CityId { get; set; }
    public City City { get;set; } = null!;
    public int CountryId { get; set; }
    public Country Country { get; set; } = null!;
}