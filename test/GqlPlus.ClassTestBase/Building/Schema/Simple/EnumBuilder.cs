using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Building.Schema.Simple;

public class EnumBuilder
  : SimpleBuilder
{
  internal IGqlpEnumLabel[] _labels = [];

  public EnumBuilder(string name)
    : base(name)
  {
    Add<IGqlpEnum>();
    Add<IGqlpType>();
  }

  protected new T Build<T>()
    where T : class, IGqlpEnum
  {
    T result = base.Build<T>();
    result.Items.Returns(_labels);

    HashSet<string> labels = [.. _labels.Select(l => l.Name)];
    result.HasValue(Arg.Is<string>(v => labels.Contains(v))).Returns(true);

    return result;
  }

  public IGqlpEnum AsEnum
    => Build<IGqlpEnum>();
}

public static class EnumBuilderHelper
{
  public static T WithLabels<T>(this T builder, params IGqlpEnumLabel[] labels)
    where T : EnumBuilder
    => builder.FluentAction(b => b._labels = labels);
  public static T WithLabels<T>(this T builder, string[] labels)
    where T : EnumBuilder
    => builder.WithLabels(labels.AsArray(l => builder.Aliased<IGqlpEnumLabel>(l, [])));
}
