//HintName: Model_generic-alt-arg+input.gen.cs
// Generated from generic-alt-arg+input.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_arg_input;

public interface IInpGnrcAltArg<Ttype>
{
  RefInpGnrcAltArg<Ttype> AsRefInpGnrcAltArg { get; }
}
public class InputInpGnrcAltArg<Ttype>
  : IInpGnrcAltArg<Ttype>
{
  public RefInpGnrcAltArg<Ttype> AsRefInpGnrcAltArg { get; set; }
}

public interface IRefInpGnrcAltArg<Tref>
{
  Tref Asref { get; }
}
public class InputRefInpGnrcAltArg<Tref>
  : IRefInpGnrcAltArg<Tref>
{
  public Tref Asref { get; set; }
}
