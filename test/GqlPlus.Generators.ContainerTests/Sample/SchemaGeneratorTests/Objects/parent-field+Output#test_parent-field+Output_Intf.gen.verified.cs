//HintName: test_parent-field+Output_Intf.gen.cs
// Generated from parent-field+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Output;

public interface ItestPrntFieldOutp
  : ItestRefPrntFieldOutp
{
}

public interface ItestPrntFieldOutpObject
  : ItestRefPrntFieldOutpObject
{
  public ItestNumber Field { get; set; }
}

public interface ItestRefPrntFieldOutp
{
  public ItestString AsString { get; set; }
}

public interface ItestRefPrntFieldOutpObject
{
  public ItestNumber Parent { get; set; }
}
