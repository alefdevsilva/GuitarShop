using CSharpFunctionalExtensions;
using GuitarShop.Domain.Entities;
using MediatR;

namespace GuitarShop.Application.Features.Guitars.Queries;

public record GetGuitarByIdQuery(Guid Id) : IRequest<Result<Guitar>>;
