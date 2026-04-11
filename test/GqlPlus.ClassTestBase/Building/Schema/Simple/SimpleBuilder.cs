using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Building.Schema.Simple;

public class SimpleBuilder
  : TypeBuilder
{
  internal IAstTypeRef? _parent;

  public SimpleBuilder(string name)
    : base(name)
    => Add<IAstSimple>();

  protected new T Build<T>()
    where T : class, IAstSimple
  {
    T result = base.Build<T>();
    result.Parent.Returns(_parent);
    return result;
  }
}

public abstract class SimpleBuilder<T>
  : SimpleBuilder
    where T : class, IAstSimple
{
  protected SimpleBuilder(string name)
    : base(name)
    => Add<T>();

  public abstract T AsSimple { get; }
}

public static class SimpleBuilderHelper
{
  public static T WithParent<T>(this T builder, string parent = "")
    where T : SimpleBuilder
    => builder.FluentAction(b => b._parent = new NamedBuilder<IAstTypeRef>(parent).AsNamed);
}
