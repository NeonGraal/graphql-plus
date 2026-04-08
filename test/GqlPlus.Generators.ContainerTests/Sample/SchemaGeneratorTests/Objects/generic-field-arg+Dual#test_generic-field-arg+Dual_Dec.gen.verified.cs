//HintName: test_generic-field-arg+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-field-arg+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_arg_Dual;

public interface ItestGnrcFieldArgDual<TType>
  // No Base because it's Class
{
  ItestGnrcFieldArgDualObject<TType>? As_GnrcFieldArgDual { get; }
}

public interface ItestGnrcFieldArgDualObject<TType>
  // No Base because it's Class
{
  ItestRefGnrcFieldArgDual<TType> Field { get; }
}

public interface ItestRefGnrcFieldArgDual<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefGnrcFieldArgDualObject<TRef>? As_RefGnrcFieldArgDual { get; }
}

public interface ItestRefGnrcFieldArgDualObject<TRef>
  // No Base because it's Class
{
}
