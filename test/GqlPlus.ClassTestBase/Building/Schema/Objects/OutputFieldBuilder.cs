using GqlPlus.Abstractions.Schema;
using NSubstitute.Core;

namespace GqlPlus.Building.Schema.Objects;

public class OutputFieldBuilder
  : ObjFieldBuilder
{
  internal IGqlpInputParam[] _inputParams = [];

  public OutputFieldBuilder(string name, string type)
    : base(name, type)
    => Add<IGqlpOutputField>();

  protected new T Build<T>()
    where T : class, IGqlpOutputField
  {
    T result = base.Build<T>();

    result.Params.Returns(_inputParams);

    return result;
  }

  public IGqlpOutputField AsOutputField
    => Build<IGqlpOutputField>();
}

public static class OutputFieldBuilderHelper
{
  public static T WithParams<T>(this T builder, IEnumerable<IGqlpInputParam> inputParams)
    where T : OutputFieldBuilder
    => builder.FluentAction(b => b._inputParams = [.. inputParams]);
}
