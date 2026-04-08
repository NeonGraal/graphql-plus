//HintName: test_generic-descr+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_descr_Dual;

public interface ItestGnrcDescrDual<TType>
  // No Base because it's Class
{
  ItestGnrcDescrDualObject<TType>? As_GnrcDescrDual { get; }
}

public interface ItestGnrcDescrDualObject<TType>
  // No Base because it's Class
{
  TType Field { get; }
}
