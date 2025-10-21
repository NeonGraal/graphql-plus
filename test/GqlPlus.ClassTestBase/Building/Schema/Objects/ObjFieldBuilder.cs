using GqlPlus.Abstractions.Schema;
using NSubstitute.Core;

namespace GqlPlus.Building.Schema.Objects;

public class ObjFieldBuilder
  : AliasedBuilder
  , ITypeBuilder
  , IObjEnumBuilder
{
  private IGqlpModifier[] _modifiers = [];
  private IGqlpEnumValue? _enumValue;

  public ObjBaseBuilder BaseBuilder { get; }

  public ObjFieldBuilder(string name, string type)
    : base(name)
  {
    Add<IGqlpObjField>();
    Add<IGqlpObjFieldType>();
    Add<IGqlpModifiers>();
    Add<IGqlpObjEnum>();

    BaseBuilder = new ObjBaseBuilder(type);
  }

  protected new T Build<T>()
    where T : class, IGqlpObjField
  {
    T result = base.Build<T>();

    IGqlpObjBase type = BaseBuilder.AsObjBase;
    result.Type.Returns(type);
    string modifiedType = _modifiers.AsString().Prepend(type.FullType).Joined();
    result.ModifiedType.Returns(modifiedType);
    result.EnumValue.Returns(_enumValue);
    result.Modifiers.Returns(_modifiers);

    if (_enumValue is not null) {
      string typeName = _enumValue.EnumType;
      type.Name.Returns(typeName);
      type.FullType.Returns(typeName);
      result.EnumTypeName.Returns(typeName);
    }

    result.WhenForAnyArgs(a => a.SetEnumType("")).Do(SetEnumType);

    return result;

    void SetEnumType(CallInfo c)
    {
      string typeName = c.Arg<string>();
      type.Name.Returns(typeName);
      type.FullType.Returns(typeName);
      result.EnumTypeName.Returns(typeName);
      string modifiedType = _modifiers.AsString().Prepend(typeName).Joined();
      result.ModifiedType.Returns(modifiedType);
    }
  }

  public void SetModifiers(IEnumerable<IGqlpModifier> modifiers)
    => _modifiers = [.. modifiers];
  public void SetEnumValue(IGqlpEnumValue enumValue)
    => _enumValue = enumValue;

  public string Name => BaseBuilder._name;
}

public class ObjFieldBuilder<T>
  : ObjFieldBuilder
  where T : class, IGqlpObjField
{
  public ObjFieldBuilder(string name, string type)
    : base(name, type)
    => Add<T>();

  public T AsObjField
    => Build<T>();
}
