using GqlPlus.Abstractions.Schema;
using NSubstitute.Core;

namespace GqlPlus.Building.Schema.Objects;

public interface IObjEnumBuilder
  : IMockBuilder
{
  string Name { get; }
  void SetEnumValue(IGqlpEnumValue enumValue);
}

public static class ObjEnumBuilderHelper
{
  public static T WithObjEnum<T>(this T builder, IGqlpEnumValue enumValue)
    where T : IObjEnumBuilder
    => builder.FluentAction(b => b.SetEnumValue(enumValue));
  public static T WithObjEnum<T>(this T builder, string enumLabel)
    where T : IObjEnumBuilder
    => builder.FluentAction(b => b.SetEnumValue(builder.EnumValue(b.Name, enumLabel)));

  public static Action<CallInfo> MakeSetEnumValue(this IObjEnumBuilder _, IGqlpObjEnum result, IGqlpObjType type)
    => c => {
      string enumType = c.Arg<string>();
      IGqlpEnumValue? enumValue = result.EnumValue;
      string enumLabel = enumValue?.EnumLabel ?? type.TypeName;

      type.Name.Returns(enumType);
      type.TypeName.Returns(enumType);
      type.FullType.Returns(enumType);
      result.EnumTypeName.Returns(enumType);
      if (enumValue is null) {
        enumValue = new EnumValueBuilder(enumType, enumLabel).AsEnumValue;
        result.EnumValue.Returns(enumValue);
      } else {
        EnumValueBuilder.SetEnumValue(enumValue, enumType, enumLabel);
      }

      if (type is IGqlpObjFieldType field) {
        string modifiedType = field.Modifiers.AsString().Prepend(enumType).Joined();
        field.ModifiedType.Returns(modifiedType);
      }
    };
}
