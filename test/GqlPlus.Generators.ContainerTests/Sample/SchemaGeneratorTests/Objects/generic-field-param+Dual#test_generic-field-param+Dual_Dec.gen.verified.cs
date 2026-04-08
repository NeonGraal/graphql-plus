//HintName: test_generic-field-param+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-field-param+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Dual;

public interface ItestGnrcFieldParamDual
  // No Base because it's Class
{
  ItestGnrcFieldParamDualObject? As_GnrcFieldParamDual { get; }
}

public interface ItestGnrcFieldParamDualObject
  // No Base because it's Class
{
  ItestRefGnrcFieldParamDual<ItestAltGnrcFieldParamDual> Field { get; }
}

public interface ItestRefGnrcFieldParamDual<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefGnrcFieldParamDualObject<TRef>? As_RefGnrcFieldParamDual { get; }
}

public interface ItestRefGnrcFieldParamDualObject<TRef>
  // No Base because it's Class
{
}

public interface ItestAltGnrcFieldParamDual
  // No Base because it's Class
{
  string? AsString { get; }
  ItestAltGnrcFieldParamDualObject? As_AltGnrcFieldParamDual { get; }
}

public interface ItestAltGnrcFieldParamDualObject
  // No Base because it's Class
{
  decimal Alt { get; }
}
