//HintName: Model_generic-alt-arg+Dual.gen.cs
// Generated from generic-alt-arg+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_generic_alt_arg_Dual;

public interface IGnrcAltArgDual<Ttype>
{
  RefGnrcAltArgDual<Ttype> AsRefGnrcAltArgDual { get; }
}
public class DualGnrcAltArgDual<Ttype>
  : IGnrcAltArgDual<Ttype>
{
  public RefGnrcAltArgDual<Ttype> AsRefGnrcAltArgDual { get; set; }
}

public interface IRefGnrcAltArgDual<Tref>
{
  Tref Asref { get; }
}
public class DualRefGnrcAltArgDual<Tref>
  : IRefGnrcAltArgDual<Tref>
{
  public Tref Asref { get; set; }
}
