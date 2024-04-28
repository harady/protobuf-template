using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.Lambda.Core;

namespace AwsDotnetCsharp
{
	public partial class ExchangeService : ExchangeServiceBase
	{

		public override async Task<ExchangeExchangeResponse> ExchangeImpl(
			ExchangeExchangeRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("ExchangeImpl is not implemented"));
			var result = new ExchangeExchangeResponse();
			return result;
		}

	}
}
