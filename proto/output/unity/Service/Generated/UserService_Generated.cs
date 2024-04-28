//GENERATED CODE, DO NOT EDIT !
using System;
using System.Collections.Generic;
using Newtonsoft.Json;


public partial class UserService : AbstractApiService
{
	#region Singleton
	public static UserService instance {
		get { return SingletonContainer.GetInstance<UserService>(); }
	}
	#endregion

	private void DataListInner(
		UserDataListRequest request,
		Action<UserDataListResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/user/data_list";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<UserDataListResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (UserDataListResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void NameEditInner(
		UserNameEditRequest request,
		Action<UserNameEditResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/user/name_edit";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<UserNameEditResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (UserNameEditResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}
}

public partial class Services {
	public static UserService UserService
		=> UserService.instance;
}
#region Request/Response
public partial class UserDataListRequest : CommonRequest
{
}

public partial class UserDataListResponse : APIResponse
{
}

public partial class UserNameEditRequest : CommonRequest
{
	[JsonProperty("name")]
	public string name { get; set; }
}

public partial class UserNameEditResponse : APIResponse
{
}
#endregion
