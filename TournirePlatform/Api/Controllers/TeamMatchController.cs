using Api.Dtos;
using Api.Modules.Errors;
using Application.Common.Interfaces.Repositories;
using Application.TeamMatches.Commands;
using Application.TeamMatchs.Commands;
using Application.Teams.Commands;
using Domain.Matches;
using Domain.Teams;
using Domain.TeamsMatchs;
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
    
    [HttpPost("setWinner")]
    public async Task<ActionResult<WinnerResultDto>> SetWinner(
        [FromBody] SetWinnerDto setWinnerDto,
        CancellationToken cancellationToken)
    {
        var command = new SetWinnerCommand
        {
            TeamId = setWinnerDto.TeamId,
            MatchId = setWinnerDto.MatchId
        };

        var result = await _sender.Send(command, cancellationToken);

        return result.Match<ActionResult<WinnerResultDto>>(
            teamMatch => WinnerResultDto.FromDomainModel(teamMatch),
            exception => exception.ToObjectResult());
    }
    [HttpPost("addScore")]
    public async Task<ActionResult<TeamMatchScoreDto>> AddScore(
        [FromBody] AddScoreDto addScoreDto,
        CancellationToken cancellationToken)
    {
        var command = new AddScoreCommand
        {
            TeamId = addScoreDto.TeamId,
            MatchId = addScoreDto.MatchId
        };

        var result = await _sender.Send(command, cancellationToken);

        return result.Match<ActionResult<TeamMatchScoreDto>>(
            teamMatch => TeamMatchScoreDto.FromDomainModel(teamMatch),
            exception => exception.ToObjectResult());
    }

    [HttpDelete("{teamMatchId}")]
    public async Task<ActionResult<TeamMatchDeleteDto>> DeleteTeam([FromRoute] Guid teamMatchId,
        CancellationToken cancellationToken)
    {
        var input = new DeleteTeamMatchCommand()
        {
            TeamMatchId = teamMatchId
        };
    
        var result = await _sender.Send(input, cancellationToken);
        return result.Match<ActionResult<TeamMatchDeleteDto>>( 
            tm => TeamMatchDeleteDto.FromDomainModel(tm),
            e => e.ToObjectResult());
    }
}