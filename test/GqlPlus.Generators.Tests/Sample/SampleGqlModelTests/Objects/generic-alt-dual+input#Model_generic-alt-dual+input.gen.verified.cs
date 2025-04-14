//HintName: Model_generic-alt-dual+input.gen.cs
// Generated from generic-alt-dual+input.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_dual_input;

public interface IInpGnrcAltDual
{
  RefInpGnrcAltDual<AltInpGnrcAltDual> AsRefInpGnrcAltDual { get; }
}
public class InputInpGnrcAltDual
  : IInpGnrcAltDual
{
  public RefInpGnrcAltDual<AltInpGnrcAltDual> AsRefInpGnrcAltDual { get; set; }
}

public interface IRefInpGnrcAltDual<Tref>
{
  Tref Asref { get; }
}
public class InputRefInpGnrcAltDual<Tref>
  : IRefInpGnrcAltDual<Tref>
{
  public Tref Asref { get; set; }
}

public interface IAltInpGnrcAltDual
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltInpGnrcAltDual
  : IAltInpGnrcAltDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
