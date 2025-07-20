//HintName: Model_generic-alt-param+Input.gen.cs
// Generated from generic-alt-param+Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_generic_alt_param_Input;

public interface IGnrcAltParamInp
{
  RefGnrcAltParamInp<AltGnrcAltParamInp> AsRefGnrcAltParamInp { get; }
}
public class InputGnrcAltParamInp
  : IGnrcAltParamInp
{
  public RefGnrcAltParamInp<AltGnrcAltParamInp> AsRefGnrcAltParamInp { get; set; }
}

public interface IRefGnrcAltParamInp<Tref>
{
  Tref Asref { get; }
}
public class InputRefGnrcAltParamInp<Tref>
  : IRefGnrcAltParamInp<Tref>
{
  public Tref Asref { get; set; }
}

public interface IAltGnrcAltParamInp
{
  Number alt { get; }
  String AsString { get; }
}
public class InputAltGnrcAltParamInp
  : IAltGnrcAltParamInp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
