//HintName: test_field-dual+Dual_Intf.gen.cs
// Generated from field-dual+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_dual_Dual;

public interface ItestFieldDualDual
{
  public ItestFieldDualDualObject AsFieldDualDual { get; set; }
}

public interface ItestFieldDualDualObject
{
  public ItestFldFieldDualDual Field { get; set; }
}

public interface ItestFldFieldDualDual
{
  public string AsString { get; set; }
  public ItestFldFieldDualDualObject AsFldFieldDualDual { get; set; }
}

public interface ItestFldFieldDualDualObject
{
  public decimal Field { get; set; }
}
