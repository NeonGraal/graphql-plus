//HintName: Model_generic-alt-param+output.gen.cs
// Generated from generic-alt-param+output.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_param_output;

public interface IOutpGnrcAltParam
{
  RefOutpGnrcAltParam < I@049/0001 AltOutpGnrcAltParam > AsRefOutpGnrcAltParam { get; }
}
public class OutputOutpGnrcAltParam
{
  public RefOutpGnrcAltParam < I@049/0001 AltOutpGnrcAltParam > AsRefOutpGnrcAltParam { get; set; }
}

public interface IRefOutpGnrcAltParam
{
  $ref Asref { get; }
}
public class OutputRefOutpGnrcAltParam
{
  public $ref Asref { get; set; }
}

public interface IAltOutpGnrcAltParam
{
  Number alt { get; }
  String AsString { get; }
}
public class OutputAltOutpGnrcAltParam
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
