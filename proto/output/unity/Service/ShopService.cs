using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public partial class ShopService
{

	public void PurchaseGooglePlay(Action<ShopPurchaseGooglePlayResponse> onSuccess)
	{
		var request = new ShopPurchaseGooglePlayRequest();
		PurchaseGooglePlayInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void PurchaseAppStore(Action<ShopPurchaseAppStoreResponse> onSuccess)
	{
		var request = new ShopPurchaseAppStoreRequest();
		PurchaseAppStoreInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void PurchaseDebug(Action<ShopPurchaseDebugResponse> onSuccess)
	{
		var request = new ShopPurchaseDebugRequest();
		PurchaseDebugInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

}
