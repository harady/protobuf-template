using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public partial class MessageService
{

	public void List(Action<MessageListResponse> onSuccess)
	{
		var request = new MessageListRequest();
		ListInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Receive(Action<MessageReceiveResponse> onSuccess)
	{
		var request = new MessageReceiveRequest();
		ReceiveInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

}
