//HintName: test_generic-parent-param-parent+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-param-parent+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Output;

public interface ItestGnrcPrntParamPrntOutp
  : ItestRefGnrcPrntParamPrntOutp<ItestAltGnrcPrntParamPrntOutp>
{
  ItestGnrcPrntParamPrntOutpObject AsGnrcPrntParamPrntOutp { get; }
}

public interface ItestGnrcPrntParamPrntOutpObject
  : ItestRefGnrcPrntParamPrntOutpObject<ItestAltGnrcPrntParamPrntOutp>
{
}

public interface ItestRefGnrcPrntParamPrntOutp<TRef>
  : IGqlpModelImplementationBase
{
  TRef AsParent { get; }
  ItestRefGnrcPrntParamPrntOutpObject<TRef> AsRefGnrcPrntParamPrntOutp { get; }
}

public interface ItestRefGnrcPrntParamPrntOutpObject<TRef>
{
}

public interface ItestAltGnrcPrntParamPrntOutp
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestAltGnrcPrntParamPrntOutpObject AsAltGnrcPrntParamPrntOutp { get; }
}

public interface ItestAltGnrcPrntParamPrntOutpObject
{
  decimal Alt { get; }
}
