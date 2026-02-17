//HintName: test_Enum_Impl.gen.cs
// Generated from {CurrentDirectory}Enum.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Enum;

public class test_EnumLabel
  : test_Aliased
  , Itest_EnumLabel
{
  public Itest_Name EnumType { get; set; }
}

public class test_EnumValue
  : test_TypeRef<Itest_TypeKind>
  , Itest_EnumValue
{
  public Itest_Name Label { get; set; }
}
