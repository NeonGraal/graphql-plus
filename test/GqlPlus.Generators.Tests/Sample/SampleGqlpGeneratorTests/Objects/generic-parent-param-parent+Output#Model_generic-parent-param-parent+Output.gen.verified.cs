//HintName: Model_generic-parent-param-parent+Output.gen.cs
// Generated from generic-parent-param-parent+Output.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_generic_parent_param_parent_Output;

public interface IGnrcPrntParamPrntOutp
  : IRefGnrcPrntParamPrntOutp
{
}
public class OutputGnrcPrntParamPrntOutp
  : OutputRefGnrcPrntParamPrntOutp
  , IGnrcPrntParamPrntOutp
{
}

public interface IRefGnrcPrntParamPrntOutp<Tref>
  : Iref
{
}
public class OutputRefGnrcPrntParamPrntOutp<Tref>
  : Outputref
  , IRefGnrcPrntParamPrntOutp<Tref>
{
}

public interface IAltGnrcPrntParamPrntOutp
{
  Number alt { get; }
  String AsString { get; }
}
public class OutputAltGnrcPrntParamPrntOutp
  : IAltGnrcPrntParamPrntOutp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
