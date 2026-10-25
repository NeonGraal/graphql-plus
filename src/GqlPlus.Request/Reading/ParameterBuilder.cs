namespace GqlPlus.Reading;

public static class ParameterBuilder
{
  public static IGqlpValue Build(IReadOnlyList<(string Path, string Value)> parameters)
  {
    if (parameters is null || parameters.Count == 0) {
      return new GqlpUnit();
    }

    Dictionary<string, List<string>> grouped = [];

    foreach ((string path, string value) in parameters) {
      if (!grouped.TryGetValue(path, out List<string>? values)) {
        values = [];
        grouped[path] = values;
      }

      values.Add(value);
    }

    return BuildMap(grouped);
  }

  private static GqlpMap BuildMap(Dictionary<string, List<string>> grouped)
  {
    Dictionary<string, object> tree = [];

    foreach (KeyValuePair<string, List<string>> entry in grouped) {
      InsertPath(tree, entry.Key.Split('.'), entry.Value);
    }

    return ConvertToGqlpMap(tree);
  }

  private static void InsertPath(Dictionary<string, object> node, string[] segments, List<string> values)
  {
    string key = segments[0];

    if (segments.Length == 1) {
      node[key] = values;
      return;
    }

    if (!node.TryGetValue(key, out object? child) || child is not Dictionary<string, object> childDict) {
      childDict = [];
      node[key] = childDict;
    }

    InsertPath(childDict, [.. segments.Skip(1)], values);
  }

  private static GqlpMap ConvertToGqlpMap(Dictionary<string, object> tree)
  {
    List<KeyValuePair<IGqlpScalar, IGqlpValue>> map = [];

    foreach (KeyValuePair<string, object> entry in tree) {

      IGqlpValue value = entry.Value switch {
        List<string> values when values.Count == 1 => values[0].Encode(),
        List<string> values => values.Encode(),
        Dictionary<string, object> nested => ConvertToGqlpMap(nested),
        _ => new GqlpUnit(),
      };

      map.Add(new(new GqlpScalar(entry.Key, isIdentifier: entry.Key.IsIdentifier()), value));
    }

    return new GqlpMap(map);
  }
}
