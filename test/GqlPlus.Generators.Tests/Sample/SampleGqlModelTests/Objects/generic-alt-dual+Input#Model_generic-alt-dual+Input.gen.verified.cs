//HintName: Model_generic-alt-dual+Input.gen.cs
// Generated from generic-alt-dual+Input.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_dual_Input;

public interface IGnrcAltDualInp
{
  RefGnrcAltDualInp<AltGnrcAltDualInp> AsRefGnrcAltDualInp { get; }
}
public class InputGnrcAltDualInp
  : IGnrcAltDualInp
{
  public RefGnrcAltDualInp<AltGnrcAltDualInp> AsRefGnrcAltDualInp { get; set; }
}

public interface IRefGnrcAltDualInp<Tref>
{
  Tref Asref { get; }
}
public class InputRefGnrcAltDualInp<Tref>
  : IRefGnrcAltDualInp<Tref>
{
  public Tref Asref { get; set; }
}

public interface IAltGnrcAltDualInp
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltGnrcAltDualInp
  : IAltGnrcAltDualInp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
