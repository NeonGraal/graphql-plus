//HintName: test_generic-parent-param-parent+Output_Intf.gen.cs
// Generated from generic-parent-param-parent+Output.graphql+ for Intf
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
{
  TRef AsParent { get; }
  ItestRefGnrcPrntParamPrntOutpObject<TRef> AsRefGnrcPrntParamPrntOutp { get; }
}

public interface ItestRefGnrcPrntParamPrntOutpObject<TRef>
{
}

public interface ItestAltGnrcPrntParamPrntOutp
{
  string AsString { get; }
  ItestAltGnrcPrntParamPrntOutpObject AsAltGnrcPrntParamPrntOutp { get; }
}

public interface ItestAltGnrcPrntParamPrntOutpObject
{
  decimal Alt { get; }
}
