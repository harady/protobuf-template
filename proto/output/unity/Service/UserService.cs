using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public partial class UserService
{

	public void DataList(Action<UserDataListResponse> onSuccess)
	{
		var request = new UserDataListRequest();
		DataListInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void NameEdit(Action<UserNameEditResponse> onSuccess)
	{
		var request = new UserNameEditRequest();
		NameEditInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

}
