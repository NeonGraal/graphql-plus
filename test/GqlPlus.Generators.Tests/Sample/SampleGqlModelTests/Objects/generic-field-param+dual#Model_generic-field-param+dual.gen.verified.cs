//HintName: Model_generic-field-param+dual.gen.cs
// Generated from generic-field-param+dual.graphql+

/*
*/

namespace GqlTest.Model_generic_field_param_dual;

public interface IDualGnrcFieldParam
{
  RefDualGnrcFieldParam field { get; }
}
public class DualDualGnrcFieldParam
  : IDualGnrcFieldParam
{
  public RefDualGnrcFieldParam field { get; set; }
}

public interface IRefDualGnrcFieldParam<Tref>
{
  Tref Asref { get; }
}
public class DualRefDualGnrcFieldParam<Tref>
  : IRefDualGnrcFieldParam<Tref>
{
  public Tref Asref { get; set; }
}

public interface IAltDualGnrcFieldParam
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltDualGnrcFieldParam
  : IAltDualGnrcFieldParam
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
