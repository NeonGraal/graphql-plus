//HintName: Model_generic-parent-param+output.gen.cs
// Generated from generic-parent-param+output.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_param_output;

public interface IOutpGnrcPrntParam
  : IRefOutpGnrcPrntParam
{
}
public class OutputOutpGnrcPrntParam
  : OutputRefOutpGnrcPrntParam
  , IOutpGnrcPrntParam
{
}

public interface IRefOutpGnrcPrntParam<Tref>
{
  Tref Asref { get; }
}
public class OutputRefOutpGnrcPrntParam<Tref>
  : IRefOutpGnrcPrntParam<Tref>
{
  public Tref Asref { get; set; }
}

public interface IAltOutpGnrcPrntParam
{
  Number alt { get; }
  String AsString { get; }
}
public class OutputAltOutpGnrcPrntParam
  : IAltOutpGnrcPrntParam
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
