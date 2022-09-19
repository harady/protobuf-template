service Mission
   .monstershot.MissionAchieveResponse Achieve(.monstershot.MissionAchieveRequest)
   .monstershot.MissionReceiveResponse Receive(.monstershot.MissionReceiveRequest)
message MissionAchieveRequest
    mission_id
message MissionAchieveResponse
message MissionReceiveRequest
    mission_ids
message MissionReceiveResponse
template=template/csharp_server_model-partial.gotemplate,fileSuffix=ServiceData.cs
