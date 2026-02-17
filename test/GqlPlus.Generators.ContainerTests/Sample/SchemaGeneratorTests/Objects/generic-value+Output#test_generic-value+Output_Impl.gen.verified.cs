//HintName: test_generic-value+Output_Impl.gen.cs
// Generated from {CurrentDirectory}generic-value+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Output;

public class testGnrcValueOutp
  : ItestGnrcValueOutp
{
}

public class testRefGnrcValueOutp<TType>
  : ItestRefGnrcValueOutp<TType>
{
  public TType Field { get; set; }
}
