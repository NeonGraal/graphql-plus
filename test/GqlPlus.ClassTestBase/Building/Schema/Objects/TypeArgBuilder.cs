using GqlPlus.Abstractions.Schema;
using NSubstitute.Core;

namespace GqlPlus.Building.Schema.Objects;

public class TypeArgBuilder
  : ObjTypeBuilder
  , IObjEnumBuilder
{
  internal IGqlpEnumValue? _enumValue;

  public TypeArgBuilder(string name)
    : base(name)
  {
    Add<IGqlpTypeArg>();
    Add<IGqlpObjEnum>();
  }

  protected new T Build<T>()
    where T : class, IGqlpTypeArg
  {
    T result = base.Build<T>();
    result.EnumValue.Returns(_enumValue);
    if (!_isTypeParam) {
      result.EnumTypeName.Returns(_name);
      result.WhenForAnyArgs(a => a.SetEnumType("")).Do(this.MakeSetEnumValue(result, result));
    }

    return result;
  }

  public void SetEnumValue(IGqlpEnumValue enumValue)
    => _enumValue = enumValue;

  public IGqlpTypeArg AsTypeArg
    => Build<IGqlpTypeArg>();

  public string Name
    => _name;
}
