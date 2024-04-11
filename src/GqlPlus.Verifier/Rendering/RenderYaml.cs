using GqlPlus.Verifier.Token;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace GqlPlus.Verifier.Rendering;

internal static class RenderYaml
{
  internal static ISerializer Serializer { get; } = new SerializerBuilder()
      .WithNamingConvention(CamelCaseNamingConvention.Instance)
      .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitNull | DefaultValuesHandling.OmitEmptyCollections)
      .WithTypeConverter(RenderTypeConverter.Instance)
      .EnsureRoundtrip()
      .Build();

  internal static RenderStructure Render(this IEnumerable<string> strings, string tag = "", bool flow = true)
    => new(strings.Select(a => new RenderStructure(new RenderValue(a))), tag, flow);

  internal static RenderStructure Render(this ITokenMessages errors)
    => new(errors.Select(Render), "_Errors");

  internal static RenderStructure Render(this TokenMessage error)
    => RenderStructure.New("_Error")
      .Add(error.Kind is TokenKind.Start or TokenKind.End,
        onFalse: r => r.Add("_at", error.RenderAt()))
      .Add("_kind", error.Kind)
      .Add("_message", error.Message);

  internal static RenderStructure RenderAt(this TokenAt at)
    => RenderStructure.New("_At", true)
      .Add("_col", at.Column)
      .Add("_line", at.Line);

  internal static RenderStructure Render<T>(this IEnumerable<T> values, IRenderContext context, string tag = "", bool flow = false)
    where T : IRendering
    => new(values.Select(v => v.Render(context)), tag, flow);

  internal static RenderStructure Render<T>(this IMap<T> values, IRenderContext context, string keyTag = "", string dictTag = "", bool flow = false)
    where T : IRendering
    => new(values.ToDictionary(
        p => new RenderValue(p.Key, keyTag),
        p => p.Value.Render(context)), "_Map" + dictTag, flow);

  internal static string TrueFalse(this bool value)
    => value ? "true" : "false";

  internal static string TypeTag(this Type type)
  {
    var result = "_" + type.Name.Replace("Model", "", StringComparison.InvariantCulture);

    if (type.IsGenericType) {
      var typeParams = type.GetGenericArguments().Select(TypeTag);

      result = result.Split('`')[0] + "(" + string.Concat(typeParams) + ")";
    }

    return result;
  }

  internal static RenderStructure RenderEnum<TEnum>(this TEnum value)
    where TEnum : struct
    => new(value.ToString(), value.GetType().TypeTag());
}
