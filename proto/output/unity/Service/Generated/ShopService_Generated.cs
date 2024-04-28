//GENERATED CODE, DO NOT EDIT !
using System;
using System.Collections.Generic;
using Newtonsoft.Json;


public partial class ShopService : AbstractApiService
{
	#region Singleton
	public static ShopService instance {
		get { return SingletonContainer.GetInstance<ShopService>(); }
	}
	#endregion

	private void PurchaseGooglePlayInner(
		ShopPurchaseGooglePlayRequest request,
		Action<ShopPurchaseGooglePlayResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/shop/purchase_google_play";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<ShopPurchaseGooglePlayResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (ShopPurchaseGooglePlayResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void PurchaseAppStoreInner(
		ShopPurchaseAppStoreRequest request,
		Action<ShopPurchaseAppStoreResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/shop/purchase_app_store";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<ShopPurchaseAppStoreResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (ShopPurchaseAppStoreResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void PurchaseDebugInner(
		ShopPurchaseDebugRequest request,
		Action<ShopPurchaseDebugResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/shop/purchase_debug";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<ShopPurchaseDebugResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (ShopPurchaseDebugResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}
}

public partial class Services {
	public static ShopService ShopService
		=> ShopService.instance;
}
#region Request/Response
public partial class ShopPurchaseGooglePlayRequest : CommonRequest
{
	[JsonProperty("shop_item_id")]
	public long shopItemId { get; set; }
	[JsonProperty("signed_data")]
	public string signedData { get; set; }
	[JsonProperty("signature")]
	public string signature { get; set; }
}

public partial class ShopPurchaseGooglePlayResponse : APIResponse
{
}

public partial class ShopPurchaseAppStoreRequest : CommonRequest
{
	[JsonProperty("shop_item_id")]
	public long shopItemId { get; set; }
	[JsonProperty("receipt")]
	public string receipt { get; set; }
}

public partial class ShopPurchaseAppStoreResponse : APIResponse
{
}

public partial class ShopPurchaseDebugRequest : CommonRequest
{
	[JsonProperty("shop_item_id")]
	public long shopItemId { get; set; }
}

public partial class ShopPurchaseDebugResponse : APIResponse
{
}
#endregion
