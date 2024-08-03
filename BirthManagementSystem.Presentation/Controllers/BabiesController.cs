using BirthManagementSystem.Application.Commands.ApgarScores.GiveBabyApgarScore;
using BirthManagementSystem.Application.Commands.Babies.AddBaby;
using BirthManagementSystem.Application.Commands.Babies.RemoveBaby;
using BirthManagementSystem.Application.Commands.Babies.UpdateBaby;
using BirthManagementSystem.Application.Dtos;
using BirthManagementSystem.Application.Queries.Babies.GetBabies;
using BirthManagementSystem.Application.Queries.Babies.GetBabiesWithDetails;
using BirthManagementSystem.Application.Queries.Babies.GetBabyById;
using BirthManagementSystem.Application.Queries.GetBabyByPersonalIdentityNumber;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace BirthManagementSystem.Presentation.Controllers;

[Route("api/babies")] //Adres do endpointów udostępnianych w ramach tego kontrolera
[ApiController]
public class BabiesController : Controller
{
    private readonly IMediator _mediator;

    public BabiesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Metoda do pobierania wszystkich dzieci
    /// </summary>
    /// <returns>Dzieci</returns>
    [HttpGet]
    [SwaggerOperation("Get babies")] //Opis edndpointa
    [ProducesResponseType(typeof(IEnumerable<BabyDto>), (int)HttpStatusCode.OK)] //Typ i kod odpowiedzi zwracany z endpointu
    public async Task<ActionResult> Get()
    {
        var result = await _mediator.Send(new GetBabiesQuery());
        return Ok();
    }

    /// <summary>
    /// Metoda pobierająca dzieci wraz ze szcegółowymi danymi 
    /// </summary>
    /// <returns>Dzieci ze szegółowymi danymi</returns>
    [HttpGet("action")]
    [SwaggerOperation("Get babies with with details")]
    [ProducesResponseType(typeof(IEnumerable<BabyDetailsDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetWithDetails()
    {
        var result = await _mediator.Send(new GetBabiesWithDetailsQuery());
        return Ok(result);
    }

    /// <summary>
    /// Metoda pobierająca dane o dziecku o podanym identyfikatorze
    /// </summary>
    /// <param name="id">Identyfikator dziecka</param>
    /// <returns>Dziecko</returns>
    [HttpGet("{id}")]
    [SwaggerOperation("Get baby by ID")]
    [ProducesResponseType(typeof(BabyDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetById([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetBabyByIdQuery(id));
        return result != null ? Ok(result) : NotFound();
    }

    /// <summary>
    /// Metoda pobierająca
    /// </summary>
    /// <param name="personal_id_number"></param>
    /// <returns>Dziecko</returns>
    [HttpGet("[action]/{personal_id_number}")]
    [SwaggerOperation("Get baby by PESEL")]
    [ProducesResponseType(typeof(BabyDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetByPersonalIdentityNumber([FromRoute] string personal_id_number)
    {
        var result = await _mediator.Send(new GetBabyByPersonalIdentityNumberQuery(personal_id_number));
        return result != null ? Ok(result) : NotFound();
    }

    /// <summary>
    /// Metoda dodająca nowe dziecko
    /// </summary>
    /// <param name="command">Dodanie nowego dziecka</param>
    /// <returns></returns>
    [HttpPost]
    [SwaggerOperation("Add baby")]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<ActionResult> Post([FromBody] AddBabyCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    /// <summary>
    /// Metoda aktualizująca dane dziecka
    /// </summary>
    /// <param name="command">Aktualizacja danych dziecka</param>
    /// <returns></returns>
    [HttpPut]
    [SwaggerOperation("Update baby")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<ActionResult> Put([FromBody] UpdateBabyCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    /// <summary>
    /// Metoda przyznająca dziecku wynik w skali Apgar (podajemy id dziecka a następnie id wyniku w skali Apgar)
    /// </summary>
    /// <param name="id">Id dziecka</param>
    /// <param name="apgar_score_Id">Id wyniku w skali Apgar</param>
    /// <returns></returns>
    [HttpPut("{id}/apgar_scores/{apgar_score_Id}")]
    [SwaggerOperation("Give baby apgar score")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<ActionResult> GiveApgarScore([FromRoute] int id, [FromRoute] int apgar_score_Id)
    {
        await _mediator.Send(new GiveBabyApgarScoreCommand(id, apgar_score_Id));
        return NoContent();
    }

    /// <summary>
    /// Metoda usuwająca dziecko
    /// </summary>
    /// <param name="id">Id dziecka</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [SwaggerOperation("Remove baby")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        await _mediator.Send(new RemoveBabyCommand(id));
        return NoContent();
    }
}
