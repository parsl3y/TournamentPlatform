using System.Text.RegularExpressions;
using Api.Dtos;
using Api.Modules.Errors;
using Application.Common.Interfaces.Queries;
using Application.Matches.Commands;
using Domain.Matches;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[Route("Matches")]
[ApiController]
public class MatchController(ISender sender, IMatchQueries matchQueries) : ControllerBase
{
    [Route("MatchList")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MatchGameDto>>> GetAllGames(CancellationToken cancellationToken)
    {
        var entities = await matchQueries.GetAll(cancellationToken);
        return entities.Select(MatchGameDto.FromDomainModel).ToList();
    }

    [HttpPost]
    public async Task<ActionResult<MatchGameDto>> Create(
        [FromBody] MatchGameDtoCreate request,
        CancellationToken cancellationToken)
    {
        var input = new CreateMatchCommand
        {
            Name = request.Name,
            GameId = request.GameId,
            StartAt = DateTime.UtcNow,
            MaxTeams = request.MaxTeams,
            TournamentId = request.TournamentId,
        };
        
        var result = await sender.Send(input, cancellationToken);
        return result.Match<ActionResult<MatchGameDto>>(
            mg => MatchGameDto.FromDomainModel(mg),
            e => e.ToObjectResult());


    }
}