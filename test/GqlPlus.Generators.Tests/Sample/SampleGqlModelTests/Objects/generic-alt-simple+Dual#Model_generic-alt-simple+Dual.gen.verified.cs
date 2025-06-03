//HintName: Model_generic-alt-simple+Dual.gen.cs
// Generated from generic-alt-simple+Dual.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_simple_Dual;

public interface IDualGnrcAltSmpl
{
  RefDualGnrcAltSmpl<String> AsRefDualGnrcAltSmpl { get; }
}
public class DualDualGnrcAltSmpl
  : IDualGnrcAltSmpl
{
  public RefDualGnrcAltSmpl<String> AsRefDualGnrcAltSmpl { get; set; }
}

public interface IRefDualGnrcAltSmpl<Tref>
{
  Tref Asref { get; }
}
public class DualRefDualGnrcAltSmpl<Tref>
  : IRefDualGnrcAltSmpl<Tref>
{
  public Tref Asref { get; set; }
}
