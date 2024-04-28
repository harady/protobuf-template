using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public partial class UnitService
{

	public void DeckEdit(Action<UnitDeckEditResponse> onSuccess)
	{
		var request = new UnitDeckEditRequest();
		DeckEditInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Powerup(Action<UnitPowerupResponse> onSuccess)
	{
		var request = new UnitPowerupRequest();
		PowerupInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Evolution(Action<UnitEvolutionResponse> onSuccess)
	{
		var request = new UnitEvolutionRequest();
		EvolutionInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Sell(Action<UnitSellResponse> onSuccess)
	{
		var request = new UnitSellRequest();
		SellInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Lock(Action<UnitLockResponse> onSuccess)
	{
		var request = new UnitLockRequest();
		LockInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

}
