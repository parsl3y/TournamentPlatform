using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Converters;

public class DateTimeUtcConverter() : ValueConverter<DateTime, DateTime>(
    x => x.ToUniversalTime(),
    x => x.Kind == DateTimeKind.Unspecified ? DateTime.SpecifyKind(x, DateTimeKind.Utc) : x.ToUniversalTime());