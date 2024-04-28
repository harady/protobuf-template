using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.Lambda.Core;

namespace AwsDotnetCsharp
{
	public partial class DebugService : DebugServiceBase
	{

		public override async Task<DebugSetServerTimeResponse> SetServerTimeImpl(
			DebugSetServerTimeRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("SetServerTimeImpl is not implemented"));
			var result = new DebugSetServerTimeResponse();
			return result;
		}

		public override async Task<DebugTestResponse> TestImpl(
			DebugTestRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("TestImpl is not implemented"));
			var result = new DebugTestResponse();
			return result;
		}

		public override async Task<DebugTestResponse> Test1Impl(
			DebugTestRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("Test1Impl is not implemented"));
			var result = new DebugTestResponse();
			return result;
		}

		public override async Task<DebugTestResponse> Test2Impl(
			DebugTestRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("Test2Impl is not implemented"));
			var result = new DebugTestResponse();
			return result;
		}

		public override async Task<DebugTestResponse> Test3Impl(
			DebugTestRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("Test3Impl is not implemented"));
			var result = new DebugTestResponse();
			return result;
		}

		public override async Task<DebugTestResponse> Test4Impl(
			DebugTestRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("Test4Impl is not implemented"));
			var result = new DebugTestResponse();
			return result;
		}

		public override async Task<DebugTestResponse> Test5Impl(
			DebugTestRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("Test5Impl is not implemented"));
			var result = new DebugTestResponse();
			return result;
		}

		public override async Task<DebugTestResponse> Test6Impl(
			DebugTestRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("Test6Impl is not implemented"));
			var result = new DebugTestResponse();
			return result;
		}

	}
}
