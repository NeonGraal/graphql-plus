//HintName: test_generic-field-arg+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-field-arg+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_arg_Input;

public interface ItestGnrcFieldArgInp<TType>
  // No Base because it's Class
{
  ItestGnrcFieldArgInpObject<TType>? As_GnrcFieldArgInp { get; }
}

public interface ItestGnrcFieldArgInpObject<TType>
  // No Base because it's Class
{
  ItestRefGnrcFieldArgInp<TType> Field { get; }
}

public interface ItestRefGnrcFieldArgInp<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefGnrcFieldArgInpObject<TRef>? As_RefGnrcFieldArgInp { get; }
}

public interface ItestRefGnrcFieldArgInpObject<TRef>
  // No Base because it's Class
{
}
