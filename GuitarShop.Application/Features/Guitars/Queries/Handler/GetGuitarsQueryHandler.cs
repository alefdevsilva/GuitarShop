using CSharpFunctionalExtensions;
using GuitarShop.Application.Interfaces;
using GuitarShop.Domain.Entities;
using MediatR;

namespace GuitarShop.Application.Features.Guitars.Queries.Handler;

internal class GetGuitarsQueryHandler : IRequestHandler<GetGuitarsQuery, Result<IEnumerable<Guitar>>>
{
    private readonly IGuitarRepository _guitarRepository;

    public GetGuitarsQueryHandler(IGuitarRepository guitarRepository)
    {
        _guitarRepository = guitarRepository;
    }

    public async Task<Result<IEnumerable<Guitar>>> Handle(GetGuitarsQuery request, CancellationToken cancellationToken)
    {
        var guitars = await _guitarRepository.GetAllAsync();
        if (!guitars.Any())
            return Result.Failure<IEnumerable<Guitar>>("Nenhuma guitarra encontrada!");

        return Result.Success(guitars);
    }
}
