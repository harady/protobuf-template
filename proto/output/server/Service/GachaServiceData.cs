service Gacha
   .monstershot.GachaDrawResponse Draw(.monstershot.GachaDrawRequest)
message GachaDrawRequest
    gacha_button_id
message GachaDrawResponse
   .monstershot.GachaResultItemData gacha_result_items
template=template/csharp_server_model-partial.gotemplate,fileSuffix=ServiceData.cs
