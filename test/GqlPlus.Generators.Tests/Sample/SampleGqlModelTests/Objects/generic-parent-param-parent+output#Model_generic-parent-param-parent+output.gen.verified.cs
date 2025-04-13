//HintName: Model_generic-parent-param-parent+output.gen.cs
// Generated from generic-parent-param-parent+output.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_param_parent_output;

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
