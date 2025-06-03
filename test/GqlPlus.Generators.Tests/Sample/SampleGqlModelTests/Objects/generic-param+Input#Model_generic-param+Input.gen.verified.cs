//HintName: Model_generic-param+Input.gen.cs
// Generated from generic-param+Input.graphql+

/*
*/

namespace GqlTest.Model_generic_param_Input;

public interface IInpGnrcParam
{
  InpGnrcParamRef<InpGnrcParamAlt> field { get; }
}
public class InputInpGnrcParam
  : IInpGnrcParam
{
  public InpGnrcParamRef<InpGnrcParamAlt> field { get; set; }
}

public interface IInpGnrcParamRef<Tref>
{
  Tref Asref { get; }
}
public class InputInpGnrcParamRef<Tref>
  : IInpGnrcParamRef<Tref>
{
  public Tref Asref { get; set; }
}

public interface IInpGnrcParamAlt
{
  Number alt { get; }
  String AsString { get; }
}
public class InputInpGnrcParamAlt
  : IInpGnrcParamAlt
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
