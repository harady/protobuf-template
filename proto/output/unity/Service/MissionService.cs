using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public partial class MissionService
{

	public void Achieve(Action<MissionAchieveResponse> onSuccess)
	{
		var request = new MissionAchieveRequest();
		AchieveInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Receive(Action<MissionReceiveResponse> onSuccess)
	{
		var request = new MissionReceiveRequest();
		ReceiveInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

}
