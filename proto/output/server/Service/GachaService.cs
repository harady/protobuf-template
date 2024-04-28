using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.Lambda.Core;

namespace AwsDotnetCsharp
{
	public partial class GachaService : GachaServiceBase
	{

		public override async Task<GachaDrawResponse> DrawImpl(
			GachaDrawRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("DrawImpl is not implemented"));
			var result = new GachaDrawResponse();
			return result;
		}

	}
}
