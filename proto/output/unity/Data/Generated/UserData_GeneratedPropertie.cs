using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

[DataContract]
public partial class UserData : AbstractData
{
	[DataMember(Name = "id")]
	public long id { get; set; }

	[DataMember(Name = "name")]
	public string name { get; set; }

	[DataMember(Name = "token")]
	public string token { get; set; }

	[DataMember(Name = "code")]
	public long code { get; set; }

	[DataMember(Name = "rank")]
	public long rank { get; set; }

	[DataMember(Name = "exp")]
	public long exp { get; set; }

	[DataMember(Name = "money")]
	public long money { get; set; }

	[DataMember(Name = "stamina")]
	public long stamina { get; set; }

	[DataMember(Name = "lastStaminaUpdateAt")]
	public long lastStaminaUpdateAt { get; set; }

	public DateTime LastStaminaUpdateAt {
		get { return ServerDateTimeUtil.FromEpoch(lastStaminaUpdateAt); }
		set { lastStaminaUpdateAt = ServerDateTimeUtil.ToEpoch(value); }
	}

	[DataMember(Name = "freeCrystal")]
	public long freeCrystal { get; set; }

	[DataMember(Name = "paidCrystal")]
	public long paidCrystal { get; set; }

	[DataMember(Name = "currentDeckId")]
	public long currentDeckId { get; set; }

	[DataMember(Name = "maxStaminaPlus")]
	public long maxStaminaPlus { get; set; }

	[DataMember(Name = "deckNumPlus")]
	public long deckNumPlus { get; set; }

	[DataMember(Name = "maxFriendNumPlus")]
	public long maxFriendNumPlus { get; set; }

	[DataMember(Name = "unitBoxNumPlus")]
	public long unitBoxNumPlus { get; set; }

	[DataMember(Name = "friendUserUnitId")]
	public long friendUserUnitId { get; set; }

	public UserData Clone() {
		var result = new UserData();
		result.id = id;
		result.name = name;
		result.token = token;
		result.code = code;
		result.rank = rank;
		result.exp = exp;
		result.money = money;
		result.stamina = stamina;
		result.lastStaminaUpdateAt = lastStaminaUpdateAt;
		result.freeCrystal = freeCrystal;
		result.paidCrystal = paidCrystal;
		result.currentDeckId = currentDeckId;
		result.maxStaminaPlus = maxStaminaPlus;
		result.deckNumPlus = deckNumPlus;
		result.maxFriendNumPlus = maxFriendNumPlus;
		result.unitBoxNumPlus = unitBoxNumPlus;
		result.friendUserUnitId = friendUserUnitId;
		return result;
	}

	public string idNameText => GetIdNameText(id, name);

	public override string ToString()
	{
		return JsonConvert.SerializeObject(this);
	}
}
