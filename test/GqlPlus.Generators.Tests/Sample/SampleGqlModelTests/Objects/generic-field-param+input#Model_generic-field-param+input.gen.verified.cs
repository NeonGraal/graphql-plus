//HintName: Model_generic-field-param+input.gen.cs
// Generated from generic-field-param+input.graphql+

/*
*/

namespace GqlTest.Model_generic_field_param_input;

public interface IInpGnrcFieldParam
{
  RefInpGnrcFieldParam < I@055/0001 AltInpGnrcFieldParam > field { get; }
}
public class InputInpGnrcFieldParam
{
  public RefInpGnrcFieldParam < I@055/0001 AltInpGnrcFieldParam > field { get; set; }
}

public interface IRefInpGnrcFieldParam
{
  $ref Asref { get; }
}
public class InputRefInpGnrcFieldParam
{
  public $ref Asref { get; set; }
}

public interface IAltInpGnrcFieldParam
{
  Number alt { get; }
  String AsString { get; }
}
public class InputAltInpGnrcFieldParam
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
