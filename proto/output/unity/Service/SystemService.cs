using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public partial class SystemService
{

	public void Ping(Action<SystemPingResponse> onSuccess)
	{
		var request = new SystemPingRequest();
		PingInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Signup(Action<SystemSignupResponse> onSuccess)
	{
		var request = new SystemSignupRequest();
		SignupInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Login(Action<SystemLoginResponse> onSuccess)
	{
		var request = new SystemLoginRequest();
		LoginInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

}
