using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.Lambda.Core;

namespace AwsDotnetCsharp
{
	public partial class UnitService : UnitServiceBase
	{

		public override async Task<UnitDeckEditResponse> DeckEditImpl(
			UnitDeckEditRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("DeckEditImpl is not implemented"));
			var result = new UnitDeckEditResponse();
			return result;
		}

		public override async Task<UnitPowerupResponse> PowerupImpl(
			UnitPowerupRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("PowerupImpl is not implemented"));
			var result = new UnitPowerupResponse();
			return result;
		}

		public override async Task<UnitEvolutionResponse> EvolutionImpl(
			UnitEvolutionRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("EvolutionImpl is not implemented"));
			var result = new UnitEvolutionResponse();
			return result;
		}

		public override async Task<UnitSellResponse> SellImpl(
			UnitSellRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("SellImpl is not implemented"));
			var result = new UnitSellResponse();
			return result;
		}

		public override async Task<UnitLockResponse> LockImpl(
			UnitLockRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("LockImpl is not implemented"));
			var result = new UnitLockResponse();
			return result;
		}

	}
}
