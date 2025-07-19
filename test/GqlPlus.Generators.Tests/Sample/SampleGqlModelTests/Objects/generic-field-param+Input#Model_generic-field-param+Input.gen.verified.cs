//HintName: Model_generic-field-param+Input.gen.cs
// Generated from generic-field-param+Input.graphql+

/*
*/

namespace GqlTest.Model_generic_field_param_Input;

public interface IGnrcFieldParamInp
{
  RefGnrcFieldParamInp<AltGnrcFieldParamInp> field { get; }
}
public class InputGnrcFieldParamInp
  : IGnrcFieldParamInp
{
  public RefGnrcFieldParamInp<AltGnrcFieldParamInp> field { get; set; }
}

public interface IRefGnrcFieldParamInp<Tref>
{
  Tref Asref { get; }
}
public class InputRefGnrcFieldParamInp<Tref>
  : IRefGnrcFieldParamInp<Tref>
{
  public Tref Asref { get; set; }
}

public interface IAltGnrcFieldParamInp
{
  Number alt { get; }
  String AsString { get; }
}
public class InputAltGnrcFieldParamInp
  : IAltGnrcFieldParamInp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
