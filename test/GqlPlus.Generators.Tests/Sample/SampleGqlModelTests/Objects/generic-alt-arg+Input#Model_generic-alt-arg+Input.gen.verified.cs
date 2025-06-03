//HintName: Model_generic-alt-arg+Input.gen.cs
// Generated from generic-alt-arg+Input.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_arg_Input;

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
