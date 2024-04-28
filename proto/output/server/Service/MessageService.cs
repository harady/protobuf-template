using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.Lambda.Core;

namespace AwsDotnetCsharp
{
	public partial class MessageService : MessageServiceBase
	{

		public override async Task<MessageListResponse> ListImpl(
			MessageListRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("ListImpl is not implemented"));
			var result = new MessageListResponse();
			return result;
		}

		public override async Task<MessageReceiveResponse> ReceiveImpl(
			MessageReceiveRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("ReceiveImpl is not implemented"));
			var result = new MessageReceiveResponse();
			return result;
		}

	}
}
