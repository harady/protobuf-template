//GENERATED CODE, DO NOT EDIT !
using System;
using System.Collections.Generic;
using Newtonsoft.Json;


public partial class FriendRequestService : AbstractApiService
{
	#region Singleton
	public static FriendRequestService instance {
		get { return SingletonContainer.GetInstance<FriendRequestService>(); }
	}
	#endregion

	private void ListInner(
		FriendRequestListRequest request,
		Action<FriendRequestListResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/friend_request/list";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<FriendRequestListResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (FriendRequestListResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void AcceptInner(
		FriendRequestAcceptRequest request,
		Action<FriendRequestAcceptResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/friend_request/accept";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<FriendRequestAcceptResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (FriendRequestAcceptResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void RejectInner(
		FriendRequestRejectRequest request,
		Action<FriendRequestRejectResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/friend_request/reject";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<FriendRequestRejectResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (FriendRequestRejectResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}
}

public partial class Services {
	public static FriendRequestService FriendRequestService
		=> FriendRequestService.instance;
}
#region Request/Response
public partial class FriendRequestListRequest : CommonRequest
{
}

public partial class FriendRequestListResponse : APIResponse
{
	[JsonProperty("other_users")]
	public List<OtherUserData> otherUsers { get; set; } 
		= new List<OtherUserData>();
}

public partial class FriendRequestAcceptRequest : CommonRequest
{
	[JsonProperty("user_id")]
	public long userId { get; set; }
}

public partial class FriendRequestAcceptResponse : APIResponse
{
}

public partial class FriendRequestRejectRequest : CommonRequest
{
	[JsonProperty("user_id")]
	public long userId { get; set; }
}

public partial class FriendRequestRejectResponse : APIResponse
{
}
#endregion
