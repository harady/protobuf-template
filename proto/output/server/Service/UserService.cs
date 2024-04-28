using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.Lambda.Core;

namespace AwsDotnetCsharp
{
	public partial class UserService : UserServiceBase
	{

		public override async Task<UserDataListResponse> DataListImpl(
			UserDataListRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("DataListImpl is not implemented"));
			var result = new UserDataListResponse();
			return result;
		}

		public override async Task<UserNameEditResponse> NameEditImpl(
			UserNameEditRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("NameEditImpl is not implemented"));
			var result = new UserNameEditResponse();
			return result;
		}

	}
}
