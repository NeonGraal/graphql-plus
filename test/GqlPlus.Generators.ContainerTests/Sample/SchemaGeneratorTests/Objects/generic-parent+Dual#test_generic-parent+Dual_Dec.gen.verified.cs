//HintName: test_generic-parent+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_Dual;

public interface ItestGnrcPrntDual<TType>
  // No Base because it's Class
{
  TType? As_Parent { get; }
  ItestGnrcPrntDualObject<TType>? As_GnrcPrntDual { get; }
}

public interface ItestGnrcPrntDualObject<TType>
  // No Base because it's Class
{
}
