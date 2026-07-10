namespace GuitarShop.Application.DTOs;

public record GuitarDto(
    Guid Id,
    string Brand,
    string Model,
    decimal Price
);
