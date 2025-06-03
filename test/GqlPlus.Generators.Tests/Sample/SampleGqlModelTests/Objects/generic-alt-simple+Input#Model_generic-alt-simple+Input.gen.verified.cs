//HintName: Model_generic-alt-simple+Input.gen.cs
// Generated from generic-alt-simple+Input.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_simple_Input;

public interface IInpGnrcAltSmpl
{
  RefInpGnrcAltSmpl<String> AsRefInpGnrcAltSmpl { get; }
}
public class InputInpGnrcAltSmpl
  : IInpGnrcAltSmpl
{
  public RefInpGnrcAltSmpl<String> AsRefInpGnrcAltSmpl { get; set; }
}

public interface IRefInpGnrcAltSmpl<Tref>
{
  Tref Asref { get; }
}
public class InputRefInpGnrcAltSmpl<Tref>
  : IRefInpGnrcAltSmpl<Tref>
{
  public Tref Asref { get; set; }
}
