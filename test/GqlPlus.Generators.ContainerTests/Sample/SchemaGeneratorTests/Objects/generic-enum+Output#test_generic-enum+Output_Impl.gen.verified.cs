//HintName: test_generic-enum+Output_Impl.gen.cs
// Generated from {CurrentDirectory}generic-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Output;

public class testGnrcEnumOutp
  : ItestGnrcEnumOutp
{
}

public class testRefGnrcEnumOutp<TType>
  : ItestRefGnrcEnumOutp<TType>
{
  public TType Field { get; set; }
}
