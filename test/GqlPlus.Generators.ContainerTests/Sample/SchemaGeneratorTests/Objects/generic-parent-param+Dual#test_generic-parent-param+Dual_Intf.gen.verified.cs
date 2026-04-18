//HintName: test_generic-parent-param+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-param+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
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
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcPrntParamDualObject<TRef>? As_RefGnrcPrntParamDual { get; }
}

public interface ItestRefGnrcPrntParamDualObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcPrntParamDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcPrntParamDualObject? As_AltGnrcPrntParamDual { get; }
}

public interface ItestAltGnrcPrntParamDualObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}
