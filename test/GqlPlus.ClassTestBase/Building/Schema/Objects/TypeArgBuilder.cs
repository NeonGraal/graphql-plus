using GqlPlus.Ast.Schema;

namespace GqlPlus.Building.Schema.Objects;

public class TypeArgBuilder
  : ObjTypeBuilder
  , IObjEnumBuilder
{
  internal IAstEnumValue? _enumValue;

  public TypeArgBuilder(string name)
    : base(name)
  {
    Add<IAstTypeArg>();
    Add<IAstObjEnum>();
  }

  protected new T Build<T>()
    where T : class, IAstTypeArg
  {
    T result = base.Build<T>();
    result.EnumValue.Returns(_enumValue);
    if (!_isTypeParam) {
      result.EnumTypeName.Returns(_name);
      result.WhenForAnyArgs(a => a.SetEnumType("")).Do(this.MakeSetEnumValue(result, result));
    }

    return result;
  }

  public void SetEnumValue(IAstEnumValue enumValue)
    => _enumValue = enumValue;

  public IAstTypeArg AsTypeArg
    => Build<IAstTypeArg>();

  public string Name
    => _name;
}
