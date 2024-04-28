using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.Lambda.Core;

namespace AwsDotnetCsharp
{
	public partial class BattleService : BattleServiceBase
	{

		public override async Task<BattleHelperListResponse> HelperListImpl(
			BattleHelperListRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("HelperListImpl is not implemented"));
			var result = new BattleHelperListResponse();
			return result;
		}

		public override async Task<BattleStartResponse> StartImpl(
			BattleStartRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("StartImpl is not implemented"));
			var result = new BattleStartResponse();
			return result;
		}

		public override async Task<BattleContinueResponse> ContinueImpl(
			BattleContinueRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("ContinueImpl is not implemented"));
			var result = new BattleContinueResponse();
			return result;
		}

		public override async Task<BattleGiveupResponse> GiveupImpl(
			BattleGiveupRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("GiveupImpl is not implemented"));
			var result = new BattleGiveupResponse();
			return result;
		}

		public override async Task<BattleClearResponse> ClearImpl(
			BattleClearRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("ClearImpl is not implemented"));
			var result = new BattleClearResponse();
			return result;
		}

	}
}
