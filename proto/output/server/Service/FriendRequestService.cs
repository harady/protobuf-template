using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.Lambda.Core;

namespace AwsDotnetCsharp
{
	public partial class FriendRequestService : FriendRequestServiceBase
	{

		public override async Task<FriendRequestListResponse> ListImpl(
			FriendRequestListRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("ListImpl is not implemented"));
			var result = new FriendRequestListResponse();
			return result;
		}

		public override async Task<FriendRequestAcceptResponse> AcceptImpl(
			FriendRequestAcceptRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("AcceptImpl is not implemented"));
			var result = new FriendRequestAcceptResponse();
			return result;
		}

		public override async Task<FriendRequestRejectResponse> RejectImpl(
			FriendRequestRejectRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("RejectImpl is not implemented"));
			var result = new FriendRequestRejectResponse();
			return result;
		}

	}
}
