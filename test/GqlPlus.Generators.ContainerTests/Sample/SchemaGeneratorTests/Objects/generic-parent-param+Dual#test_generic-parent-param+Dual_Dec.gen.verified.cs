//HintName: test_generic-parent-param+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-param+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Dual;

public interface ItestGnrcPrntParamDual
  : ItestRefGnrcPrntParamDual<ItestAltGnrcPrntParamDual>
{
  ItestGnrcPrntParamDualObject? As_GnrcPrntParamDual { get; }
}

public interface ItestGnrcPrntParamDualObject
  : ItestRefGnrcPrntParamDualObject<ItestAltGnrcPrntParamDual>
{
}

public interface ItestRefGnrcPrntParamDual<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefGnrcPrntParamDualObject<TRef>? As_RefGnrcPrntParamDual { get; }
}

public interface ItestRefGnrcPrntParamDualObject<TRef>
  // No Base because it's Class
{
}

public interface ItestAltGnrcPrntParamDual
  // No Base because it's Class
{
  string? AsString { get; }
  ItestAltGnrcPrntParamDualObject? As_AltGnrcPrntParamDual { get; }
}

public interface ItestAltGnrcPrntParamDualObject
  // No Base because it's Class
{
  decimal Alt { get; }
}
