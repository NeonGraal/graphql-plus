//HintName: test_generic-field-arg+Input_Intf.gen.cs
// Generated from generic-field-arg+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_arg_Input;

public interface ItestGnrcFieldArgInp<TType>
{
  ItestGnrcFieldArgInpObject<TType> AsGnrcFieldArgInp { get; }
}

public interface ItestGnrcFieldArgInpObject<TType>
{
  ItestRefGnrcFieldArgInp<TType> Field { get; }
}

public interface ItestRefGnrcFieldArgInp<TRef>
{
  TRef Asref { get; }
  ItestRefGnrcFieldArgInpObject<TRef> AsRefGnrcFieldArgInp { get; }
}

public interface ItestRefGnrcFieldArgInpObject<TRef>
{
}
