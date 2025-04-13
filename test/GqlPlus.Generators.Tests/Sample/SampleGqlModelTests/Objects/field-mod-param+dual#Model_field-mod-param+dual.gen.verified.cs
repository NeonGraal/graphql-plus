//HintName: Model_field-mod-param+dual.gen.cs
// Generated from field-mod-param+dual.graphql+

/*
*/

namespace GqlTest.Model_field_mod_param_dual;

public interface IDualFieldModParam<Tmod>
{
  FldDualFieldModParam field { get; }
}
public class DualDualFieldModParam<Tmod>
  : IDualFieldModParam<Tmod>
{
  public FldDualFieldModParam field { get; set; }
}

public interface IFldDualFieldModParam
{
  Number field { get; }
  String AsString { get; }
}
public class DualFldDualFieldModParam
  : IFldDualFieldModParam
{
  public Number field { get; set; }
  public String AsString { get; set; }
}
