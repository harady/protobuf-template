using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public partial class OperationService
{

	public void Test(Action<OperationTestResponse> onSuccess)
	{
		var request = new OperationTestRequest();
		TestInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Test1(Action<OperationTestResponse> onSuccess)
	{
		var request = new OperationTestRequest();
		Test1Inner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Test2(Action<OperationTestResponse> onSuccess)
	{
		var request = new OperationTestRequest();
		Test2Inner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Test3(Action<OperationTestResponse> onSuccess)
	{
		var request = new OperationTestRequest();
		Test3Inner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Test4(Action<OperationTestResponse> onSuccess)
	{
		var request = new OperationTestRequest();
		Test4Inner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void Test5(Action<OperationTestResponse> onSuccess)
	{
		var request = new OperationTestRequest();
		Test5Inner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void UpdateMasterVersion(Action<OperationUpdateMasterVersionResponse> onSuccess)
	{
		var request = new OperationUpdateMasterVersionRequest();
		UpdateMasterVersionInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

	public void UpdateEventSchedule(Action<OperationUpdateEventScheduleResponse> onSuccess)
	{
		var request = new OperationUpdateEventScheduleRequest();
		UpdateEventScheduleInner(
			request: request,
			onSuccess: (response) => {
				onSuccess?.Invoke(response);
			}
		);
	}

}
