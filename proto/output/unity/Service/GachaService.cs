using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public partial class GachaService
{

	public void Draw(Action<GachaDrawResponse> onSuccess)
	{
		var request = new GachaDrawRequest();
		DrawInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

}
