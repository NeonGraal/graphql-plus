//HintName: test_generic-parent-param+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-param+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Input;

public interface ItestGnrcPrntParamInp
  : ItestRefGnrcPrntParamInp<ItestAltGnrcPrntParamInp>
{
  ItestGnrcPrntParamInpObject? As_GnrcPrntParamInp { get; }
}

public interface ItestGnrcPrntParamInpObject
  : ItestRefGnrcPrntParamInpObject<ItestAltGnrcPrntParamInp>
{
}

public interface ItestRefGnrcPrntParamInp<TRef>
  : IGqlpModelImplementationBase
{
  TRef? Asref { get; }
  ItestRefGnrcPrntParamInpObject<TRef>? As_RefGnrcPrntParamInp { get; }
}

public interface ItestRefGnrcPrntParamInpObject<TRef>
  : IGqlpModelImplementationBase
{
}

public interface ItestAltGnrcPrntParamInp
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestAltGnrcPrntParamInpObject? As_AltGnrcPrntParamInp { get; }
}

public interface ItestAltGnrcPrntParamInpObject
  : IGqlpModelImplementationBase
{
  decimal Alt { get; }
}
