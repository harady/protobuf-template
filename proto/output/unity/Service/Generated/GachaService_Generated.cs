//GENERATED CODE, DO NOT EDIT !
using System;
using System.Collections.Generic;
using Newtonsoft.Json;


public partial class GachaService : AbstractApiService
{
	#region Singleton
	public static GachaService instance {
		get { return SingletonContainer.GetInstance<GachaService>(); }
	}
	#endregion

	private void DrawInner(
		GachaDrawRequest request,
		Action<GachaDrawResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/gacha/draw";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<GachaDrawResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (GachaDrawResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}
}

public partial class Services {
	public static GachaService GachaService
		=> GachaService.instance;
}
#region Request/Response
public partial class GachaDrawRequest : CommonRequest
{
	[JsonProperty("gacha_button_id")]
	public long gachaButtonId { get; set; }
}

public partial class GachaDrawResponse : APIResponse
{
	[JsonProperty("gacha_result_items")]
	public List<GachaResultItemData> gachaResultItems { get; set; } 
		= new List<GachaResultItemData>();
}
#endregion
