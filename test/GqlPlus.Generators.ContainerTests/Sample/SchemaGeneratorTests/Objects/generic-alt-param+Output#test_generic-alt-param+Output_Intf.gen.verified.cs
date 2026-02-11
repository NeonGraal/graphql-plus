//HintName: test_generic-alt-param+Output_Intf.gen.cs
// Generated from generic-alt-param+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Output;

public interface ItestGnrcAltParamOutp
{
  ItestRefGnrcAltParamOutp<ItestAltGnrcAltParamOutp> AsRefGnrcAltParamOutp { get; }
  ItestGnrcAltParamOutpObject AsGnrcAltParamOutp { get; }
}

public interface ItestGnrcAltParamOutpObject
{
}

public interface ItestRefGnrcAltParamOutp<TRef>
{
  TRef Asref { get; }
  ItestRefGnrcAltParamOutpObject AsRefGnrcAltParamOutp { get; }
}

public interface ItestRefGnrcAltParamOutpObject<TRef>
{
}

public interface ItestAltGnrcAltParamOutp
{
  string AsString { get; }
  ItestAltGnrcAltParamOutpObject AsAltGnrcAltParamOutp { get; }
}

public interface ItestAltGnrcAltParamOutpObject
{
  decimal Alt { get; }
}
