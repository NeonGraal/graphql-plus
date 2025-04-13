//HintName: Model_generic-parent-param+output.gen.cs
// Generated from generic-parent-param+output.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_param_output;

public interface IOutpGnrcPrntParam
{
}
public class OutputOutpGnrcPrntParam
{
}

public interface IRefOutpGnrcPrntParam
{
  $ref Asref { get; }
}
public class OutputRefOutpGnrcPrntParam
{
  public $ref Asref { get; set; }
}

public interface IAltOutpGnrcPrntParam
{
  Number alt { get; }
  String AsString { get; }
}
public class OutputAltOutpGnrcPrntParam
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
