//HintName: test_generic-field+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-field+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_Dual;

public interface ItestGnrcFieldDual<TType>
  // No Base because it's Class
{
  ItestGnrcFieldDualObject<TType>? As_GnrcFieldDual { get; }
}

public interface ItestGnrcFieldDualObject<TType>
  // No Base because it's Class
{
  TType Field { get; }
}
