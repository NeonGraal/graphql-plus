//HintName: test_Enum_Intf.gen.cs
// Generated from {CurrentDirectory}Enum.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Enum;

public interface Itest_EnumLabel
  : Itest_Aliased
{
  Itest_EnumLabelObject? As__EnumLabel { get; }
}

public interface Itest_EnumLabelObject
  : Itest_AliasedObject
{
  Itest_Name EnumType { get; }
}

public interface Itest_EnumValue
  : Itest_TypeRef<Itest_TypeKind>
{
  Itest_EnumValueObject? As__EnumValue { get; }
}

public interface Itest_EnumValueObject
  : Itest_TypeRefObject<Itest_TypeKind>
{
  Itest_Name Label { get; }
}
