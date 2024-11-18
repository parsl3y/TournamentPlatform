using Api.Dtos;
using Api.Modules.Errors;
using Application.Common.Interfaces.Repositories;
using Application.TeamMatchs.Commands;
using Application.Teams.Commands;
using Domain.Matches;
using Domain.Teams;
using Domain.TeamsMatch;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/addTeamToMatch")]
[ApiController]
public class TeamMatchController : ControllerBase
{
    private readonly ISender _sender;
    private readonly ITeamRepository _teamRepository;

    public TeamMatchController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<ActionResult<TeamMatchCreateDto>> JoinTeamToMatch(
        [FromBody] TeamMatchCreateDto teamMatchCreateDto,
        CancellationToken cancellationToken)
    {
        var command = new CreateTeamMatchCommand(new TeamId(teamMatchCreateDto.TeamId), new MatchId(teamMatchCreateDto.MatchId));
        
        var result = await _sender.Send(command, cancellationToken);

        return result.Match<ActionResult<TeamMatchCreateDto>>(
            tm => TeamMatchCreateDto.FromDomainModel(tm),
            e => e.ToObjectResult());
    }
}