//HintName: test_generic-enum+Input_Impl.gen.cs
// Generated from {CurrentDirectory}generic-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Input;

public class testGnrcEnumInp
  : ItestGnrcEnumInp
{
}

public class testRefGnrcEnumInp<TType>
  : ItestRefGnrcEnumInp<TType>
{
  public TType Field { get; set; }
}
