//HintName: test_field-dual+Output_Intf.gen.cs
// Generated from field-dual+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_dual_Output;

public interface ItestFieldDualOutp
{
  ItestFieldDualOutpObject AsFieldDualOutp { get; }
}

public interface ItestFieldDualOutpObject
{
  ItestFldFieldDualOutp Field { get; }
}

public interface ItestFldFieldDualOutp
{
  string AsString { get; }
  ItestFldFieldDualOutpObject AsFldFieldDualOutp { get; }
}

public interface ItestFldFieldDualOutpObject
{
  decimal Field { get; }
}
