using System.Text.Json;
using System.Text.Json.Serialization;

namespace DataModel
{
    // This is special JSON class required to serialize Coordinate to json as text value.
    // This class converts Coordinate to String and back during different JSON serializarion scenarious.
    internal class CoordinateSerializeConvertor : JsonConverter<Coordinate>
    {
        public override Coordinate Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return new Coordinate { Name = reader.GetString()! };
        }

        public override void Write(Utf8JsonWriter writer, Coordinate value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.Name);
        }

        public override Coordinate ReadAsPropertyName(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return new Coordinate { Name = reader.GetString()! };
        }

        public override void WriteAsPropertyName(Utf8JsonWriter writer, Coordinate value, JsonSerializerOptions options)
        {
            writer.WritePropertyName(value.Name);
        }
    }
}
