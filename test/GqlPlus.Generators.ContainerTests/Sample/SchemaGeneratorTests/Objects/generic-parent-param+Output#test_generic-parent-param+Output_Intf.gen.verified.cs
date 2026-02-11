//HintName: test_generic-parent-param+Output_Intf.gen.cs
// Generated from generic-parent-param+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Output;

public interface ItestGnrcPrntParamOutp
  : ItestRefGnrcPrntParamOutp
{
  ItestGnrcPrntParamOutpObject AsGnrcPrntParamOutp { get; }
}

public interface ItestGnrcPrntParamOutpObject
  : ItestRefGnrcPrntParamOutpObject
{
}

public interface ItestRefGnrcPrntParamOutp<Tref>
{
  Tref Asref { get; }
  ItestRefGnrcPrntParamOutpObject AsRefGnrcPrntParamOutp { get; }
}

public interface ItestRefGnrcPrntParamOutpObject<Tref>
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
