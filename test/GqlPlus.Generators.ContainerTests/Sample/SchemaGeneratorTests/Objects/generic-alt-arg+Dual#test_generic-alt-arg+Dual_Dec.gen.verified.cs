//HintName: test_generic-alt-arg+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Dual;

public interface ItestGnrcAltArgDual<TType>
  // No Base because it's Class
{
  ItestRefGnrcAltArgDual<TType>? AsRefGnrcAltArgDual { get; }
  ItestGnrcAltArgDualObject<TType>? As_GnrcAltArgDual { get; }
}

public interface ItestGnrcAltArgDualObject<TType>
  // No Base because it's Class
{
}

public interface ItestRefGnrcAltArgDual<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefGnrcAltArgDualObject<TRef>? As_RefGnrcAltArgDual { get; }
}

public interface ItestRefGnrcAltArgDualObject<TRef>
  // No Base because it's Class
{
}
