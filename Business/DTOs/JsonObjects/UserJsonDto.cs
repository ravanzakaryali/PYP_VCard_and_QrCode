namespace Business.DTOs.JsonObjects;

public class UserJsonDto
{
    public IdJsonDto Id { get; set; } = null!;
    public string Gender { get; set; } = null!;
    public NameJsonDto Name { get; set; } = null!; 
    public LocationJsonDto Location { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
}
