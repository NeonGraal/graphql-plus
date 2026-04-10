using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Building.Schema.Objects;

public class AlternateBuilder
  : ObjBaseBuilder
  , IModifiersBuilder
  , IObjEnumBuilder
{
  private IAstModifier[] _modifiers = [];
  private IAstEnumValue? _enumValue;

  public AlternateBuilder(string name)
    : base(name)
  {
    Add<IAstAlternate>();
    Add<IAstModifiers>();
    Add<IAstObjEnum>();
  }

  protected new T Build<T>()
    where T : class, IAstAlternate
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

  public void SetModifiers(IAstModifier[] modifiers)
    => _modifiers = modifiers;
  public void SetEnumValue(IAstEnumValue enumValue)
    => _enumValue = enumValue;

  public IAstAlternate AsAlternate
    => Build<IAstAlternate>();

  public string Name => _name;
}
