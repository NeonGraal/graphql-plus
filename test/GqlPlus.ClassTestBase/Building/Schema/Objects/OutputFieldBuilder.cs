using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Building.Schema.Objects;

public class OutputFieldBuilder
  : ObjFieldBuilder
{
  internal IGqlpInputParam? _inputParam;

  public OutputFieldBuilder(string name, string type)
    : base(name, type)
    => Add<IGqlpOutputField>();

  protected new T Build<T>()
    where T : class, IGqlpOutputField
  {
    T result = base.Build<T>();

    result.Parameter.Returns(_inputParam);

    return result;
  }

  public IGqlpOutputField AsOutputField
    => Build<IGqlpOutputField>();
}

public static class OutputFieldBuilderHelper
{
  public static T WithParam<T>(this T builder, IGqlpInputParam? inputParam)
    where T : OutputFieldBuilder
    => builder.FluentAction(b => b._inputParam = inputParam);
}
