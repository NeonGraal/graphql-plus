//HintName: test_parent-field+Dual_Intf.gen.cs
// Generated from parent-field+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Dual;

public interface ItestPrntFieldDual
  : ItestRefPrntFieldDual
{
  public ItestPrntFieldDualObject AsPrntFieldDual { get; set; }
}

public interface ItestPrntFieldDualObject
  : ItestRefPrntFieldDualObject
{
  public decimal Field { get; set; }
}

public interface ItestRefPrntFieldDual
{
  public string AsString { get; set; }
  public ItestRefPrntFieldDualObject AsRefPrntFieldDual { get; set; }
}

public interface ItestRefPrntFieldDualObject
{
  public decimal Parent { get; set; }
}
