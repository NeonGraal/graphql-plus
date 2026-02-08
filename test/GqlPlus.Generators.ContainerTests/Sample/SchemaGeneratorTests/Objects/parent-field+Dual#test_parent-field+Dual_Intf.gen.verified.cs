//HintName: test_parent-field+Dual_Intf.gen.cs
// Generated from parent-field+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Dual;

public interface ItestPrntFieldDual
  : ItestRefPrntFieldDual
{
}

public interface ItestPrntFieldDualObject
  : ItestRefPrntFieldDualObject
{
  public ItestNumber Field { get; set; }
}

public interface ItestRefPrntFieldDual
{
  public ItestString AsString { get; set; }
}

public interface ItestRefPrntFieldDualObject
{
  public ItestNumber Parent { get; set; }
}
