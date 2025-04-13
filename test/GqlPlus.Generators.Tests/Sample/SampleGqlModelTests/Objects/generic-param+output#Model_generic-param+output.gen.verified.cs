//HintName: Model_generic-param+output.gen.cs
// Generated from generic-param+output.graphql+

/*
*/

namespace GqlTest.Model_generic_param_output;

public interface IOutpGnrcParam
{
  OutpGnrcParamRef < I@048/0001 OutpGnrcParamAlt > field { get; }
}
public class OutputOutpGnrcParam
{
  public OutpGnrcParamRef < I@048/0001 OutpGnrcParamAlt > field { get; set; }
}

public interface IOutpGnrcParamRef
{
  $ref Asref { get; }
}
public class OutputOutpGnrcParamRef
{
  public $ref Asref { get; set; }
}

public interface IOutpGnrcParamAlt
{
  Number alt { get; }
  String AsString { get; }
}
public class OutputOutpGnrcParamAlt
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
