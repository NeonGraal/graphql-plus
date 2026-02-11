//HintName: test_generic-parent-param+Output_Intf.gen.cs
// Generated from generic-parent-param+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Output;

public interface ItestGnrcPrntParamOutp
  : ItestRefGnrcPrntParamOutp<ItestAltGnrcPrntParamOutp>
{
  ItestGnrcPrntParamOutpObject AsGnrcPrntParamOutp { get; }
}

public interface ItestGnrcPrntParamOutpObject
  : ItestRefGnrcPrntParamOutpObject<ItestAltGnrcPrntParamOutp>
{
}

public interface ItestRefGnrcPrntParamOutp<TRef>
{
  TRef Asref { get; }
  ItestRefGnrcPrntParamOutpObject AsRefGnrcPrntParamOutp { get; }
}

public interface ItestRefGnrcPrntParamOutpObject<TRef>
{
}

public interface ItestAltGnrcPrntParamOutp
{
  string AsString { get; }
  ItestAltGnrcPrntParamOutpObject AsAltGnrcPrntParamOutp { get; }
}

public interface ItestAltGnrcPrntParamOutpObject
{
  decimal Alt { get; }
}
