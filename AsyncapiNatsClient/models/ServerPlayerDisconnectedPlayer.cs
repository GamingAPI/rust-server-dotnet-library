namespace Asyncapi.Nats.Client.Models
{
  using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Linq;
  [JsonConverter(typeof(ServerPlayerDisconnectedPlayerConverter))]
public class ServerPlayerDisconnectedPlayer {
  private string id;
  private Dictionary<string, dynamic> additionalProperties;

  public string Id 
  {
    get { return id; }
    set { id = value; }
  }

  public Dictionary<string, dynamic> AdditionalProperties 
  {
    get { return additionalProperties; }
    set { additionalProperties = value; }
  }
}

internal class ServerPlayerDisconnectedPlayerConverter : JsonConverter<ServerPlayerDisconnectedPlayer>
{
  public override bool CanConvert(Type objectType)
  {
    // this converter can be applied to any type
    return true;
  }
  public override ServerPlayerDisconnectedPlayer Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    if (reader.TokenType != JsonTokenType.StartObject)
    {
      throw new JsonException();
    }

    var instance = new ServerPlayerDisconnectedPlayer();
  
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
      if (propertyName == "id")
      {
        var value = JsonSerializer.Deserialize<string>(ref reader, options);
        instance.Id = value;
        continue;
      }

    

      if(instance.AdditionalProperties == null) { instance.AdditionalProperties = new Dictionary<string, dynamic>(); }
      var deserializedValue = JsonSerializer.Deserialize<dynamic>(ref reader, options);
      instance.AdditionalProperties.Add(propertyName, deserializedValue);
      continue;
    }
  
    throw new JsonException();
  }
  public override void Write(Utf8JsonWriter writer, ServerPlayerDisconnectedPlayer value, JsonSerializerOptions options)
  {
    if (value == null)
    {
      JsonSerializer.Serialize(writer, null);
      return;
    }
    var properties = value.GetType().GetProperties().Where(prop => prop.Name != "AdditionalProperties");
  
    writer.WriteStartObject();

    if(value.Id != null) { 
      // write property name and let the serializer serialize the value itself
      writer.WritePropertyName("id");
      JsonSerializer.Serialize(writer, value.Id);
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