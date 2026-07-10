using MediatR;

namespace GuitarShop.Application.Features.Guitars.Commands;

public record CreateGuitarCommand(
    string Name,
    string Brand,
    string Model,
    decimal Price
) : IRequest<Guid>;