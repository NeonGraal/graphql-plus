//HintName: Model_generic-field+dual.gen.cs
// Generated from generic-field+dual.graphql+

/*
*/

namespace GqlTest.Model_generic_field_dual;

public interface IDualGnrcField<Ttype>
{
  Ttype field { get; }
}
public class DualDualGnrcField<Ttype>
  : IDualGnrcField<Ttype>
{
  public Ttype field { get; set; }
}
