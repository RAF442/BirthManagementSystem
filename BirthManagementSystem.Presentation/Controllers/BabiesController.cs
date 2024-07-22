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

[Route("api/babies")]
[ApiController]
public class BabiesController : Controller
{
    private readonly IMediator _mediator;

    public BabiesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [SwaggerOperation("Get babies")]
    [ProducesResponseType(typeof(IEnumerable<BabyDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Get()
    {
        var result = await _mediator.Send(new GetBabiesQuery());
        return Ok();
    }

    [HttpGet("action")]
    [SwaggerOperation("Get babies with with details")]
    [ProducesResponseType(typeof(IEnumerable<BabyDetailsDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetWithDetails()
    {
        var result = await _mediator.Send(new GetBabiesWithDetailsQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    [SwaggerOperation("Get baby by ID")]
    [ProducesResponseType(typeof(BabyDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetById([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetBabyByIdQuery(id));
        return result != null ? Ok(result) : NotFound();
    }

    [HttpGet("[action]/{personal_id_number}")]
    [SwaggerOperation("Get baby by PESEL")]
    [ProducesResponseType(typeof(BabyDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetByPersonalIdentityNumber([FromRoute] string personal_id_number)
    {
        var result = await _mediator.Send(new GetBabyByPersonalIdentityNumberQuery(personal_id_number));
        return result != null ? Ok(result) : NotFound();
    }

    [HttpPost]
    [SwaggerOperation("Add baby")]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<ActionResult> Post([FromBody] AddBabyCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut]
    [SwaggerOperation("Update baby")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<ActionResult> Put([FromBody] UpdateBabyCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPut("{id}/apgar_scores/{apgar_score_Id}")]
    [SwaggerOperation("Give baby apgar score")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<ActionResult> GiveApgarScore([FromRoute] int id, [FromRoute] int apgar_score_Id)
    {
        await _mediator.Send(new GiveBabyApgarScoreCommand(id, apgar_score_Id));
        return NoContent();
    }

    [HttpDelete("{id}")]
    [SwaggerOperation("Remove baby")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        await _mediator.Send(new RemoveBabyCommand(id));
        return NoContent();
    }
}
