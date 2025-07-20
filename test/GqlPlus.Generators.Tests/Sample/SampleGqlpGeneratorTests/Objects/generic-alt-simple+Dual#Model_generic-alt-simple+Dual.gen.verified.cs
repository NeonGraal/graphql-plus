//HintName: Model_generic-alt-simple+Dual.gen.cs
// Generated from generic-alt-simple+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_generic_alt_simple_Dual;

public interface IGnrcAltSmplDual
{
  RefGnrcAltSmplDual<String> AsRefGnrcAltSmplDual { get; }
}
public class DualGnrcAltSmplDual
  : IGnrcAltSmplDual
{
  public RefGnrcAltSmplDual<String> AsRefGnrcAltSmplDual { get; set; }
}

public interface IRefGnrcAltSmplDual<Tref>
{
  Tref Asref { get; }
}
public class DualRefGnrcAltSmplDual<Tref>
  : IRefGnrcAltSmplDual<Tref>
{
  public Tref Asref { get; set; }
}
