//HintName: Model_generic-parent-param+Output.gen.cs
// Generated from generic-parent-param+Output.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_generic_parent_param_Output;

public interface IGnrcPrntParamOutp
  : IRefGnrcPrntParamOutp
{
}
public class OutputGnrcPrntParamOutp
  : OutputRefGnrcPrntParamOutp
  , IGnrcPrntParamOutp
{
}

public interface IRefGnrcPrntParamOutp<Tref>
{
  Tref Asref { get; }
}
public class OutputRefGnrcPrntParamOutp<Tref>
  : IRefGnrcPrntParamOutp<Tref>
{
  public Tref Asref { get; set; }
}

public interface IAltGnrcPrntParamOutp
{
  Number alt { get; }
  String AsString { get; }
}
public class OutputAltGnrcPrntParamOutp
  : IAltGnrcPrntParamOutp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
