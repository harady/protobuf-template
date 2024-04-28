using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public partial class ExchangeService
{

	public void Exchange(Action<ExchangeExchangeResponse> onSuccess)
	{
		var request = new ExchangeExchangeRequest();
		ExchangeInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

}
