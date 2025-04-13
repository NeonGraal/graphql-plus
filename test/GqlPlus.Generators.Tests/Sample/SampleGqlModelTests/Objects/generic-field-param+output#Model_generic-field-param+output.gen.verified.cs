//HintName: Model_generic-field-param+output.gen.cs
// Generated from generic-field-param+output.graphql+

/*
*/

namespace GqlTest.Model_generic_field_param_output;

public interface IOutpGnrcFieldParam
{
  RefOutpGnrcFieldParam field { get; }
}
public class OutputOutpGnrcFieldParam
  : IOutpGnrcFieldParam
{
  public RefOutpGnrcFieldParam field { get; set; }
}

public interface IRefOutpGnrcFieldParam<Tref>
{
  Tref Asref { get; }
}
public class OutputRefOutpGnrcFieldParam<Tref>
  : IRefOutpGnrcFieldParam<Tref>
{
  public Tref Asref { get; set; }
}

public interface IAltOutpGnrcFieldParam
{
  Number alt { get; }
  String AsString { get; }
}
public class OutputAltOutpGnrcFieldParam
  : IAltOutpGnrcFieldParam
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
