//HintName: Model_generic-alt-dual+output.gen.cs
// Generated from generic-alt-dual+output.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_dual_output;

public interface IOutpGnrcAltDual
{
  RefOutpGnrcAltDual < I@047/0001 AltOutpGnrcAltDual > AsRefOutpGnrcAltDual { get; }
}
public class OutputOutpGnrcAltDual
{
  public RefOutpGnrcAltDual < I@047/0001 AltOutpGnrcAltDual > AsRefOutpGnrcAltDual { get; set; }
}

public interface IRefOutpGnrcAltDual
{
  $ref Asref { get; }
}
public class OutputRefOutpGnrcAltDual
{
  public $ref Asref { get; set; }
}

public interface IAltOutpGnrcAltDual
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltOutpGnrcAltDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
