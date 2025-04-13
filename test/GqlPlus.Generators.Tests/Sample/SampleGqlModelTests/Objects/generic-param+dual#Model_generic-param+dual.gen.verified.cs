//HintName: Model_generic-param+dual.gen.cs
// Generated from generic-param+dual.graphql+

/*
*/

namespace GqlTest.Model_generic_param_dual;

public interface IDualGnrcParam
{
  DualGnrcParamRef field { get; }
}
public class DualDualGnrcParam
  : IDualGnrcParam
{
  public DualGnrcParamRef field { get; set; }
}

public interface IDualGnrcParamRef<Tref>
{
  Tref Asref { get; }
}
public class DualDualGnrcParamRef<Tref>
  : IDualGnrcParamRef<Tref>
{
  public Tref Asref { get; set; }
}

public interface IDualGnrcParamAlt
{
  Number alt { get; }
  String AsString { get; }
}
public class DualDualGnrcParamAlt
  : IDualGnrcParamAlt
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
