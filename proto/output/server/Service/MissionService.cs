using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.Lambda.Core;

namespace AwsDotnetCsharp
{
	public partial class MissionService : MissionServiceBase
	{

		public override async Task<MissionAchieveResponse> AchieveImpl(
			MissionAchieveRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("AchieveImpl is not implemented"));
			var result = new MissionAchieveResponse();
			return result;
		}

		public override async Task<MissionReceiveResponse> ReceiveImpl(
			MissionReceiveRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("ReceiveImpl is not implemented"));
			var result = new MissionReceiveResponse();
			return result;
		}

	}
}
