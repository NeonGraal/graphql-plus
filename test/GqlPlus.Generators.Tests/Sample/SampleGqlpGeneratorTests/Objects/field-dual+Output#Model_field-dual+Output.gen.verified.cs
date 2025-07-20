//HintName: Model_field-dual+Output.gen.cs
// Generated from field-dual+Output.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_field_dual_Output;

public interface IFieldDualOutp
{
  FldFieldDualOutp field { get; }
}
public class OutputFieldDualOutp
  : IFieldDualOutp
{
  public FldFieldDualOutp field { get; set; }
}

public interface IFldFieldDualOutp
{
  Number field { get; }
  String AsString { get; }
}
public class DualFldFieldDualOutp
  : IFldFieldDualOutp
{
  public Number field { get; set; }
  public String AsString { get; set; }
}
