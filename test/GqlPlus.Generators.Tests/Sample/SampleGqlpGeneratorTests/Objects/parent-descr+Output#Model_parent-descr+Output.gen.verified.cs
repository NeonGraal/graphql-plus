//HintName: Model_parent-descr+Output.gen.cs
// Generated from parent-descr+Output.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_parent_descr_Output;

public interface IPrntDescrOutp
  : IRefPrntDescrOutp
{
}
public class OutputPrntDescrOutp
  : OutputRefPrntDescrOutp
  , IPrntDescrOutp
{
}

public interface IRefPrntDescrOutp
{
  Number parent { get; }
  String AsString { get; }
}
public class OutputRefPrntDescrOutp
  : IRefPrntDescrOutp
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
