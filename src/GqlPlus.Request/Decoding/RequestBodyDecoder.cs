namespace GqlPlus.Decoding;

public class RequestBodyDecoder
  : IRequestBodyDecoder
{
  public RequestBodyInput Decode(IGqlpValue body)
  {
    if (body is null || body is GqlpNull or GqlpVoid or GqlpUnit
        || body is GqlpScalar { Kind: GqlpScalarKind.Boolean or GqlpScalarKind.Number }) {
      return InvalidBody();
    }

    if (body is GqlpScalar { Text: not null } scalar) {
      return new RequestBodyInput(null, null, scalar.Text, null);
    }

    if (body is GqlpList list) {
      return DecodeList(list.Items);
    }

    if (body is GqlpMap map) {
      return DecodeMap(map);
    }

    return InvalidBody();
  }

  private static RequestBodyInput DecodeList(IReadOnlyList<IGqlpValue> list)
  {
    string? definition = list.Count > 0 && list[0] is GqlpScalar { Text: not null } first ? first.Text : null;

    if (string.IsNullOrEmpty(definition)) {
      return new RequestBodyInput(null, null, "", null) {
        Errors = Messages.New.Add("List request body must have a string definition as first element.".Error()),
      };
    }

    IGqlpValue? parameters = list.Count switch {
      2 => list[1],
      > 2 => new GqlpList(list.Skip(1)),
      _ => null,
    };

    return new RequestBodyInput(null, null, definition!, parameters);
  }

  private static RequestBodyInput DecodeMap(GqlpMap map)
  {
    string? definition = GetStringValue(map, "definition");
    if (definition is null) {
      return new RequestBodyInput(null, null, "", null) {
        Errors = Messages.New.Add("Map request body must have a 'definition' key.".Error()),
      };
    }

    return new RequestBodyInput(
      GetStringValue(map, "category"),
      GetStringValue(map, "operation"),
      definition,
      GetValue(map, "parameters"));
  }

  private static string? GetStringValue(GqlpMap map, string key)
    => GetValue(map, key) is GqlpScalar { Text: not null } value ? value.Text : null;

  private static IGqlpValue? GetValue(GqlpMap map, string key)
    => map.Entries.FirstOrDefault(e => e.Key.Text == key).Value;

  private static RequestBodyInput InvalidBody()
    => new(null, null, "", null) {
      Errors = Messages.New.Add("Request body must be a string, list, or map with a definition.".Error()),
    };
}
