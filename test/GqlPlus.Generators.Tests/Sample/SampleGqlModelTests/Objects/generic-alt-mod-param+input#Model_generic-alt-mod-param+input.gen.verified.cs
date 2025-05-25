//HintName: Model_generic-alt-mod-param+input.gen.cs
// Generated from generic-alt-mod-param+input.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_mod_param_input;

public interface IRefInpGnrcAltModParam<Tref,Tmod>
{
  Tref Asref { get; }
}
public class InputRefInpGnrcAltModParam<Tref,Tmod>
  : IRefInpGnrcAltModParam<Tref,Tmod>
{
  public Tref Asref { get; set; }
}
