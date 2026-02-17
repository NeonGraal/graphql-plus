//HintName: test_generic-value+Input_Impl.gen.cs
// Generated from {CurrentDirectory}generic-value+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Input;

public class testGnrcValueInp
  : ItestGnrcValueInp
{
}

public class testRefGnrcValueInp<TType>
  : ItestRefGnrcValueInp<TType>
{
  public TType Field { get; set; }
}
