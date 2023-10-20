using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductionPlanner.Application.Queries.GetProductionPlan;

namespace ProductionPlanner.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class ProductionPlanController
{
    private readonly IMediator _mediator;

    public ProductionPlanController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ProductionPlan[]), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetProductionPlan(
        [FromBody] GetProductionPlanRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return new OkObjectResult(response);
    }
}