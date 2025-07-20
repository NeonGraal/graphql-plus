//HintName: Model_generic-field-arg+Dual.gen.cs
// Generated from generic-field-arg+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_generic_field_arg_Dual;

public interface IGnrcFieldArgDual<Ttype>
{
  RefGnrcFieldArgDual<Ttype> field { get; }
}
public class DualGnrcFieldArgDual<Ttype>
  : IGnrcFieldArgDual<Ttype>
{
  public RefGnrcFieldArgDual<Ttype> field { get; set; }
}

public interface IRefGnrcFieldArgDual<Tref>
{
  Tref Asref { get; }
}
public class DualRefGnrcFieldArgDual<Tref>
  : IRefGnrcFieldArgDual<Tref>
{
  public Tref Asref { get; set; }
}
