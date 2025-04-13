//HintName: Model_generic-alt-dual+output.gen.cs
// Generated from generic-alt-dual+output.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_dual_output;

public interface IOutpGnrcAltDual
{
  RefOutpGnrcAltDual AsRefOutpGnrcAltDual { get; }
}
public class OutputOutpGnrcAltDual
  : IOutpGnrcAltDual
{
  public RefOutpGnrcAltDual AsRefOutpGnrcAltDual { get; set; }
}

public interface IRefOutpGnrcAltDual<Tref>
{
  Tref Asref { get; }
}
public class OutputRefOutpGnrcAltDual<Tref>
  : IRefOutpGnrcAltDual<Tref>
{
  public Tref Asref { get; set; }
}

public interface IAltOutpGnrcAltDual
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltOutpGnrcAltDual
  : IAltOutpGnrcAltDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
