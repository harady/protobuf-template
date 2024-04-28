using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public partial class FriendService
{

	public void List(Action<FriendListResponse> onSuccess)
	{
		var request = new FriendListRequest();
		ListInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Remove(Action<FriendRemoveResponse> onSuccess)
	{
		var request = new FriendRemoveRequest();
		RemoveInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Search(Action<FriendSearchResponse> onSuccess)
	{
		var request = new FriendSearchRequest();
		SearchInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Request(Action<FriendRequestResponse> onSuccess)
	{
		var request = new FriendRequestRequest();
		RequestInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

}
