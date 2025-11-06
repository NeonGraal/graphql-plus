using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Building.Schema.Simple;

public class SimpleBuilder
  : TypeBuilder
{
  internal IGqlpTypeRef? _parent;

  public SimpleBuilder(string name)
    : base(name)
    => Add<IGqlpSimple>();

  protected new T Build<T>()
    where T : class, IGqlpSimple
  {
    T result = base.Build<T>();
    result.Parent.Returns(_parent);
    return result;
  }
}

public class SimpleBuilder<T>
  : SimpleBuilder
    where T : class, IGqlpSimple
{
  public SimpleBuilder(string name)
    : base(name)
    => Add<T>();

  public T AsSimple
    => Build<T>();
}

public static class SimpleBuilderHelper
{
  public static T WithParent<T>(this T builder, string parent = "")
    where T : SimpleBuilder
    => builder.FluentAction(b => b._parent = new NamedBuilder<IGqlpTypeRef>(parent).AsNamed);
}
