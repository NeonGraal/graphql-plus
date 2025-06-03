//HintName: Model_generic-parent-param-parent+Output.gen.cs
// Generated from generic-parent-param-parent+Output.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_param_parent_Output;

public interface IOutpGnrcPrntParamPrnt
  : IRefOutpGnrcPrntParamPrnt
{
}
public class OutputOutpGnrcPrntParamPrnt
  : OutputRefOutpGnrcPrntParamPrnt
  , IOutpGnrcPrntParamPrnt
{
}

public interface IRefOutpGnrcPrntParamPrnt<Tref>
  : Iref
{
}
public class OutputRefOutpGnrcPrntParamPrnt<Tref>
  : Outputref
  , IRefOutpGnrcPrntParamPrnt<Tref>
{
}

public interface IAltOutpGnrcPrntParamPrnt
{
  Number alt { get; }
  String AsString { get; }
}
public class OutputAltOutpGnrcPrntParamPrnt
  : IAltOutpGnrcPrntParamPrnt
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
