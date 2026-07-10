using GuitarShop.Application.Features.Guitars.Commands;
using GuitarShop.Application.Interfaces;
using GuitarShop.Domain.Entities;
using MediatR;

namespace GuitarShop.Application.Features.Guitars.Commands.Handlers;

internal class CreateGuitarCommandHandler : IRequestHandler<CreateGuitarCommand, Guid>
{
    private readonly IGuitarRepository _guitarRepository;

    public CreateGuitarCommandHandler(IGuitarRepository guitarRepository)
    {
        _guitarRepository = guitarRepository;
    }

    public async Task<Guid> Handle(CreateGuitarCommand request, CancellationToken cancellationToken)
    {
        var guitar = new Guitar(
            request.Name,
            request.Brand,
            request.Model,
            request.Price);

        await _guitarRepository.AddAsync(guitar);
        await _guitarRepository.SaveChangesAsync();

        return guitar.Id;
    }
}
