using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Building.Schema.Objects;

public class AlternateBuilder
  : ObjBaseBuilder
  , IModifiersBuilder
  , IObjEnumBuilder
{
  private IGqlpModifier[] _modifiers = [];
  private IGqlpEnumValue? _enumValue;

  public AlternateBuilder(string name)
    : base(name)
  {
    Add<IGqlpAlternate>();
    Add<IGqlpModifiers>();
    Add<IGqlpObjEnum>();
  }

  protected new T Build<T>()
    where T : class, IGqlpAlternate
  {
    T result = base.Build<T>();

    result.EnumValue.Returns(_enumValue);
    if (!_isTypeParam) {
      result.Modifiers.Returns(_modifiers);
      result.EnumTypeName.Returns(_name);
      result.WhenForAnyArgs(a => a.SetEnumType("")).Do(this.MakeSetEnumValue(result, result));
    }

    return result;
  }

  public void SetModifiers(IGqlpModifier[] modifiers)
    => _modifiers = modifiers;
  public void SetEnumValue(IGqlpEnumValue enumValue)
    => _enumValue = enumValue;

  public IGqlpAlternate AsAlternate
    => Build<IGqlpAlternate>();

  public string Name => _name;
}
