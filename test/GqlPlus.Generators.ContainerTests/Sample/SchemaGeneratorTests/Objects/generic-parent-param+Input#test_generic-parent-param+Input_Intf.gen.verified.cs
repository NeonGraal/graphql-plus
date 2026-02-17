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
  ItestGnrcPrntParamInpObject AsGnrcPrntParamInp { get; }
}

public interface ItestGnrcPrntParamInpObject
  : ItestRefGnrcPrntParamInpObject<ItestAltGnrcPrntParamInp>
{
}

public interface ItestRefGnrcPrntParamInp<TRef>
  : IGqlpModelImplementationBase
{
  TRef Asref { get; }
  ItestRefGnrcPrntParamInpObject<TRef> AsRefGnrcPrntParamInp { get; }
}

public interface ItestRefGnrcPrntParamInpObject<TRef>
{
}

public interface ItestAltGnrcPrntParamInp
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestAltGnrcPrntParamInpObject AsAltGnrcPrntParamInp { get; }
}

public interface ItestAltGnrcPrntParamInpObject
{
  decimal Alt { get; }
}
