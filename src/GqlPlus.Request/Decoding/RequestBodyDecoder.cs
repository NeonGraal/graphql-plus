namespace GqlPlus.Decoding;

public class RequestBodyDecoder
  : IRequestBodyDecoder
{
  public RequestBodyInput Decode(Structured body)
  {
    if (body is null || body.IsEmpty || body.Value?.Boolean is not null || body.Value?.Number is not null) {
      return new RequestBodyInput(null, null, "", null) {
        Errors = Messages.New.Add("Request body must be a string, list, or map with a definition.".Error()),
      };
    }

    if (body.Value is { } value && !string.IsNullOrEmpty(value.Text)) {
      return new RequestBodyInput(null, null, value.Text!, null);
    }

    if (body.List.Count > 0) {
      return DecodeList(body.List);
    }

    if (body.Map.Count > 0) {
      return DecodeMap(body.Map);
    }

    return new RequestBodyInput(null, null, "", null) {
      Errors = Messages.New.Add("Request body must be a string, list, or map with a definition.".Error()),
    };
  }

  private static RequestBodyInput DecodeList(IList<Structured> list)
  {
    string? definition = null;
    Structured? parameters = null;

    foreach (Structured item in list) {
      if (definition is null && item.Value is { } val && !string.IsNullOrEmpty(val.Text)) {
        definition = val.Text;
      } else if (definition is not null) {
        parameters = item;
        break;
      }
    }

    if (definition is null) {
      return new RequestBodyInput(null, null, "", null) {
        Errors = Messages.New.Add("List request body must have a string definition as first element.".Error()),
      };
    }

    return new RequestBodyInput(null, null, definition, parameters);
  }

  private static RequestBodyInput DecodeMap(IDictionary<StructureValue, Structured> map)
  {
    string? definition = GetStringValue(map, "definition");

    if (definition is null) {
      return new RequestBodyInput(null, null, "", null) {
        Errors = Messages.New.Add("Map request body must have a 'definition' key.".Error()),
      };
    }

    string? category = GetStringValue(map, "category");
    string? operation = GetStringValue(map, "operation");
    Structured? parameters = GetValue(map, "parameters");

    return new RequestBodyInput(category, operation, definition, parameters);
  }

  private static string? GetStringValue(IDictionary<StructureValue, Structured> map, string key)
  {
    Structured? value = GetValue(map, key);
    return value?.Value?.Text;
  }

  private static Structured? GetValue(IDictionary<StructureValue, Structured> map, string key)
  {
    StructureValue mapKey = new(key);
    return map.TryGetValue(mapKey, out Structured? value) ? value : null;
  }
}
