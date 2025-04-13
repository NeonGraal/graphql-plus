//HintName: Model_generic-alt-simple+dual.gen.cs
// Generated from generic-alt-simple+dual.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_simple_dual;

public interface IDualGnrcAltSmpl
{
  RefDualGnrcAltSmpl AsRefDualGnrcAltSmpl { get; }
}
public class DualDualGnrcAltSmpl
  : IDualGnrcAltSmpl
{
  public RefDualGnrcAltSmpl AsRefDualGnrcAltSmpl { get; set; }
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
