service Message
   .monstershot.MessageListResponse List(.monstershot.MessageListRequest)
   .monstershot.MessageReceiveResponse Receive(.monstershot.MessageReceiveRequest)
message MessageListRequest
message MessageListResponse
message MessageReceiveRequest
    user_message_id
message MessageReceiveResponse
template=template/csharp_unity_service-partial.gotemplate,fileSuffix=Service.cs
