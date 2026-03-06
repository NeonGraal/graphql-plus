//HintName: test_generic-parent-param-parent+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-param-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Dual;

public interface ItestGnrcPrntParamPrntDual
  : ItestRefGnrcPrntParamPrntDual<ItestAltGnrcPrntParamPrntDual>
{
  ItestGnrcPrntParamPrntDualObject? As_GnrcPrntParamPrntDual { get; }
}

public interface ItestGnrcPrntParamPrntDualObject
  : ItestRefGnrcPrntParamPrntDualObject<ItestAltGnrcPrntParamPrntDual>
{
}

public interface ItestRefGnrcPrntParamPrntDual<TRef>
  : IGqlpModelImplementationBase
{
  TRef? As_Parent { get; }
  ItestRefGnrcPrntParamPrntDualObject<TRef>? As_RefGnrcPrntParamPrntDual { get; }
}

public interface ItestRefGnrcPrntParamPrntDualObject<TRef>
  : IGqlpModelImplementationBase
{
}

public interface ItestAltGnrcPrntParamPrntDual
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestAltGnrcPrntParamPrntDualObject? As_AltGnrcPrntParamPrntDual { get; }
}

public interface ItestAltGnrcPrntParamPrntDualObject
  : IGqlpModelImplementationBase
{
  decimal Alt { get; }
}
