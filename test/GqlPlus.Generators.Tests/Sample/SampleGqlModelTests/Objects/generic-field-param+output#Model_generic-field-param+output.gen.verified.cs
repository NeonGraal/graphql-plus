//HintName: Model_generic-field-param+output.gen.cs
// Generated from generic-field-param+output.graphql+

/*
*/

namespace GqlTest.Model_generic_field_param_output;

public interface IOutpGnrcFieldParam
{
  RefOutpGnrcFieldParam < I@058/0001 AltOutpGnrcFieldParam > field { get; }
}
public class OutputOutpGnrcFieldParam
{
  public RefOutpGnrcFieldParam < I@058/0001 AltOutpGnrcFieldParam > field { get; set; }
}

public interface IRefOutpGnrcFieldParam
{
  $ref Asref { get; }
}
public class OutputRefOutpGnrcFieldParam
{
  public $ref Asref { get; set; }
}

public interface IAltOutpGnrcFieldParam
{
  Number alt { get; }
  String AsString { get; }
}
public class OutputAltOutpGnrcFieldParam
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
