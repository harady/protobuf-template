using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.Lambda.Core;

namespace AwsDotnetCsharp
{
	public partial class ShopService : ShopServiceBase
	{

		public override async Task<ShopPurchaseGooglePlayResponse> PurchaseGooglePlayImpl(
			ShopPurchaseGooglePlayRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("PurchaseGooglePlayImpl is not implemented"));
			var result = new ShopPurchaseGooglePlayResponse();
			return result;
		}

		public override async Task<ShopPurchaseAppStoreResponse> PurchaseAppStoreImpl(
			ShopPurchaseAppStoreRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("PurchaseAppStoreImpl is not implemented"));
			var result = new ShopPurchaseAppStoreResponse();
			return result;
		}

		public override async Task<ShopPurchaseDebugResponse> PurchaseDebugImpl(
			ShopPurchaseDebugRequest request, ILambdaContext context)
		{
			await Task.Run(() => Console.WriteLine("PurchaseDebugImpl is not implemented"));
			var result = new ShopPurchaseDebugResponse();
			return result;
		}

	}
}
