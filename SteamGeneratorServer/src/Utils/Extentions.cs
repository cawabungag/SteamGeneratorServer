﻿using SteamGeneratorServer.Entities.Measure;
using SteamGeneratorServer.Entities.State;

namespace SteamGeneratorServer.Utils;

public static class Extentions
{
	public static StateDto AsDto(this State state) =>
		new()
		{
			Id = state.Id,
			Type = state.Type,
			Status = state.Status,
			Duration = state.Duration,
			CreatedDate = state.CreatedDate
		};
	
	public static MeasureDto AsDto(this Measure measure) =>
		new()
		{
			Id = measure.Id,
			Title = measure.Title,
			Value = measure.Value,
			CreatedDate = measure.CreatedDate
		};
}