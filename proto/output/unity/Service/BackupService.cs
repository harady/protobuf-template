using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public partial class BackupService
{

	public void SaveToken(Action<BackupSaveTokenResponse> onSuccess)
	{
		var request = new BackupSaveTokenRequest();
		SaveTokenInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void RemoveToken(Action<BackupRemoveTokenResponse> onSuccess)
	{
		var request = new BackupRemoveTokenRequest();
		RemoveTokenInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Transfer(Action<BackupTransferResponse> onSuccess)
	{
		var request = new BackupTransferRequest();
		TransferInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

}
