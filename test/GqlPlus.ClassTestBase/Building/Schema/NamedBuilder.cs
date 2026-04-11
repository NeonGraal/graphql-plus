using GqlPlus.Ast.Schema;

namespace GqlPlus.Building.Schema;

public class NamedBuilder
  : DescribedBuilder
{
  internal string _name;

  public NamedBuilder(string name)
  {
    Add<IAstNamed>();
    _name = name;
  }

  protected new T Build<T>()
    where T : class, IAstNamed
  {
    T result = base.Build<T>();
    result.Name.Returns(_name);
    return result;
  }
}

public class NamedBuilder<T>
  : NamedBuilder
    where T : class, IAstNamed
{
  public NamedBuilder(string name)
    : base(name)
    => Add<T>();

  public T? AsNamed
    => string.IsNullOrWhiteSpace(_name) ? null : Build<T>();
}

public static class NamedBuilderHelper
{
  public static T WithName<T>(this T builder, string name)
    where T : NamedBuilder
    => builder.FluentAction(b => b._name = name);
}
