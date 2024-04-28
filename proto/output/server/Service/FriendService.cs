using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.Lambda.Core;

namespace AwsDotnetCsharp
{
	public partial class FriendService : FriendServiceBase
	{

		public override async Task<FriendListResponse> ListImpl(
			FriendListRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("ListImpl is not implemented"));
			var result = new FriendListResponse();
			return result;
		}

		public override async Task<FriendRemoveResponse> RemoveImpl(
			FriendRemoveRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("RemoveImpl is not implemented"));
			var result = new FriendRemoveResponse();
			return result;
		}

		public override async Task<FriendSearchResponse> SearchImpl(
			FriendSearchRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("SearchImpl is not implemented"));
			var result = new FriendSearchResponse();
			return result;
		}

		public override async Task<FriendRequestResponse> RequestImpl(
			FriendRequestRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("RequestImpl is not implemented"));
			var result = new FriendRequestResponse();
			return result;
		}

	}
}
