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
  ItestGnrcPrntParamPrntDualObject AsGnrcPrntParamPrntDual { get; }
}

public interface ItestGnrcPrntParamPrntDualObject
  : ItestRefGnrcPrntParamPrntDualObject<ItestAltGnrcPrntParamPrntDual>
{
}

public interface ItestRefGnrcPrntParamPrntDual<TRef>
  : IGqlpModelImplementationBase
{
  TRef AsParent { get; }
  ItestRefGnrcPrntParamPrntDualObject<TRef> AsRefGnrcPrntParamPrntDual { get; }
}

public interface ItestRefGnrcPrntParamPrntDualObject<TRef>
{
}

public interface ItestAltGnrcPrntParamPrntDual
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestAltGnrcPrntParamPrntDualObject AsAltGnrcPrntParamPrntDual { get; }
}

public interface ItestAltGnrcPrntParamPrntDualObject
{
  decimal Alt { get; }
}
