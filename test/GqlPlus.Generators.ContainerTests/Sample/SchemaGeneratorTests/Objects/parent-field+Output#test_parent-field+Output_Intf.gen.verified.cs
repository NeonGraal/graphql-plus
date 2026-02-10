//HintName: test_parent-field+Output_Intf.gen.cs
// Generated from parent-field+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Output;

public interface ItestPrntFieldOutp
  : ItestRefPrntFieldOutp
{
  public ItestPrntFieldOutpObject AsPrntFieldOutp { get; set; }
}

public interface ItestPrntFieldOutpObject
  : ItestRefPrntFieldOutpObject
{
  public decimal Field { get; set; }
}

public interface ItestRefPrntFieldOutp
{
  public string AsString { get; set; }
  public ItestRefPrntFieldOutpObject AsRefPrntFieldOutp { get; set; }
}

public interface ItestRefPrntFieldOutpObject
{
  public decimal Parent { get; set; }
}
