//HintName: Model_generic-param+Dual.gen.cs
// Generated from generic-param+Dual.graphql+

/*
*/

namespace GqlTest.Model_generic_param_Dual;

public interface IDualGnrcParam
{
  DualGnrcParamRef<DualGnrcParamAlt> field { get; }
}
public class DualDualGnrcParam
  : IDualGnrcParam
{
  public DualGnrcParamRef<DualGnrcParamAlt> field { get; set; }
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
