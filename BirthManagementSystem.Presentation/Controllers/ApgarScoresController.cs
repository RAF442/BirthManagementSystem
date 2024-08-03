using BirthManagementSystem.Application.Commands.ApgarScores.AddApgarScore;
using BirthManagementSystem.Application.Dtos;
using BirthManagementSystem.Application.Queries.ApgarScores.GetApgarScoreBabies;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace BirthManagementSystem.Presentation.Controllers;

[Route("api/apgar_scores")] //Adres do endpointów udostępnianych w ramach tego kontrolera
[ApiController]
public class ApgarScoresController : Controller
{
    private readonly IMediator _mediator;

    public ApgarScoresController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Pobranie dzieci
    /// </summary>
    /// <param name="id">Id wyniku w skali Apgar</param>
    /// <returns>Dzieci z danym wynikiem w skali Apgar</returns>
    [HttpGet("{id}/babies")]
    [SwaggerOperation("Get apgar score babies")] //Opis edndpointa
    [ProducesResponseType(typeof(IEnumerable<BabyDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetApgarScoreBabies([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetApgarScoreBabiesQuery(id));
        return Ok(result);
    }

    /// <summary>
    /// Metoda dodająca nowy wynik w skali Apgar
    /// </summary>
    /// <param name="command">Dodanie nowego wyniku w skali Apgar</param>
    /// <returns></returns>
    [HttpPost]
    [SwaggerOperation("Add apgar score")]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<ActionResult> Post([FromBody] AddApgarScoreCommand command)
    {
        var apgar_score = await _mediator.Send(command);
        return Created($"api/apgar_scores{apgar_score.Id}",apgar_score);
    }
}
