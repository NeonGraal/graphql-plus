//HintName: test_parent-field+Output_Intf.gen.cs
// Generated from parent-field+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Output;

public interface ItestPrntFieldOutp
  : ItestRefPrntFieldOutp
{
  public testPrntFieldOutp PrntFieldOutp { get; set; }
}

public interface ItestPrntFieldOutpField
  : ItestRefPrntFieldOutpField
{
  public testNumber field { get; set; }
}

public interface ItestRefPrntFieldOutp
{
  public testString AsString { get; set; }
  public testRefPrntFieldOutp RefPrntFieldOutp { get; set; }
}

public interface ItestRefPrntFieldOutpField
{
  public testNumber parent { get; set; }
}
