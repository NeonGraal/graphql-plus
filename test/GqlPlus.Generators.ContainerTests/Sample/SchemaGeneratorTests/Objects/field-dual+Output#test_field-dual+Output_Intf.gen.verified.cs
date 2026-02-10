//HintName: test_field-dual+Output_Intf.gen.cs
// Generated from field-dual+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_dual_Output;

public interface ItestFieldDualOutp
{
  public ItestFieldDualOutpObject AsFieldDualOutp { get; set; }
}

public interface ItestFieldDualOutpObject
{
  public ItestFldFieldDualOutp Field { get; set; }
}

public interface ItestFldFieldDualOutp
{
  public string AsString { get; set; }
  public ItestFldFieldDualOutpObject AsFldFieldDualOutp { get; set; }
}

public interface ItestFldFieldDualOutpObject
{
  public decimal Field { get; set; }
}
