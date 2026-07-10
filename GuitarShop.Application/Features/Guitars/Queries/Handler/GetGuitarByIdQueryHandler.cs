using CSharpFunctionalExtensions;
using GuitarShop.Application.Interfaces;
using GuitarShop.Domain.Entities;
using MediatR;

namespace GuitarShop.Application.Features.Guitars.Queries.Handler;

internal class GetGuitarByIdQueryHandler : IRequestHandler<GetGuitarByIdQuery, Result<Guitar>>
{
    private readonly IGuitarRepository _guitarRepository;

    public GetGuitarByIdQueryHandler(IGuitarRepository guitarRepository)
    {
        _guitarRepository = guitarRepository;
    }

    public async Task<Result<Guitar>> Handle(GetGuitarByIdQuery request, CancellationToken cancellationToken)
    {
        var guitar = await _guitarRepository.GetByIdAsync(request.Id);
        if (guitar is null)
            return Result.Failure<Guitar>($"Não foi possível encontrar nenhuma guitarra com o id: {nameof(request.Id)}");

        return Result.Success(guitar);
    }
}
