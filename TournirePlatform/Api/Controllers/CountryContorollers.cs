using Api.Dtos;
using Api.Modules.Errors;
using Application.Common.Interfaces.Queries;
using Application.Countries.Commands;
using Application.Games.Commands;
using Domain.Countries;
using EFCore.NamingConventions.Internal;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("Country")]
[ApiController]
public class CountryControllers(ISender sender, ICountryQueries countryQueries) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CountryDto>>> GetAllGames(CancellationToken cancellationToken)
    {
        var entities = await countryQueries.GetAll(cancellationToken);
        return entities.Select(CountryDto.FromDomainModel).ToList();
    }
    [HttpPost]
    public async Task<ActionResult<CountryDto>> Create(
        [FromBody] CountryDto request,
        CancellationToken cancellationToken)
    {
        var input = new CreateCountryCommand()
        {
            Name = request.Name
        };

        var result = await sender.Send(input, cancellationToken);

        return result.Match<ActionResult<CountryDto>>(
            c => CountryDto.FromDomainModel(c),
            e => e.ToObjectResult());
    }
    [HttpPut]
    public async Task<ActionResult<CountryDto>> Update(
        [FromBody] CountryDto request,
        CancellationToken cancellationToken)
    {
        var input = new UpdateCountryCommand()
        {
            CountryId = request.Id!.Value,
            Name = request.Name
        };

        var result = await sender.Send(input, cancellationToken);

        return result.Match<ActionResult<CountryDto>>(
            c => CountryDto.FromDomainModel(c),
            e => e.ToObjectResult());
    }
}