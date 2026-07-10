using CSharpFunctionalExtensions;
using GuitarShop.Domain.Entities;
using MediatR;

namespace GuitarShop.Application.Features.Guitars.Queries;

public record GetGuitarsQuery : IRequest<Result<IEnumerable<Guitar>>>;