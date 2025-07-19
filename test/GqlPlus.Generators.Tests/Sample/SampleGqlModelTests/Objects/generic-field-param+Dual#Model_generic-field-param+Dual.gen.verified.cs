//HintName: Model_generic-field-param+Dual.gen.cs
// Generated from generic-field-param+Dual.graphql+

/*
*/

namespace GqlTest.Model_generic_field_param_Dual;

public interface IGnrcFieldParamDual
{
  RefGnrcFieldParamDual<AltGnrcFieldParamDual> field { get; }
}
public class DualGnrcFieldParamDual
  : IGnrcFieldParamDual
{
  public RefGnrcFieldParamDual<AltGnrcFieldParamDual> field { get; set; }
}

public interface IRefGnrcFieldParamDual<Tref>
{
  Tref Asref { get; }
}
public class DualRefGnrcFieldParamDual<Tref>
  : IRefGnrcFieldParamDual<Tref>
{
  public Tref Asref { get; set; }
}

public interface IAltGnrcFieldParamDual
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltGnrcFieldParamDual
  : IAltGnrcFieldParamDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
