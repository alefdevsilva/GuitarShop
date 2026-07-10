namespace GuitarShop.Application.DTOs;

public record CreateGuitarDto(
    string Brand,
    string Model,
    decimal Price,
    int Year,
    string Color
);