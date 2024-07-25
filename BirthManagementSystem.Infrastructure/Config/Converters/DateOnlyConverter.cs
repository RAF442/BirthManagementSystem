using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BirthManagementSystem.Infrastructure.Config.Converters;

/// <summary>
/// Konwerter z typu DateOnly na DateTime
/// </summary>
public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
{
    public DateOnlyConverter() : base(
        d => d.ToDateTime(TimeOnly.MinValue),
        d => DateOnly.FromDateTime(d))
    {

    }
}
