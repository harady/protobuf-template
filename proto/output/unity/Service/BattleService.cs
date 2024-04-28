using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public partial class BattleService
{

	public void HelperList(Action<BattleHelperListResponse> onSuccess)
	{
		var request = new BattleHelperListRequest();
		HelperListInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Start(Action<BattleStartResponse> onSuccess)
	{
		var request = new BattleStartRequest();
		StartInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Continue(Action<BattleContinueResponse> onSuccess)
	{
		var request = new BattleContinueRequest();
		ContinueInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Giveup(Action<BattleGiveupResponse> onSuccess)
	{
		var request = new BattleGiveupRequest();
		GiveupInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Clear(Action<BattleClearResponse> onSuccess)
	{
		var request = new BattleClearRequest();
		ClearInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

}
