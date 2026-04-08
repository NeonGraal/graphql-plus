//HintName: test_generic-parent-arg+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-arg+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_arg_Dual;

public interface ItestGnrcPrntArgDual<TType>
  : ItestRefGnrcPrntArgDual<TType>
{
  ItestGnrcPrntArgDualObject<TType>? As_GnrcPrntArgDual { get; }
}

public interface ItestGnrcPrntArgDualObject<TType>
  : ItestRefGnrcPrntArgDualObject<TType>
{
}

public interface ItestRefGnrcPrntArgDual<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefGnrcPrntArgDualObject<TRef>? As_RefGnrcPrntArgDual { get; }
}

public interface ItestRefGnrcPrntArgDualObject<TRef>
  // No Base because it's Class
{
}
