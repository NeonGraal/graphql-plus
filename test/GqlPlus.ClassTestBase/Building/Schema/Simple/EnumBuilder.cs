using GqlPlus.Ast.Schema;

namespace GqlPlus.Building.Schema.Simple;

public class EnumBuilder
  : SimpleBuilder<IAstEnum>
{
  internal IAstEnumLabel[] _labels = [];

  public EnumBuilder(string name)
    : base(name)
  {
    Add<IAstEnum>();
    _typeKind = TypeKind.Enum;
  }

  protected new T Build<T>()
    where T : class, IAstEnum
  {
    T result = base.Build<T>();
    result.Items.Returns(_labels);

    HashSet<string> labels = [.. _labels.Select(l => l.Name)];
    result.HasValue(Arg.Is<string>(v => labels.Contains(v))).Returns(true);

    return result;
  }

  public IAstEnum AsEnum
    => Build<IAstEnum>();

  public override IAstEnum AsSimple => AsEnum;
}

public static class EnumBuilderHelper
{
  public static T WithLabels<T>(this T builder, params IAstEnumLabel[] labels)
    where T : EnumBuilder
    => builder.FluentAction(b => b._labels = labels);
  public static T WithLabels<T>(this T builder, string[] labels)
    where T : EnumBuilder
    => builder.WithLabels(labels.AsArray(l => builder.Aliased<IAstEnumLabel>(l, [])));
}
