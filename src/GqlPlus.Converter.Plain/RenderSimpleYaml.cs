using System.Text;

namespace GqlPlus;

public static class RenderSimpleYaml
{
  public const int MaxLineLength = 120;

  public static string[] ToSimpleYaml(this IGqlpValue model, bool _)
    => model is null || model is GqlpUnit && string.IsNullOrEmpty(model.Tag) ? []
      : [.. WriteStructure(model).RemoveEmpty()];

  private static string[] WriteStructure(IGqlpValue item)
  {
    if (item is IGqlpScalar scalar && !ScalarIsEmpty(scalar)) {
      StringBuilder sb = new();
      WriteValue(sb, scalar);
      return [sb.ToString()];
    }

    string[] result = item switch {
      GqlpList list when list.Items.Count > 0 => [.. WriteList(item.Tag, list.Items)],
      GqlpMap map when map.Entries.Count > 0 => [.. WriteMap(item.Tag, map.Entries)],
      _ => [],
    };

    return IsFlow(item) ? WriteStructureFlow(item, result) : result;
  }

  private static string[] WriteStructureFlow(IGqlpValue item, string[] result)
  {
    int maxLength = MaxLineLength * 3 / 2;
    int totalLength = 0;
    foreach (string line in result) {
      totalLength += line.Length;
      if (totalLength > maxLength) {
        return result;
      }
    }

    StringBuilder flow = new();
    WriteFlowStructure(flow, item);

    return flow.Length is > 0 and < MaxLineLength ? [flow.ToString()] : result;
  }

  private static void WriteFlowStructure(StringBuilder flow, IGqlpValue item)
  {
    if (item is IGqlpScalar scalar && !ScalarIsEmpty(scalar)) {
      WriteValue(flow, scalar);
      return;
    }

    if (item is GqlpList list && list.Items.Count > 0) {
      WriteFlowBlock(flow, item.Tag.Prefixed("!") + "[", "]", list.Items, child => WriteFlowStructure(flow, child));
      return;
    }

    if (item is GqlpMap map && map.Entries.Count > 0) {
      WriteFlowBlock(flow,
        item.Tag.Prefixed("!") + "{", "}",
        map.Entries.OrderBy(kv => ScalarText(kv.Key), StringComparer.Ordinal),
        entry => {
          WriteValue(flow, entry.Key);
          flow.Append(':');
          WriteFlowStructure(flow, entry.Value);
        });
    }
  }

  private static void WriteFlowBlock<T>(
    StringBuilder flow,
    string before,
    string after,
    IEnumerable<T> list,
    Action<T> action
  )
  {
    string prefix = before;
    foreach (T item in list) {
      flow.Append(prefix);
      action(item);
      prefix = ",";
    }

    flow.Append(after);
  }

  private static IEnumerable<string> WriteList(string tag, IReadOnlyList<IGqlpValue> list)
  {
    if (list.Count == 0) {
      yield break;
    }

    yield return tag.Prefixed("!");
    foreach (IGqlpValue item in list) {
      foreach (string line in WriteItem(item, "-")) {
        yield return line;
      }
    }
  }

  private static IEnumerable<string> WriteItem(IGqlpValue item, string prefix)
  {
    List<string> newLines = [.. WriteStructure(item)];
    if (newLines.Count == 0) {
      yield break;
    }

    string first = newLines[0];
    if (first.TrimStart().StartsWith("!", StringComparison.Ordinal) || newLines.Count == 1) {
      newLines.RemoveAt(0);
      yield return prefix + " " + first;
      if (newLines.Count == 0) {
        yield break;
      }
    } else {
      yield return prefix;
    }

    foreach (string line in newLines) {
      yield return "  " + line;
    }
  }

  private static IEnumerable<string> WriteMap(string tag, IReadOnlyDictionary<IGqlpScalar, IGqlpValue> map)
  {
    if (map.Count == 0) {
      yield break;
    }

    yield return tag.Prefixed("!");
    foreach (KeyValuePair<IGqlpScalar, IGqlpValue> item in map.OrderBy(kv => ScalarText(kv.Key), StringComparer.Ordinal)) {
      StringBuilder sb = new("");
      WriteValue(sb, item.Key);
      sb.Append(':');

      foreach (string line in WriteItem(item.Value, sb.ToString())) {
        yield return line;
      }
    }
  }

  private static void WriteValue(StringBuilder sb, IGqlpScalar value)
  {
    if (ScalarIsEmpty(value)) {
      return;
    }

    if (!string.IsNullOrWhiteSpace(value.Tag)) {
      sb.Append($"!{value.Tag} ");
    }

    if (value.Kind == GqlpScalarKind.Boolean) {
      sb.Append(value.BooleanValue!.Value.ToString().ToLowerInvariant());
    } else if (value.Kind == GqlpScalarKind.Number) {
      sb.Append($"{value.Number:0.#####}");
    } else if (value.Kind == GqlpScalarKind.Identifier) {
      sb.Append(value.Text);
    } else if (!string.IsNullOrEmpty(value.Text)) {
      sb.Append(value.Text.QuotedIdentifier());
    }
  }

  private static bool IsFlow(IGqlpValue value)
    => value is GqlpList { Flow: true } or GqlpMap { Flow: true };

  private static bool ScalarIsEmpty(IGqlpScalar value)
    => (value.Kind is GqlpScalarKind.Text or GqlpScalarKind.Identifier) && string.IsNullOrEmpty(value.Text);

  private static string ScalarText(IGqlpScalar value)
    => value.Kind switch {
      GqlpScalarKind.Boolean => value.BooleanValue!.Value.TrueFalse(),
      GqlpScalarKind.Number => $"{value.Number:0.#####}",
      _ => value.Text ?? "",
    };
}
