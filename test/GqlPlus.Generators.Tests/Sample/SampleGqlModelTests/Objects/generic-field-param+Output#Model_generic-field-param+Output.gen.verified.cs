//HintName: Model_generic-field-param+Output.gen.cs
// Generated from generic-field-param+Output.graphql+

/*
*/

namespace GqlTest.Model_generic_field_param_Output;

public interface IOutpGnrcFieldParam
{
  RefOutpGnrcFieldParam<AltOutpGnrcFieldParam> field { get; }
}
public class OutputOutpGnrcFieldParam
  : IOutpGnrcFieldParam
{
  public RefOutpGnrcFieldParam<AltOutpGnrcFieldParam> field { get; set; }
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
