//HintName: Model_generic-param+dual.gen.cs
// Generated from generic-param+dual.graphql+

/*
*/

namespace GqlTest.Model_generic_param_dual;

public interface IDualGnrcParam
{
  DualGnrcParamRef < I@046/0001 DualGnrcParamAlt > field { get; }
}
public class DualDualGnrcParam
{
  public DualGnrcParamRef < I@046/0001 DualGnrcParamAlt > field { get; set; }
}

public interface IDualGnrcParamRef
{
  $ref Asref { get; }
}
public class DualDualGnrcParamRef
{
  public $ref Asref { get; set; }
}

public interface IDualGnrcParamAlt
{
  Number alt { get; }
  String AsString { get; }
}
public class DualDualGnrcParamAlt
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
