using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public partial class DebugService
{

	public void SetServerTime(Action<DebugSetServerTimeResponse> onSuccess)
	{
		var request = new DebugSetServerTimeRequest();
		SetServerTimeInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Test(Action<DebugTestResponse> onSuccess)
	{
		var request = new DebugTestRequest();
		TestInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Test1(Action<DebugTestResponse> onSuccess)
	{
		var request = new DebugTestRequest();
		Test1Inner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Test2(Action<DebugTestResponse> onSuccess)
	{
		var request = new DebugTestRequest();
		Test2Inner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Test3(Action<DebugTestResponse> onSuccess)
	{
		var request = new DebugTestRequest();
		Test3Inner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Test4(Action<DebugTestResponse> onSuccess)
	{
		var request = new DebugTestRequest();
		Test4Inner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Test5(Action<DebugTestResponse> onSuccess)
	{
		var request = new DebugTestRequest();
		Test5Inner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Test6(Action<DebugTestResponse> onSuccess)
	{
		var request = new DebugTestRequest();
		Test6Inner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

}
