//HintName: test_generic-parent-arg+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}generic-parent-arg+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_arg_Dual;

public class testGnrcPrntArgDual<TType>
  : testRefGnrcPrntArgDual<TType>
  , ItestGnrcPrntArgDual<TType>
{
}

public class testRefGnrcPrntArgDual<TRef>
  : ItestRefGnrcPrntArgDual<TRef>
{
}
