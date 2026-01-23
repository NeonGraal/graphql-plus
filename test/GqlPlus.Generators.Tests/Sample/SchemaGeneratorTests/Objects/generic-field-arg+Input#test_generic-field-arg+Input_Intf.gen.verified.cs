//HintName: test_generic-field-arg+Input_Intf.gen.cs
// Generated from generic-field-arg+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_arg_Input;

public interface ItestGnrcFieldArgInp<Ttype>
{
  public testGnrcFieldArgInp GnrcFieldArgInp { get; set; }
}

public interface ItestGnrcFieldArgInpObject<Ttype>
{
  public testRefGnrcFieldArgInp<Ttype> field { get; set; }
}

public interface ItestRefGnrcFieldArgInp<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcFieldArgInp RefGnrcFieldArgInp { get; set; }
}

public interface ItestRefGnrcFieldArgInpObject<Tref>
{
}
