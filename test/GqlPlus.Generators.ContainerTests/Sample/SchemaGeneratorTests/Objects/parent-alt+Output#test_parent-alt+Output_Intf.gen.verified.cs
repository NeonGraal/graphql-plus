//HintName: test_parent-alt+Output_Intf.gen.cs
// Generated from parent-alt+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Output;

public interface ItestPrntAltOutp
  : ItestRefPrntAltOutp
{
  public ItestNumber AsNumber { get; set; }
}

public interface ItestPrntAltOutpObject
  : ItestRefPrntAltOutpObject
{
}

public interface ItestRefPrntAltOutp
{
  public ItestString AsString { get; set; }
}

public interface ItestRefPrntAltOutpObject
{
  public ItestNumber Parent { get; set; }
}
