//GENERATED CODE, DO NOT EDIT !
using System;
using System.Collections.Generic;
using Newtonsoft.Json;


public partial class OperationService : AbstractApiService
{
	#region Singleton
	public static OperationService instance {
		get { return SingletonContainer.GetInstance<OperationService>(); }
	}
	#endregion

	private void TestInner(
		OperationTestRequest request,
		Action<OperationTestResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/operation/test";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<OperationTestResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (OperationTestResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void Test1Inner(
		OperationTestRequest request,
		Action<OperationTestResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/operation/test1";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<OperationTestResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (OperationTestResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void Test2Inner(
		OperationTestRequest request,
		Action<OperationTestResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/operation/test2";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<OperationTestResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (OperationTestResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void Test3Inner(
		OperationTestRequest request,
		Action<OperationTestResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/operation/test3";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<OperationTestResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (OperationTestResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void Test4Inner(
		OperationTestRequest request,
		Action<OperationTestResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/operation/test4";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<OperationTestResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (OperationTestResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void Test5Inner(
		OperationTestRequest request,
		Action<OperationTestResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/operation/test5";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<OperationTestResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (OperationTestResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void UpdateMasterVersionInner(
		OperationUpdateMasterVersionRequest request,
		Action<OperationUpdateMasterVersionResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/operation/update_master_version";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<OperationUpdateMasterVersionResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (OperationUpdateMasterVersionResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void UpdateEventScheduleInner(
		OperationUpdateEventScheduleRequest request,
		Action<OperationUpdateEventScheduleResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/operation/update_event_schedule";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<OperationUpdateEventScheduleResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (OperationUpdateEventScheduleResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}
}

public partial class Services {
	public static OperationService OperationService
		=> OperationService.instance;
}
#region Request/Response
public partial class OperationTestRequest : CommonRequest
{
	[JsonProperty("message")]
	public string message { get; set; }
}

public partial class OperationTestResponse : APIResponse
{
	[JsonProperty("message")]
	public string message { get; set; }
}

public partial class OperationUpdateMasterVersionRequest : CommonRequest
{
	[JsonProperty("message")]
	public string message { get; set; }
}

public partial class OperationUpdateMasterVersionResponse : APIResponse
{
	[JsonProperty("message")]
	public string message { get; set; }
}

public partial class OperationUpdateEventScheduleRequest : CommonRequest
{
	[JsonProperty("message")]
	public string message { get; set; }
}

public partial class OperationUpdateEventScheduleResponse : APIResponse
{
	[JsonProperty("message")]
	public string message { get; set; }
}
#endregion
