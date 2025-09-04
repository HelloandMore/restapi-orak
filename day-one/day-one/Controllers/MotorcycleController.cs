using day_one.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;

namespace day_one.Controllers;

public class MotorcycleController: ControllerBase
{
    public List<string> Motorcycles = [
        "Honda Hornet",
        "Triumph Tiger valami",
        "Sport, Az",
        "Valami Yamaha"
        ];

    [HttpGet]
    [Route("motorcycle/id/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] [Required] int id)
    {
        return Ok($"hello! {Motorcycles[id]}");
    }

    [HttpGet]
    [Route("motorcycle")]
    public async Task<IActionResult> GetAsync([FromQuery] [Required] int id)
    {
        return Ok($"hello! {Motorcycles[id]}");
    }

    [HttpGet]
    [Route("motorcycle/all")]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(Motorcycles);
    }

    [HttpPost]
    [Route("motorcycle/create")]
    public async Task<IActionResult> CreateAsync([FromBody] [Required] string motorcycle)
    {
        Motorcycles.Add(motorcycle);
        return Ok($"Successfully added {motorcycle} to database!");
    }

    [HttpPut]
    [Route("motorcycle/update")]
    public async Task<IActionResult> UpdateAsync([FromRoute] [Required] MotorcycleUpdateModel model)
    {
        Motorcycles[model.Id] = model.Name;
        return Ok($"Successfully updated motorcycle with id {model.Id} to {model.Name}!");
    }

    [HttpDelete]
    [Route("motorcycle/delete/{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] [Required] int id)
    {
        Motorcycles.RemoveAt(id);
        return Ok($"Success: {Motorcycles.ToString()}");
    }
}
