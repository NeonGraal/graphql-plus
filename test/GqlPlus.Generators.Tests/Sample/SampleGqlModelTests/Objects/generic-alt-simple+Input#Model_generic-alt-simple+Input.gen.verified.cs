//HintName: Model_generic-alt-simple+Input.gen.cs
// Generated from generic-alt-simple+Input.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_simple_Input;

public interface IGnrcAltSmplInp
{
  RefGnrcAltSmplInp<String> AsRefGnrcAltSmplInp { get; }
}
public class InputGnrcAltSmplInp
  : IGnrcAltSmplInp
{
  public RefGnrcAltSmplInp<String> AsRefGnrcAltSmplInp { get; set; }
}

public interface IRefGnrcAltSmplInp<Tref>
{
  Tref Asref { get; }
}
public class InputRefGnrcAltSmplInp<Tref>
  : IRefGnrcAltSmplInp<Tref>
{
  public Tref Asref { get; set; }
}
