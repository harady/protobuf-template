using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.Lambda.Core;

namespace AwsDotnetCsharp
{
	public partial class BackupService : BackupServiceBase
	{

		public override async Task<BackupSaveTokenResponse> SaveTokenImpl(
			BackupSaveTokenRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("SaveTokenImpl is not implemented"));
			var result = new BackupSaveTokenResponse();
			return result;
		}

		public override async Task<BackupRemoveTokenResponse> RemoveTokenImpl(
			BackupRemoveTokenRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("RemoveTokenImpl is not implemented"));
			var result = new BackupRemoveTokenResponse();
			return result;
		}

		public override async Task<BackupTransferResponse> TransferImpl(
			BackupTransferRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("TransferImpl is not implemented"));
			var result = new BackupTransferResponse();
			return result;
		}

	}
}
