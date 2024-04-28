using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.Lambda.Core;

namespace AwsDotnetCsharp
{
	public partial class SystemService : SystemServiceBase
	{

		public override async Task<SystemPingResponse> PingImpl(
			SystemPingRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("PingImpl is not implemented"));
			var result = new SystemPingResponse();
			return result;
		}

		public override async Task<SystemSignupResponse> SignupImpl(
			SystemSignupRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("SignupImpl is not implemented"));
			var result = new SystemSignupResponse();
			return result;
		}

		public override async Task<SystemLoginResponse> LoginImpl(
			SystemLoginRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("LoginImpl is not implemented"));
			var result = new SystemLoginResponse();
			return result;
		}

	}
}
