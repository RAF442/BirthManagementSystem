namespace BirthManagementSystem.Application.Dtos;

public class BabyDetailsDto : BabyDto
{
    public PlaceOfBirthDto PlaceOfBirth { get; set; }

    public ApgarScoreDto ApgarScore { get; set; }
}
