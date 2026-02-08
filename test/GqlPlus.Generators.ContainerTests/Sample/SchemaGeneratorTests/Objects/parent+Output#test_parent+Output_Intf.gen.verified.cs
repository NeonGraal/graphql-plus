//HintName: test_parent+Output_Intf.gen.cs
// Generated from parent+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_Output;

public interface ItestPrntOutp
  : ItestRefPrntOutp
{
}

public interface ItestPrntOutpObject
  : ItestRefPrntOutpObject
{
}

public interface ItestRefPrntOutp
{
  public ItestString AsString { get; set; }
}

public interface ItestRefPrntOutpObject
{
  public ItestNumber Parent { get; set; }
}
