using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public partial class FriendRequestService
{

	public void List(Action<FriendRequestListResponse> onSuccess)
	{
		var request = new FriendRequestListRequest();
		ListInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Accept(Action<FriendRequestAcceptResponse> onSuccess)
	{
		var request = new FriendRequestAcceptRequest();
		AcceptInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Reject(Action<FriendRequestRejectResponse> onSuccess)
	{
		var request = new FriendRequestRejectRequest();
		RejectInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

}
