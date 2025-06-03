//HintName: Model_generic-alt-dual+Output.gen.cs
// Generated from generic-alt-dual+Output.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_dual_Output;

public interface IOutpGnrcAltDual
{
  RefOutpGnrcAltDual<AltOutpGnrcAltDual> AsRefOutpGnrcAltDual { get; }
}
public class OutputOutpGnrcAltDual
  : IOutpGnrcAltDual
{
  public RefOutpGnrcAltDual<AltOutpGnrcAltDual> AsRefOutpGnrcAltDual { get; set; }
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
