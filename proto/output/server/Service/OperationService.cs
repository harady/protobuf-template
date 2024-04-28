using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.Lambda.Core;

namespace AwsDotnetCsharp
{
	public partial class OperationService : OperationServiceBase
	{

		public override async Task<OperationTestResponse> TestImpl(
			OperationTestRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("TestImpl is not implemented"));
			var result = new OperationTestResponse();
			return result;
		}

		public override async Task<OperationTestResponse> Test1Impl(
			OperationTestRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("Test1Impl is not implemented"));
			var result = new OperationTestResponse();
			return result;
		}

		public override async Task<OperationTestResponse> Test2Impl(
			OperationTestRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("Test2Impl is not implemented"));
			var result = new OperationTestResponse();
			return result;
		}

		public override async Task<OperationTestResponse> Test3Impl(
			OperationTestRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("Test3Impl is not implemented"));
			var result = new OperationTestResponse();
			return result;
		}

		public override async Task<OperationTestResponse> Test4Impl(
			OperationTestRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("Test4Impl is not implemented"));
			var result = new OperationTestResponse();
			return result;
		}

		public override async Task<OperationTestResponse> Test5Impl(
			OperationTestRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("Test5Impl is not implemented"));
			var result = new OperationTestResponse();
			return result;
		}

		public override async Task<OperationUpdateMasterVersionResponse> UpdateMasterVersionImpl(
			OperationUpdateMasterVersionRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("UpdateMasterVersionImpl is not implemented"));
			var result = new OperationUpdateMasterVersionResponse();
			return result;
		}

		public override async Task<OperationUpdateEventScheduleResponse> UpdateEventScheduleImpl(
			OperationUpdateEventScheduleRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("UpdateEventScheduleImpl is not implemented"));
			var result = new OperationUpdateEventScheduleResponse();
			return result;
		}

	}
}
