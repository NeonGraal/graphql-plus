//HintName: test_constraint-alt-dual+Output_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-alt-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Output;

public interface ItestCnstAltDualOutp
  // No Base because it's Class
{
  ItestRefCnstAltDualOutp<ItestAltCnstAltDualOutp>? AsRefCnstAltDualOutp { get; }
  ItestCnstAltDualOutpObject? As_CnstAltDualOutp { get; }
}

public interface ItestCnstAltDualOutpObject
  // No Base because it's Class
{
}

public interface ItestRefCnstAltDualOutp<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefCnstAltDualOutpObject<TRef>? As_RefCnstAltDualOutp { get; }
}

public interface ItestRefCnstAltDualOutpObject<TRef>
  // No Base because it's Class
{
}

public interface ItestPrntCnstAltDualOutp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestPrntCnstAltDualOutpObject? As_PrntCnstAltDualOutp { get; }
}

public interface ItestPrntCnstAltDualOutpObject
  // No Base because it's Class
{
}

public interface ItestAltCnstAltDualOutp
  : ItestPrntCnstAltDualOutp
{
  ItestAltCnstAltDualOutpObject? As_AltCnstAltDualOutp { get; }
}

public interface ItestAltCnstAltDualOutpObject
  : ItestPrntCnstAltDualOutpObject
{
  decimal Alt { get; }
}
