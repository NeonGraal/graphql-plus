//HintName: test_generic-alt-param+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-param+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Dual;

public interface ItestGnrcAltParamDual
  : IGqlpModelImplementationBase
{
  ItestRefGnrcAltParamDual<ItestAltGnrcAltParamDual>? AsRefGnrcAltParamDual { get; }
  ItestGnrcAltParamDualObject? As_GnrcAltParamDual { get; }
}

public interface ItestGnrcAltParamDualObject
  : IGqlpModelImplementationBase
{
}

public interface ItestRefGnrcAltParamDual<TRef>
  : IGqlpModelImplementationBase
{
  TRef? Asref { get; }
  ItestRefGnrcAltParamDualObject<TRef>? As_RefGnrcAltParamDual { get; }
}

public interface ItestRefGnrcAltParamDualObject<TRef>
  : IGqlpModelImplementationBase
{
}

public interface ItestAltGnrcAltParamDual
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestAltGnrcAltParamDualObject? As_AltGnrcAltParamDual { get; }
}

public interface ItestAltGnrcAltParamDualObject
  : IGqlpModelImplementationBase
{
  decimal Alt { get; }
}
