//GENERATED CODE, DO NOT EDIT !
using System;
using System.Collections.Generic;
using Newtonsoft.Json;


public partial class MessageService : AbstractApiService
{
	#region Singleton
	public static MessageService instance {
		get { return SingletonContainer.GetInstance<MessageService>(); }
	}
	#endregion

	private void ListInner(
		MessageListRequest request,
		Action<MessageListResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/message/list";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<MessageListResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (MessageListResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void ReceiveInner(
		MessageReceiveRequest request,
		Action<MessageReceiveResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/message/receive";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<MessageReceiveResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (MessageReceiveResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}
}

public partial class Services {
	public static MessageService MessageService
		=> MessageService.instance;
}
#region Request/Response
public partial class MessageListRequest : CommonRequest
{
}

public partial class MessageListResponse : APIResponse
{
}

public partial class MessageReceiveRequest : CommonRequest
{
	[JsonProperty("user_message_id")]
	public long userMessageId { get; set; }
}

public partial class MessageReceiveResponse : APIResponse
{
}
#endregion
