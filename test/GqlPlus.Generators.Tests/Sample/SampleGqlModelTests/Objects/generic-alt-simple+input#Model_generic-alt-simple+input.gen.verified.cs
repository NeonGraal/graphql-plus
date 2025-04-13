//HintName: Model_generic-alt-simple+input.gen.cs
// Generated from generic-alt-simple+input.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_simple_input;

public interface IInpGnrcAltSmpl
{
  RefInpGnrcAltSmpl AsRefInpGnrcAltSmpl { get; }
}
public class InputInpGnrcAltSmpl
  : IInpGnrcAltSmpl
{
  public RefInpGnrcAltSmpl AsRefInpGnrcAltSmpl { get; set; }
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
