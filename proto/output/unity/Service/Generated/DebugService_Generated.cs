//GENERATED CODE, DO NOT EDIT !
using System;
using System.Collections.Generic;
using Newtonsoft.Json;


public partial class DebugService : AbstractApiService
{
	#region Singleton
	public static DebugService instance {
		get { return SingletonContainer.GetInstance<DebugService>(); }
	}
	#endregion

	private void SetServerTimeInner(
		DebugSetServerTimeRequest request,
		Action<DebugSetServerTimeResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/debug/set_server_time";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<DebugSetServerTimeResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (DebugSetServerTimeResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void TestInner(
		DebugTestRequest request,
		Action<DebugTestResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/debug/test";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<DebugTestResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (DebugTestResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void Test1Inner(
		DebugTestRequest request,
		Action<DebugTestResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/debug/test1";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<DebugTestResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (DebugTestResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void Test2Inner(
		DebugTestRequest request,
		Action<DebugTestResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/debug/test2";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<DebugTestResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (DebugTestResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void Test3Inner(
		DebugTestRequest request,
		Action<DebugTestResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/debug/test3";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<DebugTestResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (DebugTestResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void Test4Inner(
		DebugTestRequest request,
		Action<DebugTestResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/debug/test4";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<DebugTestResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (DebugTestResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void Test5Inner(
		DebugTestRequest request,
		Action<DebugTestResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/debug/test5";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<DebugTestResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (DebugTestResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void Test6Inner(
		DebugTestRequest request,
		Action<DebugTestResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/debug/test6";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<DebugTestResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (DebugTestResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}
}

public partial class Services {
	public static DebugService DebugService
		=> DebugService.instance;
}
#region Request/Response
public partial class DebugSetServerTimeRequest : CommonRequest
{
	[JsonProperty("is_clear")]
	public bool isClear { get; set; }
	[JsonProperty("to_set_server_time")]
	public long toSetServerTime { get; set; }
}

public partial class DebugSetServerTimeResponse : APIResponse
{
}

public partial class DebugTestRequest : CommonRequest
{
	[JsonProperty("message")]
	public string message { get; set; }
}

public partial class DebugTestResponse : APIResponse
{
	[JsonProperty("message")]
	public string message { get; set; }
}
#endregion
