using GqlPlus.Ast.Schema;

namespace GqlPlus.Building.Schema;

public class DescribedBuilder
  : ErrorBuilder
{
  internal string? _description;

  public DescribedBuilder()
    => Add<IAstDescribed>();

  protected new T Build<T>()
    where T : class, IAstDescribed
  {
    T result = base.Build<T>();
    result.Description.Returns(_description);
    return result;
  }
}

public static class DescribedBuilderHelper
{
  public static T WithDescr<T>(this T builder, string descr)
    where T : DescribedBuilder
    => builder.FluentAction(b => b._description = descr);
}
