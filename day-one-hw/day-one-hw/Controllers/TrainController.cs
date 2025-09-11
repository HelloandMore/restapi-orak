using day_one_hw.Controllers;
using day_one_hw.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace day_one_hw.Controllers;

public class TrainController : ControllerBase
{
	public List<TrainUpdateModel> Trains = [
		new TrainUpdateModel
		{
			Id = 0,
			Name = "Frecciarossa 1000",
			Type = "High-speed train",
			BuildDate = 2015,
			MaxSpeed = 400,
			Weight = 500.5f,
			Length = 200.8f,
			Gauge = 1435.0f,
			Power = 12000.0f
		},
		new TrainUpdateModel
		{
			Id = 1,
			Name = "Shinkansen N700",
			Type = "High-speed train",
			BuildDate = 2007,
			MaxSpeed = 300,
			Weight = 598.2f,
			Length = 252.7f,
			Gauge = 1435.0f,
			Power = 10040.0f
		},
		new TrainUpdateModel
		{
			Id = 2,
			Name = "TGV Duplex",
			Type = "High-speed train",
			BuildDate = 1996,
			MaxSpeed = 320,
			Weight = 383.6f,
			Length = 200.19f,
			Gauge = 1435.0f,
			Power = 8800.0f
		},
		new TrainUpdateModel
		{
			Id = 3,
			Name = "ICE 3",
			Type = "High-speed train",
			BuildDate = 2000,
			MaxSpeed = 330,
			Weight = 409.3f,
			Length = 200.32f,
			Gauge = 1435.0f,
			Power = 9280.0f
		}
		];

	[HttpGet]
	[Route("trains/getall")]
	public async Task<IActionResult> GetAllTrains()
	{
		return Ok(Trains);
	}

	[HttpGet]
	[Route("trains/getbyid/{id}")]
	public async Task<IActionResult> GetTrainById(int id)
	{
		TrainUpdateModel result = Trains.FirstOrDefault(t => t.Id == id);
		if (result == null) return NotFound($"Train with ID {id} not found.");
		return Ok(result);
	}

	[HttpPost]
	[Route("trains/add")]
	public async Task<IActionResult> AddTrain([FromBody] TrainUpdateModel newTrain)
	{
		if (newTrain == null) return BadRequest("Train data is null.");

		Trains.Add(newTrain);
		return CreatedAtAction(nameof(GetTrainById), new { id = newTrain.Id }, newTrain);
	}

	[HttpPut]
	[Route("trains/update/{id}")]
	public async Task<IActionResult> UpdateTrain(int id, [FromBody] TrainUpdateModel updatedTrain)
	{
		var existingTrain = Trains.FirstOrDefault(t => t.Id == id);
		if (existingTrain == null) return NotFound($"Train with ID {id} not found.");
		if (!string.IsNullOrEmpty(updatedTrain.Name)) existingTrain.Name = updatedTrain.Name;
		if (!string.IsNullOrEmpty(updatedTrain.Type)) existingTrain.Type = updatedTrain.Type;
		if (updatedTrain.BuildDate != null) existingTrain.BuildDate = updatedTrain.BuildDate;
		if (updatedTrain.MaxSpeed != null) existingTrain.MaxSpeed = updatedTrain.MaxSpeed;
		if (updatedTrain.Weight != null) existingTrain.Weight = updatedTrain.Weight;
		if (updatedTrain.Length != null) existingTrain.Length = updatedTrain.Length;
		if (updatedTrain.Gauge != null) existingTrain.Gauge = updatedTrain.Gauge;
		if (updatedTrain.Power != null) existingTrain.Power = updatedTrain.Power;
		return Ok();
	}

	[HttpDelete]
	[Route("trains/delete/{id}")]
	public async Task<IActionResult> DeleteTrain(int id)
	{
		var trainToDelete = Trains.FirstOrDefault(t => t.Id == id);
		if (trainToDelete == null) return NotFound($"Train with ID {id} not found.");
		Trains.Remove(trainToDelete);
		return NoContent();
	}
}
