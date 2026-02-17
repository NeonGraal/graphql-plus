//HintName: test_generic-value+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}generic-value+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Dual;

public class testGnrcValueDual
  : ItestGnrcValueDual
{
}

public class testRefGnrcValueDual<TType>
  : ItestRefGnrcValueDual<TType>
{
  public TType Field { get; set; }
}
