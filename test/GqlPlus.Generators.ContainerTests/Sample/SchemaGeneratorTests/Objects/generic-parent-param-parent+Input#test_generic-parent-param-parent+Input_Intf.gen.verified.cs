//HintName: test_generic-parent-param-parent+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-param-parent+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Input;

public interface ItestGnrcPrntParamPrntInp
  : ItestRefGnrcPrntParamPrntInp<ItestAltGnrcPrntParamPrntInp>
{
  ItestGnrcPrntParamPrntInpObject? As_GnrcPrntParamPrntInp { get; }
}

public interface ItestGnrcPrntParamPrntInpObject
  : ItestRefGnrcPrntParamPrntInpObject<ItestAltGnrcPrntParamPrntInp>
{
}

public interface ItestRefGnrcPrntParamPrntInp<TRef>
  : IGqlpModelImplementationBase
{
  TRef? As_Parent { get; }
  ItestRefGnrcPrntParamPrntInpObject<TRef>? As_RefGnrcPrntParamPrntInp { get; }
}

public interface ItestRefGnrcPrntParamPrntInpObject<TRef>
  : IGqlpModelImplementationBase
{
}

public interface ItestAltGnrcPrntParamPrntInp
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestAltGnrcPrntParamPrntInpObject? As_AltGnrcPrntParamPrntInp { get; }
}

public interface ItestAltGnrcPrntParamPrntInpObject
  : IGqlpModelImplementationBase
{
  decimal Alt { get; }
}
