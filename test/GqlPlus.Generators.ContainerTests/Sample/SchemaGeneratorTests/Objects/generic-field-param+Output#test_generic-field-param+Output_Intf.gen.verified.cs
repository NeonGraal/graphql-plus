//HintName: test_generic-field-param+Output_Intf.gen.cs
// Generated from generic-field-param+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Output;

public interface ItestGnrcFieldParamOutp
{
  ItestGnrcFieldParamOutpObject AsGnrcFieldParamOutp { get; }
}

public interface ItestGnrcFieldParamOutpObject
{
  ItestRefGnrcFieldParamOutp<ItestAltGnrcFieldParamOutp> Field { get; }
}

public interface ItestRefGnrcFieldParamOutp<Tref>
{
  Tref Asref { get; }
  ItestRefGnrcFieldParamOutpObject AsRefGnrcFieldParamOutp { get; }
}

public interface ItestRefGnrcFieldParamOutpObject<Tref>
{
}

public interface ItestAltGnrcFieldParamOutp
{
  string AsString { get; }
  ItestAltGnrcFieldParamOutpObject AsAltGnrcFieldParamOutp { get; }
}

public interface ItestAltGnrcFieldParamOutpObject
{
  decimal Alt { get; }
}
