//GENERATED CODE, DO NOT EDIT !
using System;
using System.Collections.Generic;
using Newtonsoft.Json;


public partial class BackupService : AbstractApiService
{
	#region Singleton
	public static BackupService instance {
		get { return SingletonContainer.GetInstance<BackupService>(); }
	}
	#endregion

	private void SaveTokenInner(
		BackupSaveTokenRequest request,
		Action<BackupSaveTokenResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/backup/save_token";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<BackupSaveTokenResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (BackupSaveTokenResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void RemoveTokenInner(
		BackupRemoveTokenRequest request,
		Action<BackupRemoveTokenResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/backup/remove_token";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<BackupRemoveTokenResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (BackupRemoveTokenResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}

	private void TransferInner(
		BackupTransferRequest request,
		Action<BackupTransferResponse> onSuccess,
		Action<ErrorResponse> onFailure = null)
	{
		const string Path = "api/backup/transfer";
		request.SetupCommon();
		var apiRequest = new APIRequest(Path, request);
		// リクエストを送信.
		GetApiSender().SendRequest<BackupTransferResponse>(
			apiRequest: apiRequest,
			onSuccess: (apiResponse) => {
				var response = (BackupTransferResponse)apiResponse;
				onSuccess?.Invoke(response);
			},
			onFailure: onFailure
		);
	}
}

public partial class Services {
	public static BackupService BackupService
		=> BackupService.instance;
}
#region Request/Response
public partial class BackupSaveTokenRequest : CommonRequest
{
	[JsonProperty("backup_type")]
	public BackupType backupType { get; set; }
	[JsonProperty("backup_token")]
	public string backupToken { get; set; }
}

public partial class BackupSaveTokenResponse : APIResponse
{
}

public partial class BackupRemoveTokenRequest : CommonRequest
{
	[JsonProperty("backup_type")]
	public BackupType backupType { get; set; }
}

public partial class BackupRemoveTokenResponse : APIResponse
{
}

public partial class BackupTransferRequest : CommonRequest
{
	[JsonProperty("backup_type")]
	public BackupType backupType { get; set; }
	[JsonProperty("backup_token")]
	public string backupToken { get; set; }
}

public partial class BackupTransferResponse : APIResponse
{
	[JsonProperty("token")]
	public string token { get; set; }
	[JsonProperty("session_id")]
	public string sessionId { get; set; }
}
#endregion
