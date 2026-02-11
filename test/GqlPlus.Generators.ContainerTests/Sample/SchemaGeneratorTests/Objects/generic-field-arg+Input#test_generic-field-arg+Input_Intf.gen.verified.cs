//HintName: test_generic-field-arg+Input_Intf.gen.cs
// Generated from generic-field-arg+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_arg_Input;

public interface ItestGnrcFieldArgInp<Ttype>
{
  ItestGnrcFieldArgInpObject AsGnrcFieldArgInp { get; }
}

public interface ItestGnrcFieldArgInpObject<Ttype>
{
  ItestRefGnrcFieldArgInp<Ttype> Field { get; }
}

public interface ItestRefGnrcFieldArgInp<Tref>
{
  Tref Asref { get; }
  ItestRefGnrcFieldArgInpObject AsRefGnrcFieldArgInp { get; }
}

public interface ItestRefGnrcFieldArgInpObject<Tref>
{
}
