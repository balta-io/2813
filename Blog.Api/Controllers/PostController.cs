using Blog.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;

/// <summary>
/// CRUD de Post
/// </summary>
[ApiController]
public class PostController : Controller
{
    /// <summary>
    /// Creates a TodoItem.
    /// </summary>
    /// <param name="item"></param>
    /// <returns>A newly created TodoItem</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Todo
    ///     {
    ///        "id": 1,
    ///        "name": "Item #1",
    ///        "isComplete": true
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    [HttpPost("v1/posts")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(Post item)
    {
        await Task.Delay(1);
        return CreatedAtAction("", new {id = item.Id}, item);
    }
}