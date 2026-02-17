//HintName: test_generic-parent-arg+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-arg+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_arg_Dual;

public interface ItestGnrcPrntArgDual<TType>
  : ItestRefGnrcPrntArgDual<TType>
{
  ItestGnrcPrntArgDualObject<TType> AsGnrcPrntArgDual { get; }
}

public interface ItestGnrcPrntArgDualObject<TType>
  : ItestRefGnrcPrntArgDualObject<TType>
{
}

public interface ItestRefGnrcPrntArgDual<TRef>
  : IGqlpModelImplementationBase
{
  TRef Asref { get; }
  ItestRefGnrcPrntArgDualObject<TRef> AsRefGnrcPrntArgDual { get; }
}

public interface ItestRefGnrcPrntArgDualObject<TRef>
{
}
