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
  ItestGnrcPrntParamPrntInpObject AsGnrcPrntParamPrntInp { get; }
}

public interface ItestGnrcPrntParamPrntInpObject
  : ItestRefGnrcPrntParamPrntInpObject<ItestAltGnrcPrntParamPrntInp>
{
}

public interface ItestRefGnrcPrntParamPrntInp<TRef>
  : IGqlpModelImplementationBase
{
  TRef AsParent { get; }
  ItestRefGnrcPrntParamPrntInpObject<TRef> AsRefGnrcPrntParamPrntInp { get; }
}

public interface ItestRefGnrcPrntParamPrntInpObject<TRef>
{
}

public interface ItestAltGnrcPrntParamPrntInp
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestAltGnrcPrntParamPrntInpObject AsAltGnrcPrntParamPrntInp { get; }
}

public interface ItestAltGnrcPrntParamPrntInpObject
{
  decimal Alt { get; }
}
