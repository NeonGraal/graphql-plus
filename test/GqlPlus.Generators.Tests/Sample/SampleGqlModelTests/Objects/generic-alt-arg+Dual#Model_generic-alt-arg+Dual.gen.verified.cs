//HintName: Model_generic-alt-arg+Dual.gen.cs
// Generated from generic-alt-arg+Dual.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_arg_Dual;

public interface IDualGnrcAltArg<Ttype>
{
  RefDualGnrcAltArg<Ttype> AsRefDualGnrcAltArg { get; }
}
public class DualDualGnrcAltArg<Ttype>
  : IDualGnrcAltArg<Ttype>
{
  public RefDualGnrcAltArg<Ttype> AsRefDualGnrcAltArg { get; set; }
}

public interface IRefDualGnrcAltArg<Tref>
{
  Tref Asref { get; }
}
public class DualRefDualGnrcAltArg<Tref>
  : IRefDualGnrcAltArg<Tref>
{
  public Tref Asref { get; set; }
}
