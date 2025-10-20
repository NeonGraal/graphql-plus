using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Building.Schema.Objects;

public class ObjBaseBuilder
  : ObjTypeBuilder
{
  internal IGqlpTypeArg[] _args = [];
  public ObjBaseBuilder(string name)
    : base(name)
    => Add<IGqlpObjBase>();

  protected new T Build<T>()
    where T : class, IGqlpObjBase
  {
    T result = base.Build<T>();

    if (_isTypeParam) {
      return result;
    }

    result.Args.Returns(_args);
    string typeName = _args
      .Bracket("<", ">")
      .Prepend(_name).Joined();
    result.FullType.Returns(typeName);

    return result;
  }

  public IGqlpObjBase AsObjBase
    => Build<IGqlpObjBase>();
}

public static class ObjBaseBuilderHelper
{
  public static T WithArgs<T>(this T builder, IEnumerable<IGqlpTypeArg> args)
    where T : ObjBaseBuilder
    => builder.FluentAction(b => b._args = [.. args]);
}
