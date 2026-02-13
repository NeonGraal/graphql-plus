//HintName: test_constraint-field-dual+Output_Intf.gen.cs
// Generated from constraint-field-dual+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Output;

public interface ItestCnstFieldDualOutp
  : ItestRefCnstFieldDualOutp<ItestAltCnstFieldDualOutp>
{
  ItestCnstFieldDualOutpObject AsCnstFieldDualOutp { get; }
}

public interface ItestCnstFieldDualOutpObject
  : ItestRefCnstFieldDualOutpObject<ItestAltCnstFieldDualOutp>
{
}

public interface ItestRefCnstFieldDualOutp<TRef>
{
  ItestRefCnstFieldDualOutpObject<TRef> AsRefCnstFieldDualOutp { get; }
}

public interface ItestRefCnstFieldDualOutpObject<TRef>
{
  TRef Field { get; }
}

public interface ItestPrntCnstFieldDualOutp
{
  string AsString { get; }
  ItestPrntCnstFieldDualOutpObject AsPrntCnstFieldDualOutp { get; }
}

public interface ItestPrntCnstFieldDualOutpObject
{
}

public interface ItestAltCnstFieldDualOutp
  : ItestPrntCnstFieldDualOutp
{
  ItestAltCnstFieldDualOutpObject AsAltCnstFieldDualOutp { get; }
}

public interface ItestAltCnstFieldDualOutpObject
  : ItestPrntCnstFieldDualOutpObject
{
  decimal Alt { get; }
}
