//HintName: test_generic-parent-param+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-param+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Dual;

public interface ItestGnrcPrntParamDual
  : ItestRefGnrcPrntParamDual<ItestAltGnrcPrntParamDual>
{
  ItestGnrcPrntParamDualObject AsGnrcPrntParamDual { get; }
}

public interface ItestGnrcPrntParamDualObject
  : ItestRefGnrcPrntParamDualObject<ItestAltGnrcPrntParamDual>
{
}

public interface ItestRefGnrcPrntParamDual<TRef>
  : IGqlpModelImplementationBase
{
  TRef Asref { get; }
  ItestRefGnrcPrntParamDualObject<TRef> AsRefGnrcPrntParamDual { get; }
}

public interface ItestRefGnrcPrntParamDualObject<TRef>
{
}

public interface ItestAltGnrcPrntParamDual
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestAltGnrcPrntParamDualObject AsAltGnrcPrntParamDual { get; }
}

public interface ItestAltGnrcPrntParamDualObject
{
  decimal Alt { get; }
}
