//HintName: Model_generic-field-param+input.gen.cs
// Generated from generic-field-param+input.graphql+

/*
*/

namespace GqlTest.Model_generic_field_param_input;

public interface IInpGnrcFieldParam
{
  RefInpGnrcFieldParam<AltInpGnrcFieldParam> field { get; }
}
public class InputInpGnrcFieldParam
  : IInpGnrcFieldParam
{
  public RefInpGnrcFieldParam<AltInpGnrcFieldParam> field { get; set; }
}

public interface IRefInpGnrcFieldParam<Tref>
{
  Tref Asref { get; }
}
public class InputRefInpGnrcFieldParam<Tref>
  : IRefInpGnrcFieldParam<Tref>
{
  public Tref Asref { get; set; }
}

public interface IAltInpGnrcFieldParam
{
  Number alt { get; }
  String AsString { get; }
}
public class InputAltInpGnrcFieldParam
  : IAltInpGnrcFieldParam
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
