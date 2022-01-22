
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Linq;
namespace Asyncapi.Nats.Client.Models {
  [JsonConverter(typeof(PlayerOnPlayerHitConverter))]
public class PlayerOnPlayerHit {
  private int? hitAreaId;
  private float? hitDistance;
  private float? hitDamage;
  private bool? isKill;
  private PlayerHit victim;
  private PlayerHit attacker;
  private Dictionary<string, dynamic> additionalProperties;

  public int? HitAreaId 
  {
    get { return hitAreaId; }
    set { hitAreaId = value; }
  }

  public float? HitDistance 
  {
    get { return hitDistance; }
    set { hitDistance = value; }
  }

  public float? HitDamage 
  {
    get { return hitDamage; }
    set { hitDamage = value; }
  }

  public bool? IsKill 
  {
    get { return isKill; }
    set { isKill = value; }
  }

  public PlayerHit Victim 
  {
    get { return victim; }
    set { victim = value; }
  }

  public PlayerHit Attacker 
  {
    get { return attacker; }
    set { attacker = value; }
  }

  public Dictionary<string, dynamic> AdditionalProperties 
  {
    get { return additionalProperties; }
    set { additionalProperties = value; }
  }
}

internal class PlayerOnPlayerHitConverter : JsonConverter<PlayerOnPlayerHit>
{
  public override bool CanConvert(Type objectType)
  {
    // this converter can be applied to any type
    return true;
  }
  public override PlayerOnPlayerHit Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    if (reader.TokenType != JsonTokenType.StartObject)
    {
      throw new JsonException();
    }

    var instance = new PlayerOnPlayerHit();
  
    while (reader.Read())
    {
      if (reader.TokenType == JsonTokenType.EndObject)
      {
        return instance;
      }

      // Get the key.
      if (reader.TokenType != JsonTokenType.PropertyName)
      {
        throw new JsonException();
      }

      string propertyName = reader.GetString();
      if (propertyName == "hit_area_id")
      {
        var value = JsonSerializer.Deserialize<int?>(ref reader, options);
        instance.HitAreaId = value;
        continue;
      }
      if (propertyName == "hit_distance")
      {
        var value = JsonSerializer.Deserialize<float?>(ref reader, options);
        instance.HitDistance = value;
        continue;
      }
      if (propertyName == "hit_damage")
      {
        var value = JsonSerializer.Deserialize<float?>(ref reader, options);
        instance.HitDamage = value;
        continue;
      }
      if (propertyName == "isKill")
      {
        var value = JsonSerializer.Deserialize<bool?>(ref reader, options);
        instance.IsKill = value;
        continue;
      }
      if (propertyName == "victim")
      {
        var value = JsonSerializer.Deserialize<PlayerHit>(ref reader, options);
        instance.Victim = value;
        continue;
      }
      if (propertyName == "attacker")
      {
        var value = JsonSerializer.Deserialize<PlayerHit>(ref reader, options);
        instance.Attacker = value;
        continue;
      }

    

      if(instance.AdditionalProperties == null) { instance.AdditionalProperties = new Dictionary<string, dynamic>(); }
      var deserializedValue = JsonSerializer.Deserialize<dynamic>(ref reader, options);
      instance.AdditionalProperties.Add(propertyName, deserializedValue);
      continue;
    }
  
    throw new JsonException();
  }
  public override void Write(Utf8JsonWriter writer, PlayerOnPlayerHit value, JsonSerializerOptions options)
  {
    if (value == null)
    {
      JsonSerializer.Serialize(writer, null);
      return;
    }
    var properties = value.GetType().GetProperties().Where(prop => prop.Name != "AdditionalProperties");
  
    writer.WriteStartObject();

    if(value.HitAreaId != null) { 
      // write property name and let the serializer serialize the value itself
      writer.WritePropertyName("hit_area_id");
      JsonSerializer.Serialize(writer, value.HitAreaId);
    }
    if(value.HitDistance != null) { 
      // write property name and let the serializer serialize the value itself
      writer.WritePropertyName("hit_distance");
      JsonSerializer.Serialize(writer, value.HitDistance);
    }
    if(value.HitDamage != null) { 
      // write property name and let the serializer serialize the value itself
      writer.WritePropertyName("hit_damage");
      JsonSerializer.Serialize(writer, value.HitDamage);
    }
    if(value.IsKill != null) { 
      // write property name and let the serializer serialize the value itself
      writer.WritePropertyName("isKill");
      JsonSerializer.Serialize(writer, value.IsKill);
    }
    if(value.Victim != null) { 
      // write property name and let the serializer serialize the value itself
      writer.WritePropertyName("victim");
      JsonSerializer.Serialize(writer, value.Victim);
    }
    if(value.Attacker != null) { 
      // write property name and let the serializer serialize the value itself
      writer.WritePropertyName("attacker");
      JsonSerializer.Serialize(writer, value.Attacker);
    }


  

    // Unwrap additional properties in object
    if (value.AdditionalProperties != null) {
      foreach (var additionalProperty in value.AdditionalProperties)
      {
        //Ignore any additional properties which might already be part of the core properties
        if (properties.Any(prop => prop.Name == additionalProperty.Key))
        {
            continue;
        }
        // write property name and let the serializer serialize the value itself
        writer.WritePropertyName(additionalProperty.Key);
        JsonSerializer.Serialize(writer, additionalProperty.Value);
      }
    }

    writer.WriteEndObject();
  }

}

}
    